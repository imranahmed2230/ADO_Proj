using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectMainADO
{
    public partial class Public_Portal : Form
    {
        public Public_Portal()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\v11.0;Initial Catalog=ProjectMainADO;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            string sub = "INSERT INTO tblPublic (Pname,Pphno,Pmail,Pselopt,Pdescription) VALUES ('" + textBox1.Text + "'," + textBox2.Text + ",'" + textBox3.Text +"','" + comboBox1.Text + "','" + textBox4.Text + "')";

            SqlCommand cmd = new SqlCommand(sub,con);
            con.Open();
            int r = cmd.ExecuteNonQuery();
            MessageBox.Show((r > 0) ? "Data Inserted" : "Data Insertion Failed");
            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string upd = "UPDATE tblPublic SET Pphno="+textBox2.Text+",Pmail='"+textBox3.Text+"',Pselopt='"+comboBox1.Text+"',Pdescription='"+textBox4.Text+"' WHERE Pname='"+textBox1.Text+"'";
            SqlCommand cmd = new SqlCommand(upd,con);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            MessageBox.Show((res > 0) ? "Modification Successful" : "Modification Failed");
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string view = "SELECT *FROM tblPublic";
            SqlCommand v = new SqlCommand(view, con);
            SqlDataAdapter sda = new SqlDataAdapter(v);
            DataSet ds= new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource =ds;
            dataGridView1.DataMember="table";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string load = "SELECT Pname,Pphno,pmail,Pselopt,Pdescription FROM tblPublic WHERE Pname='" + textBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(load, con);
            con.Open();
            SqlDataReader sd = cmd.ExecuteReader();
            while (sd.Read())
            {
                textBox1.Text = sd["Pname"].ToString();
                textBox2.Text = sd["Pphno"].ToString();
                textBox3.Text = sd["Pmail"].ToString();
                comboBox1.Text = sd["Pselopt"].ToString();
                textBox4.Text = sd["Pdescription"].ToString();
                //if (sd["Pselopt"].ToString() == "Feedback") 

            }
            con.Close();
             
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string del = "DELETE FROM tblPublic WHERE Pname='" + textBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(del, con);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            MessageBox.Show((res > 0) ? "Deleted Successfully" : "Deletion Failed");
            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.SelectedIndex=-1;
            textBox4.Clear();
        }
    }
}
