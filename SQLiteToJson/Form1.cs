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
                JObject jo = new JObject();
                JArray lst = new JArray();
                using (SQLiteConnection Connection = new SQLiteConnection(ConnectionString.ToString()))
                {
                    Connection.Open();
                    SQLiteCommand command = Connection.CreateCommand();
                    command.CommandText = "SELECT col_1, count(*) as cnt FROM data group by col_1 having cnt >= 2 ";
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        String key = reader.GetString(0);


                        JObject left = new JObject();
                        JObject right = new JObject();

                        SQLiteCommand command3 = Connection.CreateCommand();
                        command3.CommandText = "SELECT col_1, col_3 FROM data where col_2 = '" + key + "'";

                        var reader3 = command3.ExecuteReader();
                        while (reader3.Read())
                        {
                            left[reader3.GetString(0)] = reader3.GetString(1);
                        }

                        if (left.Count >= 2)
                        {

                            SQLiteCommand command2 = Connection.CreateCommand();
                            command2.CommandText = "SELECT col_2, col_3 FROM data where col_1 = '" + key + "'";
                            var reader2 = command2.ExecuteReader();
                            while (reader2.Read())
                            {
                                right[reader2.GetString(0)] = reader2.GetString(1);
                            }
                            JObject item = new JObject();
                            item["l"] = left;
                            item["r"] = right;
                            jo[key] = item;
                            lst.Add(key);
                        }
                        
                        Console.WriteLine(string.Format("col_1 = {0}, cnt = {1}",
                            reader.GetString(0),
                            reader.GetInt16(1)
                        ));
                    }

                    tb_output.Text = jo.ToString();
                    tb_output.Text += "=======================";
                    tb_output.Text += lst.ToString();
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

        //Examples:
        private static SQLiteConnection _connection;
        /// <summary>
        /// connect to DB
        /// </summary>
        private static void ConnectionOpen()
        {
            _connection = new SQLiteConnection();
            _connection.ConnectionString = "Data Source=testdb.db;Version=3;";
            _connection.Open();
        }


        /// <summary>
        /// create table
        /// </summary>
        private static void CreateTable()
        {
            SQLiteCommand command = _connection.CreateCommand();
            command.CommandText = "CREATE TABLE Test (id integer primary key AUTOINCREMENT, text varchar(100))";
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// insert record
        /// </summary>
        private static void InsertRecord()
        {
            for (int i = 0; i < 10; i++)
            {
                SQLiteCommand command = _connection.CreateCommand();
                command.CommandText = "INSERT INTO Test (text) VALUES (@1)";
                SQLiteParameter parameter = command.CreateParameter();
                parameter.ParameterName = "@1";
                parameter.Value = "this is " + i.ToString() + " text";
                command.Parameters.Add(parameter);
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// select record
        /// </summary>
        private static void SelectRecord()
        {
            SQLiteCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT * FROM Test";
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(string.Format("ID = {0}, Name = {1}",
                    reader.GetInt32(0),
                    reader.GetString(1)
                ));
            }
        }


        /// <summary>
        /// Close connection
        /// </summary>
        private static void ConnectionClose()
        {
            _connection.Close();
        }

        private void btn_process_large_Click(object sender, EventArgs e)
        {
            if (tb_file.Text.Length > 0)
            {
                SQLiteConnectionStringBuilder ConnectionString = new SQLiteConnectionStringBuilder
                {
                    DataSource = tb_file.Text
                };
                JArray ja = new JArray();
                using (SQLiteConnection Connection = new SQLiteConnection(ConnectionString.ToString()))
                {
                    Connection.Open();
                    SQLiteCommand command = Connection.CreateCommand();
                    command.CommandText = "SELECT col_1, col_2, col_3, col_4, col_5, col_6, col_7, col_8, col_9, col_10, col_11, col_12 FROM data";
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int num = int.Parse(reader.GetString(0));
                        //String num = reader.GetString(0);
                        String info = reader.GetString(1);

                        JArray ja2 = new JArray();
                        ja2.Add(num);
                        ja2.Add(reader.GetString(1));
                        ja2.Add(reader.GetString(2));
                        //ja2.Add(reader.GetString(3));

                        string gua_info = reader.GetString(3);
                        string part1 = gua_info.Substring(0, gua_info.IndexOf("\n[譯文"));
                        string part2 = gua_info.Substring(gua_info.IndexOf("\n[譯文") +1, gua_info.IndexOf("\n\n") - part1.Length - 1);
                        string part3 = gua_info.Substring(gua_info.IndexOf("\n\n") + 2, gua_info.Length - part1.Length - part2.Length - 3);
                        Console.WriteLine(string.Format("1 = {0}, 2 = {1}, 3 = {2}",
                            part1,
                            part2,
                            part3
                        ));
                        ja2.Add(part1);
                        ja2.Add(part2);
                        ja2.Add(part3);

                        ja2.Add(reader.GetString(4));
                        ja2.Add(reader.GetString(5));
                        ja2.Add(reader.GetString(6));
                        ja2.Add(reader.GetString(7));
                        ja2.Add(reader.GetString(8));
                        ja2.Add(reader.GetString(9));
                        ja2.Add(reader.GetString(10));
                        ja2.Add(reader.GetString(11));
                        Console.WriteLine(string.Format("col_1 = {0}, cnt = {1}",
                            num,
                            info
                        ));
                        ja.Add(ja2);
                    }

                    tb_output.Text = ja.ToString();
                }
            }
        }

        private void btn_process_simple_Click(object sender, EventArgs e)
        {
            if (tb_file.Text.Length > 0)
            {
                SQLiteConnectionStringBuilder ConnectionString = new SQLiteConnectionStringBuilder
                {
                    DataSource = tb_file.Text
                };
                JObject jo = new JObject();
                JArray lst = new JArray();
                using (SQLiteConnection Connection = new SQLiteConnection(ConnectionString.ToString()))
                {
                    Connection.Open();
                    SQLiteCommand command = Connection.CreateCommand();
                    command.CommandText = "SELECT col_1, count(*) as cnt FROM data group by col_1 having cnt >= 2 ";
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        String key = reader.GetString(0);


                        JObject left = new JObject();
                        JObject right = new JObject();

                        SQLiteCommand command3 = Connection.CreateCommand();
                        command3.CommandText = "SELECT col_1 FROM data where col_2 = '" + key + "'";

                        var reader3 = command3.ExecuteReader();
                        while (reader3.Read())
                        {
                            left[reader3.GetString(0)] = "";
                        }

                        if (left.Count >= 2)
                        {

                            SQLiteCommand command2 = Connection.CreateCommand();
                            command2.CommandText = "SELECT col_2 FROM data where col_1 = '" + key + "'";
                            var reader2 = command2.ExecuteReader();
                            while (reader2.Read())
                            {
                                right[reader2.GetString(0)] = "";
                            }
                            JObject item = new JObject();
                            item["l"] = left;
                            item["r"] = right;
                            jo[key] = item;
                            lst.Add(key);
                        }
                        
                        Console.WriteLine(string.Format("col_1 = {0}, cnt = {1}",
                            reader.GetString(0),
                            reader.GetInt16(1)
                        ));
                    }

                    tb_output.Text = jo.ToString();
                    tb_output.Text += "=======================";
                    tb_output.Text += lst.ToString();
                }
            }
        }
    }
}
