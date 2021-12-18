namespace Exceptions
{
    public class FixedSizeQueue : IFixedSizeQueue
    {
        private object[] _items;
        private int _firstIndex = 0;
        private int _lastIndex = 0;

        public FixedSizeQueue(uint capacity)
        {
            Capacity = capacity;
            _items = new object[capacity];
        }

        public uint Capacity { get; }

        public uint Count => (uint)(_lastIndex - _firstIndex);

        public object GetFirst()
        {
            if (Count.Equals(0))
            {
                throw new EmptyQueueException("Cannot get first item, the queue is empty");
            }
            else
            {
                var first = _items[_firstIndex % Capacity];
                _firstIndex++;
                return first;
            }
        }

        public void AddLast(object item)
        {
            if (Count.Equals(Capacity))
            {
                throw new FullQueueException("Cannot add last item, the queue is full");
            }
            else
            {
                _items[_lastIndex % Capacity] = item;
                _lastIndex++;

            }
        }
    }
}
