#nullable enable
using System;
using System.Collections.Generic;

namespace ConsoleApp4
{
    public class ListNode
    {
        public int Val { get; }
        public ListNode? Next { get; set; }

        public ListNode(int val = 0, ListNode? next = null)
        {
            Val = val;
            Next = next;
        }
    }

    public static class ListNodeExtensions
    {
        public static void Remove(ref ListNode? head, int index)
        {
            var current = head;
            var temp = new Dictionary<int, ListNode>();

            for (var i = 0; current is { }; i++)
            {
                temp.Add(i, current);
                current = current.Next;
            }

            if(index > temp.Count) throw new IndexOutOfRangeException();

            if (index == temp.Count)
            {
                head = head?.Next;
                return;
            }

            var prevIndex = temp.Count - index - 1;
            var prevNode = temp.GetValueOrDefault(prevIndex)!;

            prevNode.Next = prevNode.Next?.Next;
        }

        public static void Print(this ListNode? node)
        {
            while (true)
            {
                if (node is null) return;

                Console.WriteLine(node.Val);
                node = node.Next;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var head = new ListNode(1,
                new ListNode(2,
                    new ListNode(3,
                        new ListNode(4,
                            new ListNode(5)))));

            head.Print();
            ListNodeExtensions.Remove(ref head, 5);
            head.Print();
            Console.ReadKey();
        }
    }
}
