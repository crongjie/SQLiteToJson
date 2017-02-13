using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Data.SQLite;

namespace SQLiteToJson
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter sw = new
                   System.IO.StreamWriter(saveFileDialog1.FileName, false, System.Text.Encoding.UTF8);
                sw.Write(tb_output.Text);
                sw.Close();
            }
        }

        private void btn_process_Click(object sender, EventArgs e)
        {
            if (tb_file.Text.Length > 0)
            {
                SQLiteConnectionStringBuilder ConnectionString = new SQLiteConnectionStringBuilder
                {
                    DataSource = tb_file.Text
                };
                using (SQLiteConnection Connection = new SQLiteConnection(ConnectionString.ToString()))
                {
                    Connection.Open();

                    
                }
            }

        }

        private void btn_browse_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tb_file.Text = openFileDialog1.FileName;
            }
            else
            {
                tb_file.Text = "";
            }

        }
    }
}
