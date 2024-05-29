using System.Windows;

namespace Zadanie4
{
    public partial class VehicleWindow : Window
    {
        public Subcategory Subcategory { get; set; }

        public VehicleWindow(Subcategory subcategory)
        {
            InitializeComponent();
            Subcategory = subcategory;
            DataContext = this;
        }

    }
}