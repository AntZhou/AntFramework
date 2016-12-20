namespace SortAlgorithm
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SortAlgorithmUnitTest
    {
        private static readonly int Size = (int)Math.Pow(10, 5);

        private readonly int[] randomNumbers;

        public SortAlgorithmUnitTest()
        {
            this.randomNumbers = GetInts();
        }

        private static int[] GetInts()
        {
            var random = new Random();
            var list = new List<int>();
            for (var i = 0; i < Size; i++)
            {
                list.Add(random.Next(0, Size));
            }
            return list.ToArray();
        }

        private void AfterSort(IList<int> arr)
        {
            //for (var i = 0; i < Size; i++)
            //{
            //    Trace.WriteLine($"{i}:{this.randomNumbers[i]}");
            //}
            for (var i = 0; i < Size; i++)
            {
                Trace.WriteLine($"{i}:{arr[i]}");
            }
            for (var i = 1; i < arr.Count; i++)
            {
                if (arr[i] < arr[i - 1])
                {
                    Assert.Fail($"第{i}位:{arr[i]}小于第{(i - 1)}位:{arr[i - 1]}");
                }
            }
        }

        private void BeforeSort(IList<int> arr)
        {
            for (var i = 0; i < Size; i++)
            {
                Trace.WriteLine($"{i}:{arr[i]}");
            }
        }

        private static void SwapValue(ref int a, ref int b)
        {
            a = a ^ b;
            b = b ^ a;
            a = a ^ b;
            //int temp = a;
            //a = b;
            //b = a;
        }

        private void DoSort(Action<int[]> sortFunc)
        {
            var currentArr = (int[])this.randomNumbers.Clone();
            //this.BeforeSort(currentArr);
            sortFunc(currentArr);
            //this.AfterSort(currentArr);
            var aa = "asd" + "Fd";
        }

        /// <summary>
        ///     快速排序
        /// </summary>
        [TestMethod]
        public void QuickSortTest()
        {
            this.DoSort(arr => { this.QuickSortFunc(arr, 0, arr.Length - 1); });
        }

        private void QuickSortFunc(int[] arr, int low, int high)
        {
            if (low >= high)
            {
                return;
            }
            var keyIndex = GetKeyIndex(arr, low, high);
            this.QuickSortFunc(arr, low, keyIndex - 1);
            this.QuickSortFunc(arr, keyIndex + 1, high);
        }

        private static int GetKeyIndex(int[] arr, int low, int high)
        {
            var keyValue = arr[low];
            var left = low;
            var right = high;
            while (left < right)
            {
                while (left < right && keyValue >= arr[left])
                {
                    left++;
                }
                while (left < right && keyValue <= arr[right])
                {
                    right--;
                }
                if (left < right)
                {
                    SwapValue(ref arr[left], ref arr[right]);
                }
            }
            if (keyValue >= arr[left])
            {
                arr[low] = arr[left];
                arr[left] = keyValue;
                return left;
            }
            arr[low] = arr[left - 1];
            arr[left - 1] = keyValue;
            return left - 1;
        }

        /// <summary>
        ///     冒泡排序
        /// </summary>
        [TestMethod]
        public void BubbleSortTest()
        {
            this.DoSort(this.BubbleSortFunc);
        }

        private void BubbleSortFunc(int[] arr)
        {
            for (var i = 0; i < Size; i++)
            {
                for (var j = i + 1; j < Size; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        SwapValue(ref arr[i], ref arr[j]);
                    }
                }
            }
        }

        /// <summary>
        ///     堆排序
        /// </summary>
        [TestMethod]
        public void HeapSortTest()
        {
            this.DoSort(this.HeapSortFunc);
        }

        private void HeapSortFunc(int[] arr)
        {
            for (var i = arr.Length / 2 - 1; i >= 0; i--)
            {
                this.MaxToParentNode(arr, i, arr.Length - 1);
            }
            for (var i = arr.Length - 1; i > 0; i--)
            {
                SwapValue(ref arr[0], ref arr[i]);
                this.MaxToParentNode(arr, 0, i);
            }
        }

        private void MaxToParentNode(int[] arr, int currentIndex, int arrSize)
        {
            while (true)
            {
                var left = currentIndex * 2 + 1;
                var right = currentIndex * 2 + 2;
                var large = currentIndex;
                if (left < arrSize && arr[left] > arr[large])
                {
                    large = left;
                }
                if (right < arrSize && arr[right] > arr[large])
                {
                    large = right;
                }
                if (large == currentIndex)
                {
                    return;
                }
                SwapValue(ref arr[currentIndex], ref arr[large]);
                currentIndex = large;
            }
        }

        [TestMethod]
        public void MergeSortTest()
        {
            this.DoSort(arr => { this.MergeSortFunc(arr, 0, arr.Length - 1); });
        }

        private void MergeSortFunc(int[] arr, int start, int end)
        {
            if (start < end)
            {
                var midIndex = (start + end) / 2;
                this.MergeSortFunc(arr, start, midIndex);
                this.MergeSortFunc(arr, midIndex + 1, end);
                this.MergeArray(arr, start, midIndex, end);
            }
        }

        private void MergeArray(int[] arr, int start, int midIndex, int end)
        {
            var tempArrSize = end - start + 1;
            var tempArr = new int[tempArrSize];
            var tempIndex = 0;
            var n = start;
            var m = midIndex + 1;
            while (n <= midIndex && m <= end)
            {
                if (arr[n] <= arr[m])
                {
                    tempArr[tempIndex] = arr[n];
                    n++;
                }
                else
                {
                    tempArr[tempIndex] = arr[m];
                    m++;
                }
                tempIndex++;
            }
            while (n <= midIndex)
            {
                tempArr[tempIndex++] = arr[n++];
            }
            while (m <= end)
            {
                tempArr[tempIndex++] = arr[m++];
            }
            for (int i = start; i <= end; i++)
            {
                arr[i] = tempArr[i-start];
            }
        }
    }
}