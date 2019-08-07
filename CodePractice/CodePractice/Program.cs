using System;
using System.Collections.Generic;
using System.Text;

namespace CodePractice
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<List<string>> queenResult = new QueenSolution().solveNQueens(4);
            Console.WriteLine("Hello World!");
            Console.WriteLine(new Program().MySqrt(66));
            Console.WriteLine(new Program().MySqrt(128));
            Console.WriteLine(new Program().MySqrt(166));
            Console.WriteLine(new Program().MySqrt(266));
            Console.WriteLine(new Program().MySqrt(366));
            Console.ReadLine();
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
            if (J.Length == 0 || S.Length == 0)
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
        /// 709. To Lower Case
        /// Runtime: 92 ms, faster than 32.49% of C# online submissions for To Lower Case.
        /// Memory Usage: 20.7 MB, less than 5.15% of C# online submissions for To Lower Case.
        /// </summary>
        public string ToLowerCase(string str)
        {
            Byte[] bytes = Encoding.ASCII.GetBytes(str);
            for (int i = 0; i < bytes.Length; i++)
            {
                if (bytes[i] > 64 && bytes[i] < 91)
                {
                    bytes[i] = Convert.ToByte(bytes[i] + 32);
                }
            }
            return Encoding.ASCII.GetString(bytes);
        }

        /// <summary>
        /// 1021. Remove Outermost Parentheses
        /// Runtime: 88 ms, faster than 85.36% of C# online submissions for Remove Outermost Parentheses.
        /// Memory Usage: 21.7 MB, less than 66.18% of C# online submissions for Remove Outermost Parentheses.
        /// </summary>
        /// <param name="S"></param>
        /// <returns></returns>
        public string RemoveOuterParentheses(string S)
        {
            bool hashead = false;
            StringBuilder sb = new StringBuilder();
            int balance = 0;
            foreach (var s in S)
            {
                if (s.Equals('('))
                {
                    balance++;
                    if (hashead)
                    {
                        sb.Append(s);
                    }
                    else
                    {
                        hashead = true;
                    }
                }
                else
                {
                    balance--;
                    if (balance == 0)
                    {
                        hashead = false;
                    }
                    else
                    {
                        sb.Append(s);
                    }
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// 804. Unique Morse Code Words
        /// Runtime: 92 ms, faster than 96.56% of C# online submissions for Unique Morse Code Words.
        /// Memory Usage: 23.4 MB, less than 6.52% of C# online submissions for Unique Morse Code Words.
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public int UniqueMorseRepresentations(string[] words)
        {
            var transformations = new Dictionary<string,int>();
            for (int i = 0; i < words.Length; i++)
            {
                string temp = WordToMorse(words[i]);
                if (!transformations.ContainsKey(temp)) {
                    transformations.Add(temp,0);
                }                
            }
            return transformations.Count;
        }

        private string WordToMorse(string word)
        {
            var morseCode = new string[] {".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",
            ".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."};
            var sb = new StringBuilder();

            for (int i = 0; i < word.Length; i++)
            {
                sb.Append(morseCode[word[i] - 'a']);
            }

            return sb.ToString();
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
                Iterator(current.left, L, R);
            }
            if (current.val >= L && current.val <= R)
            {
                RangeSumBSTResult = RangeSumBSTResult + current.val;
            }
            if (current.right != null && current.val <= R)
            {
                Iterator(current.right, L, R);
            }
        }

        /// <summary>
        /// 69. Sqrt(x)
        /// Runtime: 52 ms, faster than 26.96% of C# online submissions for Sqrt(x).
        /// Runtime: 44 ms, faster than 56.41% of C# online submissions for Sqrt(x).
        /// Runtime: 36 ms, faster than 97.83% of C# online submissions for Sqrt(x).
        /// Memory Usage: 12.8 MB, less than 100.00% of C# online submissions for Sqrt(x).
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int MySqrt(int x)
        {
            if (x <= 1) {
                return x;
            }
            int start = 1;
            int end = x;
            int mid = start + (end - start) / 2;

            // i^2 <=x &&i+1^2 >x 
            while (true)
            {
                if (mid <= x /mid && ((mid + 1) > x / (mid + 1)))
                {
                    return mid;
                }
                if (mid < x / mid)
                {
                    start = mid+1;
                    mid = start + (end-start) / 2;
                }
                else {
                    end = mid-1;
                    mid = start + (end - start) / 2;
                }
            }
        }

        /// <summary>
        /// 914. X of a Kind in a Deck of Cards
        /// </summary>
        /// <param name="deck"></param>
        /// <returns></returns>
        public bool HasGroupsSizeX(int[] deck)
        {
            if (deck.Length >= 2)
            {

            }
            return false;
        }

        public int TotalNQueens(int n)
        {
            int[,] array = new int[n, n];
            for (int j = 0; j < n; j++)
            {
                array[0, j] = 1;
                UpdateArrayStatus(array, 0, j, n, 1);
                int count = 2;
                for (int i = 1; i < n; i++)
                {
                    int y = GetAvailableQueen(array, i, n, count);
                    if (y > -1)
                    {
                        UpdateArrayStatus(array, i, y, n, count);
                        count++;
                    }
                }
                PrintArray(array, n, count);
                array = new int[n, n];


            }

            //int y = GetAvailableQueen(array, 0, n, 1);
            //UpdateArrayStatus(array, 0, y, n, 1);
            //GetAvailableQueen(array,n);
            //PrintArray(array,n);

            return n;
        }

        public int GetAvailableQueen(int[,] temp, int x, int n, int count)
        {
            int tempY = -1;
            for (int i = 0; i < n; i++)
            {
                if (temp[x, i] == 0)
                {
                    temp[x, i] = count;
                    tempY = i;
                    Console.WriteLine("{0},{1}", x, i);
                    return tempY;
                }
            }
            return tempY;
        }



        int[,] UpdateArrayStatus(int[,] temp, int x, int y, int n, int count)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == x && j == y)
                    {
                        temp[i, j] = count;
                    }
                    else if (i == x || j == y || Math.Abs(i - x) == Math.Abs(j - y))
                    {
                        temp[i, j] = -1;
                    }
                }
            }
            return temp;
        }

        void PrintArray(int[,] temp, int n, int count)
        {
            Console.WriteLine("================RESULT:{0}================", count);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(string.Format("{0,-5}", temp[i, j]));
                }
                Console.WriteLine();
            }
            Console.WriteLine("================RESULT:{0}================", count);
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
