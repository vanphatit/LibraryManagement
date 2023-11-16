using LibraryManagement.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LibraryManagement.ViewModel
{
    public class RegisterViewModel : BaseViewModel
    {
        private ObservableCollection<Model.Gender> _ListGender;
        public ObservableCollection<Gender> ListGender { get => _ListGender; set { _ListGender = value; OnPropertyChanged(); } }

        private Gender _SelectedGender3;
        public Gender SelectedGender3 { get => _SelectedGender3; set { _SelectedGender3 = value; OnPropertyChanged(); } }

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

        #region InfoUser
        private string _DisplayName_User;
        public string DisplayName_User { get => _DisplayName_User; set { _DisplayName_User = value; OnPropertyChanged(); } }

        private string _UserName_User;
        public string UserName_User { get => _UserName_User; set { _UserName_User = value; OnPropertyChanged(); } }

        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }
        #endregion

        public ICommand PasswordChangedCommand { get; set; }

        public ICommand RegisterCommand { get; set; }

        public ICommand ExitCommand { get; set; }

        public RegisterViewModel()
        {
            ListUserRole = new ObservableCollection<Model.UserRole>(DataProvider.Ins.db.UserRoles);

            ListGender = new ObservableCollection<Gender>(DataProvider.Ins.db.Genders);

            RegisterCommand = new RelayCommand<Window>((p) => 
            {
                if (string.IsNullOrEmpty(UserName_User) || string.IsNullOrEmpty(DisplayName_User) || string.IsNullOrEmpty(Password))
                    return false;
                if (SelectedUserRole == null)
                    return false;
                return true;
            }, (p) =>
            {
                Register(p);
            });
            ExitCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { p.Close(); });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Password = p.Password; });

            void Register(Window p)
            {
                string passEncode = MD5Hash(Base64Encode(Password));
                var userlist = DataProvider.Ins.db.Users.Where(a => a.UserName == UserName_User);
                if(userlist == null || userlist.Count() == 0)
                {
                    var user = new User();
                    user.DisplayName = DisplayName_User;
                    user.IDGender = SelectedGender3.ID;
                    user.UserName = UserName_User;
                    user.Password = passEncode;
                    user.IDUserRoles = SelectedUserRole.ID;
                    DataProvider.Ins.db.Users.Add(user);
                    DataProvider.Ins.db.SaveChanges();
                    MessageBox.Show("Đăng ký tài khoản thành công!", "Thông báo", MessageBoxButton.OK);
                    p.Close();
                    MainWindow main = new MainWindow();
                    var mainvm = main.DataContext as MainViewModel;
                    mainvm.ListUser.Add(user);
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại, vui lòng nhập tên đăng nhập mới!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Stop);
                }
            }            
        }

        #region String_to_base64_to_MD5
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string MD5Hash(string input)
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
}
