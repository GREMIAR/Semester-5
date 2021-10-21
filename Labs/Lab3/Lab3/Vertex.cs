﻿using System.Collections.Generic;

namespace Lab3
{
    class Vertex
    {
        List<Vertex> directions;
        public string Name { get; set; }
        public Vertex Next { get; set; }
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

        public Vertex(string name)
        {
            Name = name; 
        }
    }
}
