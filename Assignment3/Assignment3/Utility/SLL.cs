using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assignment3
{
    [Serializable]
    public class SLL : ILinkedListADT
    {
        private Node head;
        private int count;

        public SLL()
        {
            head = null;
            count = 0;
        }

        public bool IsEmpty()
        {
            return head == null;
        }

        public void Clear()
        {
            head = null;
            count = 0;
        }

        public void AddLast(User value)
        {
            Node newNode = new Node(value);
            if (IsEmpty())
            {
                head = newNode;
            }
            else
            {
                Node current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
            count++;
        }

        public void AddFirst(User value)
        {
            Node newNode = new Node(value);
            newNode.Next = head;
            head = newNode;
            count++;
        }

        public void Add(User value, int index)
        {
            if (index < 0 || index > count)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            if (index == 0)
            {
                AddFirst(value);
            }
            else if (index == count)
            {
                AddLast(value);
            }
            else
            {
                Node newNode = new Node(value);
                Node current = head;

                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }

                newNode.Next = current.Next;
                current.Next = newNode;
                count++;
            }
        }

        public void Replace(User value, int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            current.Data = value;
        }

        public int Count()
        {
            return count;
        }

        public void RemoveFirst()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Cannot remove from an empty list.");
            }

            head = head.Next;
            count--;
        }

        public void RemoveLast()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Cannot remove from an empty list.");
            }

            if (count == 1)
            {
                head = null;
            }
            else
            {
                Node current = head;
                while (current.Next.Next != null)
                {
                    current = current.Next;
                }
                current.Next = null;
            }

            count--;
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            if (index == 0)
            {
                RemoveFirst();
            }
            else if (index == count - 1)
            {
                RemoveLast();
            }
            else
            {
                Node current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }

                current.Next = current.Next.Next;
                count--;
            }
        }

        public User GetValue(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            return current.Data;
        }

        public int IndexOf(User value)
        {
            Node current = head;
            for (int i = 0; i < count; i++)
            {
                if (current.Data.Equals(value))
                {
                    return i;
                }
                current = current.Next;
            }

            return -1;
        }

        public bool Contains(User value)
        {
            return IndexOf(value) != -1;
        }

        public void Reverse()
        {
            if (count <= 1)
            {
                return;
            }

            Node prev = null;
            Node current = head;
            Node next = null;

            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }

            head = prev;
        }

        public void SortByName()
        {
            if (count <= 1)
            {
                return;
            }

            bool swapped;
            do
            {
                Node current = head;
                Node previous = null;
                swapped = false;

                while (current.Next != null)
                {
                    if (string.Compare(current.Data.Name, current.Next.Data.Name) > 0)
                    {
                        Node temp = current.Next;
                        current.Next = temp.Next;
                        temp.Next = current;

                        if (previous == null)
                        {
                            head = temp;
                        }
                        else
                        {
                            previous.Next = temp;
                        }

                        swapped = true;
                    }

                    previous = current;
                    current = current.Next;
                }
            } while (swapped);
        }

        public User[] CopyToArray()
        {
            User[] array = new User[count];
            Node current = head;

            for (int i = 0; i < count; i++)
            {
                array[i] = current.Data;
                current = current.Next;
            }

            return array;
        }

        public void Join(ILinkedListADT otherList)
        {
            if (otherList == null || otherList.IsEmpty())
            {
                return;
            }

            Node current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = ((SLL)otherList).head;
            count += otherList.Count();
        }

        public (ILinkedListADT, ILinkedListADT) Divide(int index)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException("Index is out of range.");
    
            var firstList = new SLL();
            var secondList = new SLL();

            var current = head;
            for (int i = 0; i < index; i++)
            {
                firstList.AddLast(current.Data);
                current = current.Next;
            }

            while (current != null)
            {
                secondList.AddLast(current.Data);
                current = current.Next;
            }

            return (firstList, secondList);
        }
    }
}
