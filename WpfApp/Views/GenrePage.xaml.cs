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
    /// Interaction logic for GenrePage.xaml
    /// </summary>
    public partial class GenrePage : Page {
        CollectionViewSource _viewSource;
        BookCatalogEntities _context = new BookCatalogEntities();
        public GenrePage() {
            InitializeComponent();
            _viewSource = ((CollectionViewSource)(FindResource("genreViewSource")));
        }

        private void PageLoaded(object sender, RoutedEventArgs e) {
            _context.Genres.Load();
            _viewSource.Source = _context.Genres.Local;
        }
    }
}
