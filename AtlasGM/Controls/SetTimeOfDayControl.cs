using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AtlasGM.Controls
{
    /// <summary>
    /// 设置时间
    /// </summary>
    public partial class SetTimeOfDayControl : UserControl
    {
        public event DelegateSendClick SendClick;
        public SetTimeOfDayControl()
        {
            InitializeComponent();
        }

        private void SetTimeOfDay_Click(object sender, EventArgs e)
        {
            ((Button)sender).Tag = TextValue.Text;
           
            SendClick(sender, e);
        }
    }
}
