using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegetes
{
   
    delegate bool compareDelegates<T>(T first, T second);
    class MyArray
    {
        public static void sort<T>(T[] arr, compareDelegates<T> func)
        {
            T temp;
            for(int i = 0; i < arr.Length; ++i)
            {
                for(int j = 0; j < arr.Length - 1 - i; ++j)
                {
                    if (!func(arr[j], arr[j + 1]))
                    {
                        temp = arr[j];
                        arr[j] = arr[j+1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        public static List<Product> setAllEquals(Storage storage1,Storage storage2, compareDelegates<Product> func) {
            List<Product> productList = new List<Product>();
            foreach(Product product in storage1)
            {
                foreach (Product product2 in storage2)
                {
                    if (func(product, product2))
                    {

                        productList.Add(product);
                    }

                }
               
            }
            return productList;
        }
        public static List<Product> noConsist(Storage storage1, Storage storage2, compareDelegates<Product> func)
        {
            List<Product> productList = new List<Product>();
            bool consist = false;
            foreach (Product product in storage1)
            {
               
                consist = false;
                foreach (Product product2 in storage2)
                {
                    
                    if (!func(product, product2))
                    {
                        consist = true;
                    }

                }
                if (!consist)
                {
                    productList.Add(product);
                }

            }
            return productList;
        }
        public static List<Product> getDifferent(Storage storage1, Storage storage2, compareDelegates<Product> func)
        {
            List<Product> productList = new List<Product>();
            productList.AddRange(MyArray.noConsist(storage1, storage2,(x,y)=>x.name!=y.name));
            productList.AddRange(MyArray.noConsist(storage2, storage1, (x, y) => x.name != y.name));

            return productList;
        }


    }

    
}
