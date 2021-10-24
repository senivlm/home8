using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace delegetes
{
    class Storage : IEnumerable
    {

        Product[] arrProduct;
        public int capacity { get; private set; } = 0;
        public int size { get; private set; } = 0;

        public Storage(int size)
        {
            arrProduct = new Product[size];
            for (int i = 0; i < size; i++)
            {
                arrProduct[i] = new Product();
            }
           
            capacity = size;
        }
        public Product this[int index]
        {

            get => arrProduct[index];
            set => arrProduct[index] = value;
        }


        public void changeCost(double percent)
        {
            foreach (Product a in arrProduct)
            {
                a.changeCost(percent);
            }
        }
        public override string ToString()
        {
            string value = "";
            /*  for (int i = 0; i < arrProduct.Length; i++)
              {
                  value += arrProduct[i];
              }*/
            foreach (Product a in arrProduct)
            {
                value += a;
            }
            return value;
        }
        public void getInfo()
        {
            for (int i = 0; i < arrProduct.Length; i++)
            {
                Console.WriteLine($"Poduct №{i + 1}Enter the name product\t");
                arrProduct[i].name = Console.ReadLine();
                Console.WriteLine("Enter the cost of  product\t");
                arrProduct[i].Cost = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter the weight of  product\t");
                arrProduct[i].weight = Convert.ToDouble(Console.ReadLine());

            }
        }
        public void deleteExpireDairyProduct()
        {
            DateTime currentDate = DateTime.Now;
            int amount = 0;
            Product[] temp = new Product[arrProduct.Length];
            for (int i = 0; i < size; i++)
            {
                if (arrProduct[i].manufactureDate + arrProduct[i].expireDays > currentDate)
                {
                    temp[amount] = arrProduct[i];
                    ++amount;
                }
            }
            arrProduct = new Product[amount];
            for (int i = 0; i < amount; i++)
            {

                arrProduct[i] = temp[i];
            }
            size = amount;

        }
        public void readFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                string[] lines = File.ReadAllLines(fileName);


                for (int i = 0, j = 0; j < arrProduct.Length && i < lines.Length; i++)
                {
                    try
                    {
                        arrProduct[j].Parse(lines[i]);
                        size++;
                        ++j;
                    }
                    catch (Exception ex)
                    {
                        // throw;
                        Console.WriteLine(ex.Message);

                    }
                }
            }
        }
        public Product getModa()
        {

            int[] arrFreq = new int[arrProduct.Length];
            Product[] diference = new Product[arrProduct.Length];
            int count = 0;
            for (int i = 0; i < arrProduct.Length; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    if (arrProduct[i].Cost == diference[j].Cost)
                    {
                        arrFreq[j]++;
                    }
                    else if (j + 1 == count)
                    {
                        diference[j + 1] = arrProduct[i];
                        ++count;
                    }
                }
            }
            int max = arrFreq[0];
            int index = 0;
            for (int i = 0; i < count; i++)
            {
                if (max < arrFreq[i])
                {
                    max = arrFreq[i];
                    index = i;
                }
            }
            return diference[index];


        }
        public IEnumerator GetEnumerator()
        {
            return new Enumerator(this);
        }
        class Enumerator : IEnumerator<Product>
        {
            int position = -1;
            int size;
            Product[] products;

            public Enumerator(Storage storage)
            {
                this.products = storage.arrProduct;
                size = storage.size;
            }
            public Product Current => products[position];

            object IEnumerator.Current => products[position];

            public void Dispose()
            {

            }

            public bool MoveNext()
            {
                if (position + 1 <size)
                {
                    position += 1;
                    return true;
                }
                return false;

            }

            public void Reset()
            {
                position = -1;
            }
        }

        
    }
}
