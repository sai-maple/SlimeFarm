using System.Linq;
using System.Numerics;
using System.Text;
using Unity.Mathematics;

namespace SlimeFarm.Scripts.Application.Utility
{
    public static class NumberConverter
    {
        private static readonly string[] Units =
        {
            "", "万", "億", "兆", "京", "垓", "秭", "穣", "溝", "澗", "正",
            "載", "極 ", "恒河沙", "阿僧祇", "那由他", "不可思議", "無量大数"
        };

        public static string ConvertToChineseNumber(BigInteger num, int limit = 17)
        {
            var splitNums = new short[17];
            var splitUnit = (BigInteger) math.pow(10, 4);
            var digit = 0;

            for (; num > 0; num /= splitUnit)
            {
                var x = num % splitUnit;
                splitNums[digit] = (short) x;
                digit++;
            }

            var builder = new StringBuilder();
            var viewCount = 0;
            foreach (var (number, unit) in splitNums.Select((splitNum, i) => (splitNum, Units[i])).Reverse())
            {
                if (number == 0) continue;
                builder.Append(number);
                builder.Append(unit);
                viewCount++;
                if (viewCount == limit) break;
            }

            if (viewCount == 0) builder.Append(0);
            return builder.ToString();
        }
    }
}