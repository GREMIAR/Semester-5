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

        

        public void Remove(int id)
        {
            Node currentNode = head;
            Node diploma = this.diploma;
            Node redDiploma = this.redDiploma;
            Node housing = this.housing;
            Node needHousing = this.needHousing;
            while(head.next != null)
            {
                if(currentNode.next.student.id == id)
                {
                    if(currentNode.student.redDiploma)
                    {
                        redDiploma.Diploma = currentNode.Diploma;
                    }
                    else
                    {
                        diploma.Diploma = currentNode.Diploma;
                    }
                    if(currentNode.student.needHousing)
                    {
                        needHousing.Housing = currentNode.Housing;
                    }
                    else
                    {
                        housing.Housing = currentNode.Housing;
                    }
                    currentNode.next = currentNode.next.next;
                    
                }
                if (redDiploma == currentNode && currentNode.student.redDiploma)
                {
                    redDiploma = currentNode.Diploma;
                }
                else if (diploma == currentNode && !currentNode.student.redDiploma)
                {
                    diploma = currentNode.Diploma;
                }
                if (needHousing == currentNode && currentNode.student.needHousing)
                {
                    needHousing = currentNode.Housing;
                }
                else if (housing == currentNode)
                {
                    housing = currentNode.Housing;
                }
            }
        }


    }
}
