using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        Class1 c = new Class1();

        public Form2()
        {
            InitializeComponent();
        }

        public Form2(string str)
        {
            InitializeComponent();
            c.chr = str;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                switch (control)//可以根据不同控件类型判断赋值，比如text本文的默认不显示
                {
                    case TextBox textBox: break;
                    case DateTimePicker dateTimePicker: break;
                    default://基本控件语言
                        control.Text = c.Chargs(this.Name, control.Name);
                        break;
                }
                //tab选项卡
                if (control is TabControl)
                {
                    TabControl t = (TabControl)control;
                    foreach (TabPage item in t.TabPages)
                    {
                        item.Text = c.Chargs(this.Name, item.Name);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("TEST");
        }
    }
}
