using LibraryManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Controls;
using Microsoft.Win32;
using System.Windows.Media.Imaging;
using System.Diagnostics;
using System.Collections.ObjectModel;
using LibraryManagement.Model;
using System.Threading;
using System.Data.SqlClient;
using System.Windows.Data;
using OfficeOpenXml;
using System.IO;
using OfficeOpenXml.Style;
using System.Security.Cryptography;

namespace LibraryManagement.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        #region Instance
        public ICommand BtnShowBorrowBooks { get; set; }

        private ObservableCollection<Gender> _ListGender;
        public ObservableCollection<Gender> ListGender { get => _ListGender; set { _ListGender = value; OnPropertyChanged(); } }

        private ObservableCollection<BookBorrow> _ListBookBorrow;
        public ObservableCollection<BookBorrow> ListBookBorrow { get => _ListBookBorrow; set { _ListBookBorrow = value; OnPropertyChanged(); } }

        private Gender _SelectedGender;
        public Gender SelectedGender { get => _SelectedGender; set { _SelectedGender = value; OnPropertyChanged(); } }

        private Gender _SelectedGender1;
        public Gender SelectedGender1 { get => _SelectedGender1; set { _SelectedGender1 = value; OnPropertyChanged(); } }

        private Gender _SelectedGender2;
        public Gender SelectedGender2 { get => _SelectedGender2; set { _SelectedGender2 = value; OnPropertyChanged(); } }

        public ICommand LogoutCommand { get; set; }

        private string _SumBooks;
        public string SumBooks { get => _SumBooks; set { _SumBooks = value; OnPropertyChanged(); } }

        private string _SumReaders;
        public string SumReaders { get => _SumReaders; set { _SumReaders = value; OnPropertyChanged(); } }

        private string _SumBorrows;
        public string SumBorrows { get => _SumBorrows; set { _SumBorrows = value; OnPropertyChanged(); } }

        private string _WelcomeBack;
        public string WelcomeBack { get => _WelcomeBack; set { _WelcomeBack = value; OnPropertyChanged(); } }

        private string _AccountNamelogin;
        public string AccountNameLogin { get => _AccountNamelogin; set { _AccountNamelogin = value; OnPropertyChanged(); } }


        private ObservableCollection<Model.Object> _ListBook;
        public ObservableCollection<Model.Object> ListBook { get => _ListBook; set { _ListBook = value; OnPropertyChanged(); } }

        private ObservableCollection<BorrowDashboard> _ListDashboard;
        public ObservableCollection<BorrowDashboard> ListDashboard { get => _ListDashboard; set { _ListDashboard = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.Suplier> _ListSuplier;
        public ObservableCollection<Model.Suplier> ListSuplier {  get => _ListSuplier; set { _ListSuplier = value; OnPropertyChanged(); } }

        private ObservableCollection<Model.Bookshelf> _ListBookshelf;
        public ObservableCollection<Model.Bookshelf> ListBookshelf
        {
            get => _ListBookshelf;
            set
            {
                _ListBookshelf = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Model.Reader> _ListReader;
        public ObservableCollection<Reader> ListReader
        {
            get => _ListReader;
            set
            {
                _ListReader = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Model.Position> _ListPosition;
        public ObservableCollection<Model.Position> ListPosition
        {
            get => _ListPosition;
            set
            {
                _ListPosition = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Model.User> _ListUser;
        public ObservableCollection<Model.User> ListUser
        {
            get => _ListUser;
            set
            {
                _ListUser = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Model.UserRole> _ListUserRole;
        public ObservableCollection<Model.UserRole> ListUserRole
        {
            get => _ListUserRole;
            set
            {
                _ListUserRole = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Model.Input> _ListInput;
        public ObservableCollection<Model.Input> ListInput
        {
            get => _ListInput;
            set
            {
                _ListInput = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Staff> _StaffList;
        public ObservableCollection<Staff> StaffList
        {
            get => _StaffList;
            set
            {
                _StaffList = value;
                OnPropertyChanged();
            }
        }

        private Model.Object _SelectedItem_Book;
        public Model.Object SelectedItem_Book { get => _SelectedItem_Book;
            set
            {
                _SelectedItem_Book = value;
                OnPropertyChanged();
                if (SelectedItem_Book != null)
                {
                    DisplayName_Book = SelectedItem_Book.DisplayName;
                    Author_Book = SelectedItem_Book.Author;
                    Kind_Book = SelectedItem_Book.Kind;
                    PublishingYear_Book = SelectedItem_Book.PublishingYear;
                    Pages_Book = SelectedItem_Book.Pages;
                    Copies_Book = SelectedItem_Book.Copies;
                    SelectedSuplier = SelectedItem_Book.Suplier;
                    Catagories_Book = SelectedItem_Book.Catagories;
                    SelectedBookshelf = SelectedItem_Book.Bookshelf;
                }
            }
        }

        private Model.Bookshelf _SelectedItem_Bookshelf;
        public Model.Bookshelf SelectedItem_Bookshelf
        {
            get => _SelectedItem_Bookshelf;
            set
            {
                _SelectedItem_Bookshelf = value;
                OnPropertyChanged();
                if (SelectedItem_Bookshelf != null)
                {
                    DisplayName_Bookshelf = SelectedItem_Bookshelf.DisplayName;
                }
            }
        }

        private Model.Position _SelectedPosition;
        public Model.Position SelectedPosition
        {
            get => _SelectedPosition;
            set
            {
                _SelectedPosition = value;
                OnPropertyChanged();
                if (SelectedPosition != null)
                {
                    DisplayName_Position = SelectedPosition.DisplayName;
                }
            }
        }

        private Model.UserRole _SelectedUserRole;
        public Model.UserRole SelectedUserRole
        {
            get => _SelectedUserRole;
            set
            {
                _SelectedUserRole = value;
                OnPropertyChanged();
            }
        }

        private Model.Suplier _SelectedItem_Suplier;
        public Model.Suplier SelectedItem_Suplier
        {
            get => _SelectedItem_Suplier;
            set
            {
                _SelectedItem_Suplier = value;
                OnPropertyChanged();
                if (SelectedItem_Suplier != null)
                {
                    DisplayName_Suplier = SelectedItem_Suplier.DisplayName;
                    Address_Suplier = SelectedItem_Suplier.Address;
                    Email_Suplier = SelectedItem_Suplier.Email;
                    PhoneNumber_Suplier = SelectedItem_Suplier.PhoneNumber;
                    ContractDate_Suplier = SelectedItem_Suplier.ContractDate;
                    Moreinfo_Suplier = SelectedItem_Suplier.MoreInfo;
                }
            }
        }

        private Model.Reader _SelectedItem_Reader;
        public Model.Reader SelectedItem_Reader
        {
            get => _SelectedItem_Reader;
            set
            {
                _SelectedItem_Reader = value;
                OnPropertyChanged();
                if (SelectedItem_Reader != null)
                {
                    DisplayName_Reader = SelectedItem_Reader.DisplayName;
                    SelectedGender = SelectedItem_Reader.Gender;
                    
                    Address_Reader = SelectedItem_Reader.Address;
                    Email_Reader = SelectedItem_Reader.Email;
                    PhoneNumber_Reader = SelectedItem_Reader.PhoneNumber;
                    Facebook_Reader = SelectedItem_Reader.Facebook;
                    Moreinfo_Reader = SelectedItem_Reader.MoreInfo;
                }
            }
        }

        private Model.Staff _SelectedItem_Staff;
        public Model.Staff SelectedItem_Staff
        {
            get => _SelectedItem_Staff;
            set
            {
                _SelectedItem_Staff = value;
                OnPropertyChanged();
                if (SelectedItem_Staff != null)
                {
                    DisplayName_Staff = SelectedItem_Staff.DisplayName;
                    SelectedGender1 = SelectedItem_Staff.Gender;
                    Address_Staff = SelectedItem_Staff.Address;
                    Email_Staff = SelectedItem_Staff.Email;
                    PhoneNumber_Staff = SelectedItem_Staff.Zalo;
                    SelectedPosition = SelectedItem_Staff.Position;
                    ContractDate_Staff = SelectedItem_Staff.ContractDate;
                    Moreinfo_Staff = SelectedItem_Staff.MoreInfo;
                }
            }
        }

        private Model.Position _SelectedItem_Position;
        public Model.Position SelectedItem_Position
        {
            get => _SelectedItem_Position;
            set
            {
                _SelectedItem_Position = value;
                OnPropertyChanged();
                if (SelectedItem_Position != null)
                {
                    DisplayName_Position = SelectedItem_Position.DisplayName;
                }
            }
        }

        private Model.User _SelectedItem_User;
        public Model.User SelectedItem_User
        {
            get => _SelectedItem_User;
            set
            {
                _SelectedItem_User = value;
                OnPropertyChanged();
                if (SelectedItem_User != null)
                {
                    DisplayName_User = SelectedItem_User.DisplayName;
                    SelectedGender2 = SelectedItem_User.Gender;
                    UserName_User = SelectedItem_User.UserName;
                    SelectedUserRole = SelectedItem_User.UserRole;
                }
            }
        }

        private Model.Input _SelectedItem_Input;
        public Model.Input SelectedItem_Input
        {
            get => _SelectedItem_Input;
            set
            {
                _SelectedItem_Input = value;
                OnPropertyChanged();
                if (SelectedItem_Input != null)
                {
                    DisplayNameBook_Input = DisplayName_Book = SelectedItem_Input.Object.DisplayName;
                    Author_Book = SelectedItem_Input.Object.Author;
                    Catagories_Book = SelectedItem_Input.Object.Catagories;
                    Kind_Book = SelectedItem_Input.Object.Kind;
                    SelectedSuplier = SelectedItem_Input.Object.Suplier;
                    SelectedBookshelf = SelectedItem_Input.Object.Bookshelf;
                    PublishingYear_Book = SelectedItem_Input.Object.PublishingYear;
                    Pages_Book = SelectedItem_Input.Object.Pages;
                    Count_Input = SelectedItem_Input.Count;
                    Pages_Book = Count_Input.ToString();
                    Status_Input = SelectedItem_Input.Status;
                    InputPrice_Input = SelectedItem_Input.InputPrice;
                    OutputPrice_Input = SelectedItem_Input.OutputPrice;
                    DateInput_Input = SelectedItem_Input.DateInput;
                }
            }
        }

        private Model.Suplier _SelectedSuplier;
        public Model.Suplier SelectedSuplier
        {
            get => _SelectedSuplier;
            set
            {
                _SelectedSuplier = value;
                OnPropertyChanged();
            }
        }

        private Model.Bookshelf _SelectedBookshelf;
        public Model.Bookshelf SelectedBookshelf
        {
            get => _SelectedBookshelf;
            set
            {
                _SelectedBookshelf = value;
                OnPropertyChanged();
            }
        }

        private List<Search1> _ListSearch1;
        public List<Search1> ListSearch1 { get => _ListSearch1; set { _ListSearch1 = value; OnPropertyChanged(); } }

        private Search1 _SelectedSearch1;
        public Search1 SelectedSearch1
        {
            get => _SelectedSearch1;
            set
            {
                _SelectedSearch1 = value;
                OnPropertyChanged();
            }
        }

        private List<Search2> _ListSearch2;
        public List<Search2> ListSearch2 { get => _ListSearch2; set { _ListSearch2 = value; OnPropertyChanged(); } }

        private Search2 _SelectedSearch2;
        public Search2 SelectedSearch2
        {
            get => _SelectedSearch2;
            set
            {
                _SelectedSearch2 = value;
                OnPropertyChanged();
            }
        }

        private List<Search4> _ListSearch4;
        public List<Search4> ListSearch4 { get => _ListSearch4; set { _ListSearch4 = value; OnPropertyChanged(); } }

        private Search4 _SelectedSearch4;
        public Search4 SelectedSearch4
        {
            get => _SelectedSearch4;
            set
            {
                _SelectedSearch4 = value;
                OnPropertyChanged();
            }
        }

        private List<Search5> _ListSearch5;
        public List<Search5> ListSearch5 { get => _ListSearch5; set { _ListSearch5 = value; OnPropertyChanged(); } }

        private Search5 _SelectedSearch5;
        public Search5 SelectedSearch5
        {
            get => _SelectedSearch5;
            set
            {
                _SelectedSearch5 = value;
                OnPropertyChanged();
            }
        }

        private List<Search6> _ListSearch6;
        public List<Search6> ListSearch6 { get => _ListSearch6; set { _ListSearch6 = value; OnPropertyChanged(); } }

        private Search6 _SelectedSearch6;
        public Search6 SelectedSearch6
        {
            get => _SelectedSearch6;
            set
            {
                _SelectedSearch6 = value;
                OnPropertyChanged();
            }
        }

        private List<Search7> _ListSearch7;
        public List<Search7> ListSearch7 { get => _ListSearch7; set { _ListSearch7 = value; OnPropertyChanged(); } }

        private Search7 _SelectedSearch7;
        public Search7 SelectedSearch7
        {
            get => _SelectedSearch7;
            set
            {
                _SelectedSearch7 = value;
                OnPropertyChanged();
            }
        }

        private List<Search8> _ListSearch8;
        public List<Search8> ListSearch8 { get => _ListSearch8; set { _ListSearch8 = value; OnPropertyChanged(); } }

        private Search8 _SelectedSearch8;
        public Search8 SelectedSearch8
        {
            get => _SelectedSearch8;
            set
            {
                _SelectedSearch8 = value;
                OnPropertyChanged();
            }
        }

        private List<Search9> _ListSearch9;
        public List<Search9> ListSearch9 { get => _ListSearch9; set { _ListSearch9 = value; OnPropertyChanged(); } }

        private Search9 _SelectedSearch9;
        public Search9 SelectedSearch9
        {
            get => _SelectedSearch9;
            set
            {
                _SelectedSearch9 = value;
                OnPropertyChanged();
            }
        }

        #region InfoBook
        private string _DisplayName_Book;
        public string DisplayName_Book { get => _DisplayName_Book; set { _DisplayName_Book = value; OnPropertyChanged(); } }

        private string _Author_Book;
        public string Author_Book { get => _Author_Book; set { _Author_Book = value; OnPropertyChanged(); } }

        private string _Suplier_Book;
        public string Suplier_Book { get => _Suplier_Book; set { _Suplier_Book = value; OnPropertyChanged(); } }

        private string _Kind_Book;
        public string Kind_Book { get => _Kind_Book; set { _Kind_Book = value; OnPropertyChanged(); } }

        private string _PublishingYear_Book;
        public string PublishingYear_Book { get => _PublishingYear_Book; set { _PublishingYear_Book = value; OnPropertyChanged(); } }

        private string _Pages_Book;
        public string Pages_Book { get => _Pages_Book; set { _Pages_Book = value; OnPropertyChanged(); } }

        private string _Copies_Book;
        public string Copies_Book { get => _Copies_Book; set { _Copies_Book = value; OnPropertyChanged(); } }

        private string _Location_Book;
        public string Location_Book { get => _Location_Book; set { _Location_Book = value; OnPropertyChanged(); } }

        private string _Catagories_Book;
        public string Catagories_Book { get => _Catagories_Book; set { _Catagories_Book = value; OnPropertyChanged(); } }
        #endregion

        private string _DisplayName_Bookshelf;
        public string DisplayName_Bookshelf { get => _DisplayName_Bookshelf; set { _DisplayName_Bookshelf = value; OnPropertyChanged(); } }

        private string _DisplayName_Position;
        public string DisplayName_Position { get => _DisplayName_Position; set { _DisplayName_Position = value; OnPropertyChanged(); } }

        #region InfoSuplier
        private string _DisplayName_Suplier;
        public string DisplayName_Suplier { get => _DisplayName_Suplier; set { _DisplayName_Suplier = value; OnPropertyChanged(); } }
        private string _Address_Suplier;
        public string Address_Suplier { get => _Address_Suplier; set { _Address_Suplier = value; OnPropertyChanged(); } }
        private string _Email_Suplier;
        public string Email_Suplier { get => _Email_Suplier; set { _Email_Suplier = value; OnPropertyChanged(); } }
        private string _PhoneNumber_Suplier;
        public string PhoneNumber_Suplier { get => _PhoneNumber_Suplier; set { _PhoneNumber_Suplier = value; OnPropertyChanged(); } }
        private string _Moreinfo_Suplier;
        public string Moreinfo_Suplier { get => _Moreinfo_Suplier; set { _Moreinfo_Suplier = value; OnPropertyChanged(); } }
        private DateTime? _ContractDate_Suplier;
        public DateTime? ContractDate_Suplier { get => _ContractDate_Suplier; set { _ContractDate_Suplier = value; OnPropertyChanged(); } }
        #endregion

        #region InfoReader
        private string _DisplayName_Reader;
        public string DisplayName_Reader { get => _DisplayName_Reader; set { _DisplayName_Reader = value; OnPropertyChanged(); } }
        private string _Address_Reader;
        public string Address_Reader { get => _Address_Reader; set { _Address_Reader = value; OnPropertyChanged(); } }
        private string _Email_Reader;
        public string Email_Reader { get => _Email_Reader; set { _Email_Reader = value; OnPropertyChanged(); } }
        private string _PhoneNumber_Reader;
        public string PhoneNumber_Reader { get => _PhoneNumber_Reader; set { _PhoneNumber_Reader = value; OnPropertyChanged(); } }
        private string _Moreinfo_Reader;
        public string Moreinfo_Reader { get => _Moreinfo_Reader; set { _Moreinfo_Reader = value; OnPropertyChanged(); } }
        private string _Facebook_Reader;
        public string Facebook_Reader { get => _Facebook_Reader; set { _Facebook_Reader = value; OnPropertyChanged(); } }
        #endregion

        #region BorrowPay
        private string _DisplayNameReader_BorrowPay;
        public string DisplayNameReader_BorrowPay { get => _DisplayNameReader_BorrowPay; set { _DisplayNameReader_BorrowPay = value; OnPropertyChanged(); } }
        private DateTime? _BorrowDate_BorrowPay;
        public DateTime? BorrowDate_BorrowPay { get => _BorrowDate_BorrowPay; set { _BorrowDate_BorrowPay = value; OnPropertyChanged(); } }
        private DateTime? _PayDate_BorrowPay;
        public DateTime? PayDate_BorrowPay { get => _PayDate_BorrowPay; set { _PayDate_BorrowPay = value; OnPropertyChanged(); } }
        private int _BorrowBooks_BorrowPay;
        public int BorrowBooks_BorrowPay { get => _BorrowBooks_BorrowPay; set { _BorrowBooks_BorrowPay = value; OnPropertyChanged(); } }
        private string _Status_BorrowPay;
        public string Status_BorrowPay { get => _Status_BorrowPay; set { _Status_BorrowPay = value; OnPropertyChanged(); } }
        #endregion

        #region InfoStaff
        private string _DisplayName_Staff;
        public string DisplayName_Staff { get => _DisplayName_Staff; set { _DisplayName_Staff = value; OnPropertyChanged(); } }

        private string _Address_Staff;
        public string Address_Staff { get => _Address_Staff; set { _Address_Staff = value; OnPropertyChanged(); } }

        private string _Email_Staff;
        public string Email_Staff { get => _Email_Staff; set { _Email_Staff = value; OnPropertyChanged(); } }

        private string _PhoneNumber_Staff;
        public string PhoneNumber_Staff { get => _PhoneNumber_Staff; set { _PhoneNumber_Staff = value; OnPropertyChanged(); } }

        private string _Position_Staff;
        public string Position_Staff { get => _Position_Staff; set { _Position_Staff = value; OnPropertyChanged(); } }

        private string _Moreinfo_Staff;
        public string Moreinfo_Staff { get => _Moreinfo_Staff; set { _Moreinfo_Staff = value; OnPropertyChanged(); } }

        private string _Facebook_Staff;
        public string Facebook_Staff { get => _Facebook_Staff; set { _Facebook_Staff = value; OnPropertyChanged(); } }

        private DateTime? _ContractDate_Staff;
        public DateTime? ContractDate_Staff { get => _ContractDate_Staff; set { _ContractDate_Staff = value; OnPropertyChanged(); } }
        #endregion

        #region InfoUser
        private string _DisplayName_User;
        public string DisplayName_User { get => _DisplayName_User; set { _DisplayName_User = value; OnPropertyChanged(); } }

        private string _UserName_User;
        public string UserName_User { get => _UserName_User; set { _UserName_User = value; OnPropertyChanged(); } }
        #endregion

        #region InfoInput
        private string _DisplayNameBook_Input;
        public string DisplayNameBook_Input { get => _DisplayNameBook_Input; set { _DisplayNameBook_Input = value; OnPropertyChanged(); } }

        private int? _Count_Input;
        public int? Count_Input { get => _Count_Input; set { _Count_Input = value; OnPropertyChanged(); } }

        private string _Status_Input;
        public string Status_Input { get => _Status_Input; set { _Status_Input = value; OnPropertyChanged(); } }

        private double? _InputPrice_Input;
        public double? InputPrice_Input { get => _InputPrice_Input; set { _InputPrice_Input = value; OnPropertyChanged(); } }

        private double? _OutputPrice_Input;
        public double? OutputPrice_Input { get => _OutputPrice_Input; set { _OutputPrice_Input = value; OnPropertyChanged(); } }

        private DateTime? _DateInput_Input;
        public DateTime? DateInput_Input { get => _DateInput_Input; set { _DateInput_Input = value; OnPropertyChanged(); } }
        #endregion

        #region Myinform
        private string _DisplayName_MyInform;
        public string DisplayName_MyInform { get => _DisplayName_MyInform; set { _DisplayName_MyInform = value; OnPropertyChanged(); } }
        
        private string _Gender_MyInform;
        public string Gender_MyInform { get => _Gender_MyInform; set { _Gender_MyInform = value; OnPropertyChanged(); } }

        private string _UserName_MyInform;
        public string UserName_MyInform { get => _UserName_MyInform; set { _UserName_MyInform = value; OnPropertyChanged(); } }
        
        private string _UserRole_MyInform;
        public string UserRole_MyInform { get => _UserRole_MyInform; set { _UserRole_MyInform = value; OnPropertyChanged(); } }
        
        #endregion

        public ICommand LoadedWindowCommand { get; set; }
        public ICommand LoadedDashboardCommand { get; set; }

        #region TabMainCommands        
        public ICommand LoadTab1Command { get; set; }
        public ICommand LoadTab2Command { get; set; }
        public ICommand LoadTab3Command { get; set; }
        public ICommand LoadTab4Command { get; set; }
        public ICommand LoadTab5Command { get; set; }
        public ICommand LoadTab6Command { get; set; }
        #endregion

        #region Tab1Commands
        public ICommand LoadTab1_1Command { get; set; }

        public ICommand LoadTab1_2Command { get; set; }

        public ICommand LoadTab1_3Command { get; set; }

        public ICommand ButtonAdd1Command { get; set; }

        public ICommand ButtonEdit1Command { get; set; }

        public ICommand ButtonDelete1Command { get; set; }

        public ICommand ButtonAdd2Command { get; set; }

        public ICommand ButtonEdit2Command { get; set; }

        public ICommand ButtonDelete2Command { get; set; }

        public ICommand ButtonAdd3Command { get; set; }

        public ICommand ButtonEdit3Command { get; set; }

        public ICommand ButtonDelete3Command { get; set; }

        #endregion

        #region Tab2Commands
        public ICommand LoadTab2_1Command { get; set; }

        public ICommand LoadTab2_2Command { get; set; }

        public ICommand ButtonAdd4Command { get; set; }

        public ICommand ButtonDelete4Command { get; set; }

        public ICommand ButtonEdit4Command { get; set; }

        public ICommand ButtonAdd5Command { get; set; }

        public ICommand ButtonEdit5Command { get; set; }

        public ICommand ButtonDelete5Command { get; set; }

        public ICommand LoadDetailBorrowBooksWindowCommand { get; set; }

        public bool IsLoadedDetialBorrow { get; set; }
        #endregion

        #region Tab3Commands
        public ICommand LoadTab3_1Command { get; set; }

        public ICommand LoadTab3_2Command { get; set; }

        public ICommand LoadTab3_3Command { get; set; }

        public ICommand ButtonAdd6Command { get; set; }

        public ICommand ButtonDelete6Command { get; set; }

        public ICommand ButtonEdit6Command { get; set; }

        public ICommand ButtonAdd7Command { get; set; }

        public ICommand ButtonDelete7Command { get; set; }

        public ICommand ButtonEdit7Command { get; set; }

        public ICommand ButtonAdd8Command { get; set; }

        public ICommand ButtonDelete8Command { get; set; }

        public ICommand ButtonEdit8Command { get; set; }
        #endregion

        #region Tab4Commands
        public ICommand ButtonAdd9Command { get; set; }

        public ICommand ButtonEdit9Command { get; set; }

        public ICommand ButtonDelete9Command { get; set; }
        #endregion

        #region Tab6Commands
        public ICommand LoadTab6_1Command { get; set; }

        private string _LoadAvtImage;

        public string LoadAvtImage { get => _LoadAvtImage; set { _LoadAvtImage = value; OnPropertyChanged("LoadAvtImage"); } }

        public ICommand LoadTab6_2Command { get; set; }

        public ICommand LoadTab6_3Command { get; set; }

        public ICommand ImageChangedCommand { get; set; }

        public ICommand ButtonSavePersonalInforCommand { get; set; }

        public ICommand ButtonEditPersonalInforCommand { get; set; }

        public ICommand LoadfbgvCommand { get; set; }

        public ICommand LoadfbhsCommand { get; set; }

        private string _OldPassword;
        public string OldPassword { get => _OldPassword; set { _OldPassword = value; OnPropertyChanged(); } }

        public ICommand PasswordChangedCommand { get; set; }

        private string _NewPassword;
        public string NewPassword { get => _NewPassword; set { _NewPassword = value; OnPropertyChanged(); } }

        public ICommand PasswordChangedCommand1 { get; set; }

        private string _ConfirmPassword;
        public string ConfirmPassword { get => _ConfirmPassword; set { _ConfirmPassword = value; OnPropertyChanged(); } }

        public ICommand PasswordChangedCommand2 { get; set; }

        #endregion

        #region Search
        //Search1
        public ICommand TxbSearch1ChangedCommand { get; set; }

        private string _txbSearch1;
        public string txbSearch1 { get => _txbSearch1; set { _txbSearch1 = value; OnPropertyChanged(); } }
        
        //Search2
        public ICommand TxbSearch2ChangedCommand { get; set; }

        private string _txbSearch2;
        public string txbSearch2 { get => _txbSearch2; set { _txbSearch2 = value; OnPropertyChanged(); } }
        
        //Search3
        public ICommand TxbSearch3ChangedCommand { get; set; }

        private string _txbSearch3;
        public string txbSearch3 { get => _txbSearch3; set { _txbSearch3 = value; OnPropertyChanged(); } }
        
        //Search4
        public ICommand TxbSearch4ChangedCommand { get; set; }

        private string _txbSearch4;
        public string txbSearch4 { get => _txbSearch4; set { _txbSearch4 = value; OnPropertyChanged(); } }

        //Search5
        public ICommand TxbSearch5ChangedCommand { get; set; }

        private string _txbSearch5;
        public string txbSearch5 { get => _txbSearch5; set { _txbSearch5 = value; OnPropertyChanged(); } }

        //Search6
        public ICommand TxbSearch6ChangedCommand { get; set; }

        private string _txbSearch6;
        public string txbSearch6 { get => _txbSearch6; set { _txbSearch6 = value; OnPropertyChanged(); } }

        //Search7
        public ICommand TxbSearch7ChangedCommand { get; set; }

        private string _txbSearch7;
        public string txbSearch7 { get => _txbSearch7; set { _txbSearch7 = value; OnPropertyChanged(); } }

        //Search8
        public ICommand TxbSearch8ChangedCommand { get; set; }

        private string _txbSearch8;
        public string txbSearch8 { get => _txbSearch8; set { _txbSearch8 = value; OnPropertyChanged(); } }

        //Search9
        public ICommand TxbSearch9ChangedCommand { get; set; }

        private string _txbSearch9;
        public string txbSearch9 { get => _txbSearch9; set { _txbSearch9 = value; OnPropertyChanged(); } }
        #endregion

        #region ExportExcel
        public ICommand ExportExcelCommand { get; set; }
        public ICommand ExportExcel1Command { get; set; }
        public ICommand ExportExcel2Command { get; set; }
        public ICommand ExportExcel3Command { get; set; }
        public ICommand ExportExcel4Command { get; set; }
        public ICommand ExportExcel5Command { get; set; }
        public ICommand ExportExcel6Command { get; set; }
        public ICommand ExportExcel7Command { get; set; }
        public ICommand ExportExcel8Command { get; set; }
        public ICommand ExportExcel9Command { get; set; }
        #endregion

        public bool IsLoaded = false;
        #endregion

        #region Excel
        public void ExportExcel1()
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
                    a.Workbook.Properties.Title = String.Format("Danh sách các cuốn sách trong thư viện - {0}", DateTime.Now.ToLongDateString());

                    //Tạo một sheet để làm việc trên đó
                    a.Workbook.Worksheets.Add("Book sheet");

                    // lấy sheet vừa add ra để thao tác
                    ExcelWorksheet ws = a.Workbook.Worksheets[1];

                    // đặt tên cho sheet
                    ws.Name = "Book sheet";
                    // fontsize mặc định cho cả sheet
                    ws.Cells.Style.Font.Size = 14;
                    // font family mặc định cho cả sheet
                    ws.Cells.Style.Font.Name = "Segoe UI";

                    // Tạo danh sách các column header
                    string[] arrColumnHeader = {
                                                "Mã sách",
                                                "Tên sách",
                                                "Tác giả",
                                                "Thể loại",
                                                "Nhà cung cấp",
                                                "Vị trí",
                                                "Số trang",
                                                "Sổ bản",
                                                "Năm xuất bản",
                                                "Chuyên mục"
                        };

                    // lấy ra số lượng cột cần dùng dựa vào số lượng header
                    var countColHeader = arrColumnHeader.Count();

                    // merge các column lại từ column 1 đến số column header
                    // gán giá trị cho cell vừa merge là Danh sách các cuốn sách trong thư viện - Ngày tháng năm export
                    ws.Cells[1, 1].Value = String.Format("Danh sách các cuốn sách trong thư viện - {0}", DateTime.Now.ToLongDateString());
                    ws.Cells[1, 1, 1, countColHeader].Merge = true;
                    // in đậm
                    ws.Cells[1, 1, 1, countColHeader].Style.Font.Bold = true;
                    ws.Cells[1, 1, 1, countColHeader].Style.Font.Size = 18;
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
                    foreach (Model.Object item in ListBook)
                    {
                        // bắt đầu ghi từ cột 1. Excel bắt đầu từ 1 không phải từ 0
                        colIndex = 1;

                        // rowIndex tương ứng từng dòng dữ liệu
                        rowIndex++;

                        var cell = ws.Cells[rowIndex, colIndex];
                        //căn chỉnh các border
                        var border = cell.Style.Border;
                        for (int i = 1; i <= 10; i++)
                        {
                            cell = ws.Cells[rowIndex, i];
                            border = cell.Style.Border;
                            border.Bottom.Style = border.Top.Style = border.Left.Style =
                                border.Right.Style = ExcelBorderStyle.Thin;
                        }
                        //gán giá trị cho từng cell 
                        // lưu ý phải .ToShortDateString để dữ liệu khi in ra Excel là ngày như ta vẫn thấy.Nếu không sẽ ra tổng số :v
                        ws.Cells[rowIndex, colIndex++].Value = item.ID;
                        ws.Cells[rowIndex, colIndex++].Value = item.DisplayName;
                        ws.Cells[rowIndex, colIndex++].Value = item.Author;
                        ws.Cells[rowIndex, colIndex++].Value = item.Kind;
                        ws.Cells[rowIndex, colIndex++].Value = item.Suplier.DisplayName;
                        ws.Cells[rowIndex, colIndex++].Value = item.Bookshelf.DisplayName;
                        ws.Cells[rowIndex, colIndex++].Value = item.Pages;
                        ws.Cells[rowIndex, colIndex++].Value = item.Copies;
                        ws.Cells[rowIndex, colIndex++].Value = item.PublishingYear;
                        ws.Cells[rowIndex, colIndex++].Value = item.Catagories;

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
        public void ExportExcel2() {
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
                    a.Workbook.Properties.Title = String.Format("Danh sách các nhà cung cấp sách cho thư viện - {0}", DateTime.Now.ToLongDateString());

                    //Tạo một sheet để làm việc trên đó
                    a.Workbook.Worksheets.Add("Suplier sheet");

                    // lấy sheet vừa add ra để thao tác
                    ExcelWorksheet ws = a.Workbook.Worksheets[1];

                    // đặt tên cho sheet
                    ws.Name = "Suplier sheet";
                    // fontsize mặc định cho cả sheet
                    ws.Cells.Style.Font.Size = 14;
                    // font family mặc định cho cả sheet
                    ws.Cells.Style.Font.Name = "Segoe UI";

                    // Tạo danh sách các column header
                    string[] arrColumnHeader = {
                                                "Mã",
                                                "Tên nhà cung cấp",
                                                "Địa chỉ",
                                                "Số điện thoại",
                                                "Email",
                                                "Ngày bắt đầu cung cấp",
                                                "Thông tin thêm"
                        };

                    // lấy ra số lượng cột cần dùng dựa vào số lượng header
                    var countColHeader = arrColumnHeader.Count();

                    // merge các column lại từ column 1 đến số column header
                    // gán giá trị cho cell vừa merge là Danh sách các cuốn sách trong thư viện - Ngày tháng năm export
                    ws.Cells[1, 1].Value = String.Format("Danh sách các nhà cung cấp sách cho thư viện - {0}", DateTime.Now.ToLongDateString());
                    ws.Cells[1, 1, 1, countColHeader].Merge = true;
                    // in đậm
                    ws.Cells[1, 1, 1, countColHeader].Style.Font.Bold = true;
                    ws.Cells[1, 1, 1, countColHeader].Style.Font.Size = 18;
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
                    foreach (Suplier item in ListSuplier)
                    {
                        // bắt đầu ghi từ cột 1. Excel bắt đầu từ 1 không phải từ 0
                        colIndex = 1;

                        // rowIndex tương ứng từng dòng dữ liệu
                        rowIndex++;

                        var cell = ws.Cells[rowIndex, colIndex];
                        //căn chỉnh các border
                        var border = cell.Style.Border;
                        for (int i = 1; i <= 7; i++)
                        {
                            cell = ws.Cells[rowIndex, i];
                            border = cell.Style.Border;
                            border.Bottom.Style = border.Top.Style = border.Left.Style =
                                border.Right.Style = ExcelBorderStyle.Thin;
                        }

                        //gán giá trị cho từng cell 
                        // lưu ý phải .ToShortDateString để dữ liệu khi in ra Excel là ngày như ta vẫn thấy.Nếu không sẽ ra tổng số :v
                        ws.Cells[rowIndex, colIndex++].Value = item.ID;
                        ws.Cells[rowIndex, colIndex++].Value = item.DisplayName;
                        ws.Cells[rowIndex, colIndex++].Value = item.Address;
                        ws.Cells[rowIndex, colIndex++].Value = item.PhoneNumber;
                        ws.Cells[rowIndex, colIndex++].Value = item.Email;
                        ws.Cells[rowIndex, colIndex++].Value = item.ContractDate.Value.ToShortDateString();
                        ws.Cells[rowIndex, colIndex++].Value = item.MoreInfo;

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
        public void ExportExcel3()
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
                    a.Workbook.Properties.Title = String.Format("Danh sách các kệ sách trong thư viện - {0}", DateTime.Now.ToLongDateString());

                    //Tạo một sheet để làm việc trên đó
                    a.Workbook.Worksheets.Add("Bookshelf sheet");

                    // lấy sheet vừa add ra để thao tác
                    ExcelWorksheet ws = a.Workbook.Worksheets[1];

                    // đặt tên cho sheet
                    ws.Name = "Bookshelf sheet";
                    // fontsize mặc định cho cả sheet
                    ws.Cells.Style.Font.Size = 14;
                    // font family mặc định cho cả sheet
                    ws.Cells.Style.Font.Name = "Segoe UI";

                    // Tạo danh sách các column header
                    string[] arrColumnHeader = {
                                                "Mã",
                                                "Tên kệ sách"
                        };

                    // lấy ra số lượng cột cần dùng dựa vào số lượng header
                    var countColHeader = arrColumnHeader.Count();

                    // merge các column lại từ column 1 đến số column header
                    // gán giá trị cho cell vừa merge là Danh sách các kệ sách trong thư viện - Ngày tháng năm export
                    ws.Cells[1, 1].Value = String.Format("Danh sách các kệ sách trong thư viện - {0}", DateTime.Now.ToLongDateString());
                    ws.Cells[1, 1, 1, countColHeader].Merge = true;
                    // in đậm
                    ws.Cells[1, 1, 1, countColHeader].Style.Font.Bold = true;
                    ws.Cells[1, 1, 1, countColHeader].Style.Font.Size = 18;
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
                    foreach (Bookshelf item in ListBookshelf)
                    {
                        // bắt đầu ghi từ cột 1. Excel bắt đầu từ 1 không phải từ 0
                        colIndex = 1;

                        // rowIndex tương ứng từng dòng dữ liệu
                        rowIndex++;

                        var cell = ws.Cells[rowIndex, colIndex];
                        //căn chỉnh các border
                        var border = cell.Style.Border;
                        for (int i = 1; i <= 2; i++)
                        {
                            cell = ws.Cells[rowIndex, i];
                            border = cell.Style.Border;
                            border.Bottom.Style = border.Top.Style = border.Left.Style =
                                border.Right.Style = ExcelBorderStyle.Thin;
                        }

                        //gán giá trị cho từng cell 
                        // lưu ý phải .ToShortDateString để dữ liệu khi in ra Excel là ngày như ta vẫn thấy.Nếu không sẽ ra tổng số :v
                        ws.Cells[rowIndex, colIndex++].Value = item.ID;
                        ws.Cells[rowIndex, colIndex++].Value = item.DisplayName;

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
        public void ExportExcel4()
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
                    a.Workbook.Properties.Title = String.Format("Danh sách các độc giả đến thư viện - {0}", DateTime.Now.ToLongDateString());

                    //Tạo một sheet để làm việc trên đó
                    a.Workbook.Worksheets.Add("Reader sheet");

                    // lấy sheet vừa add ra để thao tác
                    ExcelWorksheet ws = a.Workbook.Worksheets[1];

                    // đặt tên cho sheet
                    ws.Name = "Reader sheet";
                    // fontsize mặc định cho cả sheet
                    ws.Cells.Style.Font.Size = 14;
                    // font family mặc định cho cả sheet
                    ws.Cells.Style.Font.Name = "Segoe UI";

                    // Tạo danh sách các column header
                    string[] arrColumnHeader = {
                                                "Mã",
                                                "Tên",
                                                "Địa chỉ",
                                                "Số điện thoại",
                                                "Email",
                                                "Facebook",
                                                "Thông tin thêm"
                        };

                    // lấy ra số lượng cột cần dùng dựa vào số lượng header
                    var countColHeader = arrColumnHeader.Count();

                    // merge các column lại từ column 1 đến số column header
                    // gán giá trị cho cell vừa merge là Danh sách các độc giả đến thư viện - Ngày tháng năm export
                    ws.Cells[1, 1].Value = String.Format("Danh sách các độc giả đến thư viện - {0}", DateTime.Now.ToLongDateString());
                    ws.Cells[1, 1, 1, countColHeader].Merge = true;
                    // in đậm
                    ws.Cells[1, 1, 1, countColHeader].Style.Font.Bold = true;
                    ws.Cells[1, 1, 1, countColHeader].Style.Font.Size = 18;
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
                    foreach (Reader item in ListReader)
                    {
                        // bắt đầu ghi từ cột 1. Excel bắt đầu từ 1 không phải từ 0
                        colIndex = 1;

                        // rowIndex tương ứng từng dòng dữ liệu
                        rowIndex++;

                        var cell = ws.Cells[rowIndex, colIndex];
                        //căn chỉnh các border
                        var border = cell.Style.Border;
                        for (int i = 1; i <= 7; i++)
                        {
                            cell = ws.Cells[rowIndex, i];
                            border = cell.Style.Border;
                            border.Bottom.Style = border.Top.Style = border.Left.Style =
                                border.Right.Style = ExcelBorderStyle.Thin;
                        }

                        //gán giá trị cho từng cell 
                        // lưu ý phải .ToShortDateString để dữ liệu khi in ra Excel là ngày như ta vẫn thấy.Nếu không sẽ ra tổng số :v
                        ws.Cells[rowIndex, colIndex++].Value = item.ID;
                        ws.Cells[rowIndex, colIndex++].Value = item.DisplayName;
                        ws.Cells[rowIndex, colIndex++].Value = item.Address;
                        ws.Cells[rowIndex, colIndex++].Value = item.PhoneNumber;
                        ws.Cells[rowIndex, colIndex++].Value = item.Email;
                        ws.Cells[rowIndex, colIndex++].Value = item.Facebook;
                        ws.Cells[rowIndex, colIndex++].Value = item.MoreInfo;

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
        
        public void ExportExcel6()
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
                    a.Workbook.Properties.Title = String.Format("Danh sách các nhân viên làm việc trong thư viện - {0}", DateTime.Now.ToLongDateString());

                    //Tạo một sheet để làm việc trên đó
                    a.Workbook.Worksheets.Add("Staff sheet");

                    // lấy sheet vừa add ra để thao tác
                    ExcelWorksheet ws = a.Workbook.Worksheets[1];

                    // đặt tên cho sheet
                    ws.Name = "Staff sheet";
                    // fontsize mặc định cho cả sheet
                    ws.Cells.Style.Font.Size = 14;
                    // font family mặc định cho cả sheet
                    ws.Cells.Style.Font.Name = "Segoe UI";

                    // Tạo danh sách các column header
                    string[] arrColumnHeader = {
                                                "Mã",
                                                "Tên nhân viên",
                                                "Địa chỉ",
                                                "Chức vụ",
                                                "Số điện thoại",
                                                "Email",
                                                "Thông tin thêm",
                                                "Ngày bắt đầu làm việc"
                        };

                    // lấy ra số lượng cột cần dùng dựa vào số lượng header
                    var countColHeader = arrColumnHeader.Count();

                    // merge các column lại từ column 1 đến số column header
                    // gán giá trị cho cell vừa merge là Danh sách các độc giả đến thư viện - Ngày tháng năm export
                    ws.Cells[1, 1].Value = String.Format("Danh sách các các nhân viên làm việc trong thư viện - {0}", DateTime.Now.ToLongDateString());
                    ws.Cells[1, 1, 1, countColHeader].Merge = true;
                    // in đậm
                    ws.Cells[1, 1, 1, countColHeader].Style.Font.Bold = true;
                    ws.Cells[1, 1, 1, countColHeader].Style.Font.Size = 18;
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
                    foreach (Staff item in StaffList)
                    {
                        // bắt đầu ghi từ cột 1. Excel bắt đầu từ 1 không phải từ 0
                        colIndex = 1;

                        // rowIndex tương ứng từng dòng dữ liệu
                        rowIndex++;

                        var cell = ws.Cells[rowIndex, colIndex];
                        //căn chỉnh các border
                        var border = cell.Style.Border;
                        for (int i = 1; i <= 7; i++)
                        {
                            cell = ws.Cells[rowIndex, i];
                            border = cell.Style.Border;
                            border.Bottom.Style = border.Top.Style = border.Left.Style =
                                border.Right.Style = ExcelBorderStyle.Thin;
                        }

                        //gán giá trị cho từng cell 
                        // lưu ý phải .ToShortDateString để dữ liệu khi in ra Excel là ngày như ta vẫn thấy.Nếu không sẽ ra tổng số :v
                        ws.Cells[rowIndex, colIndex++].Value = item.ID;
                        ws.Cells[rowIndex, colIndex++].Value = item.DisplayName;
                        ws.Cells[rowIndex, colIndex++].Value = item.Address;
                        ws.Cells[rowIndex, colIndex++].Value = item.Position.DisplayName;
                        ws.Cells[rowIndex, colIndex++].Value = item.Zalo;
                        ws.Cells[rowIndex, colIndex++].Value = item.Email;
                        ws.Cells[rowIndex, colIndex++].Value = item.MoreInfo;
                        ws.Cells[rowIndex, colIndex++].Value = item.ContractDate.Value.ToShortDateString();

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
        public void ExportExcel7()
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
                    a.Workbook.Properties.Title = String.Format("Danh sách các vị trí làm việc trong thư viện - {0}", DateTime.Now.ToLongDateString());

                    //Tạo một sheet để làm việc trên đó
                    a.Workbook.Worksheets.Add("Position sheet");

                    // lấy sheet vừa add ra để thao tác
                    ExcelWorksheet ws = a.Workbook.Worksheets[1];

                    // đặt tên cho sheet
                    ws.Name = "Position sheet";
                    // fontsize mặc định cho cả sheet
                    ws.Cells.Style.Font.Size = 14;
                    // font family mặc định cho cả sheet
                    ws.Cells.Style.Font.Name = "Segoe UI";

                    // Tạo danh sách các column header
                    string[] arrColumnHeader = {
                                                "Mã công việc",
                                                "Tên công việc"
                        };

                    // lấy ra số lượng cột cần dùng dựa vào số lượng header
                    var countColHeader = arrColumnHeader.Count();

                    // merge các column lại từ column 1 đến số column header
                    // gán giá trị cho cell vừa merge là Danh sách các độc giả đến thư viện - Ngày tháng năm export
                    ws.Cells[1, 1].Value = String.Format("Danh sách các các vị trí làm việc trong thư viện - {0}", DateTime.Now.ToLongDateString());
                    ws.Cells[1, 1, 1, countColHeader].Merge = true;
                    // in đậm
                    ws.Cells[1, 1, 1, countColHeader].Style.Font.Bold = true;
                    ws.Cells[1, 1, 1, countColHeader].Style.Font.Size = 18;
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
                    foreach (Position item in ListPosition)
                    {
                        // bắt đầu ghi từ cột 1. Excel bắt đầu từ 1 không phải từ 0
                        colIndex = 1;

                        // rowIndex tương ứng từng dòng dữ liệu
                        rowIndex++;

                        var cell = ws.Cells[rowIndex, colIndex];
                        //căn chỉnh các border
                        var border = cell.Style.Border;
                        for (int i = 1; i <= 7; i++)
                        {
                            cell = ws.Cells[rowIndex, i];
                            border = cell.Style.Border;
                            border.Bottom.Style = border.Top.Style = border.Left.Style =
                                border.Right.Style = ExcelBorderStyle.Thin;
                        }

                        //gán giá trị cho từng cell 
                        // lưu ý phải .ToShortDateString để dữ liệu khi in ra Excel là ngày như ta vẫn thấy.Nếu không sẽ ra tổng số :v
                        ws.Cells[rowIndex, colIndex++].Value = item.ID;
                        ws.Cells[rowIndex, colIndex++].Value = item.DisplayName;

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
        public void ExportExcel8()
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
                    a.Workbook.Properties.Title = String.Format("Danh sách các tài khoản quản lý thư viện - {0}", DateTime.Now.ToLongDateString());

                    //Tạo một sheet để làm việc trên đó
                    a.Workbook.Worksheets.Add("Users sheet");

                    // lấy sheet vừa add ra để thao tác
                    ExcelWorksheet ws = a.Workbook.Worksheets[1];

                    // đặt tên cho sheet
                    ws.Name = "Users sheet";
                    // fontsize mặc định cho cả sheet
                    ws.Cells.Style.Font.Size = 14;
                    // font family mặc định cho cả sheet
                    ws.Cells.Style.Font.Name = "Segoe UI";

                    // Tạo danh sách các column header
                    string[] arrColumnHeader = {
                                                "Mã tài khoản",
                                                "Tên tài khoản",
                                                "Quyền"
                        };

                    // lấy ra số lượng cột cần dùng dựa vào số lượng header
                    var countColHeader = arrColumnHeader.Count();

                    // merge các column lại từ column 1 đến số column header
                    // gán giá trị cho cell vừa merge là Danh sách các độc giả đến thư viện - Ngày tháng năm export
                    ws.Cells[1, 1].Value = String.Format("Danh sách các các tài khoản quản lý thư viện - {0}", DateTime.Now.ToLongDateString());
                    ws.Cells[1, 1, 1, countColHeader].Merge = true;
                    // in đậm
                    ws.Cells[1, 1, 1, countColHeader].Style.Font.Bold = true;
                    ws.Cells[1, 1, 1, countColHeader].Style.Font.Size = 18;
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
                    foreach (User item in ListUser)
                    {
                        // bắt đầu ghi từ cột 1. Excel bắt đầu từ 1 không phải từ 0
                        colIndex = 1;

                        // rowIndex tương ứng từng dòng dữ liệu
                        rowIndex++;

                        var cell = ws.Cells[rowIndex, colIndex];
                        //căn chỉnh các border
                        var border = cell.Style.Border;
                        for (int i = 1; i <= 7; i++)
                        {
                            cell = ws.Cells[rowIndex, i];
                            border = cell.Style.Border;
                            border.Bottom.Style = border.Top.Style = border.Left.Style =
                                border.Right.Style = ExcelBorderStyle.Thin;
                        }

                        //gán giá trị cho từng cell 
                        // lưu ý phải .ToShortDateString để dữ liệu khi in ra Excel là ngày như ta vẫn thấy.Nếu không sẽ ra tổng số :v
                        ws.Cells[rowIndex, colIndex++].Value = item.ID;
                        ws.Cells[rowIndex, colIndex++].Value = item.DisplayName;
                        ws.Cells[rowIndex, colIndex++].Value = item.UserRole.DisplayName;

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
        public void ExportExcel9()
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
                    a.Workbook.Properties.Title = String.Format("Danh sách các cuốn sách được nhập vào thư viện - {0}", DateTime.Now.ToLongDateString());

                    //Tạo một sheet để làm việc trên đó
                    a.Workbook.Worksheets.Add("Inputs sheet");

                    // lấy sheet vừa add ra để thao tác
                    ExcelWorksheet ws = a.Workbook.Worksheets[1];

                    // đặt tên cho sheet
                    ws.Name = "Inputs sheet";
                    // fontsize mặc định cho cả sheet
                    ws.Cells.Style.Font.Size = 14;
                    // font family mặc định cho cả sheet
                    ws.Cells.Style.Font.Name = "Segoe UI";

                    // Tạo danh sách các column header
                    string[] arrColumnHeader = {
                                                "Mã nhập",
                                                "Tên sách đã nhập",
                                                "Số lượng",
                                                "Trạng thái nhập",
                                                "Ngày nhập",
                                                "Giá nhập",
                                                "Giá xuất"
                        };

                    // lấy ra số lượng cột cần dùng dựa vào số lượng header
                    var countColHeader = arrColumnHeader.Count();

                    // merge các column lại từ column 1 đến số column header
                    // gán giá trị cho cell vừa merge là Danh sách các độc giả đến thư viện - Ngày tháng năm export
                    ws.Cells[1, 1].Value = String.Format("Danh sách các cuốn sách được nhập vào thư viện - {0}", DateTime.Now.ToLongDateString());
                    ws.Cells[1, 1, 1, countColHeader].Merge = true;
                    // in đậm
                    ws.Cells[1, 1, 1, countColHeader].Style.Font.Bold = true;
                    ws.Cells[1, 1, 1, countColHeader].Style.Font.Size = 18;
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
                    foreach (Input item in ListInput)
                    {
                        // bắt đầu ghi từ cột 1. Excel bắt đầu từ 1 không phải từ 0
                        colIndex = 1;

                        // rowIndex tương ứng từng dòng dữ liệu
                        rowIndex++;

                        var cell = ws.Cells[rowIndex, colIndex];
                        //căn chỉnh các border
                        var border = cell.Style.Border;
                        for (int i = 1; i <= 7; i++)
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
                        ws.Cells[rowIndex, colIndex++].Value = item.Count;
                        ws.Cells[rowIndex, colIndex++].Value = item.Status;
                        ws.Cells[rowIndex, colIndex++].Value = item.DateInput;
                        ws.Cells[rowIndex, colIndex++].Value = item.InputPrice;
                        ws.Cells[rowIndex, colIndex++].Value = item.OutputPrice;

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
        #endregion

        #region ControlBarCommand
        public ICommand CloseWindowCommand { get; set; }
        public ICommand MinimizeWindowCommand { get; set; }
        public ICommand MaximizeWindowCommand { get; set; }
        public ICommand MoveWindowCommand { get; set; }
        #endregion

        #region Processes
        //mọi thứ xử lý trong này
        public MainViewModel()
        {
            #region ControlBar
            CloseWindowCommand = new RelayCommand<Window>((p) => { return p == null ? false : true; }, (p) =>
            {
                if (p != null)
                {
                    
                    p.Close();
                }
            });
            MaximizeWindowCommand = new RelayCommand<Window>((p) => { return p == null ? false : true; }, (p) =>
            {
                if (p != null)
                {
                    if (p.WindowState != WindowState.Maximized)
                        p.WindowState = WindowState.Maximized;
                    else p.WindowState = WindowState.Normal;
                }
            });
            MinimizeWindowCommand = new RelayCommand<Window>((p) => { return p == null ? false : true; }, (p) =>
            {
                if (p != null)
                {
                    p.WindowState = WindowState.Minimized;
                }
            });
            MoveWindowCommand = new RelayCommand<Window>((p) => { return p == null ? false : true; }, (p) =>
            {
                if (p != null)
                {
                    p.DragMove();
                }
            });
            #endregion
            //Thực hiện chức năng gọi LoginWindow, kiểm tra đăng nhập và show MainWindow lên khi đăng nhập thành công
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                LoadProgram(p);
            });

            LoadedDashboardCommand = new RelayCommand<ListView>((p) => { return true; }, (p) =>
            {
                //LoadDashboard();
            });

            void LoadProgram(Window p)
            {
                //Kiểm tra kết nối CSDL
                try
                {
                    SqlConnection connection = new SqlConnection("data source=DESKTOP-T19JCR6\\PHATLEE;initial catalog=LibraryManagementPteam;integrated security=True;MultipleActiveResultSets=True;");
                    connection.Open();
                    connection.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Không kết nối được cơ sở dữ liệu...", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    p.Close();
                }

                IsLoaded = true;
                if (p == null) return;
                p.Hide();
                LoginWindow login = new LoginWindow();
                login.ShowDialog();
                if (login.DataContext == null) return;
                var loginVM = login.DataContext as LoginViewModel;
                if (loginVM.IsLogin)
                {
                    p.Show();
                    LoadMainList();
                }
                else
                {
                    p.Close();
                }
            }

            void LoadMainList()
            {
                FileStream stream = new FileStream("login.txt", FileMode.Open);
                StreamReader filelog = new StreamReader(stream);
                AccountNameLogin = filelog.ReadToEnd();
                WelcomeBack = "Chào mừng bạn đã trở lại, " + AccountNameLogin;
                filelog.Close();
                stream.Close();

                ListGender = new ObservableCollection<Gender>(DataProvider.Ins.db.Genders);
                ListBook = new ObservableCollection<Model.Object>(DataProvider.Ins.db.Objects);
                ListSuplier = new ObservableCollection<Suplier>(DataProvider.Ins.db.Supliers);
                ListBookshelf = new ObservableCollection<Bookshelf>(DataProvider.Ins.db.Bookshelves);
                ListReader = new ObservableCollection<Reader>(DataProvider.Ins.db.Readers);
                ListInput = new ObservableCollection<Input>(DataProvider.Ins.db.Inputs);
                StaffList = new ObservableCollection<Staff>(DataProvider.Ins.db.Staffs);
                ListPosition = new ObservableCollection<Position>(DataProvider.Ins.db.Positions);
                ListUserRole = new ObservableCollection<UserRole>(DataProvider.Ins.db.UserRoles);
                ListUser = new ObservableCollection<User>(DataProvider.Ins.db.Users);
                ListBookBorrow = new ObservableCollection<BookBorrow>(DataProvider.Ins.db.BookBorrows);

                //LoadDashboard();

                LoadTab6();
                ListSearch1 = new List<Search1>()
                {
                    new Search1(){ Ename= "DisplayName", Tname="Tên sách" },
                    new Search1(){ Ename= "Author", Tname="Tác giả" },
                    new Search1(){ Ename= "Kind", Tname="Thể loại" },
                    new Search1(){ Ename= "Suplier.DisplayName", Tname="Nhà cung cấp" },
                    new Search1(){ Ename= "Bookshelf.DisplayName", Tname="Vị trí" },
                    new Search1(){ Ename= "PublishingYear", Tname="Năm xuất bản" },
                    new Search1(){ Ename= "Pages", Tname="Số trang" },
                    new Search1(){ Ename= "Copies", Tname="Số bản" },
                    new Search1(){ Ename= "Catagories", Tname="Chuyên mục" }
                };
                ListSearch2 = new List<Search2>()
                {
                    new Search2(){ Ename= "DisplayName", Tname="Tên" },
                    new Search2(){ Ename= "Address", Tname="Địa chỉ" },
                    new Search2(){ Ename= "ContractDate", Tname="Ngày bắt đầu cung cấp" }
                };
                ListSearch4 = new List<Search4>()
                {
                    new Search4(){ Ename= "DisplayName", Tname="Tên" },
                    new Search4(){ Ename= "Address", Tname="Địa chỉ" }
                };
                ListSearch5 = new List<Search5>()
                {
                    new Search5(){ Ename= "DisplayName", Tname="Tên" },
                    new Search5(){ Ename= "BorrowDate", Tname="Ngày mượn" },
                    new Search5(){ Ename= "PayDate", Tname="Ngày hẹn trả" },
                    new Search5(){ Ename= "Count", Tname="Số sách mượn" },
                    new Search5(){ Ename= "Status", Tname="Trạng thái" }
                };
                ListSearch6 = new List<Search6>()
                {
                    new Search6(){ Ename= "DisplayName", Tname="Tên" },
                    new Search6(){ Ename= "Address", Tname="Địa chỉ" },
                    new Search6(){ Ename= "Position.DisplayName", Tname="Chức vụ" },
                    new Search6(){ Ename= "ContractDate", Tname="Ngày hợp tác" },
                    new Search6(){ Ename= "Zalo", Tname="Số điện thoại" },
                    new Search6(){ Ename= "Email", Tname="Email" }
                };
                ListSearch8 = new List<Search8>()
                {
                    new Search8(){ Ename= "DisplayName", Tname="Tên hiển thị" },
                    new Search8(){ Ename= "UserName", Tname="Tên đăng nhập" },
                    new Search8(){ Ename= "UserRole.DisplayName", Tname="Quyền" }                    
                };
                ListSearch9 = new List<Search9>()
                {
                    new Search9(){ Ename= "Object.DisplayName", Tname="Tên sách" },
                    new Search9(){ Ename= "Count", Tname="Số lượng" },
                    new Search9(){ Ename= "Status", Tname="Trạng thái" },
                    new Search9(){ Ename= "DateInput", Tname="Ngày nhập" },
                    new Search9(){ Ename= "InputPrice", Tname="Giá nhập" },
                    new Search9(){ Ename= "outputPrice", Tname="Giá xuất" }
                };
            }

            LogoutCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                LoadProgram(p);
            });

            #region LoadTabsofMain
            LoadTab1Command = new RelayCommand<TabControl>((p) => { return true; }, (p) =>
            {
                p.SelectedIndex = 0;
            });
            LoadTab2Command = new RelayCommand<TabControl>((p) => { return true; }, (p) =>
            {
                p.SelectedIndex = 1;
            });
            LoadTab3Command = new RelayCommand<TabControl>((p) => { return true; }, (p) =>
            {
                p.SelectedIndex = 2;
            });
            LoadTab4Command = new RelayCommand<TabControl>((p) => 
            {
                var accountlist = DataProvider.Ins.db.Users.Where(a => a.DisplayName == AccountNameLogin);
                if (accountlist.Count() == 0 || accountlist == null)
                    return false;
                if (accountlist.First().UserRole.DisplayName != "Admin")
                    return false;
                return true;
            }, (p) =>
            {
                p.SelectedIndex = 3;
            });
            LoadTab5Command = new RelayCommand<TabControl>((p) => { return true; }, (p) =>
            {
                p.SelectedIndex = 4;
            });
            LoadTab6Command = new RelayCommand<TabControl>((p) => { return true; }, (p) =>
            {
                p.SelectedIndex = 5;
            });
            #endregion

            #region Dashboard
            
            #endregion

            #region Tab1
            ButtonEdit1Command = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(DisplayName_Book) || SelectedSuplier == null || SelectedBookshelf == null)
                    return false;
                if (SelectedItem_Book == null)
                    return false;
                int result1;
                int result2;
                int result3;
                if (int.TryParse(Pages_Book, out result1) == false || int.TryParse(Copies_Book, out result2) == false || int.TryParse(PublishingYear_Book, out result3) == false)
                    return false;
                var displaylist_book = DataProvider.Ins.db.Objects.Where(a => a.ID == SelectedItem_Book.ID);
                if (displaylist_book.Count() != 0 && displaylist_book != null)
                    return true;
                return false;
            }, (p) =>
            {
                var book = DataProvider.Ins.db.Objects.Where(a => a.ID == SelectedItem_Book.ID).SingleOrDefault();
                book.DisplayName = DisplayName_Book;
                book.Author = Author_Book;
                book.Kind = Kind_Book;
                book.Pages = Pages_Book;
                book.Copies = Copies_Book;
                book.Catagories = Catagories_Book;
                book.PublishingYear = PublishingYear_Book;
                book.IDBookshelf = SelectedBookshelf.ID;
                book.IDSuplier = SelectedSuplier.ID;
                DataProvider.Ins.db.SaveChanges();
                SelectedItem_Book.DisplayName = DisplayName_Book;
                SelectedItem_Book.Author = Author_Book;
                SelectedItem_Book.IDBookshelf = SelectedBookshelf.ID;
                SelectedItem_Book.Copies = Copies_Book;
                SelectedItem_Book.Pages = Pages_Book;
                SelectedItem_Book.Kind = Kind_Book;
                SelectedItem_Book.PublishingYear = PublishingYear_Book;
                SelectedItem_Book.IDSuplier = SelectedSuplier.ID;
                SelectedItem_Book.Catagories = Catagories_Book;
                SelectedItem_Book.ID = book.ID;
                MessageBox.Show("Sửa sách thành công!", "Thông báo", MessageBoxButton.OK);
            });

            ButtonDelete1Command = new RelayCommand<ListView>((p) => 
            {
                if (SelectedItem_Book == null)
                    return false;
                var displaylist_book = DataProvider.Ins.db.Objects.Where(a => a.ID == SelectedItem_Book.ID);
                if (displaylist_book.Count() != 0 && displaylist_book != null)
                    return true;
                return false;
            }, (p) =>
            {
                var result = MessageBox.Show("Khi bạn xoá sách này,\n" +
                    "Hệ thống sẽ xoá sạch thông tin của sách này bên phần nhập sách. \n" +
                    "Để bảo vệ dữ liệu, bạn hãy nhấn Yes khi muốn hệ thống lưu phần nhập sách thành file Excel.\n" +
                    "Nếu muốn hệ thống xoá sách này mà không xuất file Excel, bạn hãy nhấn No.\n" +
                    "Và muốn thoát, bạn hãy nhấn Cancel!", "Cẩn thận khi xoá", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    var book = DataProvider.Ins.db.Objects.Where(a => a.ID == SelectedItem_Book.ID).SingleOrDefault();
                    if (book != null)
                    {
                        ExportExcel9();
                        //Xuất excel thành công
                        try
                        {
                            var bookdeli = DataProvider.Ins.db.Inputs.Where(a => a.IDObjects == book.ID).SingleOrDefault();
                            var bookBorrows = DataProvider.Ins.db.BookBorrows.Where(a => a.IDBook == book.ID).ToList();
                            if (bookBorrows.Count() != 0 && bookBorrows != null)
                            {
                                foreach (var item in bookBorrows)
                                {
                                    DataProvider.Ins.db.BookBorrows.Remove(item);
                                }
                            }
                            if (DataProvider.Ins.db.Inputs.Where(a => a.IDObjects == book.ID).Count() != 0 && DataProvider.Ins.db.Inputs.Where(a => a.IDObjects == book.ID) != null)
                            {
                                DataProvider.Ins.db.Inputs.Remove(bookdeli);
                            }
                            if (DataProvider.Ins.db.Objects.Where(a => a.ID == SelectedItem_Book.ID).Count() != 0 && DataProvider.Ins.db.Objects.Where(a => a.ID == SelectedItem_Book.ID) != null)
                            {
                                DataProvider.Ins.db.Objects.Remove(book);
                            }
                            DataProvider.Ins.db.SaveChanges();
                            ListInput = new ObservableCollection<Model.Input>(DataProvider.Ins.db.Inputs);
                            ListBook = new ObservableCollection<Model.Object>(DataProvider.Ins.db.Objects);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Có lỗi khi xoá!");
                        }
                    }
                }
                if(result == MessageBoxResult.No)
                {
                    var book = DataProvider.Ins.db.Objects.Where(a => a.ID == SelectedItem_Book.ID).SingleOrDefault();
                    if (book != null)
                    {
                        try
                        {
                            var bookdeli = DataProvider.Ins.db.Inputs.Where(a => a.IDObjects == book.ID).SingleOrDefault();
                            var bookBorrows = DataProvider.Ins.db.BookBorrows.Where(a => a.IDBook == book.ID);
                            
                            if (bookBorrows.Count() != 0 && bookBorrows != null)
                            {
                                foreach (var item in bookBorrows)
                                {
                                    DataProvider.Ins.db.BookBorrows.Remove(item);
                                }
                                
                            }
                            if (DataProvider.Ins.db.Inputs.Where(a => a.IDObjects == book.ID).Count() != 0 && DataProvider.Ins.db.Inputs.Where(a => a.IDObjects == book.ID) != null)
                            {
                                DataProvider.Ins.db.Inputs.Remove(bookdeli);
                            }
                            if (DataProvider.Ins.db.Objects.Where(a => a.ID == SelectedItem_Book.ID).Count() != 0 && DataProvider.Ins.db.Objects.Where(a => a.ID == SelectedItem_Book.ID) != null)
                            {
                                DataProvider.Ins.db.Objects.Remove(book);
                            }
                            DataProvider.Ins.db.SaveChanges();
                            if (DataProvider.Ins.db.BookBorrows.ToList() == null || DataProvider.Ins.db.BookBorrows.ToList().Count() == 0)
                            {
                                foreach (var item in DataProvider.Ins.db.Readers)
                                {
                                    EditReader(item, 3);
                                }
                            }
                            ListInput = new ObservableCollection<Model.Input>(DataProvider.Ins.db.Inputs);
                            ListBook = new ObservableCollection<Model.Object>(DataProvider.Ins.db.Objects);
                            foreach (var item in bookBorrows)
                            {
                                var reader = DataProvider.Ins.db.Readers.Where(a => a.ID == item.IDReader).SingleOrDefault();
                                if (reader != null)
                                {
                                    EditReader(reader, 2);
                                }
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Có lỗi khi xoá!");
                        }
                    }
                }
            });

            ButtonAdd2Command = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(DisplayName_Suplier))
                    return false;
                var displaylist_Suplier = DataProvider.Ins.db.Supliers.Where(a => a.DisplayName == DisplayName_Suplier);
                if (displaylist_Suplier.Count() != 0 || displaylist_Suplier == null)
                    return false;
                return true;
            }, (p) =>
            {
                var suplier = new Model.Suplier();
                suplier.DisplayName = DisplayName_Suplier;
                suplier.Email = Email_Suplier;
                suplier.ContractDate = ContractDate_Suplier;
                suplier.Address = Address_Suplier;
                suplier.MoreInfo = Moreinfo_Suplier;
                suplier.PhoneNumber = PhoneNumber_Suplier;
                DataProvider.Ins.db.Supliers.Add(suplier);
                DataProvider.Ins.db.SaveChanges();
                ListSuplier.Add(suplier);
                MessageBox.Show("Thêm nhà cung cấp thành công!", "Thông báo", MessageBoxButton.OK);
            });

            ButtonEdit2Command = new RelayCommand<object>((p) =>
            {
                if (SelectedItem_Suplier == null || string.IsNullOrEmpty(DisplayName_Suplier))
                    return false;
                var displaylist_suplier = DataProvider.Ins.db.Supliers.Where(a => a.ID == SelectedItem_Suplier.ID);
                if (displaylist_suplier.Count() == 0 || displaylist_suplier == null)
                    return false;
                return true;
            }, (p) =>
            {
                var suplier = DataProvider.Ins.db.Supliers.Where(a => a.ID == SelectedItem_Suplier.ID).SingleOrDefault();
                suplier.DisplayName = DisplayName_Suplier;
                suplier.Address = Address_Suplier;
                suplier.Email = Email_Suplier;
                suplier.PhoneNumber = PhoneNumber_Suplier;
                suplier.ContractDate = ContractDate_Suplier;
                suplier.MoreInfo = Moreinfo_Suplier;
                DataProvider.Ins.db.SaveChanges();
                SelectedItem_Suplier.DisplayName = DisplayName_Suplier;
                SelectedItem_Suplier.Address = Address_Suplier;
                SelectedItem_Suplier.Email = Email_Suplier;
                SelectedItem_Suplier.PhoneNumber = PhoneNumber_Suplier;
                SelectedItem_Suplier.ContractDate = ContractDate_Suplier;
                SelectedItem_Suplier.MoreInfo = Moreinfo_Suplier;
                SelectedItem_Suplier.ID = suplier.ID;
                MessageBox.Show("Sửa nhà cung cấp thành công!", "Thông báo", MessageBoxButton.OK);
            });

            ButtonDelete2Command = new RelayCommand<object>((p) => 
            {
                if (SelectedItem_Suplier == null)
                    return false;
                var displaylist_suplier = DataProvider.Ins.db.Supliers.Where(a => a.ID == SelectedItem_Suplier.ID);
                if (displaylist_suplier.Count() != 0 && displaylist_suplier != null)
                    return true;
                return false;
            }, (p) =>
            {
                Suplier suplierdel = DataProvider.Ins.db.Supliers.Where(a => a.ID == SelectedItem_Suplier.ID).SingleOrDefault();
                var result = MessageBox.Show("Khi bạn xoá nhà cung cấp này,\n" +
                    "Hệ thống sẽ xoá sạch thông tin của sách được cung cấp từ nhà cung cấp này. \n" +
                    "Để bảo vệ dữ liệu, bạn hãy nhấn Yes khi muốn hệ thống xuất các file Excel cần thiết trong chương trình.\n" +
                    "Nếu muốn hệ thống xoá sách này mà không xuất file Excel, bạn hãy nhấn No.\n" +
                    "Và muốn thoát, bạn hãy nhấn Cancel!", "Cẩn thận khi xoá", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    //Xuất excel phần sách
                    ExportExcel1();
                    //Xuất excel phần nhập sách
                    ExportExcel9();
                    //Xuất excel thành công!
                    if (DataProvider.Ins.db.Objects.Where(a => a.IDSuplier == suplierdel.ID) != null && DataProvider.Ins.db.Objects.Where(a => a.IDSuplier == suplierdel.ID).Count() != 0)
                    {
                        IQueryable<Model.Object> objectlist = DataProvider.Ins.db.Objects.Where(a => a.IDSuplier == suplierdel.ID);
                        foreach (Model.Object item in objectlist)
                        {
                            var inputdel = DataProvider.Ins.db.Inputs.Where(a => a.IDObjects == item.ID).SingleOrDefault();
                            DataProvider.Ins.db.Inputs.Remove(inputdel);
                            DataProvider.Ins.db.Objects.Remove(item);
                        }
                    }
                    DataProvider.Ins.db.Supliers.Remove(suplierdel);
                    DataProvider.Ins.db.SaveChanges();
                    ListInput = new ObservableCollection<Input>(DataProvider.Ins.db.Inputs);
                    ListBook = new ObservableCollection<Model.Object>(DataProvider.Ins.db.Objects);
                    ListSuplier = new ObservableCollection<Suplier>(DataProvider.Ins.db.Supliers);
                }
                if (result == MessageBoxResult.No)
                {
                    if(DataProvider.Ins.db.Objects.Where(a=>a.IDSuplier == suplierdel.ID) != null && DataProvider.Ins.db.Objects.Where(a => a.IDSuplier == suplierdel.ID).Count() != 0)
                    {                                                                        
                        IQueryable<Model.Object> objectlist = DataProvider.Ins.db.Objects.Where(a => a.IDSuplier == suplierdel.ID);
                        foreach (Model.Object item in objectlist)
                        {
                            var inputdel = DataProvider.Ins.db.Inputs.Where(a => a.IDObjects == item.ID).SingleOrDefault();
                            DataProvider.Ins.db.Inputs.Remove(inputdel);
                            DataProvider.Ins.db.Objects.Remove(item);
                        }                     
                    }
                    DataProvider.Ins.db.Supliers.Remove(suplierdel);
                    DataProvider.Ins.db.SaveChanges();
                    ListInput = new ObservableCollection<Input>(DataProvider.Ins.db.Inputs);
                    ListBook = new ObservableCollection<Model.Object>(DataProvider.Ins.db.Objects);
                    ListSuplier = new ObservableCollection<Suplier>(DataProvider.Ins.db.Supliers);
                }
                MessageBox.Show("Đã xoá nhà cung cấp này thành công!");
            });

            ButtonAdd3Command = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(DisplayName_Bookshelf))
                    return false;
                var displaylist_Bookshelf = DataProvider.Ins.db.Bookshelves.Where(a => a.DisplayName == DisplayName_Bookshelf);
                if (displaylist_Bookshelf.Count() != 0 || displaylist_Bookshelf == null)
                    return false;
                return true;
            }, (p) =>
            {
                int i = DataProvider.Ins.db.Objects.Count();
                i++;
                var bookshelf = new Model.Bookshelf();
                bookshelf.DisplayName = DisplayName_Bookshelf;
                DataProvider.Ins.db.Bookshelves.Add(bookshelf);
                DataProvider.Ins.db.SaveChanges();
                ListBookshelf.Add(bookshelf);
                MessageBox.Show("Thêm kệ sách thành công!", "Thông báo", MessageBoxButton.OK);
            });

            ButtonEdit3Command = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(DisplayName_Bookshelf) || SelectedItem_Bookshelf == null)
                    return false;
                if (SelectedItem_Bookshelf == null)
                    return false;
                var displaylist_bookshelf = DataProvider.Ins.db.Bookshelves.Where(a => a.ID == SelectedItem_Bookshelf.ID);
                if (displaylist_bookshelf.Count() != 0 && displaylist_bookshelf != null)
                    return true;
                return false;
            }, (p) =>
            {
                var bookshelf = DataProvider.Ins.db.Bookshelves.Where(a => a.ID == SelectedItem_Bookshelf.ID).SingleOrDefault();
                bookshelf.DisplayName = DisplayName_Bookshelf;
                DataProvider.Ins.db.SaveChanges();
                SelectedItem_Bookshelf.DisplayName = DisplayName_Bookshelf;
                MessageBox.Show("Sửa kệ sách thành công!", "Thông báo", MessageBoxButton.OK);
            });

            ButtonDelete3Command = new RelayCommand<object>((p) => {
                if (SelectedItem_Bookshelf == null)
                    return false;
                var displaylist_bookshelf = DataProvider.Ins.db.Bookshelves.Where(a => a.ID == SelectedItem_Bookshelf.ID);
                if (displaylist_bookshelf.Count() != 0 && displaylist_bookshelf != null)
                    return true;
                return false;
            }, (p) =>
            {
                Bookshelf bookshelfdel = DataProvider.Ins.db.Bookshelves.Where(a => a.ID == SelectedItem_Bookshelf.ID).SingleOrDefault();
                var result = MessageBox.Show("Khi bạn xoá kệ sách này,\n" +
                    "Hệ thống sẽ xoá sạch các sách được để trên kệ này. \n" +
                    "Để bảo vệ dữ liệu, bạn hãy nhấn Yes khi muốn hệ thống xuất các file Excel cần thiết trong chương trình.\n" +
                    "Nếu muốn hệ thống xoá sách này mà không xuất file Excel, bạn hãy nhấn No.\n" +
                    "Và muốn thoát, bạn hãy nhấn Cancel!", "Cẩn thận khi xoá", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    //Xuất excel phần sách
                    ExportExcel1();
                    //Xuất excel phần nhập sách
                    ExportExcel9();
                    //Xuất excel thành công!
                    if (DataProvider.Ins.db.Objects.Where(a => a.IDBookshelf == bookshelfdel.ID) != null && DataProvider.Ins.db.Objects.Where(a => a.IDBookshelf == bookshelfdel.ID).Count() != 0)
                    {
                        IQueryable<Model.Object> objectlist = DataProvider.Ins.db.Objects.Where(a => a.IDBookshelf == bookshelfdel.ID);
                        foreach (Model.Object item in objectlist)
                        {
                            var inputdel = DataProvider.Ins.db.Inputs.Where(a => a.IDObjects == item.ID).SingleOrDefault();
                            DataProvider.Ins.db.Inputs.Remove(inputdel);
                            DataProvider.Ins.db.Objects.Remove(item);
                        }
                    }
                    DataProvider.Ins.db.Bookshelves.Remove(bookshelfdel);
                    DataProvider.Ins.db.SaveChanges();
                    ListInput = new ObservableCollection<Input>(DataProvider.Ins.db.Inputs);
                    ListBook = new ObservableCollection<Model.Object>(DataProvider.Ins.db.Objects);
                    ListBookshelf = new ObservableCollection<Bookshelf>(DataProvider.Ins.db.Bookshelves);
                }
                if (result == MessageBoxResult.No)
                {
                    if (DataProvider.Ins.db.Objects.Where(a => a.IDBookshelf == bookshelfdel.ID) != null && DataProvider.Ins.db.Objects.Where(a => a.IDBookshelf == bookshelfdel.ID).Count() != 0)
                    {
                        IQueryable<Model.Object> objectlist = DataProvider.Ins.db.Objects.Where(a => a.IDBookshelf == bookshelfdel.ID);
                        foreach (Model.Object item in objectlist)
                        {
                            var inputdel = DataProvider.Ins.db.Inputs.Where(a => a.IDObjects == item.ID).SingleOrDefault();
                            DataProvider.Ins.db.Inputs.Remove(inputdel);
                            DataProvider.Ins.db.Objects.Remove(item);
                        }
                    }
                    DataProvider.Ins.db.Bookshelves.Remove(bookshelfdel);
                    DataProvider.Ins.db.SaveChanges();
                    ListInput = new ObservableCollection<Input>(DataProvider.Ins.db.Inputs);
                    ListBook = new ObservableCollection<Model.Object>(DataProvider.Ins.db.Objects);
                    ListBookshelf = new ObservableCollection<Bookshelf>(DataProvider.Ins.db.Bookshelves);
                }
                MessageBox.Show("Đã xoá kệ sách này thành công!");
            });
            #endregion

            #region Tab2
            BtnShowBorrowBooks = new RelayCommand<object>((p) => {
                if (SelectedItem_Reader == null)
                    return false;
                return true;
            }, (p) =>
            {
                string filepath = Directory.GetCurrentDirectory() + "\\borrowbook.txt";
                if (Directory.Exists(filepath) == true)
                {
                    Directory.Delete(filepath);
                }
                FileStream stream = new FileStream(filepath, FileMode.Create);
                StreamWriter file = new StreamWriter(stream);
                file.WriteLine(SelectedItem_Reader.ID);
                file.Flush();
                file.Close();
                stream.Close();

                BorrowBook borrowBook = new BorrowBook();
                borrowBook.Show();
            });

            ButtonAdd4Command = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(DisplayName_Reader))
                    return false;
                var displaylist_Reader = DataProvider.Ins.db.Readers.Where(a => a.DisplayName == DisplayName_Reader);
                if (displaylist_Reader.Count() != 0 || displaylist_Reader == null)
                    return false;
                return true;
            }, (p) =>
            {
                var reader = new Model.Reader();
                reader.DisplayName = DisplayName_Reader;
                reader.IDGender = SelectedGender.ID;
                reader.BookBorrowCount = DataProvider.Ins.db.BookBorrows.Where(a => a.IDReader == reader.ID).Count();
                reader.Email = Email_Reader;
                reader.Facebook = Facebook_Reader;
                reader.Address = Address_Reader;
                reader.MoreInfo = Moreinfo_Reader;
                reader.PhoneNumber = PhoneNumber_Reader;
                DataProvider.Ins.db.Readers.Add(reader);
                DataProvider.Ins.db.SaveChanges();
                ListReader.Add(reader);
                MessageBox.Show("Thêm độc giả thành công!", "Thông báo", MessageBoxButton.OK);
            });

            ButtonEdit4Command = new RelayCommand<object>((p) =>
            {
                if (SelectedItem_Reader == null || string.IsNullOrEmpty(DisplayName_Reader))
                    return false;
                var displaylist_Reader = DataProvider.Ins.db.Readers.Where(a => a.ID == SelectedItem_Reader.ID);
                if (displaylist_Reader.Count() != 0 && displaylist_Reader != null)
                    return true;
                return false;
            }, (p) =>
            {
                EditReader(SelectedItem_Reader, 1);
            });

            

            ButtonDelete4Command = new RelayCommand<object>((p) => {
                if (SelectedItem_Reader == null)
                    return false;
                var displaylist_reader = DataProvider.Ins.db.Readers.Where(a => a.ID == SelectedItem_Reader.ID);
                if (displaylist_reader.Count() != 0 && displaylist_reader != null)
                    return true;
                return false;
            }, (p) =>
            {
                Reader readerdel = DataProvider.Ins.db.Readers.Where(a => a.ID == SelectedItem_Reader.ID).SingleOrDefault();
                var result = MessageBox.Show("Khi bạn xoá độc giả này,\n" +
                    "Hệ thống sẽ xoá sạch các thông tin mượn/trả sách của độc giả này. \n" +
                    "Để bảo vệ dữ liệu, bạn hãy nhấn Yes khi muốn hệ thống xuất các file Excel cần thiết trong chương trình.\n" +
                    "Nếu muốn hệ thống xoá sách này mà không xuất file Excel, bạn hãy nhấn No.\n" +
                    "Và muốn thoát, bạn hãy nhấn Cancel!", "Cẩn thận khi xoá", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    ExportExcel4();

                    //Xuất excel thành công!
                    if (DataProvider.Ins.db.BookBorrows.Where(a => a.IDReader == readerdel.ID) != null && DataProvider.Ins.db.BookBorrows.Where(a => a.IDReader == readerdel.ID).Count() != 0)
                    {
                        var bookborrowdel = DataProvider.Ins.db.BookBorrows.Where(a => a.IDReader == readerdel.ID).SingleOrDefault();
                        DataProvider.Ins.db.BookBorrows.Remove(bookborrowdel);
                    }
                    DataProvider.Ins.db.Readers.Remove(readerdel);
                    DataProvider.Ins.db.SaveChanges();
                    ListReader = new ObservableCollection<Model.Reader>(DataProvider.Ins.db.Readers);
                }
                if (result == MessageBoxResult.No)
                {
                    if (DataProvider.Ins.db.BookBorrows.Where(a => a.IDReader == readerdel.ID) != null && DataProvider.Ins.db.BookBorrows.Where(a => a.IDReader == readerdel.ID).Count() != 0)
                    {
                        foreach (var item in DataProvider.Ins.db.BookBorrows.Where(a => a.IDReader == readerdel.ID))
                        {
                            DataProvider.Ins.db.BookBorrows.Remove(item);
                        }
                    }
                    DataProvider.Ins.db.Readers.Remove(readerdel);
                    DataProvider.Ins.db.SaveChanges();
                    ListReader = new ObservableCollection<Model.Reader>(DataProvider.Ins.db.Readers);
                }
                MessageBox.Show("Đã xoá độc giả này thành công!");
            });

            //SmileP14
            //YouTubeAPI
            //447607826599 - 3ihrnij8aen1rsm9rs2btl5u54mvcns1.apps.googleusercontent.com
            //7afwVMKf5K9dJZU2s6plfREL

            #endregion

            #region Tab3
            LoadTab3_1Command = new RelayCommand<TabControl>((p) => {
                
                return true;
            }, (p) =>
            {
                p.SelectedIndex = 0;
            });

            LoadTab3_2Command = new RelayCommand<TabControl>((p) => {
                var accountlist = DataProvider.Ins.db.Users.Where(a => a.DisplayName == AccountNameLogin);
                if (accountlist.Count() == 0 || accountlist == null)
                    return false;
                if (accountlist.First().UserRole.DisplayName != "Admin")
                    return false;
                return true;
            }, (p) =>
            {
                p.SelectedIndex = 1;
            });

            LoadTab3_3Command = new RelayCommand<TabControl>((p) => {
                var accountlist = DataProvider.Ins.db.Users.Where(a => a.DisplayName == AccountNameLogin);
                if (accountlist.Count() == 0 || accountlist == null)
                    return false;
                if (accountlist.First().UserRole.DisplayName != "Admin")
                    return false;
                return true;
            }, (p) =>
            {
                p.SelectedIndex = 2;
            });

            ButtonAdd6Command = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(DisplayName_Staff) || SelectedPosition == null || SelectedGender1 == null)
                    return false;
                var displaylist_staff = DataProvider.Ins.db.Staffs.Where(a => a.DisplayName == DisplayName_Staff);
                if (displaylist_staff.Count() != 0 || displaylist_staff == null)
                    return false;
                return true;
            }, (p) =>
            {
                var staff = new Model.Staff();
                staff.DisplayName = DisplayName_Staff;
                staff.IDGender = SelectedGender1.ID;
                staff.Address = Address_Staff;
                staff.Zalo = PhoneNumber_Staff;
                staff.Email = Email_Staff;
                staff.MoreInfo = Moreinfo_Staff;
                staff.ContractDate = ContractDate_Staff;
                staff.IDPosition = SelectedItem_Staff.ID;
                DataProvider.Ins.db.Staffs.Add(staff);
                DataProvider.Ins.db.SaveChanges();
                StaffList.Add(staff);
                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButton.OK);
            });

            ButtonEdit6Command = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(DisplayName_Staff) || SelectedItem_Staff == null || SelectedItem_Staff == null)
                    return false;
                var displaylist_staff = DataProvider.Ins.db.Staffs.Where(a => a.ID == SelectedItem_Staff.ID);
                if (displaylist_staff.Count() != 0 && displaylist_staff != null)
                    return true;
                return false;
            }, (p) =>
            {
                var staff = DataProvider.Ins.db.Staffs.Where(a => a.ID == SelectedItem_Staff.ID).SingleOrDefault();
                staff.DisplayName = DisplayName_Staff;
                staff.IDGender = SelectedGender1.ID;
                staff.Address = Address_Staff;
                staff.Zalo = PhoneNumber_Staff;
                staff.Email = Email_Staff;
                staff.MoreInfo = Moreinfo_Staff;
                staff.ContractDate = ContractDate_Staff;
                staff.IDPosition = SelectedPosition.ID;
                DataProvider.Ins.db.SaveChanges();
                SelectedItem_Staff.ID = staff.ID;
                SelectedItem_Staff.DisplayName = DisplayName_Staff;
                SelectedItem_Staff.IDGender = SelectedGender1.ID;
                SelectedItem_Staff.Address = Address_Staff;
                SelectedItem_Staff.Zalo = PhoneNumber_Staff;
                SelectedItem_Staff.IDPosition = SelectedPosition.ID;
                SelectedItem_Staff.Email = Email_Staff;
                SelectedItem_Staff.MoreInfo = Moreinfo_Staff;
                MessageBox.Show("Sửa thông tin nhân viên thành công!", "Thông báo", MessageBoxButton.OK);
            });

            ButtonDelete6Command = new RelayCommand<object>((p) => {
                if (SelectedItem_Staff == null)
                    return false;
                var displaylist_staff = DataProvider.Ins.db.Staffs.Where(a => a.ID == SelectedItem_Staff.ID);
                if (displaylist_staff.Count() != 0 && displaylist_staff != null)
                    return true;
                return false;
            }, (p) =>
            {
                Staff staffdel = DataProvider.Ins.db.Staffs.Where(a => a.ID == SelectedItem_Staff.ID).SingleOrDefault();
                DataProvider.Ins.db.Staffs.Remove(staffdel);
                DataProvider.Ins.db.SaveChanges();
                StaffList = new ObservableCollection<Staff>(DataProvider.Ins.db.Staffs);

                MessageBox.Show("Đã xoá nhân viên này thành công!");
            });

            ButtonAdd7Command = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(DisplayName_Position))
                    return false;
                var displaylist_position = DataProvider.Ins.db.Positions.Where(a => a.DisplayName == DisplayName_Position);
                if (displaylist_position.Count() != 0 || displaylist_position == null)
                    return false;
                return true;
            }, (p) =>
            {
                var position = new Model.Position();
                position.DisplayName = DisplayName_Position;
                DataProvider.Ins.db.Positions.Add(position);
                DataProvider.Ins.db.SaveChanges();
                ListPosition.Add(position);
            });

            ButtonEdit7Command = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(DisplayName_Position) || SelectedItem_Position == null)
                    return false;
                var displaylist_position = DataProvider.Ins.db.Positions.Where(a => a.DisplayName == DisplayName_Position);
                if (displaylist_position.Count() == 0 && displaylist_position != null)
                    return true;
                return false;
            }, (p) =>
            {
                var position = new Model.Position();
                position.DisplayName = DisplayName_Position;
                DataProvider.Ins.db.SaveChanges();
                SelectedItem_Position.DisplayName = DisplayName_Position;
            });

            ButtonDelete7Command = new RelayCommand<object>((p) => {
                if (SelectedItem_Position == null)
                    return false;
                var displaylist_position = DataProvider.Ins.db.Positions.Where(a => a.ID == SelectedItem_Position.ID);
                if (displaylist_position.Count() != 0 && displaylist_position != null)
                    return true;
                return false;
            }, (p) =>
            {
                Position positiondel = DataProvider.Ins.db.Positions.Where(a => a.ID == SelectedItem_Position.ID).SingleOrDefault();
                var result = MessageBox.Show("Khi bạn xoá công việc này,\n" +
                    "Hệ thống sẽ xoá sạch các nhân viên làm công việc này. \n" +
                    "Để bảo vệ dữ liệu, bạn hãy nhấn Yes khi muốn hệ thống xuất các file Excel cần thiết trong chương trình.\n" +
                    "Nếu muốn hệ thống xoá sách này mà không xuất file Excel, bạn hãy nhấn No.\n" +
                    "Và muốn thoát, bạn hãy nhấn Cancel!", "Cẩn thận khi xoá", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    //Xuất excel phần nhân viên
                    ExportExcel6();
                    //Xuất excel thành công!
                    if (DataProvider.Ins.db.Staffs.Where(a => a.IDPosition == positiondel.ID) != null && DataProvider.Ins.db.Staffs.Where(a => a.IDPosition == positiondel.ID).Count() != 0)
                    {
                        var stafflist = DataProvider.Ins.db.Staffs.Where(a => a.IDPosition == positiondel.ID);
                        foreach (Staff item in stafflist)
                        {
                            var staffdel = DataProvider.Ins.db.Staffs.Where(a => a.IDPosition == positiondel.ID).SingleOrDefault();
                            DataProvider.Ins.db.Staffs.Remove(staffdel);
                        }                        
                    }
                    DataProvider.Ins.db.Positions.Remove(positiondel);
                    DataProvider.Ins.db.SaveChanges();
                    StaffList = new ObservableCollection<Staff>(DataProvider.Ins.db.Staffs);
                    ListPosition = new ObservableCollection<Model.Position>(DataProvider.Ins.db.Positions);
                }
                if (result == MessageBoxResult.No)
                {
                    if (DataProvider.Ins.db.Staffs.Where(a => a.IDPosition == positiondel.ID) != null && DataProvider.Ins.db.Staffs.Where(a => a.IDPosition == positiondel.ID).Count() != 0)
                    {
                        var stafflist = DataProvider.Ins.db.Staffs.Where(a => a.IDPosition == positiondel.ID);
                        foreach (Staff item in stafflist)
                        {
                            var staffdel = DataProvider.Ins.db.Staffs.Where(a => a.IDPosition == positiondel.ID).SingleOrDefault();
                            DataProvider.Ins.db.Staffs.Remove(staffdel);
                        }
                    }
                    DataProvider.Ins.db.Positions.Remove(positiondel);
                    DataProvider.Ins.db.SaveChanges();
                    StaffList = new ObservableCollection<Staff>(DataProvider.Ins.db.Staffs);
                    ListPosition = new ObservableCollection<Model.Position>(DataProvider.Ins.db.Positions);
                }
                MessageBox.Show("Đã xoá công việc này thành công!");
            });

            ButtonAdd8Command = new RelayCommand<object>((p) => { return true; }, (p) => { RegisterWindow register = new RegisterWindow(); register.ShowDialog(); });

            ButtonEdit8Command = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(DisplayName_User) || SelectedUserRole == null || SelectedItem_User == null)
                    return false;
                var usernamelist_user = DataProvider.Ins.db.Users.Where(a => a.ID == SelectedItem_User.ID);
                if (usernamelist_user.Count() != 0 && usernamelist_user != null)
                    return true;
                return false;
            }, (p) =>
            {
                var user = DataProvider.Ins.db.Users.Where(a => a.ID == SelectedItem_User.ID).SingleOrDefault();
                user.DisplayName = DisplayName_User;
                user.IDGender = SelectedGender2.ID;
                user.UserName = UserName_User;
                user.IDUserRoles = SelectedUserRole.ID;
                DataProvider.Ins.db.SaveChanges();
                SelectedItem_User.DisplayName = DisplayName_User;
                SelectedItem_User.IDGender = SelectedGender2.ID;
                SelectedItem_User.UserName = UserName_User;
                SelectedItem_User.IDUserRoles = SelectedUserRole.ID;
            });

            ButtonDelete8Command = new RelayCommand<object>((p) => {
                if (SelectedItem_User == null)
                    return false;
                if (SelectedItem_User.UserRole.DisplayName == "Admin")
                    return false;
                var displaylist_user = DataProvider.Ins.db.Users.Where(a => a.ID == SelectedItem_User.ID);
                if (displaylist_user.Count() != 0 && displaylist_user != null)
                    return true;
                return false;
            }, (p) =>
            {
                User userdel = DataProvider.Ins.db.Users.Where(a => a.ID == SelectedItem_User.ID).SingleOrDefault();
                DataProvider.Ins.db.Users.Remove(userdel);
                DataProvider.Ins.db.SaveChanges();
                ListUser = new ObservableCollection<User>(DataProvider.Ins.db.Users);

                MessageBox.Show("Đã xoá tài khoản này thành công!");
            });
            #endregion

            #region Tab4
            ButtonAdd9Command = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(DisplayName_Book))
                    return false;
                int result1;
                int result2;
                int result3;
                if (int.TryParse(Pages_Book, out result1) == false || int.TryParse(Copies_Book, out result2) == false || int.TryParse(PublishingYear_Book, out result3) == false)
                    return false;
                var inputlist = DataProvider.Ins.db.Objects.Where(a => a.DisplayName == DisplayName_Book);
                if (inputlist.Count() != 0 || inputlist == null)
                    return false;
                return true;
            }, (p) =>
            {
                var input = new Model.Input();
                input.ID = Guid.NewGuid().ToString();
                input.Count = Convert.ToInt32(Copies_Book);
                input.Status = Status_Input;
                input.DateInput = DateInput_Input;
                input.InputPrice = InputPrice_Input;
                input.OutputPrice = OutputPrice_Input;
                input.IDObjects = Guid.NewGuid().ToString();
                DataProvider.Ins.db.Inputs.Add(input);
                var book = new Model.Object();
                book.ID = input.IDObjects;
                book.DisplayName = DisplayName_Book;
                book.Author = Author_Book;
                book.Kind = Kind_Book;
                book.Pages = Pages_Book;
                book.Copies = Copies_Book;
                book.Catagories = Catagories_Book;
                book.PublishingYear = PublishingYear_Book;
                book.IDBookshelf = SelectedBookshelf.ID;
                book.IDSuplier = SelectedSuplier.ID;
                DataProvider.Ins.db.Objects.Add(book);
                DataProvider.Ins.db.SaveChanges();
                ListBook.Add(book);
                ListInput.Add(input);
                MessageBox.Show("Thêm sách nhập thành công! Thông tin chi tiết của sách sẽ được cập nhật vào phần quản lý sách, bạn có thể vào đó xem chi tiết, xoá hoặc chỉnh sửa...", "Thông báo", MessageBoxButton.OK);
            });
            
            #endregion

            #region Tab5

            #endregion

            #region Tab6
            LoadAvtImage = "/ResourcesImage/AvtMain.png";

            LoadTab6_1Command = new RelayCommand<TabControl>((p) => { return true; }, (p) =>
            {
                p.SelectedIndex = 0;
            });

            LoadTab6_2Command = new RelayCommand<TabControl>((p) => { return true; }, (p) =>
            {
                p.SelectedIndex = 1;
            });
            LoadTab6_3Command = new RelayCommand<TabControl>((p) => { return true; }, (p) =>
            {
                p.SelectedIndex = 2;
            });

            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { OldPassword = p.Password; });

            PasswordChangedCommand1 = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { NewPassword = p.Password; });

            PasswordChangedCommand2 = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { ConfirmPassword = p.Password; });

            ButtonSavePersonalInforCommand = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn lưu thông tin này không?", "Thông báo", MessageBoxButton.YesNoCancel) == MessageBoxResult.Yes)
                {
                    var user = DataProvider.Ins.db.Users.Where(a => a.UserName == UserName_MyInform);
                    if(user != null || user.Count() != 0)
                    {
                        var User = user.SingleOrDefault();
                        var old = MD5Hash(Base64Encode(OldPassword));
                        if(User.Password == old && NewPassword == ConfirmPassword)
                        {
                            var New = MD5Hash(Base64Encode(NewPassword));
                            user.SingleOrDefault().Password = New;
                            DataProvider.Ins.db.SaveChanges();
                            MessageBox.Show("Đổi mật khẩu thành công!");
                        }
                        else
                        {
                            MessageBox.Show("Sai mật khẩu!");
                        }
                        
                    }
                }
            });

            ImageChangedCommand = new RelayCommand<Image>((p) => { return true; }, (p) =>
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.DefaultExt = ".png";
                if (openFile.ShowDialog() == true)
                {
                    string filename = openFile.FileName;
                    p.Source = new BitmapImage(new Uri(filename));
                }
            });

            LoadfbgvCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                Process.Start("https://www.facebook.com/profile.php?id=100008278180550");
            });
            LoadfbhsCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                Process.Start("https://www.facebook.com/phatlevanelight");
            });

            
            #endregion

            void LoadTab6()
            {
                var myinform = DataProvider.Ins.db.Users.Where(p => p.DisplayName == AccountNameLogin).SingleOrDefault();
                if(myinform != null)
                {
                    DisplayName_MyInform = myinform.DisplayName;
                    UserName_MyInform = myinform.UserName;
                    Gender_MyInform = myinform.Gender.DisplayName;
                    UserRole_MyInform = myinform.UserRole.DisplayName;
                }
            }

            #region Search1
            TxbSearch1ChangedCommand = new RelayCommand<ListView>((p) => { return true; }, (p) =>
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(p.ItemsSource);
                view.Filter = BookFilter;

                CollectionViewSource.GetDefaultView(p.ItemsSource).Refresh();
            });

            bool BookFilter(object item)
            {
                if (String.IsNullOrEmpty(txbSearch1))
                    return true;
                if (SelectedSearch1 == null)
                    return true;
                switch (SelectedSearch1.Ename)
                {
                    case "DisplayName":
                        return ((item as Model.Object).DisplayName.IndexOf(txbSearch1, StringComparison.OrdinalIgnoreCase) >= 0);
                    case "Author" :
                        return ((item as Model.Object).Author.IndexOf(txbSearch1, StringComparison.OrdinalIgnoreCase) >= 0);
                    case "Kind":
                        return ((item as Model.Object).Kind.IndexOf(txbSearch1, StringComparison.OrdinalIgnoreCase) >= 0);
                    case "Suplier.DisplayName":
                        return ((item as Model.Object).Suplier.DisplayName.IndexOf(txbSearch1, StringComparison.OrdinalIgnoreCase) >= 0);
                    case "Bookshelf.DisplayName":
                        return ((item as Model.Object).Bookshelf.DisplayName.IndexOf(txbSearch1, StringComparison.OrdinalIgnoreCase) >= 0);
                    case "Pages":
                        return ((item as Model.Object).Pages.IndexOf(txbSearch1, StringComparison.OrdinalIgnoreCase) >= 0);
                    case "Copies":
                        return ((item as Model.Object).Copies.IndexOf(txbSearch1, StringComparison.OrdinalIgnoreCase) >= 0);
                    case "PublishingYear":
                        return ((item as Model.Object).PublishingYear.IndexOf(txbSearch1, StringComparison.OrdinalIgnoreCase) >= 0);
                    case "Catagories":
                        return ((item as Model.Object).Catagories.IndexOf(txbSearch1, StringComparison.OrdinalIgnoreCase) >= 0);
                    default:
                        break;
                }
                return true;
            }

            #endregion

            #region Search2
            TxbSearch2ChangedCommand = new RelayCommand<ListView>((p) => { return true; }, (p) =>
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(p.ItemsSource);
                view.Filter = SuplierFilter;

                CollectionViewSource.GetDefaultView(p.ItemsSource).Refresh();
            });

            bool SuplierFilter(object item)
            {
                if (String.IsNullOrEmpty(txbSearch2))
                    return true;
                if (SelectedSearch2 == null)
                    return true;
                switch (SelectedSearch2.Ename)
                {
                    case "DisplayName":
                        return ((item as Model.Suplier).DisplayName.IndexOf(txbSearch2, StringComparison.OrdinalIgnoreCase) >= 0);
                    case "Address":
                        return ((item as Model.Suplier).Address.IndexOf(txbSearch2, StringComparison.OrdinalIgnoreCase) >= 0);
                    case "ContractDate":
                        return ((item as Model.Suplier).ContractDate.ToString().IndexOf(txbSearch2, StringComparison.OrdinalIgnoreCase) >= 0);                    
                    default:
                        break;
                }
                return true;
            }

            #endregion

            #region Search3
            TxbSearch3ChangedCommand = new RelayCommand<ListView>((p) => { return true; }, (p) =>
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(p.ItemsSource);
                view.Filter = BookshelfFilter;

                CollectionViewSource.GetDefaultView(p.ItemsSource).Refresh();
            });

            bool BookshelfFilter(object item)
            {
                if (String.IsNullOrEmpty(txbSearch3))
                    return true;
                return ((item as Model.Bookshelf).DisplayName.IndexOf(txbSearch3, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            #endregion

            #region Search4
            TxbSearch4ChangedCommand = new RelayCommand<ListView>((p) => { return true; }, (p) =>
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(p.ItemsSource);
                view.Filter = ReaderFilter;

                CollectionViewSource.GetDefaultView(p.ItemsSource).Refresh();
            });

            bool ReaderFilter(object item)
            {
                if (String.IsNullOrEmpty(txbSearch4))
                    return true;
                if (SelectedSearch4 == null)
                    return true;
                switch (SelectedSearch4.Ename)
                {
                    case "DisplayName":
                        return ((item as Model.Reader).DisplayName.IndexOf(txbSearch4, StringComparison.OrdinalIgnoreCase) >= 0);
                    case "Address":
                        return ((item as Model.Reader).Address.IndexOf(txbSearch4, StringComparison.OrdinalIgnoreCase) >= 0);                    
                    default:
                        break;
                }
                return true;
            }

            #endregion

            #region Search6
            TxbSearch6ChangedCommand = new RelayCommand<ListView>((p) => { return true; }, (p) =>
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(p.ItemsSource);
                view.Filter = StaffFilter;

                CollectionViewSource.GetDefaultView(p.ItemsSource).Refresh();
            });

            bool StaffFilter(object item)
            {
                if (String.IsNullOrEmpty(txbSearch6))
                    return true;
                if (SelectedSearch6 == null)
                    return true;
                switch (SelectedSearch6.Ename)
                {
                    case "DisplayName":
                        return ((item as Model.Staff).DisplayName.IndexOf(txbSearch6, StringComparison.OrdinalIgnoreCase) >= 0);
                    case "Address":
                        return ((item as Model.Staff).Address.IndexOf(txbSearch6, StringComparison.OrdinalIgnoreCase) >= 0);
                    case "Position.DisplayName":
                        return ((item as Model.Staff).Position.DisplayName.IndexOf(txbSearch6, StringComparison.OrdinalIgnoreCase) >= 0);
                    case "ContractDate":
                        return ((item as Model.Staff).ContractDate.ToString().IndexOf(txbSearch6, StringComparison.OrdinalIgnoreCase) >= 0);
                    case "Zalo":
                        return ((item as Model.Staff).Zalo.IndexOf(txbSearch6, StringComparison.OrdinalIgnoreCase) >= 0);
                    case "Email":
                        return ((item as Model.Staff).Email.IndexOf(txbSearch6, StringComparison.OrdinalIgnoreCase) >= 0);

                    default:
                        break;
                }
                return true;
            }

            #endregion

            #region Search7
            TxbSearch7ChangedCommand = new RelayCommand<ListView>((p) => { return true; }, (p) =>
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(p.ItemsSource);
                view.Filter = PositionFilter;

                CollectionViewSource.GetDefaultView(p.ItemsSource).Refresh();
            });

            bool PositionFilter(object item)
            {
                if (String.IsNullOrEmpty(txbSearch7))
                    return true;
                return ((item as Model.Position).DisplayName.IndexOf(txbSearch7, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            #endregion

            #region Search8
            TxbSearch8ChangedCommand = new RelayCommand<ListView>((p) => { return true; }, (p) =>
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(p.ItemsSource);
                view.Filter = UserFilter;

                CollectionViewSource.GetDefaultView(p.ItemsSource).Refresh();
            });

            bool UserFilter(object item)
            {
                if (String.IsNullOrEmpty(txbSearch8))
                    return true;
                if (SelectedSearch8 == null)
                    return true;
                switch (SelectedSearch8.Ename)
                {
                    case "DisplayName":
                        return ((item as Model.User).DisplayName.IndexOf(txbSearch8, StringComparison.OrdinalIgnoreCase) >= 0);
                    case "UserName":
                        return ((item as Model.User).UserName.IndexOf(txbSearch8, StringComparison.OrdinalIgnoreCase) >= 0);
                    case "UserRole.DisplayName":
                        return ((item as Model.User).UserRole.DisplayName.IndexOf(txbSearch8, StringComparison.OrdinalIgnoreCase) >= 0);
                    
                    default:
                        break;
                }
                return true;
            }

            #endregion

            #region Search9
            TxbSearch9ChangedCommand = new RelayCommand<ListView>((p) => { return true; }, (p) =>
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(p.ItemsSource);
                view.Filter = InputFilter;

                CollectionViewSource.GetDefaultView(p.ItemsSource).Refresh();
            });

            bool InputFilter(object item)
            {
                if (String.IsNullOrEmpty(txbSearch9))
                    return true;
                if (SelectedSearch9 == null)
                    return true;
                switch (SelectedSearch9.Ename)
                {
                    case "Object.DisplayName":
                        return ((item as Model.Input).Object.DisplayName.IndexOf(txbSearch9, StringComparison.OrdinalIgnoreCase) >= 0);
                    case "Count":
                        return ((item as Model.Input).Count.ToString().IndexOf(txbSearch9, StringComparison.OrdinalIgnoreCase) >= 0);
                    case "Status":
                        return ((item as Model.Input).Status.IndexOf(txbSearch9, StringComparison.OrdinalIgnoreCase) >= 0);
                    case "DateInput":
                        return ((item as Model.Input).DateInput.Value.ToShortDateString().IndexOf(txbSearch9, StringComparison.OrdinalIgnoreCase) >= 0);
                    case "InputPrice":
                        return ((item as Model.Input).InputPrice.ToString().IndexOf(txbSearch9, StringComparison.OrdinalIgnoreCase) >= 0);
                    case "OutputPrice":
                        return ((item as Model.Input).OutputPrice.ToString().IndexOf(txbSearch9, StringComparison.OrdinalIgnoreCase) >= 0);
                    
                    default:
                        break;
                }
                return true;
            }

            #endregion

            #region ExportExcel1            
           /* ExportExcel1Command = new RelayCommand<ListView>((p) => 
            {
                if(p.ItemsSource == null || p.Items.Count == 0)
                    return false;
                return true;
            }, (p) =>
            {
                ExportExcel1();
            });
            #endregion

            #region ExportExcel2
            ExportExcel2Command = new RelayCommand<ListView>((p) =>
            {
                if (p.ItemsSource == null || p.Items.Count == 0)
                    return false;
                return true;
            }, (p) =>
            {
                ExportExcel2();
            });
            #endregion

            #region ExportExcel3
            ExportExcel3Command = new RelayCommand<ListView>((p) =>
            {
                if (p.ItemsSource == null || p.Items.Count == 0)
                    return false;
                return true;
            }, (p) =>
            {
                ExportExcel3();
            });
            #endregion

            #region ExportExcel4
            ExportExcel4Command = new RelayCommand<ListView>((p) =>
            {
                if (p.ItemsSource == null || p.Items.Count == 0)
                    return false;
                return true;
            }, (p) =>
            {
                ExportExcel4();
            });
            #endregion

            #region ExportExcel6
            ExportExcel6Command = new RelayCommand<ListView>((p) =>
            {
                if (p.ItemsSource == null || p.Items.Count == 0)
                    return false;
                return true;
            }, (p) =>
            {
                ExportExcel6();
            });
            #endregion

            #region ExportExcel7
            ExportExcel7Command = new RelayCommand<ListView>((p) =>
            {
                if (p.ItemsSource == null || p.Items.Count == 0)
                    return false;
                return true;
            }, (p) =>
            {
                ExportExcel7();
            });
            #endregion

            #region ExportExcel8
            ExportExcel8Command = new RelayCommand<ListView>((p) =>
            {
                if (p.ItemsSource == null || p.Items.Count == 0)
                    return false;
                return true;
            }, (p) =>
            {
                ExportExcel8();
            });
            #endregion

            #region ExportExcel9
            ExportExcel9Command = new RelayCommand<ListView>((p) =>
            {
                if (p.ItemsSource == null || p.Items.Count == 0)
                    return false;
                return true;
            }, (p) =>
            {
                ExportExcel9();
            });*/
            #endregion

            #region LoadTabsofTab1
            LoadTab1_1Command = new RelayCommand<TabControl>((p) => { return true; }, (p) =>
            {
                p.SelectedIndex = 0;
            });
            LoadTab1_2Command = new RelayCommand<TabControl>((p) => { return true; }, (p) =>
            {
                p.SelectedIndex = 1;
            });
            LoadTab1_3Command = new RelayCommand<TabControl>((p) => { return true; }, (p) =>
            {
                p.SelectedIndex = 2;
            });
            #endregion
            
            #region LoadTabsofTab6
            LoadTab6_1Command = new RelayCommand<TabControl>((p) => { return true; }, (p) =>
            {
                p.SelectedIndex = 0;
            });
            LoadTab6_2Command = new RelayCommand<TabControl>((p) => { return true; }, (p) =>
            {
                p.SelectedIndex = 1;
            });
            #endregion

        }
        #endregion

        //public void LoadDashboard(ListView p)
        //{
        //    BorrowDashboard dashboardlist = new BorrowDashboard();

        //    CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(p.ItemsSource);
        //    view.Filter = Fil;
        //    CollectionViewSource.GetDefaultView(p.ItemsSource).Refresh();
        //    SumBooks = ListBook.Count().ToString();
        //    SumReaders = ListReader.Count().ToString();
        //    SumBorrows = dashboardlist.Count.ToString();
        //}

        //bool Fil(object item)
        //{
        //    return ((item as Model.Reader).BookBorrowCount.IndexOf(id, StringComparison.OrdinalIgnoreCase) >= 0);
        //}

        public void EditReader(Reader reader, int whatClass)
        {
            reader.BookBorrowCount = 0;
            if (whatClass == 1)
            {
                reader.DisplayName = DisplayName_Reader;
                reader.IDGender = SelectedGender.ID;
                reader.Address = Address_Reader;
                reader.Email = Email_Reader;
                reader.PhoneNumber = PhoneNumber_Reader;
                reader.Facebook = Facebook_Reader;
                reader.MoreInfo = Moreinfo_Reader;
                foreach (var item in DataProvider.Ins.db.BookBorrows.Where(a => a.IDReader == reader.ID))
                {
                    reader.BookBorrowCount += (int)item.Count;
                }
                MessageBox.Show("Sửa độc giả thành công!", "Thông báo", MessageBoxButton.OK);
            }
            if (whatClass == 2)
            {
                foreach (var item in DataProvider.Ins.db.BookBorrows.Where(a => a.IDReader == reader.ID).ToList())
                {
                    reader.BookBorrowCount += (int)item.Count;
                }
                
            }
            else
            {
                reader.BookBorrowCount = 0;
            }
            DataProvider.Ins.db.SaveChanges();
        }
        #region String_to_base64_to_MD5
        public string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
        #endregion
    }

    #region SearchClass
    public class Search1
    {
        public string Ename { get; set; }
        public string Tname { get; set; }
    }

    public class Search2
    {
        public string Ename { get; set; }
        public string Tname { get; set; }
    }

    public class Search4
    {
        public string Ename { get; set; }
        public string Tname { get; set; }
    }
    public class Search5
    {
        public string Ename { get; set; }
        public string Tname { get; set; }
    }
    public class Search6
    {
        public string Ename { get; set; }
        public string Tname { get; set; }
    }
    public class Search7
    {
        public string Ename { get; set; }
        public string Tname { get; set; }
    }
    public class Search8
    {
        public string Ename { get; set; }
        public string Tname { get; set; }
    }
    public class Search9
    {
        public string Ename { get; set; }
        public string Tname { get; set; }
    }
    #endregion
}
