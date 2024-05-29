using System.Windows;
using System.Xml.Linq;

namespace Zadanie4
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            XDocument doc = XDocument.Load("data.xml");
            var categories = doc.Root.Elements("Category")
                .Select(c => new Category
                {
                    Name = c.Attribute("Name").Value,
                    Description = c.Attribute("Description").Value,
                    Subcategories = c.Elements("Subcategory")
                        .Select(s => new Subcategory
                        {
                            Name = s.Attribute("Name").Value,
                            Description = s.Attribute("Description").Value,
                            Country = s.Attribute("Country").Value,
                            FoundingYear = int.Parse(s.Attribute("FoundingYear").Value),
                            Vehicles = s.Elements("Vehicle")
                                .Select(v => new Vehicle
                                {
                                    Name = v.Attribute("Name").Value,
                                    Year = int.Parse(v.Attribute("Year").Value),
                                    EngineCapacity = v.Attribute("EngineCapacity").Value,
                                    DriveType = v.Attribute("DriveType").Value
                                }).ToList()
                        }).ToList()
                }).ToList();

            categoryListBox.ItemsSource = categories;
        }

        private void CategoryListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var selectedCategory = (Category)categoryListBox.SelectedItem;
            if (selectedCategory != null)
            {
                var subcategoryWindow = new SubcategoryWindow(selectedCategory);
                subcategoryWindow.Show();
            }
        }
    }
}