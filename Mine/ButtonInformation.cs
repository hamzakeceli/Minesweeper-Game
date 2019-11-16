using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mine
{
    public class ButtonInformation
    {
        public static int size = 40;
        public Point location { get; set; }
        public bool isMine { get; set; }
        public bool isFlag { get; set; }
        public bool isClicked { get; set; }
        public int neigboardMine { get; set; }
        public Color color { get; set; }
    }
}
