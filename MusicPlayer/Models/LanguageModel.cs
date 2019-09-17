using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace MusicPlayer.Models
{
    public class LanguageModel
    {
        public string Name { get; private set; }
        public string Code { get; private set; }
        public FlowDirection FlowDirection { get; private set; }

        public LanguageModel(string name, string code, FlowDirection flowDirection = FlowDirection.LeftToRight)
        {
            this.Name = name;
            this.Code = code;
            this.FlowDirection = flowDirection;
        }
    }
}
