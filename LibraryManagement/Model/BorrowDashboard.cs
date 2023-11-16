using LibraryManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Model
{
    public class BorrowDashboard : BaseViewModel
    {
        private int _STT;
        public int STT { get => _STT; set { _STT = value; OnPropertyChanged(); } }

        private string _Displayname;
        public string Displayname { get => _Displayname; set { _Displayname = value; OnPropertyChanged(); } }

        private int? _Count;
        public int? Count { get => _Count; set { _Count = value; OnPropertyChanged(); } }
    }
}
