using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks;

public class DoublyLinkedList<T> : IDoublyLinkedList<T>
{
    private T[] _items;
    private int _capacity;

    public int Length { get; private set; }

    public DoublyLinkedList(int initialCapacity = 4)
    {
        _capacity = initialCapacity;
        _items = new T[_capacity];
        Length = 0;
    }

    public void Add(T value)
    {
        EnsureCapacity();
        _items[Length++] = value;
    }

    public void AddAt(int index, T value)
    {
        if (index < 0 || index > Length)
        {
            throw new IndexOutOfRangeException();
        }

        EnsureCapacity();

        if (index < Length)
        {
            Array.Copy(_items, index, _items, index + 1, Length - index);
        }

        _items[index] = value;
        Length++;
    }

    public T ElementAt(int index)
    {
        if (index < 0 || index >= Length)
        {
            throw new IndexOutOfRangeException();
        }

        return _items[index];
    }

    public void Remove(T value)
    {
        for (int i = 0; i < Length; i++)
        {
            if (EqualityComparer<T>.Default.Equals(_items[i], value))
            {
                RemoveAt(i);
                return;
            }
        }
    }

    public T RemoveAt(int index)
    {
        if (index < 0 || index >= Length)
        {
            throw new IndexOutOfRangeException();
        }

        var removedValue = _items[index];

        if (index < Length - 1)
        {
            Array.Copy(_items, index + 1, _items, index, Length - index - 1);
        }

        _items[--Length] = default;
        return removedValue;
    }

    private void EnsureCapacity()
    {
        if (Length >= _capacity)
        {
            _capacity *= 2;
            var newArray = new T[_capacity];
            Array.Copy(_items, newArray, Length);
            _items = newArray;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < Length; i++)
        {
            yield return _items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}