using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace DoublyLinkedList
{
    public class DoubleLinkedList<T>: IAbstractDoublyLinkedList<T>, IEnumerable<T>
    {
        private Node<T> _head;
        private Node<T> _tale;
        public int Size { get; private set; }
        
        public DoubleLinkedList()
        {
            _head = null;
            _tale = null;
        }

        public void AddFirst(T item)
        {
            Node<T> newNode = new Node<T>(item);
            
            if (this.Size == 0)
            {
                this._head = newNode;
                this._tale = this._head;
            }
            else
            {
                this._head.Previous = newNode;
                newNode.Next = _head;
                this._head = newNode;
            }
            
            this.Size++;
        }

        public void AddLast(T item)
        {  
            Node<T> newNode = new Node<T>(item);
            
            if (this.Size == 0)
            {
                this._head = newNode;
                this._tale = newNode;
            }
            else
            {
                this._tale.Next = newNode;
                newNode.Previous = _tale;
                this._tale = newNode;
            }
            
            this.Size++;
        }
        public void RemoveLast()
        {
            if (this.Size >= 1)
            {
                if (this.Size == 1)
                {
                    this._head = null;
                    this._tale = null;
                }
                else
                {
                    var prev = this._tale.Previous;
                    this._tale.Previous = null;
                    prev.Next = null;
                    this._tale = prev;
                }

                this.Size--;
            }
            else
            {
                throw new InvalidOperationException();
            }
            
        }

        public void RemoveFirst()
        {
            if (this.Size >= 1)
            {
                if (this.Size == 1)
                {
                    this._head = null;
                    this._tale = null;
                }
                else
                {
                    var next = this._head.Next;
                    this._head.Next = null;
                    next.Previous = null;
                    this._head = next;
                }

                this.Size--;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public void Set(int index, T item)
        {
            if (index < this.Size)
            {
                var node = this._head;
                for (int i = 0; i < index; i++)
                {
                    node = node.Next;
                }

                node.Value = item;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        
        
        public T Get(int index)
        {
            if (index < this.Size)
            {
                var node = this._head;
                for (int i = 0; i < index; i++)
                {
                    node = node.Next;
                }
                return node.Value;
            }
            
            throw new InvalidOperationException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i<this.Size;  i++)
            {
                yield return Get(i);
            }
        }

        public T this[int index]
        {
            get
            {
                if (index<0||index>=this.Size)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return Get(index);
            }

            set
            {
                Set(index, value);
            }
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}