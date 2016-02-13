namespace Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DataStructuresAlgorithms;
    using NUnit.Framework;
    [TestFixture]
    public class Unit2
    {
        [TestCase(null, 0)]
        [TestCase(new int[] { }, 0)]
        [TestCase(new int[] { 1 }, 1)]
        [TestCase(new int[] { 1, 2, 3 }, 3)]
        [TestCase(new int[] { 1, 2, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 }, 3)]
        [TestCase(new int[] { 3, 1, 3, 2, 3, 3 }, 3)]
        [TestCase(new int[] { 3, 3, 3, 3, 3, 3, 1, 2, 3 }, 3)]
        [TestCase(new int[] { 1, 3, 3, 3, 3, 3, 3, 3, 2, 3, 4 }, 4)]
        [TestCase(new int[] { 3, 3, 3, 3, 3, 1, 3, 3, 3, 3, 3, 3, 3, 2, 3, 3, 3, 3, 3, 3, 3, 3 }, 3)]
        public void NoDups(IEnumerable<int> data, int count)
        {
            LinkedList<int> list;
            if (data != null)
            {
                list = new LinkedList<int>(data);
                ListOperations.RemoveDups(list);
                Assert.AreEqual(count, list.Count);
            }
            else
            {
                list = null;
                ListOperations.RemoveDups(list);
            }
        }

        [TestCase(new int[] { }, 0, 0)]
        [TestCase(new int[] { }, 3, 0)]
        [TestCase(new int[] { 1 }, 3, 0)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 1, 9)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 2, 8)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 3, 7)]
        public void NThElement(IEnumerable<int> data, int n, int element)
        {
            var list = new LinkedList<int>(data);
            Assert.AreEqual(element, ListOperations.NThElement(list, n));
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 })]
        public void RemoveFromSingle(IEnumerable<int> data, int[] goodData)
        {
            var list = new LinkedList<int>();
            var random = new Random();
            int k = random.Next(list.Count - 1);
            var node = list.First;
            for (int i = 0; i < k; ++i)
            {
                node = node.Next;
            }
            ListOperations.RemoveNodeInSingleLinked(node);
            var head = list.First;
            foreach (int t in goodData)
            {
                Assert.AreEqual(head.Value, t);
                head = head.Next;
            }
        }

        [TestCase(new int[] { 3, 1, 5 }, new int[] { 5, 9, 2 }, new int[] { 8, 0, 8 })]
        [TestCase(new int[] { 3, 2, 1 }, new int[] { 7, 7, 8 }, new int[] { 0, 0, 0, 1 })]
        [TestCase(new int[] { 9, 9, 9, 9 }, new int[] { 1 }, new int[] { 0, 0, 0, 0, 1 })]
        [TestCase(new int[] { 1 }, new int[] { 9, 9, 9, 9 }, new int[] { 0, 0, 0, 0, 1 })]
        public void SumLists(IEnumerable<int> data1, IEnumerable<int> data2, int[] good)
        {
            var output = ListOperations.Sum(new LinkedList<int>(data1), new LinkedList<int>(data2));
            Assert.AreEqual(good.Length, output.Count);
            var head = output.First;
            foreach (int t in good)
            {
                Assert.AreEqual(t, head.Value);
                head = head.Next;
            }
        }
    }
}
