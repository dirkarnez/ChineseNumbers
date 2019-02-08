using System;
using System.Text;

namespace ChineseNumbers
{
    public class ChineseNumbersFactory
    {
        private static readonly string ZERO = "零";
        private static readonly string ONE = "一";
        private static readonly string TWO = "二";
        private static readonly string THREE = "三";
        private static readonly string FOUR = "四";
        private static readonly string FIVE = "五";
        private static readonly string SIX = "六";
        private static readonly string SEVEN = "七";
        private static readonly string EIGHT = "八";
        private static readonly string NINE = "九";
        private static readonly string TEN = "十";
        private static readonly string HUNDRED = "百";
        private static readonly string THOUSAND = "千";
        private static readonly string TENTHOUSAND = "萬";
        private static readonly string BILLION = "億";

        private static readonly string[] CHINESE_NUMS = { ZERO, ONE, TWO, THREE, FOUR, FIVE, SIX, SEVEN, EIGHT, NINE };

        private static readonly string[] CHINESE_UNIT_1 = { string.Empty, TEN, HUNDRED, THOUSAND };

        private static readonly string[] CHINESE_UNIT_2 = { string.Empty, TENTHOUSAND, BILLION };

        public string ToFullChineseNumberQuantity(decimal v)
        {
            if (v % 1 != 0)
            {
                switch (v)
                {
                    case 0.5m:
                        return "半";
                    case 0.25m:
                        return "四分一";
                    default:
                        return v.ToString("0.##");
                }
            }

            var value = Convert.ToInt32(v).ToString();

            if (value == "0" || value == "")
            {
                return ZERO;
            }

            if (value == "2")
            {
                return "兩";
            }

            var buffer = new StringBuilder();

            int i, j;
            for (i = value.Length - 1, j = 0; i >= 0; i--, j++)
            {
                char n = value[i];
                if (n == '0')
                {
                    if (i < value.Length - 1 && value[i + 1] != '0')
                    {
                        buffer.Append(CHINESE_NUMS[0]);
                    }
                    if (j % 4 == 0)
                    {
                        if (i > 0 && value[i - 1] != '0'
                        || i > 1 && value[i - 2] != '0'
                        || i > 2 && value[i - 3] != '0')
                        {
                            buffer.Append(CHINESE_UNIT_2[j / 4]);
                        }
                    }
                }
                else
                {
                    if (j % 4 == 0)
                    {
                        buffer.Append(CHINESE_UNIT_2[j / 4]);
                    }

                    buffer.Append(CHINESE_UNIT_1[j % 4]);

                    string toAdd = CHINESE_NUMS[n - '0'];
                    if (toAdd == ONE && value.Length < 3 && j != 0)
                    {
                        toAdd = null;
                    }

                    if (toAdd != null)
                    {
                        buffer.Append(toAdd);
                    }
                }
            }
            return buffer.Reverse().ToString();
        }
    }
}