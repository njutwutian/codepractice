using System;
using System.Collections.Generic;
using System.Text;

namespace CodePractice
{
    public class QueenSolution
    {

        private int[] res; // 存放一个解，下标是皇后所在的行，值是列, cheaper space cost
        private int n; // 几皇后问题
        private List<List<String>> result = new List<List<string>>(); // 存放所有的解

        public List<List<String>> solveNQueens(int n)
        {
            res = new int[n];
            this.n = n;
            calculateNQueens(0);
            return result;
        }

        private void calculateNQueens(int row)
        {
            if (row == n)
            {
                // 产生了一种结果, 加入到结果集合
                addToResult();
                return;
            }
            for (int column = 0; column < n; column++)
            {
                if (isOK(row, column))
                {
                    res[row] = column;
                    // 放置下一行,注意这里不能写++row，不能改变row原来的值
                    calculateNQueens(row + 1);
                }
            }
        }

        private bool isOK(int row, int column)
        {
            // 对角线上上一行所在的列
            int leftUp = column - 1, rightUp = column + 1;
            for (int i = row - 1; i >= 0; i--)
            {
                // res[i]表示第i行皇后在哪个位置，不能在column,leftUp,rightUp三个位置
                if (res[i] == column)
                { // 第i行的column列有皇后吗？
                    return false;
                }
                if (leftUp >= 0 && res[i] == leftUp)
                {
                    return false;
                }
                if (rightUp < n && res[i] == rightUp)
                {
                    return false;
                }
                leftUp--;
                rightUp++;
            }
            return true;
        }

        private void addToResult()
        {
            List<String> solution = new List<string>();
            for (int i = 0; i < n; i++)
            {
                int hasQueue = res[i];
                StringBuilder sb = new StringBuilder();
                for (int j = 0; j < n; j++)
                {
                    if (j == hasQueue)
                    {
                        sb.Append('Q');
                    }
                    else
                    {
                        sb.Append('.');
                    }
                }
                solution.Add(sb.ToString());
            }
            result.Add(solution);
        }
    }
}
