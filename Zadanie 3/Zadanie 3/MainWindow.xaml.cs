using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Xml.Serialization;




namespace Zadanie_3
{

    public partial class MainWindow : Window
    {
        public ObservableCollection<Book> BookList { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            BookList = new ObservableCollection<Book>();
            DataContext = this;
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.ShowDialog();
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedBook = BookListView.SelectedItem as Book;
            if (selectedBook != null)
            {
                var editWindow = new EditWindow(selectedBook);
                editWindow.ShowDialog();
            }
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedBooks = BookListView.SelectedItems.Cast<Book>().ToList();
            foreach (var book in selectedBooks)
            {
                BookList.Remove(book);
            }
        }

        private void ImportButton_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                var fileName = openFileDialog.FileName;
                var serializer = new XmlSerializer(typeof(ObservableCollection<Book>));

                using (var stream = new FileStream(fileName, FileMode.Open))
                {
                    var importedBooks = (ObservableCollection<Book>)serializer.Deserialize(stream);
                    BookList.Clear();
                    foreach (var book in importedBooks)
                    {
                        BookList.Add(book);
                    }
                }
            }
        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                var fileName = saveFileDialog.FileName;
                var serializer = new XmlSerializer(typeof(ObservableCollection<Book>));

                using (var stream = new FileStream(fileName, FileMode.Create))
                {
                    serializer.Serialize(stream, BookList);
                }
            }
        }
    }

    public class Book : INotifyPropertyChanged
    {
        private string title = string.Empty;
        private string author = string.Empty;
        private string publisher = string.Empty;
        private BookGenre genre;
        private int pageCount;
        private DateTime publicationDate;

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged();
            }
        }

        public string Author
        {
            get { return author; }
            set
            {
                author = value;
                OnPropertyChanged();
            }
        }

        public string Publisher
        {
            get { return publisher; }
            set
            {
                publisher = value;
                OnPropertyChanged();
            }
        }

        public BookGenre Genre
        {
            get { return genre; }
            set
            {
                genre = value;
                OnPropertyChanged();
            }
        }

        public int PageCount
        {
            get { return pageCount; }
            set
            {
                pageCount = value;
                OnPropertyChanged();
            }
        }

        public DateTime PublicationDate
        {
            get { return publicationDate; }
            set
            {
                publicationDate = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public enum BookGenre
    {
        Fantasy,
        ScienceFiction,
        Mystery,
        Thriller,
        Romance,
        Biography
    }
}