using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Tuple
            #region Reference Tuple - max 8 item
            //Tuple<int, string> tuple = new Tuple<int, string>(1, "Mehemmed");
            //var person = Tuple.Create(1, "Iki", true,4,5,6,7,Tuple.Create(1,2,3));
            //Console.WriteLine(person.Rest.Item1.Item3);
            #endregion
            #region ValueTuple
            //ValueTuple<int, string, string> person = (1, "Bill", "Gates");
            //(int, string, string) person = (1, "Bill", "Gates");
            //Console.WriteLine(person.Item1);
            //(int Id, string FirstName, string LastName) person = (1, "Kamran", "Jabiyev");
            //Console.WriteLine(person.Id);
            //var person = (Id: 1, FirstName: "Kamran", LastName: "Jabiyev");
            //Console.WriteLine(person.FirstName);
            #endregion
            #endregion

            #region SOLID
            #region Liskov substitution
            Fruit orange = new Orange();
            #endregion

            #region Dependency Injection
            //Client client = new Client();
            //Product product = new Product();
            //product.GetProductData();
            //client.GetClientData();
            Service service = new Service();
            service.client.GetClientData();
            service.product.GetProductData();
            #endregion
            #endregion
        }
    }

    #region SOLID
    #region Single representation
    class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Group Group { get; set; }
    }

    class Group
    {
        public string Name { get; set; }
        public string GetGroup()
        {
            return Name;
        } 
    }
    #endregion
    #region Open/Close
    public enum InvoiceType { StartInvoice,FinalInvoice,AddInvoice}

    class Invoice
    {
        public virtual void GetPrice()
        {
            Console.WriteLine("Discount - 30%");
        }
    }

    class FinalInvoice: Invoice
    {
        public override void GetPrice()
        {
            Console.WriteLine("Discount - 40%");
        }
    }

    class AddInvoice : Invoice
    {
        public override void GetPrice()
        {
            Console.WriteLine("Discount - 43%");
        }
    }

    //class Invoice
    //{
    //    public void GetPrice(int n)
    //    {
    //        switch (n)
    //        {
    //            case (int)InvoiceType.StartInvoice:
    //                Console.WriteLine("Discount - 30%");
    //                break;
    //            case (int)InvoiceType.FinalInvoice:
    //                Console.WriteLine("Discount - 40%");
    //                break;
    //            case (int)InvoiceType.AddInvoice:
    //                Console.WriteLine("Discount - 41%");
    //                break;
    //            default:
    //                break;
    //        }
    //    }
    //}
    #endregion
    #region Liskov substitution
    abstract class Fruit
    {
        public abstract void Tasty();
    }
    class Apple : Fruit
    {
        public override void Tasty()
        {
            Console.WriteLine("As Apple");
        }
    }

    class Orange:Fruit
    {
        public override void Tasty()
        {
            Console.WriteLine("As Orange");
        }
    }
    #endregion
    #region Interface Segregation
    interface ISum
    {
        int Sum();
    }

    interface IDifference
    {
        int Difference();
    }

    interface IDivide
    {
        double Divide();
    }

    class Calculate : ISum,IDifference,IDivide
    {
        public int Difference()
        {
            throw new NotImplementedException();
        }

        public double Divide()
        {
            throw new NotImplementedException();
        }

        public int Sum()
        {
            throw new NotImplementedException();
        }
    }

    class Test : IDifference
    {
        public int Difference()
        {
            throw new NotImplementedException();
        }
    }
    #endregion
    #region Dependency Injection
    interface IDatabase
    {
        void GetData(string str);
    }
    class Database : IDatabase
    {
        public void GetData(string str)
        {
            Console.WriteLine(str);
        }
    }

    class Service
    {
        public Client client;
        public Product product;

        public Service()
        {
            Database context = new Database();
            client = new Client(context);
            product = new Product(context);
        }
    }

    class Client
    {
        private readonly IDatabase _context;
        public Client(IDatabase context)
        {
            _context = context;
        }

        public void GetClientData()
        {
            _context.GetData("Client data");
        }
    }

    class Product
    {
        private readonly IDatabase _context;
        public Product(IDatabase context)
        {
            _context = context;
        }

        public void GetProductData()
        {
            _context.GetData("Product data");
        }
    }

    
    #endregion
    #endregion
}
