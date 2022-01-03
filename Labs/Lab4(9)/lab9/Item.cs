using System;
using System.Collections.Generic;

namespace lab9
{
    class Item<T>
        where T:IConvertible
    {
        public int Key { get; set; }
        public List<T> Node { get; set; }
        public Item(int key)
        {
            Key = key;
            Node = new List<T>();
        }
    }
}
