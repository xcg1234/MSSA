using System;
using System.Collections.Generic;
using System.Text;

namespace Assignments6_1
{
    internal class MoveZeroes
    {
        public static int[] MoveZeroesToEnd(int[] nums) {
            int pointer = 0;
            for(int i = 0; i < nums.Length; i++) {
                if(nums[i] != 0) {
                    int temp = nums[pointer];
                    nums[pointer] = nums[i];
                    nums[i] = temp;
                    pointer++;
                }
            }
            return nums;
        }
    }
}
