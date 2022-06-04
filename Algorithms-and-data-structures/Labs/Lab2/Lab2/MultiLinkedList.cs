using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class MultiLinkedList
    {
        public Node head { get; set; }
        public Node redDiploma { get; set; }
        public Node diploma { get; set; }
        public Node needHousing { get; set; }
        public Node housing { get; set; }
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
            if (currentNode == head&& currentNode.student.id==id)
            {
                head = currentNode.next;
                if (redDiploma == currentNode && currentNode.student.redDiploma)
                {
                    this.redDiploma = currentNode.Diploma;
                }
                else if (diploma == currentNode && !currentNode.student.redDiploma)
                {
                    this.diploma = currentNode.Diploma;
                }
                if (needHousing == currentNode && currentNode.student.needHousing)
                {
                    this.needHousing = currentNode.Housing;
                }
                else if (housing == currentNode && !currentNode.student.needHousing)
                {
                    this.housing = currentNode.Housing;
                }
                return;
            }

            while (currentNode.next != null)
            {
                if (redDiploma == currentNode && currentNode.student.redDiploma)
                {
                    redDiploma = currentNode;
                }
                else if (diploma == currentNode && !currentNode.student.redDiploma)
                {
                    diploma = currentNode;
                }
                if (needHousing == currentNode && currentNode.student.needHousing)
                {
                    needHousing = currentNode;
                }
                else if (housing == currentNode && !currentNode.student.needHousing)
                {
                    housing = currentNode;
                }
                if (currentNode.next.student.id == id)
                {
                    if(currentNode.next.student.redDiploma)
                    {
                        redDiploma.Diploma = currentNode.next.Diploma;
                    }
                    else
                    {
                        diploma.Diploma = currentNode.next.Diploma;
                    }
                    if(currentNode.next.student.needHousing)
                    {
                        needHousing.Housing = currentNode.next.Housing;
                    }
                    else
                    {
                        housing.Housing = currentNode.next.Housing;
                    }
                    currentNode.next = currentNode.next.next;
                    return;
                }
               

                currentNode = currentNode.next;
            }
        }


    }
}
