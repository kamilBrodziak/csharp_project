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
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;
using WpfApp.Models;

namespace WpfApp.Views {
    /// <summary>
    /// Interaction logic for BookDetailsPage.xaml
    /// </summary>
    public partial class BookDetailsPage : Page {
        BookCatalogEntities _context = new BookCatalogEntities();
        CollectionViewSource _viewSource;
        CollectionViewSource _genreViewSource;
        CollectionViewSource _authorViewSource;
        List<Selection> _genres;
        List<Selection> _authors;
        int _id;
        Book _book;

        public BookDetailsPage(int id) {
            _id = id;
            InitializeComponent();
            _viewSource = ((CollectionViewSource)(FindResource("bookViewSource")));
            _genreViewSource = ((CollectionViewSource)(FindResource("genresViewSource")));
            _authorViewSource = ((CollectionViewSource)(FindResource("authorsViewSource")));
        }

        private void PageLoaded(object sender, RoutedEventArgs e) {
            _context.Books.Where(a => a.ID == _id).Load();
            _viewSource.Source = _context.Books.Local;
            _book = _context.Books.SingleOrDefault(a => a.ID == _id);
            _context.Genres.Load();
            _genres = _context.Genres.Local
                .Select(g => new Selection {
                    ID = g.ID,
                    Name = g.Name,
                    Checked = _book.Genres.Any(h => h.ID == g.ID)
                }).ToList();
            _context.Authors.Load();
            _authors = _context.Authors.Local
                .Select(g => new Selection {
                    ID = g.ID,
                    Name = $"{g.FirstName} {g.LastName}",
                    Checked = _book.Authors.Any(h => h.ID == g.ID)
                }).ToList();
            _genreViewSource.Source = _genres;
            _authorViewSource.Source = _authors;
            authorsSelection.SelectedIndex = -1;
            genresSelection.SelectedIndex = -1;
        }

        private void genresChecked(object sender, RoutedEventArgs e) {
            int id = (int)((CheckBox)sender).Tag;
            _genres.FirstOrDefault(g => g.ID == id).Check();
        }

        private void genresUnchecked(object sender, RoutedEventArgs e) {
            int id = (int)((CheckBox)sender).Tag;
            _genres.FirstOrDefault(g => g.ID == id).UnCheck();
        }

        private void authorsChecked(object sender, RoutedEventArgs e) {
            int id = (int)((CheckBox)sender).Tag;
            _authors.FirstOrDefault(g => g.ID == id).Check();
        }

        private void authorsUnchecked(object sender, RoutedEventArgs e) {
            int id = (int)((CheckBox)sender).Tag;
            _authors.FirstOrDefault(g => g.ID == id).UnCheck();
        }

        private void saveBookButton_Click(object sender, RoutedEventArgs e) {
            saveInfo.Text = "";
            if(titleTextBox.Text == "") {
                saveInfo.Text = "Title cannot be empty!";
                return;
            }
            if(!Regex.IsMatch(pagesTextBox.Text, @"^[0-9]{0,5}$")) {
                saveInfo.Text = "Pages must be a number or null, bellow 32,767";
                return;
            }
            if(!Regex.IsMatch(priceTextBox.Text, @"^[0-9]*(.[0-9]{1,2})?$")) {
                saveInfo.Text = "Price must be a number or null";
                return;
            }
            _book.Title = titleTextBox.Text;
            _book.Pages = short.Parse(pagesTextBox.Text);
            _book.Price = decimal.Parse(priceTextBox.Text);
            _book.ReleaseDate = releaseDateDatePicker.SelectedDate;
            _context.Genres.Load();
            _context.Authors.Load();
            _book.Genres.Clear();
            foreach(var g in _genres.Where(x => x.Checked)) {
                _book.Genres.Add(_context.Genres.Where(h => h.ID == g.ID).FirstOrDefault());
            }
            _book.Authors.Clear();
            foreach(var g in _authors.Where(x => x.Checked)) {
                _book.Authors.Add(_context.Authors.Where(h => h.ID == g.ID).FirstOrDefault());
            }

            try {
                _context.SaveChanges();
                saveInfo.Text = "Save was successful";
            } catch(Exception ex) {
                saveInfo.Text = ex.Message;
            }
        }

        private void deleteBookButton_Click(object sender, RoutedEventArgs e) {
            _context.Books.Remove(_book);
            _context.SaveChanges();
            this.NavigationService.Navigate(new GenrePage());
        }
    }
    public class Selection : IEquatable<Genre>, IEquatable<Author> {
        public int ID { get; set; }
        public bool Checked { get; set; }
        public string Name { get; set; }

        public void Check() {
            Checked = true;
        }

        public void UnCheck() {
            Checked = false;
        }

        public bool Equals(Genre other) => ID == other.ID;
        public bool Equals(Author other) => ID == other.ID;

    }
}
