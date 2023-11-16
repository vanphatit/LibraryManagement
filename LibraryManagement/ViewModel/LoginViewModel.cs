using LibraryManagement.Model;
using LibraryManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LibraryManagement.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public ICommand Dang_nhapCommand { get; set; }
        public ICommand ThoatCommand { get; set; }
        private string _UserName;
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }
        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }
        public ICommand PasswordChangedCommand { get; set; }
        public bool IsLogin { get; set; }
        public ICommand FaceBookRequest { get; set; }
        public ICommand MoveWindowCommand { get; set; }

        public LoginViewModel()
        {
            UserName = "";
            Password = "";
            IsLogin = false;
            Dang_nhapCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                Login(p);
            });
            FaceBookRequest = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                Process.Start("https://www.facebook.com/vanphatit");
            });
            ThoatCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { p.Close(); });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Password = p.Password; });
            MoveWindowCommand = new RelayCommand<Window>((p) => { return p == null ? false : true; }, (p) =>
            {
                if (p != null)
                {
                    p.DragMove();
                }
            });
        }

        void Login(Window p)
        {
            if (p == null)
                return;

            var PassEncode = MD5Hash(Base64Encode(Password));
            var account = DataProvider.Ins.db.Users.Where(a => a.UserName == UserName && a.Password == PassEncode);
            if (account.Count() > 0)
            {
                string filepath = Directory.GetCurrentDirectory() + "\\login.txt";
                if (Directory.Exists(filepath) == true)
                {
                    Directory.Delete(filepath);
                }
                FileStream stream = new FileStream(filepath, FileMode.Create);
                StreamWriter filelog = new StreamWriter(stream, Encoding.UTF8);
                filelog.Write(account.First().DisplayName);
                filelog.Flush();
                filelog.Close();
                stream.Close();
                IsLogin = true;
                p.Close();
            }
            else
            {
                IsLogin = false;
                MessageBox.Show("Sai tài khoản và mật khẩu!");
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
