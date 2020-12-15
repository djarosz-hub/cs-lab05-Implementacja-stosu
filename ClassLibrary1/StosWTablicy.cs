using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace ClassLibrary1
{
    public class StosWTablicy<T> : IStos<T>
    {
        private T[] tab;
        private int szczyt = -1;

        public StosWTablicy(int size = 10)
        {
            tab = new T[size];
            szczyt = -1;
        }

        public T Peek => IsEmpty ? throw new StosEmptyException() : tab[szczyt];

        public int Count => szczyt + 1;

        public bool IsEmpty => szczyt == -1;

        public T this[int index] => tab[index];

        public void Clear() => szczyt = -1;

        public T Pop()
        {
            if (IsEmpty)
                throw new StosEmptyException();

            szczyt--;
            return tab[szczyt + 1];
        }

        public void Push(T value)
        {
            if (szczyt == tab.Length - 1)
            {
                Array.Resize(ref tab, tab.Length * 2);
            }

            szczyt++;
            tab[szczyt] = value;
        }
        public void TrimExcess()
        {
            if (IsEmpty)
                throw new StosEmptyException();
            int actualSize = Count;
            int newSize = actualSize + Convert.ToInt32((1 / 10d) * actualSize);
            if (newSize <= 5)
                newSize++;
            Array.Resize(ref tab, newSize);
        }
        public int GetActualTabLength() => tab.Length;


        public T[] ToArray()
        {
            //return tab;  //bardzo źle - reguły hermetyzacji

            //poprawnie:
            T[] temp = new T[szczyt + 1];
            for (int i = 0; i < temp.Length; i++)
                temp[i] = tab[i];
            return temp;
        }
        public System.Collections.ObjectModel.ReadOnlyCollection<T> ToArrayReadOnly() => Array.AsReadOnly(tab);
        //public IEnumerator<T> GetEnumerator()
        //{
        //    for (int i = 0; i < Count; i++)
        //        yield return this[i];
        //}
        public IEnumerable<T> TopToBottom
        {
            get
            {
                for (int i = Count - 1; i >= 0; i--)
                    yield return this[i];
            }
        }
        
        public IEnumerator<T> GetEnumerator() => new EnumeratorStosu(this);
        private class EnumeratorStosu : IEnumerator<T>
        {
            private StosWTablicy<T> stos;
            private int position = -1;
            internal EnumeratorStosu(StosWTablicy<T> stos)
            {
                this.stos = stos;
            }
            public T Current => stos.tab[position];
            object IEnumerator.Current => Current;
            public void Dispose() { }
            public bool MoveNext()
            {
                if (position < stos.Count - 1)
                {
                    position++;
                    return true;
                }
                else
                    return false;
            }
            public void Reset() => position = -1;
        }
    }
}
