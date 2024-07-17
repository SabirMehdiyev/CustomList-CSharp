using System.Collections;

namespace CustomList;

public  class CustomList<T>:IEnumerable<T>
{
    private T[] _items;
    private int _count;
    public int Count {  get { return _count; } }
    public int Capacity { get; set; }
    public CustomList()
    {
        _items = new T[4];
    }

    public void Add(T item)
    {
        if (_count == _items.Length)
        {
            Capacity = _items.Length * 2;
        }
        Array.Resize(ref _items, _count+1);
        _items[_count++] = item;
    }

    public bool Remove(T item)
    {
        for (int i = 0; i < _count; i++)
        {
            if (_items[i].Equals(item))
            {
                for (int j = i; j < _count - 1; j++)
                {
                    _items[j] = _items[j + 1];
                }
                _count--;
                Array.Resize(ref _items, _items.Length - 1);
                return true;
            }
        }
        return false;
    }
    public int RemoveAll(Predicate<T> match)
    {
        if (match == null)
            throw new Exception("Şərtə uyğun dəyər tapılmadı");
        int countRemoved = 0;
        int index = 0;
        while (index < _count)
        {
            if (match(_items[index]))
            {
                RemoveAt(index);
                countRemoved++;
            }
            else
            {
                index++;
            }
        }
        return countRemoved;
    }

    private void RemoveAt(int index)
    {
        for (int i = index; i < _count - 1; i++)
        {
            _items[i] = _items[i + 1];
        }
        Array.Resize(ref _items, _items.Length - 1);

        _count--;
    }
    public T Find(Predicate<T> match)
    {
        if (match == null)
            throw new Exception("Şərtə uyğun dəyər tapılmadı");

        foreach (var item in _items)
        {
            if (match(item))
            {
                return item;
            }
        }

        return default;
    }
    public List<T> FindAll(Predicate<T> match)
    {
        if (match == null)
            throw new Exception("Şərtə uyğun dəyər tapılmadı");

        List<T> matches = new List<T>();

        foreach (var item in _items)
        {
            if (match(item))
            {
                matches.Add(item);
            }
        }

        return matches;
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (var item in _items)
        {
            yield return item;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
