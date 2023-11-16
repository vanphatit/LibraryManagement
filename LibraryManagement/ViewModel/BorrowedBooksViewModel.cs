using LibraryManagement.Model;
using Microsoft.Win32;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace LibraryManagement.ViewModel
{
    public class BorrowedBooksViewModel : BaseViewModel
    {
        #region Instance
        private string _BorrowPerson;
        public string BorrowPerson { get => _BorrowPerson; set { _BorrowPerson = value; OnPropertyChanged(); } }

        private string _ObjectName;
        public string ObjectName { get => _ObjectName; set { _ObjectName = value; OnPropertyChanged(); } }

        private string _ObjectAuthor;
        public string ObjectAuthor { get => _ObjectAuthor; set { _ObjectAuthor = value; OnPropertyChanged(); } }

        private int? _ObjectCount;
        public int? ObjectCount { get => _ObjectCount; set { _ObjectCount = value; OnPropertyChanged(); } }

        

        private ObservableCollection<Model.BookBorrow> _ListBorrowBook;
        public ObservableCollection<Model.BookBorrow> ListBorrowBook { get => _ListBorrowBook; set { _ListBorrowBook = value; OnPropertyChanged(); } }

        private Model.BookBorrow _SelectedItem_BookBorrow;
        public Model.BookBorrow SelectedItem_BookBorrow
        {
            get => _SelectedItem_BookBorrow;
            set
            {
                _SelectedItem_BookBorrow = value;
                OnPropertyChanged();
                if (SelectedItem_BookBorrow != null)
                {
                    ObjectName = SelectedItem_BookBorrow.Object.DisplayName;
                    ObjectAuthor = SelectedItem_BookBorrow.Object.Author;
                    ObjectCount = SelectedItem_BookBorrow.Count;
                }
            }
        }

        private List<Search> _ListSearch;
        public List<Search> ListSearch { get => _ListSearch; set { _ListSearch = value; OnPropertyChanged(); } }

        private string _txbSearch;
        public string txbSearch { get => _txbSearch; set { _txbSearch = value; OnPropertyChanged(); } }

        private Search _SelectedSearch;
        public Search SelectedSearch
        {
            get => _SelectedSearch;
            set
            {
                _SelectedSearch = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoadWindowCommand { get; set; }
        public ICommand ButtonAddCommand { get; set; }
        public ICommand ButtonDeleteCommand { get; set; }
        public ICommand ButtonEditCommand { get; set; }
        public ICommand ExportExcel10Command { get; set; }
        public ICommand TxbSearchChangedCommand { get; set; }
        #endregion

        public void ExportExcel10()
        {
            string filePath = "";
            // tạo SaveFileDialog để lưu file excel
            SaveFileDialog dialog = new SaveFileDialog();

            // chỉ lọc ra các file có định dạng Excel
            dialog.Filter = "Excel | *.xlsx | Excel 2003 | *.xls";

            // Nếu mở file và chọn nơi lưu file thành công sẽ lưu đường dẫn lại dùng
            if (dialog.ShowDialog() == true)
            {
                filePath = dialog.FileName;
            }

            // nếu đường dẫn null hoặc rỗng thì báo không hợp lệ và return hàm
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Đường dẫn không hợp lệ");
                return;
            }

            try
            {
                using (ExcelPackage a = new ExcelPackage())
                {
                    // đặt tên người tạo file
                    a.Workbook.Properties.Author = "Admin";

                    // đặt tiêu đề cho file
                    a.Workbook.Properties.Title = String.Format("Danh sách các cuốn sách độc giả đã mượn - {0}", DateTime.Now.ToLongDateString());

                    //Tạo một sheet để làm việc trên đó
                    a.Workbook.Worksheets.Add("BookBorrows sheet");

                    // lấy sheet vừa add ra để thao tác
                    ExcelWorksheet ws = a.Workbook.Worksheets[1];

                    // đặt tên cho sheet
                    ws.Name = "BookBorrows sheet";
                    // fontsize mặc định cho cả sheet
                    ws.Cells.Style.Font.Size = 14;
                    // font family mặc định cho cả sheet
                    ws.Cells.Style.Font.Name = "Segoe UI";

                    // Tạo danh sách các column header
                    string[] arrColumnHeader = {
                                                "Mã",
                                                "Tên sách",
                                                "Tên độc giả",
                                                "Số lượng"
                        };

                    // lấy ra số lượng cột cần dùng dựa vào số lượng header
                    var countColHeader = arrColumnHeader.Count();

                    // merge các column lại từ column 1 đến số column header
                    // gán giá trị cho cell vừa merge là Danh sách các độc giả đến thư viện - Ngày tháng năm export
                    ws.Cells[1, 1].Value = String.Format("Danh sách các cuốn sách độc giả đã mượn - {0}", DateTime.Now.ToLongDateString());
                    ws.Cells[1, 1, 1, countColHeader].Merge = true;
                    // in đậm
                    ws.Cells[1, 1, 1, countColHeader].Style.Font.Bold = true;
                    ws.Cells[1, 1, 1, countColHeader].Style.Font.Size = 16;
                    // căn giữa
                    ws.Cells[1, 1, 1, countColHeader].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    int colIndex = 1;
                    int rowIndex = 2;

                    //tạo các header từ column header đã tạo từ bên trên
                    foreach (var item in arrColumnHeader)
                    {
                        var cell = ws.Cells[rowIndex, colIndex];

                        cell.Style.Font.Bold = true;

                        //set màu thành gray
                        var fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(System.Drawing.Color.MediumPurple);

                        //căn chỉnh các border
                        var border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style =
                            border.Right.Style = ExcelBorderStyle.Thin;

                        //gán giá trị
                        cell.Value = item;

                        colIndex++;
                    }

                    // với mỗi item trong danh sách sẽ ghi trên 1 dòng
                    foreach (BookBorrow item in ListBorrowBook)
                    {
                        // bắt đầu ghi từ cột 1. Excel bắt đầu từ 1 không phải từ 0
                        colIndex = 1;

                        // rowIndex tương ứng từng dòng dữ liệu
                        rowIndex++;

                        var cell = ws.Cells[rowIndex, colIndex];
                        //căn chỉnh các border
                        var border = cell.Style.Border;
                        for (int i = 1; i <= 5; i++)
                        {
                            cell = ws.Cells[rowIndex, i];
                            border = cell.Style.Border;
                            border.Bottom.Style = border.Top.Style = border.Left.Style =
                                border.Right.Style = ExcelBorderStyle.Thin;
                        }

                        //gán giá trị cho từng cell 
                        // lưu ý phải .ToShortDateString để dữ liệu khi in ra Excel là ngày như ta vẫn thấy.Nếu không sẽ ra tổng số :v
                        ws.Cells[rowIndex, colIndex++].Value = item.ID;
                        ws.Cells[rowIndex, colIndex++].Value = item.Object.DisplayName;
                        ws.Cells[rowIndex, colIndex++].Value = item.Reader.DisplayName;
                        ws.Cells[rowIndex, colIndex++].Value = item.Count;

                    }

                    //Lưu file lại
                    Byte[] bin = a.GetAsByteArray();
                    File.WriteAllBytes(filePath, bin);
                }
                MessageBox.Show("Xuất excel thành công!");
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi khi lưu file!");
            }
        }

        string FileReader()
        {
            FileStream stream = new FileStream(Directory.GetCurrentDirectory() + "\\borrowbook.txt", FileMode.Open);
            StreamReader file = new StreamReader(stream);
            var id = file.ReadLine().ToString();
            file.Close();
            stream.Close();
            return id;
        }

        public BorrowedBooksViewModel()
        {
            int IDReader = Convert.ToInt32(FileReader());
            var man = DataProvider.Ins.db.Readers.Where(a => a.ID == IDReader).SingleOrDefault();
            LoadWindowCommand = new RelayCommand<ListView>((p) => { return true;
            }, (p) =>
            {                
                BorrowPerson = man.DisplayName;
                ListBorrowBook = new ObservableCollection<Model.BookBorrow>(DataProvider.Ins.db.BookBorrows);

                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(p.ItemsSource);
                view.Filter = Fil;
                CollectionViewSource.GetDefaultView(p.ItemsSource).Refresh();

                ListSearch = new List<Search>()
                {
                    new Search(){ Ename= "Book", Tname="Tên sách" },
                    new Search(){ Ename= "Author", Tname="Tác giả" },
                    new Search(){ Ename= "Count", Tname="Số lượng" },
                    new Search(){ Ename= "Status", Tname="Trạng thái" }
                };

            });

            bool Fil(object item)
            {
                string id = (string)FileReader();
                if (String.IsNullOrEmpty(id))
                    return true;
                return ((item as Model.BookBorrow).IDReader.ToString().IndexOf(id, StringComparison.OrdinalIgnoreCase) >= 0);
            }


            ButtonAddCommand = new RelayCommand<object>((p) =>
            {
                var id = Convert.ToInt32(FileReader());
                if (string.IsNullOrEmpty(ObjectName) == true|| string.IsNullOrEmpty(ObjectCount.ToString()) == true)
                    return false;
                var obj = DataProvider.Ins.db.BookBorrows.Where(a => a.Object.DisplayName == ObjectName).ToList();
                if (obj != null || obj.Count() != 0)
                {
                    foreach (var item in obj)
                    {
                        if (item.IDReader == id)
                            return false;
                    }
                }
                var book = DataProvider.Ins.db.Objects.Where(a => a.DisplayName == ObjectName);
                if (book == null || book.Count() == 0)
                    return false;
                return true;
            }, (p) =>
            {
                var book = DataProvider.Ins.db.Objects.Where(a => a.DisplayName == ObjectName);
                if (book != null && book.Count() != 0)
                {
                    string idbook = "";
                    var obj = new BookBorrow();
                    obj.IDBook = book.SingleOrDefault().ID;
                    obj.IDReader = Convert.ToInt32(FileReader());
                    obj.Count = ObjectCount;
                    obj.BorrowDate = DateTime.Now;
                    DataProvider.Ins.db.BookBorrows.Add(obj);
                    DataProvider.Ins.db.SaveChanges();
                    ListBorrowBook.Add(obj);
                    MainViewModel mainViewModel = new MainViewModel();
                    mainViewModel.EditReader(man,2);
                    //mainViewModel.LoadDashboard();
                    MessageBox.Show("Thành công!");
                }
            });

            ButtonEditCommand = new RelayCommand<object>((p) =>
            {
                var id = Convert.ToInt32(FileReader());
                if (string.IsNullOrEmpty(ObjectName) == true || string.IsNullOrEmpty(ObjectCount.ToString()) == true)
                    return false;
                //var obj = DataProvider.Ins.db.BookBorrows.Where(a => a.Object.DisplayName == ObjectName).ToList();
                //if (obj != null || obj.Count() != 0)
                //{
                //    foreach (var item in obj)
                //    {
                //        if (item.IDReader != id)
                //            return false;
                //    }
                //}
                var book = DataProvider.Ins.db.Objects.Where(a => a.DisplayName == ObjectName);
                if (book == null || book.Count() == 0)
                    return false;
                return true;
            }, (p) =>
            {
                var book = DataProvider.Ins.db.Objects.Where(a => a.DisplayName == ObjectName);
                if (book != null && book.Count() != 0)
                {
                    string idbook = "";
                    foreach (var item in book)
                    {
                        if (item.Author == ObjectAuthor)
                        {
                            idbook = item.ID;
                        }
                    }
                    var obj = DataProvider.Ins.db.BookBorrows.Where(a => a.ID == SelectedItem_BookBorrow.ID).SingleOrDefault();
                    obj.IDBook = idbook;
                    obj.IDReader = Convert.ToInt32(FileReader());
                    obj.Count = ObjectCount;
                    DataProvider.Ins.db.SaveChanges();
                    SelectedItem_BookBorrow.IDBook = idbook;
                    SelectedItem_BookBorrow.IDReader = Convert.ToInt32(FileReader());
                    SelectedItem_BookBorrow.Count = ObjectCount;
                    MainViewModel mainViewModel = new MainViewModel();
                    mainViewModel.EditReader(man, 2);
                    //mainViewModel.LoadDashboard();
                    MessageBox.Show("Thành công!");
                }
            });

            ButtonDeleteCommand = new RelayCommand<object>((p) =>
            {
                var id = Convert.ToInt32(FileReader());
                if (string.IsNullOrEmpty(ObjectName) == true || string.IsNullOrEmpty(ObjectCount.ToString()) == true)
                    return false;
                var obj = DataProvider.Ins.db.BookBorrows.Where(a => a.Object.DisplayName == ObjectName).ToList();
                if (obj != null || obj.Count() != 0)
                {
                    foreach (var item in obj)
                    {
                        if (item.IDReader != id)
                            return false;
                    }
                }
                var book = DataProvider.Ins.db.Objects.Where(a => a.DisplayName == ObjectName);
                if (book == null || book.Count() == 0)
                    return false;
                return true;
            }, (p) =>
            {
                BookBorrow bookborrowdel = DataProvider.Ins.db.BookBorrows.Where(a => a.ID == SelectedItem_BookBorrow.ID).SingleOrDefault();
                var result = MessageBox.Show("Khi bạn xoá sách mượn này,\n" +
                    "Hệ thống sẽ xoá sạch các thông tin mượn/trả sách của độc giả này. \n" +
                    "Để bảo vệ dữ liệu, bạn hãy nhấn Yes khi muốn hệ thống xuất các file Excel cần thiết trong chương trình.\n" +
                    "Nếu muốn hệ thống xoá sách này mà không xuất file Excel, bạn hãy nhấn No.\n" +
                    "Và muốn thoát, bạn hãy nhấn Cancel!", "Cẩn thận khi xoá", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    ExportExcel10();
                    DataProvider.Ins.db.BookBorrows.Remove(bookborrowdel);
                    DataProvider.Ins.db.SaveChanges();
                    ListBorrowBook = new ObservableCollection<BookBorrow>(DataProvider.Ins.db.BookBorrows);
                }
                if (result == MessageBoxResult.No)
                {
                    DataProvider.Ins.db.BookBorrows.Remove(bookborrowdel);
                    DataProvider.Ins.db.SaveChanges();
                    ListBorrowBook = new ObservableCollection<BookBorrow>(DataProvider.Ins.db.BookBorrows);
                }
                MainViewModel mainViewModel = new MainViewModel();
                mainViewModel.EditReader(man, 2);
                MessageBox.Show("Đã xoá thành công!");
            });

            ExportExcel10Command = new RelayCommand<ListView>((p) =>
            {
                if (p.ItemsSource == null || p.Items.Count == 0)
                    return false;
                return true;
            }, (p) =>
            {
                ExportExcel10();
            });

            #region Search
            TxbSearchChangedCommand = new RelayCommand<ListView>((p) => { return true; }, (p) =>
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(p.ItemsSource);
                view.Filter = BookBorrowFilter;

                CollectionViewSource.GetDefaultView(p.ItemsSource).Refresh();
            });

            bool BookBorrowFilter(object item)
            {
                if (String.IsNullOrEmpty(txbSearch))
                    return true;
                if (SelectedSearch == null)
                    return true;
                switch (SelectedSearch.Ename)
                {
                    case "Book":
                        return ((item as Model.BookBorrow).Object.DisplayName.IndexOf(txbSearch, StringComparison.OrdinalIgnoreCase) >= 0);
                    case "Author":
                        return ((item as Model.BookBorrow).Object.Author.IndexOf(txbSearch, StringComparison.OrdinalIgnoreCase) >= 0);
                    case "Count":
                        return ((item as Model.BookBorrow).Count.ToString().IndexOf(txbSearch, StringComparison.OrdinalIgnoreCase) >= 0);
                    default:
                        break;
                }
                return true;
            }

            #endregion
        }
    }

    public class Search
    {
        public string Ename { get; set; }
        public string Tname { get; set; }
    }
}
