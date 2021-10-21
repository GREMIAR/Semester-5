using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Matrix
    {
        public Vertex NodeFirst { get; set; }

        bool SearchVertexName(string name)
        {
            if(NodeFirst!=null)
            {
                Vertex currentNode = NodeFirst;
                while(currentNode!=null)
                {
                    if (currentNode.Name==name)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        Vertex SearchVertex(string name)
        {
            if (NodeFirst != null)
            {
                Vertex currentNode = NodeFirst;
                while (currentNode != null)
                {
                    if (currentNode.Name == name)
                    {
                        return currentNode;
                    }
                }
            }
            return null;
        }

        public void SetDirection(string from, string to)
        {
            Vertex fromV = SearchVertex(from);
            Vertex toV = SearchVertex(to);
            if (fromV != null||toV!=null)
            {
                SetDirection(fromV, toV);
            }
        }

        public void SetDirection(Vertex from,Vertex to)
        {
            from.AddDirection(to);
        }

        public void AddVertext(string newVertex)
        {
            if (NodeFirst != null)
            {
                Vertex currentVertex = NodeFirst;
                while(currentVertex.Next!=null)
                {
                    currentVertex = currentVertex.Next;
                }
                currentVertex.Next = (new Vertex(newVertex));
            }
        }

        public void RemoveNotInitial()
        {
            if (NodeFirst != null)
            {
                Vertex currentVertex = NodeFirst;
                if(NodeFirst.Next==null)
                {
                    NodeFirst = null;
                }
                while (currentVertex.Next != null)
                {
                    if (!currentVertex.Next.initial)
                    {
                        currentVertex.Next = currentVertex.Next.Next;
                    }
                    currentVertex = currentVertex.Next;
                }
            }
        }

        public Matrix(string[] vertexes)
        {
            Vertex currentVertex=null;
            for(int i =0; i<vertexes.Length;i++)
            {
                if (!SearchVertexName(vertexes[i]))
                {
                    if (NodeFirst == null)
                    {
                        NodeFirst = new Vertex(vertexes[i]);
                        currentVertex = NodeFirst;
                        currentVertex.initial = true;
                    }
                    else
                    {
                        currentVertex.Next = new Vertex(vertexes[i]);
                        currentVertex = currentVertex.Next;
                        currentVertex.initial = true;
                    }
                }
            }
        }
    }
}
