using System.Collections.Generic;
using System.Linq;
using System.Text;
using SlimeFarm.Scripts.Presentation.Presenter;
using TMPro;
using UnityEngine;

namespace SlimeFarm.Scripts.Presentation.View
{
    public class NumberWithUnitView : MonoBehaviour, INumberOutPutPort
    {
        [SerializeField] private TextMeshProUGUI _text = default;
        [SerializeField] private string _unit = default;

        private static readonly string[] Units =
        {
            "", "万", "億", "兆", "京", "垓", "秭", "穣", "溝", "澗", "正",
            "載", "極 ", "恒河沙", "阿僧祇", "那由他", "不可思議", "無量大数"
        };

        void INumberOutPutPort.Count(IEnumerable<short> splitNum)
        {
            var builder = new StringBuilder();
            var viewCount = 0;
            foreach (var (num, unit) in splitNum.Select((num, i) => (num, Units[i])).Reverse())
            {
                if (num == 0) continue;
                builder.Append(num);
                builder.Append(unit);
                viewCount++;
                if (viewCount == 2) break;
            }

            if (viewCount == 0) builder.Append(0);
            builder.Append(_unit);

            _text.text = builder.ToString();
        }
    }
}