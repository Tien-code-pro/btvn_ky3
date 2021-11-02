using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai1.Models
{
    public class Car
    {
        public int CarId { get; set; }
        public string Category { get; set; }
        public string Model { get; set; }
        public string Image { get; set; }
    }
    public class CarManager
    {
        public static List<Car> GetCars()
        {
            var cars = new List<Car>();
            cars.Add(new Car { Category = "Honda", Model = "2014", Image = "Assets/Honda.png" });
            cars.Add(new Car { Category = "City", Model = "2008", Image = "Assets/City.png" });
            cars.Add(new Car { Category = "Ferrari", Model = "2010", Image = "Assets/Ferrari.png" });
            cars.Add(new Car { Category = "Toyota", Model = "2011", Image = "Assets/Toyota.png" });
            cars.Add(new Car { Category = "Mehran", Model = "2009", Image = "Assets/Mehran.png" });
            return cars;
        }
    }
}
