using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace DoublyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var m1 = new Minion();
            m1.Name = "Dmitry";
            m1.Age = 21;
            
            var m2 = new Minion();
            m2.Name = "Oleg";
            m2.Age = 21;
            
            Console.WriteLine(m1.CompareTo(m2));
            
            var list = new DoubleLinkedList<Minion>();
            list.AddLast(m1);
            list.AddLast(m2);
            
            foreach (var m in list)
            {
                Console.WriteLine(m.Name);
            }
        }
    }
}