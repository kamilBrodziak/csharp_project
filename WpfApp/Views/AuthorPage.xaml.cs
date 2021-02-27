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
using WpfApp.Models;

namespace WpfApp.Views {
    /// <summary>
    /// Interaction logic for AuthorPage.xaml
    /// </summary>
    public partial class AuthorPage : Page {
        CollectionViewSource _viewSource;
        BookCatalogEntities _context = new BookCatalogEntities();
        public AuthorPage() {
            InitializeComponent();
            _viewSource = ((CollectionViewSource)(FindResource("authorViewSource")));
        }

        private void PageLoaded(object sender, RoutedEventArgs e) {
            _context.Authors.Load();
            _viewSource.Source = _context.Authors.Local;
        }

        private void addAuthorButton_Click(object sender, RoutedEventArgs e) {
            this.NavigationService.Navigate(new AuthorAddPage());
        }

        private void detailsButton_Click(object sender, RoutedEventArgs e) {
            int id = (int)((Button)sender).DataContext;
            this.NavigationService.Navigate(new AuthorDetailsPage(id));
        }
    }
}
