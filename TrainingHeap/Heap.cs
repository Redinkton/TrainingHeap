using System.Runtime.InteropServices;

namespace TrainingHeap
{
    public class Heap
    {
        private int[] _arr;

        // free seats
        private int _count;
        public int Count { get { return _count; } }

        public Heap(int n)
        {
            _arr = new int[n];

            int i = 1;
            int j = 0;
            while (i <= n)
            {
                _arr[j] = i;
                j++;
                i++;
            }
            _count = n;
        }

        public void Add(int element)
        {
            _count++;
            int currentIndex = _count - 1;
            _arr[currentIndex] = element;
            PushUp(currentIndex);
        }

        private void PushUp(int currentIndex)
        {
            int parentIndex = (currentIndex - 1) / 2;

            while (currentIndex > 0 && _arr[parentIndex] > _arr[currentIndex])
            {
                int temp = _arr[currentIndex];
                _arr[currentIndex] = _arr[parentIndex];
                _arr[parentIndex] = temp;

                currentIndex = parentIndex;
                parentIndex = (currentIndex - 1) / 2;
            }
        }

        public int GetMin()
        {
            if (Count == 0)
            {
                return 0;
            }
            return _arr[0];
        }

        public void RemoveMin()
        {
            if (_count == 0)
            {
                return;
            }

            if(_count == 1)
            {
                _count--;
                return;
            }

            _arr[0]= _arr[_count-1];
            _count--;
            Sort(0);
        }

        private void Sort(int currentIndex)
        {
            int smallestIndex = currentIndex;
            int leftIndex = 2 * currentIndex + 1;
            int rightIndex = 2 * currentIndex + 2;

            if (leftIndex < _count && _arr[leftIndex] < _arr[smallestIndex])
            {
                smallestIndex = leftIndex;
            }

            if (rightIndex < _count && _arr[rightIndex] < _arr[smallestIndex])
            {
                smallestIndex = rightIndex;
            }

            if (smallestIndex != currentIndex)
            {
                int temp = _arr[currentIndex];
                _arr[currentIndex] = _arr[smallestIndex];
                _arr[smallestIndex] = temp;
                Sort(smallestIndex);
            }
        }
    }
}