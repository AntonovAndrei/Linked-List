namespace DoublyLinkedList
{
    public interface IAbstractDoublyLinkedList<T>
    {
        void AddFirst(T item);
        void AddLast(T item);
        void RemoveLast();
        void RemoveFirst();
        void Set(int index, T item);
        T Get(int index);
    }
}