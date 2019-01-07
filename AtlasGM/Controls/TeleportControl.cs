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
    /// 传送
    /// </summary>
    public partial class TeleportControl : UserControl
    {
        public event DelegateSendClick SendClick;
        public TeleportControl()
        {
            
            InitializeComponent();
           
        }

        private void TeleportBut_Click(object sender, EventArgs e)
        {
            ((Button)sender).Tag = TextValue.Text;
            if (this.Parent.Text == "将玩家传送到身边")
            {
                ((Button)sender).Name = "TeleportPlayerIDToMe";
            }  
            SendClick(sender, e);

        }
    }
}
