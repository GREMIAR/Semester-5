using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class MultiLinkedList
    {
        Node head { get; set; }
        Node redDiploma { get; set; }
        Node diploma { get; set; }
        Node needHousing { get; set; }
        Node housing { get; set; }
        public void Insert(Student student)
        {
            Node node = new Node(student);
            node.next = head;
            head = node;
            if (node.student.redDiploma)
            {
                node.Diploma = redDiploma;
                redDiploma = node;
            }
            else
            {
                node.Diploma = diploma;
                diploma = node;
            }
            if (node.student.needHousing)
            {
                node.Housing = needHousing;
                needHousing = node;
            }
            else
            {
                node.Housing = housing;
                housing = node;
            }
        }

        public void Remove()
        {

        }


    }
}
