using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AtlasGM
{
    
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            ButClick butClick = new ButClick();
            Enablecheats.Click += new System.EventHandler(butClick.Send_Click);
            ShowAdmin.Click += new System.EventHandler(butClick.Send_Click);
            GmBuff.Click += new System.EventHandler(butClick.Send_Click); 
            BindItem();
        }
        private void BindItem()
        { 
            ItemList.Columns.Add(new ColumnHeader() {Text="名称",Width=120, TextAlign= HorizontalAlignment.Left });
            dynamic items = JsonConvert.DeserializeObject(Properties.Resources.item);
            foreach (var item in items)
            {
                ListViewItem t = new ListViewItem();
                ItemList.Items.Add(new ListViewItem(item.name.ToString()) { Tag = item.code.ToString() });
            }

        }
     
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(GMpass.Text))
            {
                MessageBox.Show("密码不可为空");
            }
            SendMessageHelper.Send("enablecheats " + GMpass.Text);
            // SendMessage(Program.handle, 0X49, 0X49, 0); //输入TAB（0x09）
        }

        private void ShowItemForm_Click(object sender, EventArgs e)
        {
            bool isfind = false;
            foreach (Form fm in Application.OpenForms)
            {
                //判断Form2是否存在，如果在激活并给予焦点
                if (fm.Name == "ItemForm")
                {
                    fm.WindowState = FormWindowState.Maximized;
                    fm.WindowState = FormWindowState.Normal;
                    fm.Activate();
                    return;
                }
            }
            //如果窗口不存在，打开窗口
            Form itemForm = new ItemForm(); itemForm.Show(); 

        }
        List<int> l = new List<int>();
        /// <summary>
        /// 重写windows消息响应
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            const int wmHotkey = 786;
            //if (!l.Contains(m.Msg))
            //{
            //    l.Add(m.Msg);
            //    MessageBox.Show(m.Msg.ToString());
            //}
            switch (m.Msg)
            {
                case wmHotkey:                   
                    SendMessageHelper.SwitchToThisWindow(Handle, true);
                    foreach (Form fm in Application.OpenForms)
                    {
                        //判断Form2是否存在，如果在激活并给予焦点
                        if (fm.Name == "ItemForm")
                        {
                            fm.WindowState = FormWindowState.Maximized;
                            fm.WindowState = FormWindowState.Normal;
                            fm.Activate();
                            return;
                        }
                    }
                    break;
            }
            base.WndProc(ref m);
        }

        public void SetHotKey(Keys c, bool bCtrl, bool bShift, bool bAlt, bool bWindows)
        {
            //先赋到变量
            Keys m_key = c;
            bool m_ctrlhotkey = bCtrl;
            bool m_shifthotkey = bShift;
            bool m_althotkey = bAlt;
            bool m_winhotkey = bWindows;

            //注册系统热键
            NativeWIN32.KeyModifiers modifiers = NativeWIN32.KeyModifiers.None;
            if (bCtrl)
                modifiers |= NativeWIN32.KeyModifiers.Control;
            if (bShift)
                modifiers |= NativeWIN32.KeyModifiers.Shift;
            if (bAlt)
                modifiers |= NativeWIN32.KeyModifiers.Alt;
            if (bWindows)
                modifiers |= NativeWIN32.KeyModifiers.Windows;
            NativeWIN32.RegisterHotKey(Handle, 100, modifiers, c);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetHotKey(Keys.F11, false, false, false, false);
        }

        private void but_Click(object sender, EventArgs e)
        {
            //((Button)sender).Click= new System.EventHandler(new ButClick().Send_Click);
           // Program.but_click.Send_Click(sender, e);
        }

        private void ItemList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var selectitem= ((ListView)sender).SelectedItems;
            if (selectitem.Count>0)
            { 
                SendMessageHelper.Send("admincheat giveitem \"" + ((ListViewItem)selectitem[0]).Tag + "\" "+Quantity.Text+" "+Quality.Text+" "+IsBlueprint.Checked+"",Convert.ToInt32(Number.Text));
            } 
        }
    }
}
