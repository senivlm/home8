using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegetes
{
    delegate void GetMessage();

    class Program
    {
        static void Main(string[] args)
        {/*
            Product[] arr = new Product[] { new Product("milk", 23.4, 1.0, new DateTime(2021, 10, 21), new TimeSpan(25,0,0,0)),
                 new Product("bread", 20.4, 1.0, new DateTime(2021, 10, 20), new TimeSpan(7,0,0,0)),
                 new Product("eggs", 37.8, 10.0, new DateTime(2021, 10, 8), new TimeSpan(40,0,0,0)),
                 new Product("kit-kat", 17, 1.0, new DateTime(2021, 08, 12), new TimeSpan(365,0,0,0)),
                 new Product("sunflower oil", 67.4, 1.0, new DateTime(2021, 09, 10), new TimeSpan(365,0,0,0))

            };
           
         //   MyArray.sort<Product>(arr, (x,y)=>x.expireDays < y.expireDays);
            foreach (Product a in arr)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine("------------------------------------------------------------------------------------------------");
           
             MyArray.sort<Product>(arr, (x, y) => x>y);
            
            foreach (Product a in arr)
            {
                Console.WriteLine(a);
            }
            Storage storage1 = new Storage(5);
            storage1.readFromFile(@"C:\Users\Надія\Desktop\Sigma c#\projects\home1\home1\bin\Debug\ProductsList.txt");

            Storage storage2 = new Storage(3);
            storage2.readFromFile(@"C:\Users\Надія\Desktop\Sigma c#\projects\home1\home1\bin\Debug\productList2.txt");
            foreach (Product a in storage1)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine("storage2------------------------------------------------------------------------------------------------");
            foreach (Product a in storage2)
            {
                Console.WriteLine(a);
            }
            var listProd = MyArray.setAllEquals(storage1, storage2, (x, y)=>x.name==y.name);
            Console.WriteLine("listProd (x, y)=>x==y)------------------------------------------------------------------------------------------------");
            foreach (Product a in listProd)
            {
                Console.WriteLine(a);
            }
            listProd = MyArray.noConsist(storage1, storage2, (x, y) => x.name != y.name);
            Console.WriteLine("listProd (x, y) => x != y------------------------------------------------------------------------------------------------");
            foreach (Product a in listProd)
            {
                Console.WriteLine(a);
            }
            listProd = MyArray.getDifferent(storage1, storage2, (x, y) => x.name != y.name);
            Console.WriteLine("listProd different------------------------------------------------------------------------------------------------");
            foreach (Product a in listProd)
            {
                Console.WriteLine(a);
            }*/
            string[] sorted;
            string maxCountBracketStr=String.Empty;
            List<string> listStr=StringOperations.getMaxBrackets(new string[] { "fdfsd.dsfdjfsjk(dfsdf).fsfsdf.",
                "sdfsdf(()ffdfsdfd).kdj(dlkfsj(","asdk(dfskldfksj(fsf(sfdfs))dk))ks)." },ref maxCountBracketStr);
            sorted = listStr.ToArray();
            MyArray.sort<string>(sorted, (x, y) => x.Length > y.Length);

            Console.WriteLine(maxCountBracketStr);
            foreach(string s in sorted)
            {
                Console.WriteLine(s);
            }

        }
       static bool cmp(int x1,int x2)
       {
            return x1 < x2;
       }
    }
    

}
