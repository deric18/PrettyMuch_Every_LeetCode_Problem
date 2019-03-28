using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Solution
    {
        public int[] DailyTemperatures(int[] T)
        {
            int[] predictList = new int[T.Length];
            List<int> unsettledlist = new List<int>();
            int unsettled = 0;

            for (int i = 0; i < T.Length; i++)
            {
                int current = T[i];

                if (i + 1 < T.Length && T[i] < T[i + 1])
                {
                    predictList[i] = 1;
                }
                else
                {
                    unsettled++;
                    unsettledlist.Add(i);
                }

                if (unsettledlist.Count > 0)
                {
                    for (int k = 0; k < unsettledlist.Count; k++)
                    {
                        if (T[unsettledlist[k]] < current)
                        {
                            predictList[unsettledlist[k]] = i - unsettledlist[k];
                            unsettledlist.Remove(unsettledlist[k]);
                            k--;
                        }
                    }
                }
            }
            return predictList;
        }

        public class SortedIterator
        {
            private int NumLists;
            private int[] Indexes;
            private List<List<int>> SortedList;

            public SortedIterator(List<List<int>> sortelists)
            {
                NumLists = sortelists.Count;
                Indexes = new int[NumLists];
                SortedList = sortelists;
            }           
        }
        public class ListNode
        {
            public int Val;
            public ListNode next;

            public ListNode(int val)
            {
                Val = val;
                next = null;
            }
        }

        //public static void Main()
        //{
        //    Solution1 sol1 = new Solution1(23,34);

            

        //    Console.Read();
        //}

        public ListNode GetListNode(long num)
        {
            if (num == 0)
                return new ListNode(0);

            ListNode ret = null;
            ListNode head = null;
            int rem = 0;
            while (num != 0)
            {
                rem = (int)(num % 10);
                num = num / 10;
                ret = new ListNode(rem);
                if (head == null)
                    head = ret;
                else
                {
                    ret.next = head;
                    head = ret;
                }
            }

            return head;

        }

        public long GetNum(ListNode l1)
        {
            if (l1 == null)
                return 0;
            long num = 0;
            int indiceCount = 0;
            while (l1 != null)
            {
                if (num != 0)
                    num *= 10;
                num += l1.Val;                
                Console.WriteLine(num);
                l1 = l1.next;
            }

            return indiceCount >= 9 ? num : num / 10;
        }

        public int Add(int n1, int n2)
        {
            if (n2 == 0) return n1;
            int sum = n1 ^ n2;
            int carry = (n1 & n2) << 1;
            return Add(sum, carry);
        }

        public List<List<int>> FourSum(int[] nums, int target)
        {
            List<List<int>> ret = new List<List<int>>();
            List<List<int>> res = new List<List<int>>();
            if (nums.Length < 4)
                return ret;

            List<int> list = new List<int>();
            int a = nums[0], b = nums[1], c = nums[2], d = nums[3];

            res.Add(new List<int>() { a, b, c, d });

            for (int i = 4; i < nums.Length; i++)
            {
                int resindex = res.Count;
                for (int k = 0; k < resindex; k++)
                    for (int j = 0; j < 4; j++)
                    {
                        List<int> ls = new List<int>(res[k]);

                        ls.RemoveAt(j);
                        ls.Add(nums[i]);
                        res.Add(ls);
                    }
            }
            
            foreach (var item in res)
            {
                for (int i = 0; i < item.Count; i++)
                    Console.Write(item[i] + " ");
                if (item.Sum() == target )
                    ret.Add(item);
                Console.WriteLine();
            }

            for(int i=0;i<ret.Count;i++)
                for(int j=i+1;j<ret.Count;j++)
                {
                    var item = ret[i];
                    if (ret[i][0] == ret[j][0] && ret[i][1] == ret[j][1] && ret[i][2] == ret[j][2] && ret[i][3] == ret[j][3])
                        ret.RemoveAt(j);
                }


            return ret;
        }

        public class StockPlanner
        {
            private List<int> list;

            public StockPlanner()
            {
                list = new List<int>();
            }

            public int Next(int price)
            {
                list.Add(price);

                if (list.Count == 1)
                    return 1;

                int count = list.Count - 1;
                int ret = 1;

                while (count > 0)
                {
                    if (list[count - 1] > list[count - 1])
                    {
                        ++ret;
                        count--;
                    }
                    else
                        return ret;
                }

                return ret;
            }
        }
        public void Shift(String A)
        {
            char ch = A[0];
            A = A.Remove(0, 1);
            A += ch;
            Console.WriteLine(A);
        }

        public int Jump(int[] nums)
        {
            if (nums.Length == 0 || nums.Length == 1)
                return nums.Length;

            //handle for lenght = 2

            int[] dp = new int[nums.Length];
            for (int i = 0; i < dp.Length; i++)
                dp[i] = int.MaxValue;

            for (int i = nums.Length - 2; i >= 0; i--)
            {
                if (nums[i] >= nums.Length - 1 - i)
                {
                    dp[i] = 1;
                }
                else
                {
                    int min = int.MaxValue;
                    for (int j = i; j <= i + nums[i] && j < dp.Length - 1; j++)
                    {
                        min = Math.Min(dp[j], min);
                    }
                    min = min == int.MaxValue ? min - 1 : min;
                    dp[i] = min + 1;
                }
            }



            return dp[0];
        }



        public int UniqueLetterString(string S)
        {
            Queue<int> q = new Queue<int>();            
            int[] arr = new int[4];
            int a = arr[0], b = arr[1], c, d;
            List<List<int>> res = new List<List<int>>();
            List<int> list = new List<int>();
            ulong count = 0;
            ulong modulo = (ulong)Math.Pow(10, 9) + 7;

            for (int i = 0; i < S.Length; i++)
            {
                for (int j = S.Length - 1; j > 0; j--)
                {
                    count += Uniques(S.Substring(i, j));
                }
            }
            return 0;
        }        

        public ulong Uniques(string s)
        {
            HashSet<char> set = new HashSet<char>();

            
            set.Add('c');
            set.Add('k');
            string k = null;           
            Console.WriteLine(k);
            ulong count = 0;
            foreach (var c in s)
            {
                if (!set.Contains(c))
                {
                    count++;
                    set.Add(c);
                }
            }

            return count;
        }

        //public int LongestIncreasingPath(int[,] matrix)
        //{
        //    int maxpath = 0;

        //    for(int i=0;i<matrix.GetLength(0);i++)
        //        for(int j=0;j<matrix.GetLength(1);j++)
        //        {
        //            int len = dfs(matrix, i, j);
        //            maxpath = len > maxpath ? len : maxpath;
        //        }

        //    return maxpath;
        //}

        //public class Node
        //{
        //    public int x;
        //    public int y;
        //    public int val;

        //    public Node(int a, int b, int Val)
        //    {
        //        x = a;
        //        y = b;
        //        val = Val;
        //    }
        //}

        //public int bfs(int[,] graph, int i, int j)
        //{
        //    bool[,] visited = new bool[graph.GetLength(0),graph.GetLength(1)];
        //    int path = 0;
        //    Stack<Node> s = new Stack<Node>();

        //    s.Push(new Node(i, j, graph[0, 0]));
        //    while(s.Count != 0)
        //    {
        //        Node temp = s.Pop();               

        //        if(visited[temp.x,temp.y] != true)
        //        {
        //            path++;
        //            visited[temp.x, temp.y] = true;
        //            if(PushCheck(temp.x+1,temp.y, graph, visited) && graph[temp.x+1,temp.y] > graph[temp.x,temp.y])
        //            {                        
        //                s.Push(new Node(temp.x + 1, temp.y, graph[temp.x + 1, temp.y]));
        //            }
        //            if(PushCheck(temp.x-1, temp.y, graph, visited) && graph[temp.x - 1, temp.y] > graph[temp.x, temp.y])
        //            {
        //                s.Push(new Node(temp.x - 1, temp.y));
        //            }
        //            if(PushCheck(temp.x, temp.y + 1, graph, visited) && graph[temp.x, temp.y+1] > graph[temp.x, temp.y])
        //            {
        //                s.Push(new Node(temp.x, temp.y + 1));
        //            }
        //            if(PushCheck(temp.x, temp.y -1, graph, visited) && graph[temp.x, temp.y-1] > graph[temp.x, temp.y])
        //            {
        //                s.Push(new Node(temp.x, temp.y - 1));
        //            }
        //        }
        //    }

        //    return path;
        //}

        //public bool PushCheck(int x, int y, int[,] graph, bool[,] visited)
        //{
        //    if (x >= graph.GetLength(0) || x - 1 < 0 || y >= graph.GetLength(1) || y < 0 && visited[x,y])
        //        return false;

        //    return true;
        //}

        public int UniquePathsWithObstacles(int[,] obstacleGrid)
        {
            return dfs(obstacleGrid);
        }
        public class Node1
        {
            public int i;
            public int j;
            public bool visited;
            public Node1(int x, int y)
            {
                i = x;
                j = y;
                visited = false;
            }
        }

        public int dfs(int[,] graph)
        {
            int m = graph.GetLength(0);
            int n = graph.GetLength(1);
            bool[,] visited = new bool[m, n];
            int paths = 0;
            

            Stack<Node1> s = new Stack<Node1>();            
            s.Push(new Node1(0, 0));
            while (s.Count != 0)
            {
                Node1 node = s.Pop();

                if (node.i == m - 1 && node.j == n - 1)
                {
                    paths++;
                    s.Push(new Node1(0, 0));
                    continue;
                }

                if (!visited[node.i, node.j])
                {
                    if (node.i != 0 && node.j != 0)
                        visited[node.i, node.j] = true;
                    if (node.i + 1 < m && graph[node.i + 1, node.j] == 0)
                    {
                        s.Push(new Node1(node.i + 1, node.j));
                    }
                    if (node.j + 1 < n && graph[node.i, node.j + 1] == 0)
                        s.Push(new Node1(node.i, node.j + 1));
                }
            }

            return paths;
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val)
            {
                this.val = val;
                left = null;
                right = null;
            }
        }

        public List<List<int>> ZigzagLevelOrder(TreeNode root)
        {
            List<List<int>> retList = null;

            if (root == null)
                return retList;

            retList = new List<List<int>>();

            int height = GetHeight(root);

            for (int i = 0; i < height; i++)
            {
                List<int> list = new List<int>();
                PrintLevel(root, i, ref list);
                if (i % 2 != 0)
                    list.Reverse();
                retList.Add(list);
            }

            return retList;
        }

        public int GetHeight(TreeNode root)
        {
            if (root == null)
                return 0;

            int lheight = GetHeight(root.left);
            int rheight = GetHeight(root.right);

            return Math.Max(lheight + 1, rheight + 1);
        }

        public void PrintLevel(TreeNode root, int height, ref List<int> list)
        {
            if (root == null)
                return;

            if (height == 0)
            {
                list.Add(root.val);
            }
            else
            {
                PrintLevel(root.left, height - 1, ref list);
                PrintLevel(root.right, height - 1, ref list);
            }

        }

        public int Trap(int[] height)
        {
            int totalV = 0;
            int left = 0;
            int right = 1;
            int min = int.MaxValue;
            for (int i = 0; i < height.Length; i++)
            {
                if (height[i] > 0 && (i + 1 < height.Length))
                {
                    left = i;
                    right = left + 1;
                    min = Math.Min(height[i], min);
                    while (right < height.Length - 1 && height[left] > height[right])
                    {
                        right++;
                        min = Math.Min(height[right], min);
                    }
                    if (right == height.Length - 1)
                    {
                        left++;
                        i = left - 1;
                        continue;
                    }
                    if (right - left >= 2)
                        totalV += Calculate(left, right, height);
                    i = right - 1;
                }
            }

            return totalV;
        }

        public int Calculate(int left, int right, int[] height)
        {
            int val = 0;
            for (int i = left + 1; i < right; i++)
            {
                if (height[i] < height[left])
                {
                    val += height[left] - height[i];
                }
                else
                {
                    return 0;
                }
            }
            return val;
        }
        public class MyStack
        {
            List<int> list;
            int top = 0;
            /** Initialize your data structure here. */
            public MyStack()
            {
                list = new List<int>();
            }

            /** Push element x onto stack. */
            public void Push(int x)
            {
                list.Add(x);
                top++;
            }

            /** Removes the element on top of the stack and returns that element. */
            public int Pop()
            {
                int temp = list[top];
                list.RemoveAt(top);
                top--;
                return temp;
            }

            /** Get the top element. */
            public int Top()
            {
                return top;
            }

            /** Returns whether the stack is empty. */
            public bool Empty()
            {
                return top == 0;
            }
        }

        public string ConvertToTitle(int n)
        {
            string str = null;

            if (n > 26)
            {
                int div = n / 26;
                int rem = n % 26;
                if (div > 26)
                {
                    while (div > 26)
                    {
                        str += 'z';
                    }
                    if (rem != 0)
                    {
                        str += (char)(64 + rem);
                    }
                }
                else
                {
                    str += (char)(64 + div);
                    str += (char)(64 + rem);
                }
            }
            else
            {
                str += (char)(64 + n);                
                
            }
            return str;
        }

        public int LongestConsecutive(int[] nums)
        {            
            Dictionary<int, int> dict = new Dictionary<int, int>();
            List<int[]> ls = new List<int[]>();
            Dictionary<int, List<int>> dict1 = new Dictionary<int, List<int>>();
            List<List<int>> res = new List<List<int>>();

            foreach(var i in dict1.Keys)
            {
                List<int> list = dict1[i];
                res.Add(list);
            }

            for (int i = 0; i < nums.Length; i++)
                dict.Add(nums[i], 0);

            int maxseq = 1;

            var enumerator = dict.GetEnumerator();
            int val = 0;
            for (int i = 0; i < dict.Count; i++)
            {
                int num = dict.Keys.ElementAt(i);
                int seq = 1;
                while (dict.TryGetValue(num + 1, out val))
                {
                    seq++;
                    num += 1;
                }
                maxseq = Math.Max(seq, maxseq);
            }

            return maxseq;
        }


        //public IList<IList<string>> Partition(string s)
        //{
        //    IList<IList<string>> list = null;

        //    if (s?.Length == 0 || s == null)
        //        return list;

        //    Dictionary<string, int> dict = new Dictionary<string, int>();

        //    for (int i = 0; i < s.Length; i++)
        //    {
        //        for (int j = i+1; j < s.Length; j++)
        //        {
        //            string str = s.Substring(i, j);
        //            if (IsPlaindrome(str))
        //            {
        //                int val = 0;
        //                if(dict.TryGetValue(str, out val))
        //                {

        //                }
        //                else
        //                {
        //                    dict.Add(str, val);
        //                }
        //            }                                                                           s

        //        }
        //    }

        //}

        public bool IsPlaindrome(string str)
        {
            if (str.Length == 0)
                return false;
            int len = str.Length;
            for (int i = 0; i < len; i++)
            {
                if (str[i] != str[len - 1 - i])
                    return false;
            }

            return true;
        }

        public bool IsInterleave(string s1, string s2, string s3)
        {

            int first = 0;
            int second = 0;
            int i = 0;
            while (i < s3.Length)
            {
                bool flag = false;
                while (i < s3.Length && s3[i] == s1[first])
                {
                    i++;
                    first++;
                    flag = true;
                }
                while (second < s2.Length && s3[i] == s2[second])
                {
                    i++;
                    second++;
                    flag = true;
                }
                if (!flag)
                    break;
            }

            Console.WriteLine(first);
            return first == s1.Length && second == s2.Length;
        }

        //public int FindCircleNum(int[,] M)
        //{

        //}

        //public int NumCircles(int[,] M, int i, int j, bool[,] visited)
        //{
        //    if (i >= M.GetLength(0) || i < 0 || j < 0 || j >= M.GetLength(1))
        //        return 0;

        //    if(M[i,j] == 1)
        //    {
        //        visited[i, j] = true;             
        //        return NumCircles(M,i+1,j) 
        //    }

        //    return 0;
        //}

        public int RemoveDuplicates(ref int[] nums)
        {

            List<int> list = nums.ToList();

            for (int i = 0; i < list.Count; i++)
            {
                int j = i + 1;
                int counter = 0;
                while (j < list.Count && list[i] == list[j])
                {
                    counter++;
                    Console.WriteLine(counter);
                    if (counter > 1)
                    {
                        list.RemoveAt(j);
                        j--;
                    }
                    j++;
                }
            }

            nums = list.ToArray();
            return nums.Length;

        }
    }
    public class Solution1 : Solution
    {
        private int[,] arr;
        private Random rnd = new Random();

        public Solution1(int n_rows, int n_cols)
        {
            arr = new int[n_rows, n_cols];
            rnd = new Random();
        }

        public int[] Flip()
        {
            int[] ret = new int[2];
            ret[0] = rnd.Next(0, arr.GetLength(0));
            ret[1] = rnd.Next(0, arr.GetLength(1));
            arr[ret[0], ret[1]] = 1;

            return ret;
        }

        public void Reset()
        {
            
        }
    }
}
