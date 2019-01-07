using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AtlasGM
{
    public delegate void DelegateSendClick(object sender, EventArgs e);
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            ShowGiveExpToPlayer.Tag = new { Contorl = "123", Title = "给玩家增加经验" };
            ShowTeleportPlayerIDToMe.Tag = new { Contorl = "123", Title = "将玩家传送到身边" };
            ShowTeleportToPlayer.Tag = new { Contorl = "123", Title = "传送到玩家身边" };
            ShowSetTimeOfDay.Tag = new { Contorl = "123", Title = "设置时间" };
            ShowBroadcast.Tag = new { Contorl = "123", Title = "发送广播" };
            ShowBroadcast.Tag = new { Contorl = "123", Title = "发送广播"  };
            BindItem();
        }
        private void BindItem()
        {
            ItemList.Columns.Add(new ColumnHeader() { Text = "名称", Width = 120, TextAlign = HorizontalAlignment.Left });
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
        /// <summary>
        /// 重写windows消息响应
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            const int wmHotkey = 786;
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
        /// <summary>
        /// 物品资源列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var selectitem = ((ListView)sender).SelectedItems;
            if (selectitem.Count > 0)
            {
                if (!string.IsNullOrEmpty(ItemUserId.Text))
                {
                    SendMessageHelper.Send("admincheat GiveItemToPlayer " + ItemUserId.Text + " \"" + ((ListViewItem)selectitem[0]).Tag + "\" " + ItemQuantity.Text + " " + Quality.Text + " " + IsBlueprintorTame.Checked + "", Convert.ToInt32(ItemNumber.Text));
                }
                else
                {
                    SendMessageHelper.Send("admincheat giveitem \"" + ((ListViewItem)selectitem[0]).Tag + "\" " + ItemQuantity.Text + " " + Quality.Text + " " + IsBlueprintorTame.Checked + "", Convert.ToInt32(ItemNumber.Text));
                }

            }
        }
        /// <summary>
        /// 恐龙列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DinoList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var selectitem = ((ListView)sender).SelectedItems;
            if (selectitem.Count > 0)
            {
                if (IsTame.Checked)
                {
                    SendMessageHelper.Send("admincheat GMSummon \"" + selectitem[0].Tag + "\"" + DinoLevel, Convert.ToInt32(DinoNumber.Text));

                }
                else
                {
                    SendMessageHelper.Send("admincheat Summon \"" + selectitem[0].Tag + "\"" + DinoLevel, Convert.ToInt32(DinoNumber.Text));
                }
            }
        }

        public void Send_Click(object sender, EventArgs e)
        {
            string butName = ((Button)sender).Name;
            switch (butName)
            {
                case "test"://
                    SendMessageHelper.Send("cheat test ");
                    break;
                case "TakeAllDino"://获取十字面向部落恐龙
                    SendMessageHelper.Send("cheat TakeAllDino ");//缺少时间参数
                    break;
                case "GiveAllStructure"://获取相连建筑
                    SendMessageHelper.Send("cheat GiveAllStructure ");
                    break;
                case "GiveColors"://获取所有染料
                    SendMessageHelper.Send("cheat GiveColors ");//缺少数量
                    break;
                case "GiveEngrams"://解锁印痕
                    SendMessageHelper.Send("cheat GiveEngrams ");
                    break;
                case "LeaveMeAlone"://无敌
                    SendMessageHelper.Send("cheat LeaveMeAlone ");
                    break;
                case "SetAdminIconOn"://管理员图标开
                    SendMessageHelper.Send("cheat SetAdminIcon true ");
                    break;
                case "SetAdminIconOff"://管理员图标关
                    SendMessageHelper.Send("cheat SetAdminIcon false ");
                    break;
                case "ToggleInfiniteAmmo"://无限弹药
                    SendMessageHelper.Send("cheat ToggleInfiniteAmmo ");
                    break;
                case "Walk"://关闭飞行
                    SendMessageHelper.Send("cheat Walk ");
                    break;
                /*强制加入部落*/
                case "ForceJoinTribe":
                    SendMessageHelper.Send("cheat ForceJoinTribe ");
                    break;
                /*杀死指定玩家*/
                case "KillPlayer":
                    SendMessageHelper.Send("cheat KillPlayer ");//缺少玩家ID
                    break;
                //显示FPS信息
                case "Stat":
                    SendMessageHelper.Send("Stat FPS ");
                    SendMessageHelper.Send("Stat Unit ");
                    break;
                /*强制驯服*/
                case "ForceTame":
                    SendMessageHelper.Send("cheat ForceTame ");
                    break;
                /*获取面向部落所有建筑*/
                case "TakeAllStructure"://获取十字面向部落恐龙
                    SendMessageHelper.Send("cheat TakeAllStructure ");//缺少时间参数
                    break;
                /*飞行*/
                case "Fly"://
                    SendMessageHelper.Send("cheat Fly ");
                    break;
                /*对龙隐身开*/
                case "EnemyInvisibleOn"://
                    SendMessageHelper.Send("cheat EnemyInvisible true ");
                    break;
                /*对龙隐身关*/
                case "EnemyInvisibleOff"://
                    SendMessageHelper.Send("cheat EnemyInvisible false ");
                    break;
                /*穿墙*/
                case "Ghost"://
                    SendMessageHelper.Send("cheat Ghost ");
                    break;
                /*上帝模式*/
                case "God"://
                    SendMessageHelper.Send("cheat God ");
                    break;
                /*无限状态*/
                case "InfiniteStats"://
                    SendMessageHelper.Send("cheat InfiniteStats ");
                    break;
                /*传送玩家到身边*/
                case "TeleportPlayerIDToMe"://
                    SendMessageHelper.Send("cheat TeleportPlayerIDToMe ");//缺少玩家ID
                    break;
                /*传送到玩家身边*/
                case "TeleportToPlayer"://
                    SendMessageHelper.Send("cheat TeleportToPlayer ");//缺少玩家ID
                    break;
                /*给玩家经验*/
                case "GiveExpToPlayer"://
                    dynamic tag = ((Button)sender).Tag;
                    string userId = tag.UserID.ToString();
                    string Exp = tag.Exp.ToString();
                    SendMessageHelper.Send("cheat GiveExpToPlayer ");//玩家ID 经验值  1  是否与部落分享 1 不分享 0 分享
                    break;
                /*增加经验*/
                case "AddExperience"://
                    SendMessageHelper.Send("cheat AddExperience ");//经验值  1  是否与部落分享 1 不分享 0 分享
                    break;

                case "Kill"://杀死指向目标(留下尸体)
                    SendMessageHelper.Send("cheat Kill ");
                    break;

                /*设置时间 SetTimeOfDay*/
                case "SetTimeOfDay"://
                    SendMessageHelper.Send("cheat SetTimeOfDay ");//缺少时间参数
                    break;
                case "EnableSpectator"://进入观察者模式
                    SendMessageHelper.Send("cheat EnableSpectator");
                    break;
                case "MakeTribeFounder"://强制部落长
                    SendMessageHelper.Send("cheat MakeTribeFounder");
                    break;
                case "MakeTribeAdmin"://强制管理员
                    SendMessageHelper.Send("cheat MakeTribeAdmin");
                    break;
                case "DestroyTribeStructures"://摧毁面向部落所有建筑
                    SendMessageHelper.Send("cheat DestroyTribeStructures");
                    break;
                case "DestroyTribePlayers"://摧毁面向部落所有玩家
                    SendMessageHelper.Send("cheat DestroyTribePlayers");
                    break;
                case "DestroyTribeDinos"://摧毁面向部落所有生物
                    SendMessageHelper.Send("cheat DestroyTribeDinos");
                    break;
                case "DestroyWildDinos"://摧毁所有野生生物
                    SendMessageHelper.Send("cheat DestroyWildDinos");
                    break;
                case "DestroyMyTarget"://摧毁准心面向物品
                    SendMessageHelper.Send("cheat DestroyMyTarget");
                    break;
                case "ShowAdmin"://显示内置管理菜单
                    SendMessageHelper.Send("showmyadminmanager");
                    break;
                case "GmBuff"://开启管理员BUFF
                    SendMessageHelper.Send("cheat gmbuff");
                    break;
                case "EnableCheats":
                    string gmPwd = GMpass.Text;
                    if (string.IsNullOrEmpty(gmPwd))
                    {
                        MessageBox.Show("密码不可为空");
                        return;
                    }
                    SendMessageHelper.Send("enablecheats " + gmPwd);
                    break;
            }
        }

        private void DestroyTribeDinos_Click(object sender, EventArgs e)
        {

        }

        private void Show_SpringWindow(object sender, EventArgs e)
        {
            SpringWindow springWindow = new SpringWindow();
            springWindow.StartPosition = FormStartPosition.CenterParent;
            
            springWindow.Text = "asdfasdf";
          //  GiveExpToPlayerControl control = new GiveExpToPlayerControl();
          //  control.SendClick += new DelegateSendClick(Send_Click);
            //springWindow.Controls.Add(control);
            Type classType = Type.GetType("AtlasGM.GiveExpToPlayerControl, AtlasGM");
            dynamic instance = Activator.CreateInstance(classType);
            instance.SendClick += new DelegateSendClick(Send_Click);
            springWindow.Size = new Size( instance.Width+10, instance.Height+ SystemInformation.CaptionHeight+10);
            springWindow.Controls.Add(instance);
            springWindow.ShowDialog();
        }
    }
}
