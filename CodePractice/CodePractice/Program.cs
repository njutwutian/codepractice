using System;

namespace CodePractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        /// <summary>
        /// 1108. Defanging an IP Address
        /// Runtime: 88 ms, faster than 74.46% of C# online submissions for Defanging an IP Address.
        /// Memory Usage: 21 MB, less than 100.00% of C# online submissions for Defanging an IP Address.
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public string DefangIPaddr(string address)
        {
            var temp = address.Split('.');
            return string.Format("{0}[.]{1}[.]{2}[.]{3}", temp[0], temp[1], temp[2], temp[3]);
        }

        /// <summary>
        /// 771. Jewels and Stones
        /// Runtime: 92 ms, faster than 15.25% of C# online submissions for Jewels and Stones.
        /// Memory Usage: 20.9 MB, less than 98.94% of C# online submissions for Jewels and Stones.
        /// </summary>
        /// <param name="J"></param>
        /// <param name="S"></param>
        /// <returns></returns>
        public int NumJewelsInStones(string J, string S)
        {
            int result = 0;
            if (J.Length == 0||S.Length==0)
            {
                return result;
            }

            for (int i = 0; i < S.Length; i++)
            {
                for (int j = 0; j < J.Length; j++)
                {
                    result = S[i].Equals(J[j]) ? result + 1 : result;
                }
            }
            return result;
        }

        /// <summary>
        /// 938. Range Sum of BST
        /// Runtime: 200 ms, faster than 29.69% of C# online submissions for Range Sum of BST.
        /// Memory Usage: 42.5 MB, less than 19.51% of C# online submissions for Range Sum of BST. 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="L"></param>
        /// <param name="R"></param>
        /// <returns></returns>
        int RangeSumBSTResult = 0;
        public int RangeSumBST(TreeNode root, int L, int R)
        {
            Iterator(root, L, R);
            return RangeSumBSTResult;
        }

        public void Iterator(TreeNode current, int L, int R)
        {
            if (current.left != null && current.val >= L)
            {
                Iterator(current.left,L,R);
            }
            if (current.val >= L && current.val <= R)
            {
                RangeSumBSTResult = RangeSumBSTResult + current.val;
            }
            if (current.right != null && current.val <=R)
            {
                Iterator(current.right,L,R);
            }
        }
    }

    public class TreeNode
    {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { val = x; }
    }
}
