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
    /// Interaction logic for GenreDetailsPage.xaml
    /// </summary>
    public partial class GenreDetailsPage : Page {
        BookCatalogEntities _context = new BookCatalogEntities();
        CollectionViewSource _viewSource;
        int _id;
        Genre _genre;
        public GenreDetailsPage(int id) {
            _id = id;
            InitializeComponent();
            _viewSource = ((CollectionViewSource)(FindResource("genreViewSource")));
        }

        private void PageLoaded(object sender, RoutedEventArgs e) {
            _context.Genres.Where(a => a.ID == _id).Load();
            _viewSource.Source = _context.Genres.Local;
            _genre = _context.Genres.SingleOrDefault(a => a.ID == _id);

        }

        private void saveGenreButton_Click(object sender, RoutedEventArgs e) {
            saveInfo.Text = "";
            _genre.Name = nameTextBox.Text;
            _context.SaveChanges();
            saveInfo.Text = "Successfuly saved.";
        }

        private void deleteGenreButton_Click(object sender, RoutedEventArgs e) {
            _context.Genres.Remove(_genre);
            _context.SaveChanges();
            this.NavigationService.Navigate(new GenrePage());
        }
    }
}
