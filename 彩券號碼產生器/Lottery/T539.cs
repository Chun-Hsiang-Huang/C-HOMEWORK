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

namespace Lottery
{
    public partial class T539 : Form
    {
        SqlConnectionStringBuilder scsb;
        public T539()
        {
            InitializeComponent();
        }

        private void T539_Load(object sender, EventArgs e)
        {
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";//資料來源.DataBase的名稱 @".\MSQL"  @表示忽略""內的特殊符號
            scsb.InitialCatalog = "csharp1";
            scsb.IntegratedSecurity = true;

        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            //取得資料筆數
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSQL = "select * from T1";//建立SQL字串
            SqlCommand cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();

            string strOutPut = "";
            int i = 0;

            while (reader.Read() == true)//有讀到資料  迴圈就一直執行
            {
                strOutPut += string.Format("{0}\n", reader["期別"]);
                i += 1;
            }
            strOutPut += "資料筆數:" + i.ToString();
            reader.Close();
            con.Close();

            MessageBox.Show(strOutPut);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (tBox1.Text.Length > 0)
            {
                SqlConnection con = new SqlConnection(scsb.ToString());
                con.Open();
                string strSQL = "select * from T1 where 期別 like @SearchName";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@SearchName", "%" + tBox1.Text + "%");
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    tBox1.Text = string.Format("{0}", reader["期別"]);
                    dtpTime.Text = string.Format("{0}", reader["時間"]);
                    tbnum1.Text = string.Format("{0}", reader["num1"]);
                    tbnum2.Text = string.Format("{0}", reader["num2"]);
                    tbnum3.Text = string.Format("{0}", reader["num3"]);
                    tbnum4.Text = string.Format("{0}", reader["num4"]);
                    tbnum5.Text = string.Format("{0}", reader["num5"]);

                    //chkIfmarriage.Checked = (bool)reader["婚姻狀態"];
                }
                else
                {
                    MessageBox.Show("查無號碼");
                    tBox1.Text = "";
                    dtpTime.Text = "";
                    tbnum1.Text = "";
                    tbnum2.Text = "";
                    tbnum3.Text = "";
                    tbnum4.Text = "";
                    tbnum5.Text = "";
                }
                reader.Close();
                con.Close();
            }
            else
            {
                MessageBox.Show("請輸入期別");
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (tBox1.Text.Length > 0)
            {
                SqlConnection con = new SqlConnection(scsb.ToString());
                con.Open();
                string strSQL = "update T1 set 時間=@NewPhone,num1=@NewAdderss,num2=@NewEmail,num3=@NewBirth,num4=@NewMarriage ,num5=@NewMarry where 期別=@SearchName";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@SearchName", tBox1.Text);
                cmd.Parameters.AddWithValue("@NewAdderss", tbnum1.Text);
                cmd.Parameters.AddWithValue("@NewPhone", dtpTime.Value);
                cmd.Parameters.AddWithValue("@NewEmail", tbnum2.Text);
                cmd.Parameters.AddWithValue("@NewBirth", tbnum3.Text);
                cmd.Parameters.AddWithValue("@NewMarriage", tbnum4.Text);
                cmd.Parameters.AddWithValue("@NewMarry", tbnum5.Text);


                int rows = cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(string.Format("資料更新完畢，共影響{0}筆資料", rows));

            }
            else
            {
                MessageBox.Show("請輸入號碼");
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (tBox1.Text.Length > 0)
            {
                SqlConnection con = new SqlConnection(scsb.ToString());
                con.Open();
                string strSQL = "insert  into T1 values ( @SearchName,@NewPhone,@NewAdderss,@NewEmail,@NewBirth,@NewMarriage ,@NewMarry )";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@SearchName", tBox1.Text);
                cmd.Parameters.AddWithValue("@NewPhone", dtpTime.Value);
                cmd.Parameters.AddWithValue("@NewAdderss", tbnum1.Text);
                cmd.Parameters.AddWithValue("@NewEmail", tbnum2.Text);
                cmd.Parameters.AddWithValue("@NewBirth", tbnum3.Text);
                cmd.Parameters.AddWithValue("@NewMarriage", tbnum4.Text);
                cmd.Parameters.AddWithValue("@NewMarry", tbnum5.Text);


                int rows = cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(string.Format("資料更新完畢，共影響{0}筆資料", rows));

            }
            else
            {
                MessageBox.Show("請輸入號碼");
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (tBox1.Text.Length > 0)
            {
                SqlConnection con = new SqlConnection(scsb.ToString());
                con.Open();
                string strSQL = "delete from T1 where 期別=@OldNum ";
                SqlCommand cmd = new SqlCommand(strSQL, con);

                cmd.Parameters.AddWithValue("@OldNum", tBox1.Text);


                int rows = cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(string.Format("資料更新完畢，共影響{0}筆資料", rows));
                tBox1.Text = "";
                dtpTime.Value=DateTime.Now;
                tbnum1.Text = "";
                tbnum2.Text = "";
                tbnum3.Text = "";
                tbnum4.Text = "";
                tbnum5.Text = "";
                
            }
            else
            {
                MessageBox.Show("請輸入號碼");
            }
        }
    }
}
