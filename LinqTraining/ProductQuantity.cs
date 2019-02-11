using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LinqTraining
{

    class ProductQuantity
    {
        struct Product
        {
            public string Name;
            public int Quantity;
        }


        static void Main(string[] args)
        {
            List<Product> first = new List<Product> {

         { new Product { Name = "Laptop",Quantity=1 } },
         {new Product { Name = "Mousse",Quantity=1 } },
         {new Product { Name = "Keyboard",Quantity=1 } },
         {new Product { Name = "Monitor",Quantity=1 } },
         {new Product { Name = "Webcam",Quantity=1 } },
         {new Product { Name = "Iphone",Quantity=1 } },
         {new Product { Name = "Headset",Quantity=1 } },
         {new Product { Name = "Joystick",Quantity=1 } },
         {new Product { Name = "MousePad",Quantity=1 } }
         };

            List<Product> second = new List<Product> {

         { new Product { Name = "Laptop",Quantity=1 } },
         {new Product { Name = "Mousse",Quantity=1 } },
         {new Product { Name = "Keyboard",Quantity=1 } },
         {new Product { Name = "Socket",Quantity=1 } },
         {new Product { Name = "Webcam",Quantity=1 } },
         {new Product { Name = "Cable",Quantity=1 } },
         {new Product { Name = "Headset",Quantity=1 } },
         {new Product { Name = "Lightbulb",Quantity=1 } },
         {new Product { Name = "MousePad",Quantity=1 } }
         };

           
            IEnumerable<Product> firstList = from f in first
                                             select second.Any(s=>s.Name==f.Name) ?
                                             new Product { Quantity = second.First(s => s.Name == f.Name).Quantity + f.Quantity, Name = f.Name } : f;


            IEnumerable<Product> result = firstList.Concat( second.Except(first));
            foreach(var  element in result)
                Console.WriteLine($"{element.Name},{element.Quantity}");
            Console.Read();

        }
    }
}
