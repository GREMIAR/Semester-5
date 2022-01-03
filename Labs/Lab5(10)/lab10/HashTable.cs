using System;
using System.Collections.Generic;

namespace lab10
{

    delegate void HashFunction(int item);

    class HashTable
    {
        public Item[] items;

        public HashTable()
        {
            NewHashFunction(0);
        }

        public void SwitchTypeHash(HashFunction hashFunction, List<int> list)
        {
            NewHashFunction(list.Count);
            foreach (int item in list)
            {
                hashFunction(item);
            }
        }

        void NewHashFunction(int size)
        {
            items = new Item[1000];
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = new Item(i, 0);
            }
        }

        public void LinearDivision(int item)
        {
            int key = Division(item);
            while (true)
            {
                if (items[key].Value == 0)
                {
                    items[key].Value = Convert.ToInt32(item);
                    break;
                }
                key = (key + 1)%1000;
            }
        }

        public void QuadraticDivison(int item)
        {
            int key = Division(item);
            int step = 1;
            while (true)
            {
                if (items[key].Value == 0)
                {
                    items[key].Value = Convert.ToInt32(item);
                    break;
                }
                key = (key + Convert.ToInt32(Math.Pow(step, 2))) % 1000;
                step++;
            }
        }

        int Division(int item)
        {
            return item % (3);
        }

        public void LinearMultiplication(int item)
        {
            int key = Multiplication(item);
            while (true)
            {
                if (items[key].Value == 0)
                {
                    items[key].Value = Convert.ToInt32(item);
                    break;
                }
                key = (key + 1) % items.Length % 1000;
            }
        }

        public void QuadraticMultiplication(int item)
        {
            int key = Multiplication(item);
            int step = 1;
            while (true)
            {
                if (items[key].Value == 0)
                {
                    items[key].Value = Convert.ToInt32(item);
                    break;
                }
                key = (key + Convert.ToInt32(Math.Pow(step,2))) % 1000;
                step++;
            }
        }
        int Multiplication(int item)
        {
            return (int)(0.618033 * item % 1)*100;
        }
    }
}
