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
using WpfApp.Views;

namespace WpfApp {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        BookCatalogEntities _context = new BookCatalogEntities();
        public MainWindow() {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            
        }

        private void authorButton_Click(object sender, RoutedEventArgs e) {
            mainFrame.Navigate(new AuthorPage(_context));
        }

        private void bookButton_Click(object sender, RoutedEventArgs e) {
            mainFrame.Navigate(new BookPage(_context));

        }

        private void genreButton_Click(object sender, RoutedEventArgs e) {
            mainFrame.Navigate(new GenrePage(_context));
        }
    }
}
