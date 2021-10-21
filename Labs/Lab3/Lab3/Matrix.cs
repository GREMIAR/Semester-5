namespace Lab3
{
    class Matrix
    {
        public Vertex NodeFirst { get; set; }

        bool SearchVertexName(string name)
        {
            if (NodeFirst != null)
            {
                Vertex currentNode = NodeFirst;
                while (currentNode != null)
                {
                    if (currentNode.Name == name)
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
            SetDirection(SearchVertex(from), SearchVertex(to));
        }

        public void SetDirection(Vertex from, Vertex to)
        {
            if (from != null || to != null)
            {
                from.AddDirection(to);
            }
        }

        public void AddVertext(string newVertex)
        {
            if (NodeFirst != null)
            {
                Vertex currentVertex = NodeFirst;
                while (currentVertex.Next != null)
                {
                    currentVertex = currentVertex.Next;
                }
                currentVertex.Next = (new Vertex(newVertex));
            }
        }

        public void Remove(string nameVertex)
        {
            Remove(SearchVertex(nameVertex));
        }
        public void Remove(Vertex vertex)
        {
            if (NodeFirst != null)
            {
                Vertex currentVertex = NodeFirst;
                if(NodeFirst==vertex)
                {
                    NodeFirst = null;
                }
                while (currentVertex.Next != null)
                {
                    if (currentVertex.Next==vertex)
                    {
                        currentVertex.Next = currentVertex.Next.Next;
                    }
                    currentVertex = currentVertex.Next;
                }
            }
        }

        public bool FindEdge(string from, string to)
        {
            Vertex fromV = SearchVertex(from);
            Vertex toV = SearchVertex(to);
            return FindEdge(SearchVertex(from), SearchVertex(to));
        }

        public bool FindEdge(Vertex from, Vertex to)
        {
            if (from != null && to != null)
            {
                return from.FindDirection(to);
            }
            return false;
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
                    }
                    else
                    {
                        currentVertex.Next = new Vertex(vertexes[i]);
                        currentVertex = currentVertex.Next;
                    }
                }
            }
        }
    }
}
