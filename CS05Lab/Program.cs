using System;
using ClassLibrary1;

namespace CS05Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            StosWTablicy<string> s = new StosWTablicy<string>();
            s.Push("km");
            s.Push("aa");
            s.Push("ab");
            s.Push("ac");
            s.Push("xx");

            foreach (var x in s)
                Console.WriteLine(x);
            Console.WriteLine("---top to bottom---");
            foreach (var x in ((StosWTablicy<string>)s).TopToBottom)
                Console.WriteLine(x);
            Console.WriteLine($"Actual tab length: {s.GetActualTabLength()}");
            s.TrimExcess();
            Console.WriteLine($"Length after TrimExcess: {s.GetActualTabLength()}");

            Console.WriteLine($"el at position 1 (\"aa\"): {s[1]} {"aa" == s[1]}");
            Console.WriteLine();

            var sToArray = s.ToArray();
            var sToArrayReadOnly = s.ToArrayReadOnly();
            sToArray[1] = "ssss";
            foreach (var x in sToArray)
                Console.WriteLine(x);
            //sToArrayReadOnly[1] = "ss"; read only error
            Console.WriteLine("---StosWLiscie---");
            StosWLiscie<int> sl = new StosWLiscie<int>();
            sl.Push(5);
            sl.Push(6);
            Console.WriteLine($"el at index 1: {sl[1]}");
            sl.Push(7);
            sl.Push(8);
            int[] tab = sl.ToArray();
            foreach (var i in tab)
                Console.Write($"{i} ");
            Console.WriteLine("\nPop:");
            sl.Pop();
            tab = sl.ToArray();
            foreach (var i in tab)
                Console.Write($"{i} ");
            Console.WriteLine();
            Console.WriteLine("foreach through StosWLiscie");
            foreach(var i in sl)
                Console.Write($"{i} ");
            Console.WriteLine($"\nIs array empty? {sl.IsEmpty}");
            sl.Clear();
            Console.WriteLine("After clear:");
            Console.WriteLine($"Is array empty? {sl.IsEmpty}");

        }
    }
}
