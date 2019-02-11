using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace LinqTraining
{
    public class Product_Feature
    {
        public class Product
        {
            public string Name { get; set; }
            public ICollection<Feature> Features { get; set; }
        }

        public class Feature
        {
            public int Id { get; set; }
        }

        static void Main11(string[] args)
        {
            var products = new List<Product>
            {
               {new Product { Name = "Laptop", Features = new List<Feature> { new Feature { Id = 11 }, new Feature { Id = 22 }, new Feature { Id = 33 }, new Feature { Id = 44 } } } },
               {new Product { Name = "Mousse", Features = new List<Feature> { new Feature { Id = 22 }, new Feature { Id = 33 }, new Feature { Id = 11 }, new Feature { Id = 12 } } } },
               {new Product { Name = "Keyboard", Features = new List<Feature> { new Feature { Id = 12 }, new Feature { Id = 12 }, new Feature { Id = 12 }, new Feature { Id = 12 } } } },
               {new Product { Name = "Monitor", Features = new List<Feature> { new Feature { Id = 11 }, new Feature { Id = 22 }, new Feature { Id = 33 }, new Feature { Id = 44} } } },
               {new Product { Name = "Webcam", Features = new List<Feature> { new Feature { Id = 22}, new Feature { Id = 1}, new Feature { Id = 1 }, new Feature { Id = 1 } } } },
               {new Product { Name = "Iphone", Features = new List<Feature> { new Feature { Id = 12 }, new Feature { Id = 12 }, new Feature { Id = 12 }, new Feature { Id = 12 } } } },
               {new Product { Name = "Headset", Features = new List<Feature> { new Feature { Id = 12 }, new Feature { Id = 12 }, new Feature { Id = 22 }, new Feature { Id = 12 } } } },
               {new Product { Name = "Joystick", Features = new List<Feature> { new Feature { Id = 12 }, new Feature { Id = 44 }, new Feature { Id = 12 }, new Feature { Id = 12 } } } },
               {new Product { Name = "MousePad", Features = new List<Feature> { new Feature { Id = 12 }, new Feature { Id = 12 }, new Feature { Id = 12 }, new Feature { Id = 12 } } } }
            };

            var features = new List<Feature>
            {
                {new Feature{ Id=11}},
                {new Feature{ Id=22}},
                {new Feature{ Id=33}},
                {new Feature{ Id=44}},

            };

            var firstQuery = products.Where(product => product.Features.Any(p => features.Any(f => f.Id == p.Id)));

            var secondQuery = products.Where(product => features.All(p => product.Features.Any(f => f.Id == p.Id)));

            var thirdQuery = products.Where(product => !product.Features.Any(p => features.Any(f => f.Id == p.Id)));

        }
    }
}
