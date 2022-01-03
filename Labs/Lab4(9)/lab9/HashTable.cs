using System;
using System.Text;

namespace lab9
{

    class HashTable<T>
        where T : IConvertible
    {
        public Item<T>[] items;
        int size;
        int[] rndValues;
        public HashTable(int size)
        {
            this.size = size;
            items = new Item<T>[size];
            Random random = new Random();
            rndValues = new int[size];
            for (int i = 0; i < size; i++)
            {
                items[i] = new Item<T>(i);
                rndValues[i] = random.Next(48, 57);
            }
        }

        public void Division(T item)
        {
            int key = item.GetHashCode() % items.Length;
            items[key].Node.Add(item);
        }

        public void Multiplication(T item)
        {
            int key = (int)(0.618033 * Convert.ToDouble(item.GetHashCode()) % 1)* items.Length;
            items[key].Node.Add(item);
        }

        public void Additive(T item)
        {
            int m = item.GetHashCode();
            byte[] asciiBytes = Encoding.ASCII.GetBytes(Convert.ToString(m));
            int result = 0;
            for (int i = 0; i < m.ToString().Length; i++)
            {
                result = result + Convert.ToInt32(asciiBytes[i]);
            }
            var key = result % items.Length;
            items[key].Node.Add(item);
        }

        public void XOR(T item)
        {
            int m = item.GetHashCode();
            byte[] asciiBytes = BitConverter.GetBytes(m);
            int result = 0;
            for (int i = 0; i < m.ToString().Length; i++)
            {
                result = result + asciiBytes[i] ^ rndValues[i];
            }
            int key = result % items.Length;
            items[key].Node.Add(item);
        }

        public void Clear()
        {
            items = new Item<T>[size];
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = new Item<T>(i);
            }
        }
    }
}
