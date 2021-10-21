using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Vertex
    {
        List<Vertex> direction;
        public string Name { get; set; }
        public Vertex Next { get; set; }

        public bool initial {get ;set;}
        public void AddDirection(Vertex vertex)
        {
            direction.Add(vertex);
        }

        public Vertex(string name)
        {
            Name = name; 
        }
    }
}
