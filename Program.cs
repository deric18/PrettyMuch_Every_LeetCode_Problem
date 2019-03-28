using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleApp1 {
    class Solution12
    {
        private int number;

        public Solution12()
        { number = 12; }
                

        public static void Main(string[] args)
        {
            int amt = 11;
            int[] coins = new int[3] { 1, 2, 5 };
            HashSet<int> set = new HashSet<int>();
            foreach (var i in coins)
                set.Add(i);
            int len = coins.Length;
            int[] dp = new int[coins.Length];
            for(int i=0;i<len;i++)
            {
                dp[i] = amt % coins[i];
            }
            int numcoins = 0;
            for(int i=len-1;i>=0;i--)
            {
                if(set.Contains(dp[i]))
                {
                    numcoins = amt / coins[i];
                    numcoins = (numcoins + 1);
                }
            }

            return -1;
            
            Console.Read();
        }
    }
    public class Solution3
    {
        public IList<IList<string>> GroupStrings(string[] strings)
        {        //["", ""], ["pq", "rs"]
            IList<IList<string>> res = new List<IList<string>>();
            if (strings == null | strings.Length == 0)
                return res;

            List<string> list = new List<string>();
            HashSet<int> set = new HashSet<int>();

            for (int i = 0; i < strings.Length; i++)
            {
                string s1 = strings[i];
                if (string.IsNullOrWhiteSpace(s1) || (!set.Contains(i)))
                    continue;
                for (int j = i + 1; j < strings.Length; j++)
                {
                    if (set.Contains(j))
                        continue;
                    string s2 = strings[j];

                    if (string.IsNullOrWhiteSpace(s2))
                        continue;

                    if (s1.Length == s2.Length)
                    {
                        int prevdiff = 0;
                        int diff = 0;
                        int p = 0;
                        for (; p < s1.Length; p++)
                        {
                            diff = Math.Abs((int)s1[p] - (int)s2[p]);

                            if (p == 0)
                                prevdiff = diff;

                            if (diff != prevdiff)
                                break;

                        }

                        if (p == s1.Length)
                        {
                            set.Add(j);
                            list.Add(s2);
                        }
                    }
                }

                set.Add(i);
                list.Add(s1);
                res.Add(list);
                list.Clear();
            }

            return res;
        }
    }
    public class Solution2
    {
        public int NumIslands(char[,] grid)
        {
            bool[,] visited = new bool[grid.GetLength(0), grid.GetLength(1)];

            for (int i = 0; i < grid.GetLength(0); i++)
                for (int j = 0; j < grid.GetLength(1); j++)
                    visited[i, j] = false;

            int count = 0;

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (!visited[i, j] && grid[i, j] == '1')
                    {
                        if (bfs(grid, i, j, ref visited))
                        {
                            Console.WriteLine("-");
                            count++;
                        }
                    }
                }
            }

            return count;
        }

        public bool bfs(char[,] grid, int i, int j, ref bool[,] visited)
        {
            if (!check(grid, i, j, visited))
                return false;

            Queue<int[]> queue = new Queue<int[]>();

            queue.Enqueue(new int[2] { i, j });

            while (queue.Count != 0)
            {
                int[] index = queue.Dequeue();
                visited[index[0], index[1]] = true;

                if (check(grid, i + 1, j, visited))
                {
                    Console.WriteLine((i + 1).ToString() + " " + j.ToString());
                    queue.Enqueue(new int[2] { i + 1, j });
                }
                if (check(grid, i - 1, j, visited))
                {
                    Console.WriteLine((i - 1).ToString() + " " + j.ToString());
                    queue.Enqueue(new int[2] { i - 1, j });
                }
                if (check(grid, i, j + 1, visited))
                {
                    Console.WriteLine((i).ToString() + " " + j.ToString());
                    queue.Enqueue(new int[2] { i, j + 1 });
                }
                if (check(grid, i, j - 1, visited))
                {
                    Console.WriteLine((i.ToString()), j.ToString());
                    queue.Enqueue(new int[2] { i, j - 1 });
                }
            }

            return true;
        }

        public bool check(char[,] grid, int i, int j, bool[,] visited)
        {
            if (i < 0 || i >= grid.GetLength(0) || j < 0 || j >= grid.GetLength(1) || grid[i, j] == '0' || visited[i, j])
                return false;

            return true;
        }
    }
}