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
    public partial class frm_Test22 : Form
    {
        Class1 c = new Class1();
        public frm_Test22()
        {
            InitializeComponent();
        }

        public frm_Test22(string str)
        {
            InitializeComponent();
            c.chr = str;
        }

        private void frm_Test_Load(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                switch (control)//可以根据不同控件类型判断赋值，比如text本文的默认不显示
                {
                    case TextBox textBox: break;
                    case DateTimePicker dateTimePicker:break;
                    default://基本控件语言
                        control.Text = c.Chargs(this.Name, control.Name);
                        break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString.ToString();
            SqlConnection connection = new SqlConnection(connStr);
            DataTable dt = new DataTable();
            try
            {
                connection.Open();
                StringBuilder sqlstr = new StringBuilder();
                sqlstr.Append("select * from test1");

                SqlCommand cmd = new SqlCommand(sqlstr.ToString(), connection);

                cmd.Parameters.Add(new SqlParameter("@V1", "12345"));
                cmd.Parameters.Add(new SqlParameter("@V2", "67890"));

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            dataGridView1.DataSource = dt;
            //动态获取标题栏文字
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].HeaderText = c.Chargs(this.Name, "dataGridView1_" + i);
            }
        }
    }
}
