using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class Program
    {
        public class Tree
        {
            public Tree left, middle, right = null;
            public static int k;
            public int value;
            public int Value
            {
                get { return value; }
                set { this.value = value; }
            }
            public Tree() {}
            public Tree(int value)
                { Value = value; }
        }

        public int value(Tree node)
        {
            return node.Value;
        }

        Tree now = null;
        public Tree traverse(Tree node)
        {
            Tree temp;
            if (now == null)
            {
                now = start;
                return traverse(node);
            }
            else
            {
                if (value(node) < value(now) - Tree.k)
                {
                    if (now.left != null)
                        now = now.left;
                    else
                    {
                        temp = now;
                        now = null;
                        return temp;
                    }
                }
                else if (value(node) >= value(now) - Tree.k && value(node) <= value(now) + Tree.k)
                {
                    if (now.middle != null)
                        now = now.middle;
                    else
                    {
                        temp = now;
                        now = null;
                        return temp;
                    }
                }
                else if (value(node) > value(now) + Tree.k)
                {
                    if (now.right != null)
                        now = now.right;
                    else
                    {
                        temp = now;
                        now = null;
                        return temp;
                    }
                }
                return traverse(node);
            }
        }

        static Tree start = null;
        static Tree tree = null;
        public void insert(Tree node)
        {
            //Tree temp;
            if (start == null)
            {
                start = node;
                tree = start;                
            }
            else
            {
                tree = traverse(node);
                if (value(node) < value(tree) - Tree.k) tree.left = node;
                else if (value(node) >= value(tree) - Tree.k && value(node) <= value(tree) + Tree.k) tree.middle = node;
                else if (value(node) > value(tree) + Tree.k) tree.right = node;
            }
        }
        public void show(Tree node)
        {
            Tree temp = start;
            Console.Write("{0}->", node.Value);
            do
            {
                if (value(node) < value(temp) - Tree.k)
                {
                    if (temp.left != null)
                    {
                        temp = temp.left;
                    }
                    else break;
                }
                else if (value(node) >= value(temp) - Tree.k && value(node) <= value(temp) + Tree.k)
                {
                    if (temp.middle != null)
                    {
                        temp = temp.middle;
                    }
                    else break;
                }
                else if (value(node) > value(temp) + Tree.k)
                {
                    if (temp.right != null)
                    {
                        temp = temp.right;
                    }
                    else break;
                }
                Console.Write("{0}->", node.Value);
            } while (temp.left != null || temp.middle != null || temp.right != null);
        }
        
        public void show()
        {
            if (start != null)
            {
                Console.Write(" {0} ", start.Value);
                now2 = start;
            }
            showit();
        }

        Tree now2 = null;
        public void showit()
        {
            Tree temp;
            if (now2 != null)
            {
                temp = now2;
                now2 = temp.left;
                if (now2 != null) Console.Write(" {0} ", now2.Value);
                showit();

                now2 = temp.middle;
                if (now2 != null) Console.Write(" {0} ", now2.Value);
                showit();

                now2 = temp.right;
                if (now2 != null) Console.Write(" {0} ", now2.Value);
                showit();
            }
            else
            {
                now2 = start;
                return;
            }
        }

        public bool check(int val)
        {
            if (start.Value == val) return true;
            Tree temp = start; //else
            do
            {
                if (val < value(temp) - Tree.k)
                {
                    if (temp.left != null)
                    {
                        temp = temp.left;
                        if (temp.Value == val) return true;
                    }
                    else return false;
                }
                else if (val >= value(temp) - Tree.k && val <= value(temp) + Tree.k)
                {
                    if (temp.middle != null)
                    {
                        temp = temp.middle;
                        if (temp.Value == val) return true;
                    }
                    else return false;
                }
                else if (val > value(temp) + Tree.k)
                {
                    if (temp.right != null)
                    {
                        temp = temp.right;
                        if (temp.Value == val) return true;
                    }
                    else return false;
                }
            } while (temp.left != null || temp.middle != null || temp.right != null);
            return false;
        }

        static void Main(string[] args)
        {
            int num;
            char c;
            Tree.k = 0;
            Tree leaf;
            Program program = new Program();
            while (true)
            {
                Console.WriteLine("For insert, show, check push i,s,c");

                c = Convert.ToChar(Console.ReadLine());
                if (c == 'i')
                {
                    num = Convert.ToInt32(Console.ReadLine());
                    leaf = new Tree(num);
                    program.insert(leaf);
                }
                else if (c == 's')
                {
                    //program.show(leaf);
                    Console.WriteLine();
                    program.show();
                    Console.WriteLine();
                }
                else if (c == 'c')
                {
                    num = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(program.check(num));
                }
                else continue;
            }
        }
    }
}
