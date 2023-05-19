using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Class1 c = new Class1();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (c.chr == null)
            {
                string c = ""; 
                try
                {
                    c = ConfigurationManager.AppSettings["chargelang"];
                    this.Text = ConfigurationManager.AppSettings["appName" + c].ToString();
                }
                catch(Exception ex)
                {
                    c = ex.Message;
                }
            }
            else
            {
                this.Text = ConfigurationManager.AppSettings["appName" + c.chr].ToString();
            }
            
            foreach (Control control in this.Controls)
            {
                //菜单控件语言
                MenuStrip menuStrip1 = null;
                if (control is MenuStrip)
                {
                    menuStrip1 = (MenuStrip)control;
                    foreach (ToolStripMenuItem menuItem in menuStrip1.Items)
                    {
                        //一级菜单
                        menuItem.Text = menuItem.Name;
                        menuItem.Text = c.Chargs(this.Name, menuItem.Name);
                        //子菜单
                        if (menuItem.DropDownItems.Count > 0)
                        {
                            foreach (ToolStripMenuItem subMenuItem in menuItem.DropDownItems)
                            {
                                subMenuItem.Text = subMenuItem.Name;
                                subMenuItem.Text = c.Chargs(this.Name, subMenuItem.Name);
                            }
                        }
                    }
                    break;
                }
            }
            toolStripStatusLabel1.Text = c.Chargs(this.Name, toolStripStatusLabel1.Name);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            frm_Test22 frm = new frm_Test22(c.chr);
            OpenWindow(frm);

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2(c.chr);
            OpenWindow(frm);
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3(c.chr);
            OpenWindow(frm);
        }

        private void 中文ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            c.chr = "CN";
            Form1_Load(null, null);
        }

        private void 英文ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            c.chr = "EN";
            Form1_Load(null, null);
        }

        private void 日文ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            c.chr = "JP";
            Form1_Load(null, null);
        }

        //判断窗口是否打开，已打开则不重复打开
        public static bool ShowChildForm(string childFormName, Form ParentForm)
        {
            foreach (Form f in ParentForm.MdiChildren)
            {
                //判断当前子窗体的Text属性值是否与传入的字符串值相同  GetType().ToString()
                if (f.Name == childFormName)
                { 
                    f.Activate();
                    return true;
                }
            } 
            return false;
        }

        public void OpenWindow(Form frm)
        {
            if (!ShowChildForm(frm.Name, this))
            {
                frm.TopMost = true;
                frm.WindowState = FormWindowState.Maximized;
                frm.MdiParent = this;
                frm.Show();
            }
        }
    }
}
