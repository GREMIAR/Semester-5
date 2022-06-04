using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Node
    {
        public Student student { get; set; }
        public Node next { get; set; }
        public Node Diploma { get; set; }
        public Node Housing { get; set; }
        public Node(Student student)
        {
            this.student = student;
        }
    }
}
