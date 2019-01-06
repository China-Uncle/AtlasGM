using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AtlasGM
{
    public partial class ItemForm : Form
    {
        ListView ItemlistView;
        dynamic ItemJson;
        string selectedtabName;
        public ItemForm()
        {
            InitializeComponent();
            ButClick butClick = new ButClick();
            SendItem.Click += new System.EventHandler(butClick.Send_Click); 
            ItemlistView = new ListView() { LargeImageList = ItemimageList,
                Width = this.Width,Name= "ItemlistView"
            };
          
            ItemJson = JsonConvert.DeserializeObject(Properties.Resources.item); 
                foreach (dynamic item in ItemJson)
                {
                    tabControl1.Controls.Add(new TabPage(item.Path) { Name= item.Path });
                }
            dynamic itemJsonFirst = ((Newtonsoft.Json.Linq.JToken)ItemJson).First;
            ArrayImage(itemJsonFirst.Value);
            selectedtabName = itemJsonFirst.Path;
            tabControl1.Controls[0].Controls.Add(ItemlistView);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Control control = tabControl1.Controls.Find(selectedtabName, false).FirstOrDefault();
            if (control!=null)
            {
                control.Controls.Remove(ItemlistView);
            }
            control = tabControl1.Controls.Find(tabControl1.SelectedTab.Text,false).FirstOrDefault();
            if (control==null)
            {
                MessageBox.Show("程序异常", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);//弹出信息
                Application.Exit();
            }
            ArrayImage(ItemJson.GetValue(tabControl1.SelectedTab.Text));
            control.Controls.Add(ItemlistView);
            //tabControl1.Controls.Add(tabPage2);
            string P_str_TabName = tabControl1.SelectedTab.Text;//获取选择的选项卡名称
            
   
        }
        public void ArrayImage( dynamic ItemList)
        {
            ItemlistView.Items.Clear();

            this.ItemimageList.Images.Clear();
            for (int i = 0; i < ItemList.Count; i++)
            {
                if (string.IsNullOrEmpty(((String)ItemList[i].img)))
                {
                    this.ItemimageList.Images.Add((Image)Properties.Resources.loading);
                }
                else
                {
                    this.ItemimageList.Images.Add((Image)Properties.Resources.ResourceManager.GetObject(ItemList[i].img.ToString()));
                }
               
                ItemlistView.Items.Add(ItemList[i].name.ToString());
                ItemlistView.Items[i].ImageIndex = i;
                ItemlistView.Items[i].Name = ItemList[i].name.ToString();
                ItemlistView.Items[i].Tag = ItemList[i].code.ToString();
            }
        }
    }
}
