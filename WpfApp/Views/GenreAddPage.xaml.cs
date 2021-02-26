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
    /// Interaction logic for GenreAddPage.xaml
    /// </summary>
    public partial class GenreAddPage : Page {
        BookCatalogEntities _context = new BookCatalogEntities();
        public GenreAddPage() {
            InitializeComponent();
        }

        private void addGenreButton_Click(object sender, RoutedEventArgs e) {
            saveInfo.Text = "";
            if(nameTextBox.Text == "") {
                saveInfo.Text = "Name must be specified!";
                return;
            }
            Genre genre = new Genre {
                Name = nameTextBox.Text
            };
            try {
                _context.Genres.Add(genre);
                _context.SaveChanges();
                saveInfo.Text = "Succesfully added";
            } catch(Exception ex) {
                saveInfo.Text = ex.Message;
            }
        }
    }
}
