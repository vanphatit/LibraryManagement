using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibraryManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void ButtonOpenMenu3_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu3.Visibility = Visibility.Visible;
            ButtonOpenMenu3.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu3_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu3.Visibility = Visibility.Collapsed;
            ButtonOpenMenu3.Visibility = Visibility.Visible;
        }

        private void ButtonOpenMenu4_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu4.Visibility = Visibility.Visible;
            ButtonOpenMenu4.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu4_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu4.Visibility = Visibility.Collapsed;
            ButtonOpenMenu4.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);
            if (index == 0)
                return;
            index--;
            GridCursor.Background = Brushes.Yellow;
            GridCursor.Margin = new Thickness(65 + (160 * index), 0, 0, 0);
        }
    }
}
