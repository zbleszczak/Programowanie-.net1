using System.Windows;

namespace Zadanie_3
{
    public partial class AddWindow : Window
    {
        public Book NewBook { get; private set; }

        public AddWindow()
        {
            InitializeComponent();
            NewBook = new Book();
            DataContext = NewBook;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.BookList.Add(NewBook);
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