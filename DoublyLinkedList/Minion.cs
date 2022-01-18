using System;

namespace DoublyLinkedList
{
    public class Minion : IComparable<Minion>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int CompareTo(Minion minion)
        {
            int result = this.Age.CompareTo(minion.Age);
            if (result == 0)
            {
                result = this.Name.CompareTo(minion.Name);
            }
            return result;
        }
    }
}