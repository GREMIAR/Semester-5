using System.Collections.Generic;
using System.Drawing;

namespace Lab3
{
    class Vertex
    {
        List<Vertex> directions;
        public string Name { get; set; }
        public Vertex Next { get; set; }
        public Point Coor { get; set; }
        public void AddDirection(Vertex vertex)
        {
            directions.Add(vertex);
        }

        public bool FindDirection(Vertex vertex)
        {
            foreach (Vertex direction in directions)
            {
                if(direction==vertex)
                {
                    return true;
                }
            }
            return false;
        }

        public void RemoveDirection(Vertex vertex)
        {
            directions.Remove(vertex);
        }

        public Vertex[] GetDirection()
        {
            return directions.ToArray();
        }


        public Vertex(string name)
        {
            directions = new List<Vertex>();
            Name = name; 
        }
    }
}
