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
    public partial class BH649 : Form
    {
        SqlConnectionStringBuilder scsb;
        public BH649()
        {
            InitializeComponent();
        }

        private void BH649_Load(object sender, EventArgs e)
        {
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";//資料來源.DataBase的名稱 @".\MSQL"  @表示忽略""內的特殊符號
            scsb.InitialCatalog = "csharp1";
            scsb.IntegratedSecurity = true;
        }

        private void btnCount1_Click(object sender, EventArgs e)
        {
            //取得資料筆數
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSQL = "select * from T2";//建立SQL字串
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

        private void btnSearch1_Click(object sender, EventArgs e)
        {
            if (tBox2.Text.Length > 0)
            {
                SqlConnection con = new SqlConnection(scsb.ToString());
                con.Open();
                string strSQL = "select * from T2 where 期別 like @SearchName";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@SearchName", "%" + tBox2.Text + "%");
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    tBox2.Text = string.Format("{0}", reader["期別"]);
                    dtpTime2.Text = string.Format("{0}", reader["時間"]);
                    tbBH1.Text = string.Format("{0}", reader["num1"]);
                    tbBH2.Text = string.Format("{0}", reader["num2"]);
                    tbBH3.Text = string.Format("{0}", reader["num3"]);
                    tbBH4.Text = string.Format("{0}", reader["num4"]);
                    tbBH5.Text = string.Format("{0}", reader["num5"]);
                    tbBH6.Text = string.Format("{0}", reader["num6"]);

                    //chkIfmarriage.Checked = (bool)reader["婚姻狀態"];
                }
                else
                {
                    MessageBox.Show("查無號碼");
                    tBox2.Text = "";
                    dtpTime2.Text = "";
                    tbBH1.Text = "";
                    tbBH2.Text = "";
                    tbBH3.Text = "";
                    tbBH4.Text = "";
                    tbBH5.Text = "";
                    tbBH6.Text = "";
                }
                reader.Close();
                con.Close();
            }
            else
            {
                MessageBox.Show("請輸入期別");
            }
        }

        private void btnModify1_Click(object sender, EventArgs e)
        {
            if (tBox2.Text.Length > 0)
            {
                SqlConnection con = new SqlConnection(scsb.ToString());
                con.Open();
                string strSQL = "update T2 set 時間=@NewPhone, num1=@NewAdderss, num2=@NewEmail, num3=@NewBirth, num4=@NewMarriage , num5=@NewMarry, num6=@NewNumber where 期別=@SearchName";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@SearchName", tBox2.Text);
                cmd.Parameters.AddWithValue("@NewAdderss", tbBH1.Text);
                cmd.Parameters.AddWithValue("@NewPhone", dtpTime2.Value);
                cmd.Parameters.AddWithValue("@NewEmail", tbBH2.Text);
                cmd.Parameters.AddWithValue("@NewBirth", tbBH3.Text);
                cmd.Parameters.AddWithValue("@NewMarriage", tbBH4.Text);
                cmd.Parameters.AddWithValue("@NewMarry", tbBH5.Text);
                cmd.Parameters.AddWithValue("@NewNumber", tbBH6.Text);


                int rows = cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(string.Format("資料更新完畢，共影響{0}筆資料", rows));

            }
            else
            {
                MessageBox.Show("請輸入號碼");
            }
        }

        private void btnNew1_Click(object sender, EventArgs e)
        {
            if (tBox2.Text.Length > 0)
            {
                SqlConnection con = new SqlConnection(scsb.ToString());
                con.Open();
                string strSQL = "insert  into T2 values ( @SearchName,@NewPhone,@NewAdderss,@NewEmail,@NewBirth,@NewMarriage ,@NewMarry,@NewNumber )";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@SearchName", tBox2.Text);
                cmd.Parameters.AddWithValue("@NewPhone", dtpTime2.Value);
                cmd.Parameters.AddWithValue("@NewAdderss", tbBH1.Text);
                cmd.Parameters.AddWithValue("@NewEmail", tbBH2.Text);
                cmd.Parameters.AddWithValue("@NewBirth", tbBH3.Text);
                cmd.Parameters.AddWithValue("@NewMarriage", tbBH4.Text);
                cmd.Parameters.AddWithValue("@NewMarry", tbBH5.Text);
                cmd.Parameters.AddWithValue("@NewNumber", tbBH6.Text);


                int rows = cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(string.Format("資料更新完畢，共影響{0}筆資料", rows));

            }
            else
            {
                MessageBox.Show("請輸入期別");
            }
        }

        private void btnDel1_Click(object sender, EventArgs e)
        {
            if (tBox2.Text.Length > 0)
            {
                SqlConnection con = new SqlConnection(scsb.ToString());
                con.Open();
                string strSQL = "delete from T2 where 期別=@OldNum ";
                SqlCommand cmd = new SqlCommand(strSQL, con);

                cmd.Parameters.AddWithValue("@OldNum", tBox2.Text);


                int rows = cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(string.Format("資料更新完畢，共影響{0}筆資料", rows));
                tBox2.Text = "";
                dtpTime2.Value = DateTime.Now;
                tbBH1.Text = "";
                tbBH2.Text = "";
                tbBH3.Text = "";
                tbBH4.Text = "";
                tbBH5.Text = "";
                tbBH6.Text = "";

            }
            else
            {
                MessageBox.Show("請輸入期別");
            }
        }
    }
}
