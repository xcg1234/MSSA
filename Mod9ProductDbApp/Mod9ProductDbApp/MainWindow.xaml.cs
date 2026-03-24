using Mod9ProductDbApp.Models;
using Mod9ProductDbApp.Services;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Mod9ProductDbApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ICRUD crud;
        private ObservableCollection<Book> books = new();

        public MainWindow(ICRUD _crud)
        {
            InitializeComponent();
            this.crud = _crud; // a ref is attached/created for the crud service
            LoadBooks();
        }

        private void LoadBooks()
        {
            books = new ObservableCollection<Book>(crud.GetBooks());
            BookGrid.ItemsSource = books;
        }

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            var book = new Book();
            books.Add(book);
            BookGrid.SelectedItem = book;
            BookGrid.ScrollIntoView(book);
        }

        private void SaveBooks_Click(object sender, RoutedEventArgs e)
        {
            BookGrid.CommitEdit(DataGridEditingUnit.Cell, true);
            BookGrid.CommitEdit(DataGridEditingUnit.Row, true);

            if (books.Any(b => string.IsNullOrWhiteSpace(b.ISBN)))
            {
                MessageBox.Show("Every book must have an ISBN.");
                return;
            }

            var duplicateIsbn = books
                .GroupBy(b => b.ISBN.Trim())
                .FirstOrDefault(g => g.Count() > 1);

            if (duplicateIsbn != null)
            {
                MessageBox.Show($"Duplicate ISBN found: {duplicateIsbn.Key}");
                return;
            }

            foreach (var book in books)
            {
                book.ISBN = book.ISBN.Trim();
                book.Name = book.Name?.Trim() ?? string.Empty;
                book.AuthorName = book.AuthorName?.Trim() ?? string.Empty;
                book.Description = book.Description?.Trim() ?? string.Empty;
                crud.UpsertBook(book);
            }

            LoadBooks();
        }

        private void DeleteBook_Click(object sender, RoutedEventArgs e)
        {
            if (BookGrid.SelectedItem is not Book selectedBook)
            {
                MessageBox.Show("Select a row to delete.");
                return;
            }

            if (!string.IsNullOrWhiteSpace(selectedBook.ISBN))
            {
                crud.DeleteBook(selectedBook.ISBN.Trim());
            }

            books.Remove(selectedBook);
        }

        private void RefreshBooks_Click(object sender, RoutedEventArgs e)
        {
            LoadBooks();
        }
    }
}