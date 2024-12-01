using System;
using Tasks.DoNotChange;

namespace Tasks;

public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
{
    private readonly DoublyLinkedList<T> _items = [];

    public void Push(T item)
    {
        _items.AddAt(0, item);
    }

    public T Pop()
    {
        if (_items.Length == 0)
            throw new InvalidOperationException("No items to pop.");

        return _items.RemoveAt(0);
    }

    public void Enqueue(T item)
    {
        _items.Add(item);
    }

    public T Dequeue()
    {
        if (_items.Length == 0)
            throw new InvalidOperationException("No items to dequeue.");

        return _items.RemoveAt(0);
    }
}
