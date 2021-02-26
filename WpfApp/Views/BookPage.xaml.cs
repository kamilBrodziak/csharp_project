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
using System.Data.Entity;

namespace WpfApp.Views {
    /// <summary>
    /// Interaction logic for BookPage.xaml
    /// </summary>
    public partial class BookPage : Page {
        CollectionViewSource _viewSource;
        BookCatalogEntities _context;
        public BookPage(BookCatalogEntities context) {
            InitializeComponent();
            _context = context;
            _viewSource = ((CollectionViewSource)(FindResource("bookViewSource")));
        }

        private void PageLoaded(object sender, RoutedEventArgs e) {
            _context.Books.Load();
            _viewSource.Source = _context.Books.Local;
        }
    }
}
