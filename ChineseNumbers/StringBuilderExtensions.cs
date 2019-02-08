using System.Text;

namespace ChineseNumbers
{
    public static class StringBuilderExtensions
    {
        public static StringBuilder Reverse(this StringBuilder sb)
        {
            char t;
            int end = sb.Length - 1;
            int start = 0;

            while (end - start > 0)
            {
                t = sb[end];
                sb[end] = sb[start];
                sb[start] = t;
                start++;
                end--;
            }
            return sb;
        }
    }
}
