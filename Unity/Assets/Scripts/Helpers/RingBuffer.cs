using System.Collections.Generic;
using System.Linq;

namespace CaromBilliardsGame.Stolzenberg.Helpers
{
    public class RingBuffer<T>
    {
        private Queue<T> _queue;
        private int _size;

        public RingBuffer(int size)
        {
            _queue = new Queue<T>(size);
            _size = size;
        }

        public void Add(T obj)
        {
            if (_queue.Count == _size)
            {
                _queue.Dequeue();
                _queue.Enqueue(obj);
            }
            else
            {
                _queue.Enqueue(obj);
            }
        }

        public T Read()
        {
            return _queue.Dequeue();
        }

        public int Count()
        {
            return _queue.Count();
        }
        
        public List<T> GetList()
        {
            return _queue.ToList();
        }

        public T Peek()
        {
            return _queue.Peek();
        }
    }
}