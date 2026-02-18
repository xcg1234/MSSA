using System;
using System.Collections.Generic;
using System.Text;

namespace Assignments6._2
{
    public class ProductExceptSelf
    {
        public int[] ProductOfNumsExceptSelf(int[] nums)
        {
            int length = nums.Length;
            int[] l = new int[length];
            int[] r = new int[length];
            int[] res = new int[length];

            l[0] = 1;
            for (int i = 1; i < length; i++)
            {
                l[i] = l[i - 1] * nums[i - 1];
            }
            r[length - 1] = 1;
            for (int i = length - 2; i >= 0; i--)
            {
                r[i] = r[i + 1] * nums[i + 1];
            }
            for (int i = 0; i < length; i++)
            {
                res[i] = l[i] * r[i];
            }

            return res;
            // and of course, this can be done in O(1) space by using the output array to store the left products
            // and then multiplying by the right products on the fly,but this is more straightforward to understand
        }
    }
    }
