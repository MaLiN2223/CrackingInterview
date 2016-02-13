#pragma warning disable 1587
/// <summary>
/// Chapter 1 | Arrays and Strings
/// </summary>
#pragma warning restore 1587
namespace DataStructuresAlgorithms
{ 
    using System.Linq; 
    using System.Text;

    public static class Stringer
    {

        #region 1st task
        /// <summary>
        /// Implement an algorithm to determine if a string has all unique characters.
        /// </summary>
        /// <param name="data">String to determine</param>
        /// <returns></returns>
        public static bool Unique(string data)
        {
            return UniqueSortBased(data);
            //return UniqueArrayBased(data);
            //return UniqueNaive(data);
        }
        /// <summary>
        /// Naive method.
        /// </summary>
        /// <remarks>
        /// Checks every char with rest. O(n) complexity and no additional memory.
        /// </remarks>
        /// <param name="data"></param>
        /// <returns></returns>
        private static bool UniqueNaive(string data)
        { 
            int size = data.Length;
            for (int i = 0; i < size; ++i)
            {
                char c = data[i];
                for (int j = i + 1; j < size; ++j)
                {
                    if (c == data[j])
                        return false;
                }
            }
            return true;
        }
        private static bool[] UniqueArray = new bool[256];
        /// <summary>
        /// Method based on bool array.
        /// </summary>
        /// <remarks>
        /// Checks if character existed based on bool 128 long bool array. We asume that there is 256 unique characters. O(n) complexity and O(1) additional memory
        /// </remarks>
        /// <param name="data"></param>
        /// <returns></returns>
        private static bool UniqueArrayBased(string data)
        {
            for (int i = 0; i < 256; ++i)
            {
                UniqueArray[i] = false;
            }
            int size = data.Length;
            for (int i = 0; i < size; ++i)
            {
                if (UniqueArray[data[i]])
                    return false;
                UniqueArray[data[i]] = true;
            }
            return true;
        }
        /// <summary>
        /// Method based on sorting the string
        /// </summary>
        /// <remarks>
        /// Checks if character existed by comparing nearby elements in sorted list. O(n*log(n)) complexity ( n (ToList) + n*log(n) (sort) ) O(n) additional memory
        /// </remarks>
        /// <param name="data"></param>
        /// <returns></returns>
        private static bool UniqueSortBased(string data)
        {
            int size = data.Length;
            var sorted = data.ToList();
            sorted.Sort();
            for (int i = 0; i < size - 1; ++i)
            {
                if (sorted[i] == sorted[i + 1])
                    return false;
            }
            return true;
        }
        #endregion
        #region 2nd task
        /// <summary>
        /// Write code to reverse a C-Style String. (C-String means that “abcd” is represented as five characters, including the null character.)
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static char[] Reverse(char[] array)
        {
            return ReverseInPlace(array);
            //return ReverseSecondArray(array);
        }
        /// <summary>
        /// Typical reverse by using second array
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>

        private static char[] ReverseSecondArray(char[] array)
        {

            int k = array.Length;
            char[] output = new char[k];
            for (int i = k - 2; i >= 0; --i)
            {
                output[k - i - 2] = array[i];
            }
            return output;
        }

        private static char[] ReverseInPlace(char[] array)
        {
            int i = 0; // first pointer
            int k = array.Length - 2;//second pointer (-2 because of \0 char)
            while (i < k)
            {
                char tmp = array[i];
                array[i] = array[k];
                array[k] = tmp;
                --k;
                ++i;
            }
            return array;
        }
        #endregion
        #region 3rd task
        /// <summary>
        /// Design an algorithm and write code to remove the duplicate characters in a string without using any additional buffer.
        /// </summary>
        /// <remarks> 
        /// O(n^2) complexity ( 1/2 * n * (n+1) ), no additional memory
        /// </remarks>
        /// <param name="data"></param>
        /// <returns></returns>
        public static char[] RemoveDuplicates(char[] data)
        {
            int size = data.Length;
            int start = 0;
            int removedCount = 0;
            while (start < size - 1 && start < size - removedCount)
            {
                var removed = 0;
                int ptr = start + 1;
                while (ptr < size && ptr < size - removedCount) // size - globalremoved == first position where '\0' occurs
                {
                    if (data[ptr] == data[start])
                    {
                        data[ptr] = '\0';
                        removed++;
                    }
                    else if (removed > 0)
                        data[ptr - removed] = data[ptr];
                    ++ptr;
                }

                start++;
                removedCount += removed;
            }
            return data;
        }
        #endregion
        #region 4th task

        /// <summary>
        /// Write a method to decide if two strings are anagrams or not.
        /// </summary>
        public static bool Anagram(string first, string second)
        {
            //return AnagramSorted(first, second);
            return AnagramArrayBased(first, second);
        }
        /// <summary>
        /// Method based on sorting strings.
        /// </summary> 
        /// <remarks>
        /// Complexity O(n) for creating lists, O(n*log(n)) for sorting and O(n) for comparing thus complexity is O(n*log(n)) and additional space is O(n)
        /// </remarks>
        private static bool AnagramSorted(string first, string second)
        {
            int size = first.Length;
            if (size != second.Length)
                return false;
            var firstS = first.ToList();
            var secondS = second.ToList();
            firstS.Sort();
            secondS.Sort();
            for (int i = 0; i < size; ++i)
            {
                if (firstS[i] != secondS[i])
                    return false;
            }
            return true;
        }
        /// <summary>
        /// Method based on two arrays. Both for counting characters in string
        /// </summary>
        /// <remarks>
        /// Complexity O(n), Additional Space O(1)
        /// </remarks> 
        private static bool AnagramArrayBased(string first, string second)
        {
            int size = first.Length;
            if (size != second.Length)
                return false;
            char[] arrayF = new char[256];
            char[] arrayS = new char[256];
            for (int i = 0; i < size; ++i)
            {
                char a = first[i];
                char b = second[i];
                ++arrayF[a];
                ++arrayS[b];
            }
            for (int i = 0; i < 256; ++i)
            {
                if (arrayF[i] != arrayS[i])
                    return false;
            }
            return true;
        }

        #endregion
        #region 5th task
        /// <summary>
        /// Write a method to replace all spaces in a string with ‘%20’
        /// </summary> 
        public static char[] SpaceChange(string text)
        {
            //return SpaceChangeStringBuilder(text);
            return SpaceChangeCounting(text);
        }
        /// <summary>
        /// Method based on StringBuilder class.
        /// </summary>
        /// <remarks>
        /// Complexity depends on Append method.
        /// </remarks>
        /// <param name="text"></param>
        /// <returns></returns>
        private static char[] SpaceChangeStringBuilder(string text)
        {
            int size = text.Length;
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < size; ++i)
            {
                if (text[i] == ' ')
                    builder.Append("%20");
                else
                    builder.Append(text[i]);
            }
            return builder.ToString().ToCharArray();

        }
        /// <summary>
        /// Method based on space counting and helper array
        /// </summary> 
        /// <remarks>
        /// Complexity O(n), additional memory O(n)
        /// </remarks>
        private static char[] SpaceChangeCounting(string text)
        {
            int count = text.Length;
            int spacesCount = 0;
            for (int i = 0; i < count; ++i)
            {
                if (text[i] == ' ')
                    spacesCount++;
            }
            char[] array = new char[count + 2 * spacesCount];
            int k = 0;
            for (int i = 0; i < count; ++i)
            {
                if (text[i] == ' ')
                {
                    array[k++] = '%';
                    array[k++] = '2';
                    array[k++] = '0';
                }
                else
                    array[k++] = text[i];
            }
            return array;
        }
        #endregion
        #region 6th task
        /// <summary>
        /// Given an image represented by an NxN matrix, where each pixel in the image is 4 bytes, write a method to rotate the image by 90 degrees in place.
        /// </summary> 
        public static int[][] rotateArray(int[][] array, int n)
        {

            for (int i = 0; i < n / 2; ++i)
            {
                for (int k = i; k < n - 1 - i; ++k)
                {
                    int tmp = array[k][n - 1 - i];
                    array[k][n - 1 - i] = array[i][k];
                    array[i][k] = array[n - 1 - k][i];
                    array[n - 1 - k][i] = array[n - 1 - i][n - 1 - k];
                    array[n - i - 1][n - 1 - k] = tmp;
                }
            }
            return array;
        }
        #endregion

    }
}
