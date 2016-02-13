namespace Tests
{
    using System.Linq;
    using DataStructuresAlgorithms;
    using NUnit.Framework;
    [TestFixture]
    public class Unit1
    {
        [Test]
        public void StringerUniquity()
        {
            Assert.IsTrue(Stringer.Unique("abcef"));
            Assert.IsTrue(Stringer.Unique("zxcvbnmasdfghjklqwertyuiop"));
            Assert.IsTrue(Stringer.Unique("12azsxdc478fvgbh"));
            Assert.IsFalse(Stringer.Unique("asdfghjklqwertyuiopzxcvbmna789456"));
            Assert.IsFalse(Stringer.Unique("1324567897"));
        }

        [Test]
        [TestCase("abcdef\0")]
        [TestCase("hfobnufibef\0")]
        [TestCase("wretvretbre\0")]
        [TestCase("5437685b4wnu#@!^%\0")]
        [TestCase("36nb456wv54#@!^%\0")]
        [TestCase("$#%BV$#5f$#F%$##@!^%\0")]
        [TestCase("68726/*/#$#DSFDS\0")]
        public void StringerReverse(string input)
        {
            var data = input.ToCharArray();
            var output = data.Reverse().ToArray();
            for (int i = 0; i < data.Length - 1; ++i)
            {
                output[i] = output[i + 1];
            }
            output[data.Length - 1] = '\0';
            Assert.AreEqual(output, Stringer.Reverse(data));
        }
        [Test]
        [TestCase("abacadaefa", "abcdef")]
        [TestCase("", "")]
        [TestCase("a", "a")]
        [TestCase("abcdef", "abcdef")]
        [TestCase("aaaaaaaaabcdef", "abcdef")]
        [TestCase("aaaaaaaaaaa", "a")]
        [TestCase("aabbccddeeff", "abcdef")]
        [TestCase("aabbbbbcccccdddddeeeeefffff", "abcdef")]
        public void StringerRemoveDuplicates(string input, string output)
        {
            var good = Stringer.RemoveDuplicates(input.ToCharArray());
            for (int i = 0; i < output.Length; ++i)
            {
                Assert.AreEqual(output[i], good[i]);
            }
        }

        [Test]
        [TestCase("a", "a", true)]
        [TestCase("ab", "ba", true)]
        [TestCase("bqacbqhqcc", "cqbcbqchqa", true)]
        [TestCase("jjjajjkaaakakkka", "jajajaaajkkkjkka", true)]
        [TestCase("abcde", "abcdek", false)]
        [TestCase("abcdea", "abcdek", false)]
        public void StringerAnagrams(string first, string second, bool decide)
        {
            Assert.AreEqual(decide, Stringer.Anagram(first, second));
        }

        [Test]
        [TestCase("a", "a")]
        [TestCase("a ", "a%20")]
        [TestCase("a  ", "a%20%20")]
        [TestCase("  ", "%20%20")]
        [TestCase("a b c ", "a%20b%20c%20")]
        public void exchangeSpaces(string input, string output)
        {
            Assert.AreEqual(output, Stringer.SpaceChange(output));
        }

        [Test]
        public void rotateArray()
        {
            int n = 4;
            int[][] arr = new int[n][];
            arr[0] = new int[] { 1, 2, 3, 4 };
            arr[1] = new int[] { 5, 6, 7, 8 };
            arr[2] = new int[] { 9, 10, 11, 12 };
            arr[3] = new int[] { 13, 14, 15, 16 };
            int[][] good = new int[n][];
            good[0] = new int[] { 13, 9, 5, 1 };
            good[1] = new int[] { 14, 10, 6, 2 };
            good[2] = new int[] { 15, 11, 7, 3 };
            good[3] = new int[] { 16, 12, 8, 4 };

            var output = Stringer.rotateArray(arr, n);
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    Assert.AreEqual(good[i][j], output[i][j]);
                }
            }

        }
    }
}
