using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AtlasGM
{
    public class ButClick
    {
        public void Send_Click(object sender, EventArgs e)
        {
            string butName = ((Button)sender).Name;
            switch (butName)
            {
                /*强制加入部落*/
                /*踢玩家出服务器*/
                /*对恐龙隐身*/
                /*杀死指定玩家*/
                /*强制驯服*/
                /*获取面向相连建筑*/
                /*获取面向部落所有建筑*/
                /*飞行*/
                /*穿墙*/
                /*无限状态*/
                /*传送玩家到身边*/
                /*传送到玩家身边*/
                /*给玩家经验*/
                /*增加经验*/
                /*设置时间*/

                case "Broadcast"://发送通知
                    SendMessageHelper.Send("cheat EnableSpectator");
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
                case "Enablecheats":
                    string gmpwd = ((TextBox)Form1.ActiveForm.Controls.Find("GMpass", false).First()).Text;
                    if (string.IsNullOrEmpty(gmpwd))
                    {
                        MessageBox.Show("密码不可为空");
                        return;
                    }
                    SendMessageHelper.Send("enablecheats " + gmpwd);
                    break; 
            }
        }

    }
}
