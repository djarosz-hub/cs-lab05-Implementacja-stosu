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
            Console.WriteLine(s.GetActualTabLength());
            s.TrimExcess();
            Console.WriteLine(s.GetActualTabLength());

            Console.WriteLine($"el at position 1 (\"aa\"): {s[1]} {"aa" == s[1]}");
            Console.WriteLine();

            var sToArray = s.ToArray();
            var sToArrayReadOnly = s.ToArrayReadOnly();
            sToArray[1] = "ssss";
            foreach (var x in sToArray)
                Console.WriteLine(x);
            //sToArrayReadOnly[1] = "ss"; read only error
        }
    }
}
