using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment7_2
{
    internal class MergeSort
    {
        public static void MergeSortAlgo(int[] arr) {
            if (arr.Length > 1) {
                int mid = arr.Length / 2;
                int[] left = new int[mid];
                int[] right = new int[arr.Length - mid];

                for (int idx = 0; idx < mid; idx++) {
                    left[idx] = arr[idx];
                }
                for (int idx = mid; idx < arr.Length; idx++) {
                    right[idx - mid] = arr[idx];
                }

                MergeSortAlgo(left);
                MergeSortAlgo(right);

                int i = 0;
                int j = 0;
                int k = 0;

                while (i < left.Length && j < right.Length) {
                    if (left[i] < right[j]) {
                        arr[k] = left[i];
                        i++;
                    } else {
                        arr[k] = right[j];
                        j++;
                    }
                    k++;
                }
                // for all the remaining elements in the left array
                while (i < left.Length) {
                    arr[k] = left[i];
                    i++;
                    k++;
                }
                // for all the remaining elements in the right array
                while (j < right.Length) {
                    arr[k] = right[j];
                    j++;
                    k++;
                }
            }
        }
    }
}
