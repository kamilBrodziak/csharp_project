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
    /// Interaction logic for AuthorAddPage.xaml
    /// </summary>
    public partial class AuthorAddPage : Page {
        CollectionViewSource _viewSource;
        BookCatalogEntities _context = new BookCatalogEntities();
        public AuthorAddPage() {
            InitializeComponent();
        }

        private void PageLoaded(object sender, RoutedEventArgs e) {
            _viewSource.Source = _context.Authors.Local;
        }

        private void addAuthorButton_Click(object sender, RoutedEventArgs e) {
            saveInfo.Text = "";
            if(lastNameTextBox.Text == "" || firstNameTextBox.Text == "") {
                saveInfo.Text = "First and last name must be specified!";
                return;
            }
            Author author = new Author {
                Email = emailTextBox.Text,
                FirstName = firstNameTextBox.Text,
                LastName = lastNameTextBox.Text
            };
            try {
                _context.Authors.Add(author);
                _context.SaveChanges();
                saveInfo.Text = "Succesfully added";
            } catch(Exception ex) {
                saveInfo.Text = ex.Message;
            }
        }
    }
}
