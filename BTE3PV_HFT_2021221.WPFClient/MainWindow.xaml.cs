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

namespace BTE3PV_HFT_2021221.WPFClient
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BookWindow Bookw = new BookWindow();
            Bookw.ShowDialog(); 
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AuthorWindow AuthorWindow = new AuthorWindow();
            AuthorWindow.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PublisherWindow publisherWindow = new PublisherWindow();
            publisherWindow.ShowDialog();
        }
    }
}
