using System;
using System.Windows;

namespace Zadanie_3
{
    public partial class EditWindow : Window
    {
        private Book _selectedBook;

        public EditWindow(Book selectedBook)
        {
            InitializeComponent();
            _selectedBook = selectedBook;
            DataContext = _selectedBook;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Aktualizacja danych książki w kolekcji BookList
            var mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                var index = mainWindow.BookList.IndexOf(_selectedBook);
                if (index >= 0)
                {
                    mainWindow.BookList[index] = _selectedBook;
                }
            }
            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}