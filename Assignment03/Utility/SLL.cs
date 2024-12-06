using Assignment03;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Assignment03.Utility
{
    [Serializable]
    public class SLL : ILinkedListADT, ISerializable
    {
        private Node<User> head;
        private int count;

        public SLL()
        {
            head = null;
            count = 0;
        }

        protected SLL(SerializationInfo info, StreamingContext context)
        {
            var users = (List<User>)info.GetValue("Users", typeof(List<User>));
            foreach (var user in users)
            {
                AddLast(user);
            }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            var users = new List<User>();
            var current = head;
            while (current != null)
            {
                users.Add(current.Data);
                current = current.Next;
            }
            info.AddValue("Users", users, typeof(List<User>));
        }

        public bool IsEmpty() => head == null;

        public void Clear()
        {
            head = null;
            count = 0;
        }

        public void AddLast(User value)
        {
            var newNode = new Node<User>(value);

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                var current = head;
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
            var newNode = new Node<User>(value) { Next = head };
            head = newNode;
            count++;
        }

        public void Add(User value, int index)
        {
            if (index < 0 || index > count)
                throw new IndexOutOfRangeException();

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
                var newNode = new Node<User>(value);
                var current = head;

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
                throw new IndexOutOfRangeException();

            var current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            current.Data = value;
        }

        public int Count() => count;

        public void RemoveFirst()
        {
            if (IsEmpty())
                throw new InvalidOperationException("List is empty.");
            head = head.Next;
            count--;
        }

        public void RemoveLast()
        {
            if (IsEmpty())
                throw new InvalidOperationException("List is empty.");

            if (head.Next == null)
            {
                head = null;
            }
            else
            {
                var current = head;
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
                throw new IndexOutOfRangeException();

            if (index == 0)
            {
                RemoveFirst();
            }
            else
            {
                var current = head;
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
                throw new IndexOutOfRangeException();

            var current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.Data;
        }

        public int IndexOf(User value)
        {
            var current = head;
            for (int i = 0; i < count; i++)
            {
                if (current.Data.Equals(value))
                    return i;
                current = current.Next;
            }
            return -1;
        }

        public bool Contains(User value) => IndexOf(value) != -1;

        public void Insert(int v, User user)
        {
            throw new NotImplementedException();
        }

        public void Replace(int v, User user)
        {
            throw new NotImplementedException();
        }

        public void Reverse()
        {
            throw new NotImplementedException();
        }
    }
}
