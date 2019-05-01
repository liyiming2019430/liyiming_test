using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //string str = "";
            //str.Insert(0, "a");
            //Console.WriteLine(TwoCharSubtraction('0', '1'));
            //Console.WriteLine(AddBinary("11", "1"));
            //TestLevelOrderBottom();
            Console.ReadKey();
        }

        public static void TestLevelOrderBottom()
        {
            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(9);
            root.right = new TreeNode(20);
            root.right.left = new TreeNode(15);
            root.right.right = new TreeNode(7);

            var list = LevelOrderBottom(root);
            foreach (var itemList in list)
            {
                string str = string.Empty;
                foreach (var item in itemList)
                {
                    str += item + ",";
                }
                Console.WriteLine(str);
            }
        }
        public static IList<IList<int>> LevelOrderBottom_0(TreeNode root)
        {
            List<IList<int>> rList = new List<IList<int>>();
            if (root == null) return rList;
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                List<int> list = new List<int>();
                int count = q.Count;
                for (int i = 0; i < count; ++i)
                {
                    TreeNode node = q.Dequeue();
                    list.Add(node.val);
                    if (node.left != null) q.Enqueue(node.left);
                    if (node.right != null) q.Enqueue(node.right);
                }
                rList.Add(list);
            }
            rList.Reverse();
            return rList;

        }

        public static IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            List<IList<int>> rList = new List<IList<int>>();
            if (root == null) return rList;
            LevelOrderBottom(rList, 0, root);
            rList.Reverse();

            return rList;
        }

        public static void LevelOrderBottom(IList<IList<int>> rList, int level, TreeNode node)
        {
            if (node == null) return;
            if (rList.Count == level) rList.Add(new List<int>());
            rList[level].Add(node.val);
            if (node.left != null) LevelOrderBottom(rList, level + 1, node.left);
            if (node.right != null) LevelOrderBottom(rList, level + 1, node.right);
        }

        public static string AddBinary(string a, string b)
        {
            int aIdx = a.Length - 1, bIdx = b.Length - 1, carry = 0;
            string ret = "";

            while (aIdx >= 0 || bIdx >= 0)
            {
                int m = aIdx >= 0 ? a[aIdx--] - '0' : 0;
                int n = bIdx >= 0 ? b[bIdx--] - '0' : 0;
                int add = m + n + carry;
                ret = ret.Insert(0, (add % 2).ToString());
                carry = add / 2;
            }

            if (carry == 1) ret = ret.Insert(0, "1");
            return ret;
        }

        private static int TwoCharSubtraction(char a, char b)
        {
            Console.WriteLine("a:" + a + " b:" + b);
            return b - a;
        }
    }
}
