namespace Lab3
{
    class Matrix
    {
        public Vertex NodeFirst { get; set; }
        public bool SearchVertexName(string name)
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
                    currentNode = currentNode.Next;
                }
            }
            return false;
        }

        public int Size()
        {
            int quantity=0;
            if (NodeFirst != null)
            {
                Vertex currentNode = NodeFirst;
                while (currentNode != null)
                {
                    quantity++;
                    currentNode = currentNode.Next;
                }
            }
            return quantity;
        }

        public string GetVertex(int number)
        {
            if (NodeFirst != null)
            {
                Vertex currentNode = NodeFirst;
                int idx = 1;
                while (currentNode != null)
                {
                    if (number == idx)
                    {
                        return currentNode.Name;
                    }
                    idx++;
                    currentNode = currentNode.Next;
                }
            }
            return null;
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
                    currentNode = currentNode.Next;
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
            if (from != null && to != null)
            {
                from.AddDirection(to);
            }
        }

        public Vertex AddVertext(string newVertex)
        {
            if (NodeFirst != null)
            {
                Vertex currentVertex = NodeFirst;
                while (currentVertex.Next != null)
                {
                    currentVertex = currentVertex.Next;
                }
                return currentVertex.Next = (new Vertex(newVertex));
            }
            else
            {
                return NodeFirst = new Vertex(newVertex);
            }
        }

        public Matrix()
        {

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
                    NodeFirst = NodeFirst.Next;
                }
                while (currentVertex.Next != null)
                {
                    if (currentVertex.Next==vertex)
                    {
                        Vertex vrtx = NodeFirst;
                        while (vrtx != null)
                        {
                            foreach (Vertex vertexToRemove in vrtx.GetDirection())
                            {
                                if (vertexToRemove == currentVertex.Next)
                                {
                                    vrtx.RemoveDirection(vertexToRemove);
                                }
                            }
                            vrtx = vrtx.Next;
                        }
                        currentVertex.Next = currentVertex.Next.Next;
                        return;
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
