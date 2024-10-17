using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace A_program_for_bookkeeping
{
    public partial class MainWindow : Window
    {
        private List<Book> books; // Хранит все книги
        private BookRepository bookRepository = new BookRepository();

        public MainWindow()
        {
            InitializeComponent();
            LoadBooks();
        }

        private void LoadBooks()
        {
            books = bookRepository.LoadBooks();
            BooksDataGrid.ItemsSource = books;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string titleFilter = TitleFilterTextBox.Text.ToLower().Trim();
            string authorFilter = AuthorFilterTextBox.Text.ToLower().Trim();

            // Фильтрация книг по названию или автору
            var filteredBooks = books.FindAll(book =>
                (string.IsNullOrEmpty(titleFilter) || book.Title.ToLower().Contains(titleFilter)) ||
                (string.IsNullOrEmpty(authorFilter) || book.Author.ToLower().Contains(authorFilter))
            );

            BooksDataGrid.ItemsSource = filteredBooks;
        }


        private void RemovePlaceholderText(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text == "Filter by Title" || textBox.Text == "Filter by Author")
            {
                textBox.Text = "";
            }
        }

        private void AddPlaceholderText(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrEmpty(textBox.Text))
            {
                if (textBox.Name == "TitleFilterTextBox")
                    textBox.Text = "Filter by Title";
                else if (textBox.Name == "AuthorFilterTextBox")
                    textBox.Text = "Filter by Author";
            }
        }
    }
}
