using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Library
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0RV7KDT\SQLEXPRESS;Initial Catalog=Lıbrary;Integrated Security=True");


        private void View()
        {
            listView1.Items.Clear();
            conn.Open();

            SqlCommand cmd = new SqlCommand("select*from Library", conn);
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                ListViewItem item = new ListViewItem();
                item.Text = (rdr["Id"].ToString());
                item.SubItems.Add(rdr["Book"].ToString());
                item.SubItems.Add(rdr["Author"].ToString());
                item.SubItems.Add(rdr["Publisher"].ToString());
                item.SubItems.Add(rdr["Page"].ToString());
                listView1.Items.Add(item);


            }

            conn.Close();
        }

        private void Clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            View();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("insert into Library (Id,Book,Author,Publisher,Page) values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "')",conn);
            cmd.ExecuteNonQuery();
            Clear();
            MessageBox.Show("Added..");
            conn.Close();


        }
        int id = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from Library where Id=(" + id + ")", conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Deleted..");
            Clear();
            conn.Close();
            View();

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[3].Text;
            textBox5.Text = listView1.SelectedItems[0].SubItems[4].Text;

        }
    }
}
