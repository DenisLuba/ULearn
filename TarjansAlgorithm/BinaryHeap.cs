using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class BinaryHeap
    {
        public static void HeapifyUp(List<int> heap)
        {
            var itemIndex = heap.Count - 1; // этот элемент только что вставили в кучу

            // поднимем его до нужного уровня в дереве
            while (true)
            {
                var parentIndex = itemIndex / 2;
                if (parentIndex <= 0 || heap[parentIndex] <= heap[itemIndex])
                    break;

                (heap[parentIndex], heap[itemIndex]) = (heap[itemIndex], heap[parentIndex]);
                itemIndex = parentIndex;
            }
        }
    }
}
