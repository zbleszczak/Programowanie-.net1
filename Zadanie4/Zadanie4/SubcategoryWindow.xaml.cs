using System.Windows;

namespace Zadanie4
{
    public partial class SubcategoryWindow : Window
    {
        public Category Category { get; set; }

        public SubcategoryWindow(Category category)
        {
            InitializeComponent();
            Category = category;
            DataContext = this;
            subcategoryListBox.ItemsSource = category.Subcategories;
        }

        private void SubcategoryListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var selectedSubcategory = (Subcategory)subcategoryListBox.SelectedItem;
            if (selectedSubcategory != null)
            {
                var vehicleWindow = new VehicleWindow(selectedSubcategory);
                vehicleWindow.Show();
            }
        }
    }
}