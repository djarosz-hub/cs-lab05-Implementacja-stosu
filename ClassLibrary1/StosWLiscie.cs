using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class StosWLiscie<T> : IStos<T>
    {
        private List<Node<T>> lista;
        public StosWLiscie()
        {
            lista = new List<Node<T>>();
        }
        class Node<T>
        {
            internal T data;
            internal Node<T> next;
            internal Node<T> prev;
            internal Node(T element, Node<T> next = null, Node<T> prev = null)
            {
                this.data = element;
                this.next = next;
                this.prev = prev;
            }
        }
        public T Peek => Count != 0 ? lista[Count - 1].data : throw new StosEmptyException();
        public int Count => lista.Count;

        public bool IsEmpty => lista.Count == 0;
        public T this[int index] => index < Count ? lista[Count - 1].data : throw new IndexOutOfRangeException();
        public void Clear() => lista.Clear();

        public T Pop()
        {
            if (Count == 0)
                throw new StosEmptyException();
            Node<T> last = lista[Count - 1];
            lista.RemoveAt(Count - 1);
            if (Count != 0)
                lista[Count - 1].next = null;
            return last.data;
        }

        public void Push(T value)
        {
            Node<T> el;
            if (Count == 0)
            {
                el = new Node<T>(value, null, null);
                lista.Add(el);
            }
            else
            {
                Node<T> prev = lista[Count - 1];
                el = new Node<T>(value, null, prev);
                lista.Add(el);
                prev.next = el;
            }
        }

        public T[] ToArray()
        {
            T[] temp = new T[Count];
            for (int i = 0; i < Count; i++)
                temp[i] = lista[i].data;
            return temp;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
                yield return lista[i].data;
        }
    }
}
