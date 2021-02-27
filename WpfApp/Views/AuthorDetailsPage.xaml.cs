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
    /// Interaction logic for AuthorDetailsPage.xaml
    /// </summary>
    public partial class AuthorDetailsPage : Page {
        BookCatalogEntities _context = new BookCatalogEntities();
        CollectionViewSource _viewSource;
        int _id;
        Author _author;
        public AuthorDetailsPage(int id) {
            _id = id;
            InitializeComponent();
            _viewSource = ((CollectionViewSource)(FindResource("authorViewSource")));
        }

        private void PageLoaded(object sender, RoutedEventArgs e) {
            _context.Authors.Where(a => a.ID == _id).Load();
            _viewSource.Source = _context.Authors.Local;
            _author = _context.Authors.SingleOrDefault(a => a.ID == _id);

        }

        private void saveAuthorButton_Click(object sender, RoutedEventArgs e) {
            saveInfo.Text = "";
            _author.FirstName = firstNameTextBox.Text;
            _author.LastName = lastNameTextBox.Text;
            _author.Email = emailTextBox.Text;
            _context.SaveChanges();
            saveInfo.Text = "Successfuly saved.";
        }

        private void deleteAuthorButton_Click(object sender, RoutedEventArgs e) {
            _context.Authors.Remove(_author);
            _context.SaveChanges();
            this.NavigationService.Navigate(new AuthorPage());
        }
    }
}
