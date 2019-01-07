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
    /// 给玩家增加经验
    /// </summary>
    public partial class GiveExpToPlayerControl : UserControl
    {
        public event DelegateSendClick SendClick;
        public GiveExpToPlayerControl()
        {
            InitializeComponent();
        }

        private void GiveExpToPlayer_Click(object sender, EventArgs e)
        {

            ((Button)sender).Tag = new { UserID = UserId.Text, Exp = Exp.Text };
            SendClick(sender, e);
        }
    }
}
