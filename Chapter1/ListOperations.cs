namespace DataStructuresAlgorithms
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Chapter 2 | Linked Lists
    /// </summary>
    public static class ListOperations
    {
        #region 1st Task
        /// <summary>
        /// Write code to remove duplicates from an unsorted linked list. 
        /// </summary>
        /// <remarks>
        /// Method based on comparing 'next' nodes. Complexity O(n^2) no additional space
        /// </remarks> 
        private static LinkedList<T> RemoveDupsNextBased<T>(LinkedList<T> list)
        {
            if (ReferenceEquals(null, list) || ReferenceEquals(null, list.First))
                return list;
            var head = list.First;
            while (head?.Next != null)
            {
                var tmp = head.Next;
                while (tmp != null)
                {
                    if (head.Value.Equals(tmp.Value))
                    {
                        list.Remove(tmp);
                        tmp = head.Next;
                        continue;
                    }
                    tmp = tmp.Next;
                }
                head = head.Next;
            }
            return list;
        }
        /// <summary>
        /// Method based on hash table.
        /// </summary>
        /// <remarks>
        /// Complexity O(n) and unknown additional space (based on Hashtable implementation)
        /// </remarks> 
        private static LinkedList<T> RemoveDupsHashBased<T>(LinkedList<T> list)
        {
            Dictionary<T, bool> table = new Dictionary<T, bool>();
            LinkedListNode<T> prev = null;
            var head = list?.First;
            while (head != null)
            {
                if (!table.ContainsKey(head.Value))
                {
                    table.Add(head.Value, true);
                    prev = head;
                    head = head.Next;
                    continue;
                }
                list.Remove(head);
                head = prev.Next; // I am ignoring null reference because upper if will always be executed on first while entrance
            }
            return list;

        }
        public static LinkedList<T> RemoveDups<T>(LinkedList<T> list)
        {
            return RemoveDupsHashBased(list);
            ///return RemoveDupsNextBased(list);
        }
        #endregion
        #region 2nd task
        /// <summary>
        /// Implement an algorithm to find the nth to last element of a singly linked list.
        /// </summary>
        /// <remarks>
        /// Complexity O(n), no additional space
        /// </remarks> 
        public static T NThElement<T>(LinkedList<T> list, int n)
        {
            if (n <= 0 || list.Count <= n)
                return default(T);
            int i = 0; // counter
            var elemnt = list.First; // nth element 
            var head = list.First;
            while (head != null)
            {
                if (i > n)
                    elemnt = elemnt.Next;
                ++i;
                head = head.Next;
            }
            return elemnt.Value;
        }
        #endregion
        #region 3rd Task

        public static LinkedList<T> RemoveNodeInSingleLinked<T>(LinkedListNode<T> node)
        {
            //TODO : implement own LinkedList with setter for LinkedListNode.next
            throw new NotImplementedException();
        }
        #endregion
        #region 4th task

        public static LinkedList<T> Sum<T>(LinkedList<T> first, LinkedList<T> second)
        {
            LinkedList<T> list = new LinkedList<T>();
            var headFirst = first.First;
            var headSecond = second.First;
            dynamic last = 0;
            while (headFirst != null && headSecond != null)
            {
                dynamic a = headFirst.Value;
                dynamic b = headSecond.Value;
                dynamic sum = a + b + last;
                dynamic v = sum % 10;
                last = sum / 10;
                list.AddLast(new LinkedListNode<T>(v));
                headFirst = headFirst.Next;
                headSecond = headSecond.Next;
            }
            while (headFirst != null)
            {
                dynamic a = headFirst.Value;
                dynamic sum = a + last;
                dynamic v = sum % 10;
                last = sum / 10;
                list.AddLast(new LinkedListNode<T>(v));
                headFirst = headFirst.Next;
            }
            while (headSecond != null)
            {
                dynamic a = headSecond.Value;
                dynamic sum = a + last;
                dynamic v = sum % 10;
                last = sum / 10;
                list.AddLast(new LinkedListNode<T>(v));
                headSecond = headSecond.Next;
            }
            if (last > 0)
                list.AddLast(new LinkedListNode<T>(last));
            return list;
        }
        #endregion

    }
}
