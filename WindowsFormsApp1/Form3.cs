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
    public partial class Form3 : Form
    {
        Class1 c = new Class1();

        public Form3()
        {
            InitializeComponent();
        }

        public Form3(string str)
        {
            InitializeComponent();
            c.chr = str;
        }

        private void Form3_Load(object sender, EventArgs e)
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
            }
        }
    }
}
