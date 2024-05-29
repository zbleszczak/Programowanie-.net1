using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie4
{
    public class Category
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Subcategory> Subcategories { get; set; }
    }

    public class Subcategory
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public int FoundingYear { get; set; }
        public List<Vehicle> Vehicles { get; set; }
    }

    public class Vehicle
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public string EngineCapacity { get; set; }
        public string DriveType { get; set; }
    }
}
