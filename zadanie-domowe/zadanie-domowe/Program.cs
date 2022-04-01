using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie_domowe
{
    class Program
    {
        static void Main(string[] args)
        {
            Seller treacher = new Seller("Jan Kowalski", 50);

            Buyer buyer1 = new Buyer("Jaś Fasola 1", 25);
            Buyer buyer2 = new Buyer("Jaś Fasola 2", 21);
            Buyer buyer3 = new Buyer("Jaś Fasola 3", 23);

            buyer1.AddProduct(new Fruit("Apple", 6));
            buyer1.AddProduct(new Meat("Fish", 0.5));

            Person[] persons = { treacher, buyer1, buyer2, buyer3 };

            Product[] products = {
                new Fruit("Apple", 1000),
                new Fruit("Banana", 700),
                new Fruit("Orange", 500),
                new Meat("Fish", 100.0),
                new Meat("Beef", 75.0)
            };

            Shop shop = new Shop("Super Market", persons, products);

            shop.Print();
        }
    }

    interface IThing
    {
        public string Name { get; set; }
    }


    abstract class Product : IThing
    {
        protected string name;
        public string Name { get; set; }


        public Product(string name)
        {
            this.name = name;
        }

        public abstract void Print(string prefix);

    }

    abstract class Person : IThing
    {
        protected string name;
        protected int age;

        public string Name { get; set; }
        public string Age { get; set; }


        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public abstract void Print(string prefix);
    }

     class Buyer : Person
     {
        public Buyer(string name, int age) : base(name, age)
        {

        }

        protected List<Product> products = new List<Product>();
        public void AddProduct(Product product)
        {
            this.products.Add(product);
        }

        public void RemoveProduct(int index)
        {
            this.products.RemoveAt(index);
        }


        public override void Print(string prefix)
        {
            Console.WriteLine(prefix + "Buyer: " + this.name + " (" + this.age.ToString() + " y.o.)");
            if (products.Count > 0)
            {
                Console.WriteLine(prefix + "\tProducts:");
                foreach (var p in products)
                {
                    p.Print(prefix + "\t");
                }
            }
        }
    }

    class Seller : Person
    {
        public Seller(string name, int age) : base(name, age)
        {

        }

        public override void Print(string prefix)
        {
            Console.WriteLine(prefix + "Seller: " + this.name + " (" + this.age.ToString() + " y.o.)");
        }
    }

    class Fruit : Product
    {
        private int count;
        public int Count { get => this.count; }
        public Fruit(string name, int count) : base(name)
        {
            this.count = count;
        }

        public override void Print(string prefix)
        {
            Console.WriteLine(prefix + this.name + " (" + this.count + " " + "fruits) ");
        }
    }

    class Meat : Product
    {
        private double weight;

        public double Weight { get => this.weight; }

        public Meat(string name, int weight) : base(name)
        {
            this.weight = weight;
        }

        public override void Print(string prefix)
        {
            Console.WriteLine(prefix + this.name + " (" + this.weight + " kg)");
        }
    }

    class Shop
    {
        private string name;
        private Person[] people;
        private Product[] products;

        public string Name
        {
            get { return name; }
        }

        public Shop(string name, Person[] people, Product[] products)
        {
            this.name = name;
            this.people = people;
            this.products = products;
        }

        public void Print()
        {
            Console.WriteLine("Shop: " + this.name);

            Console.WriteLine("People");

            foreach (var p in people)
            {
                p.Print("\t");
            }

            Console.WriteLine("Products: ");

            foreach (var p in products)
            {
                p.Print("\t");
            }

        }
    }
}
