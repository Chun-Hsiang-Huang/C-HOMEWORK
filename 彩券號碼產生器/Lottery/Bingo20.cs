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
    public partial class Bingo20 : Form
    {
        SqlConnectionStringBuilder scsb;
        public Bingo20()
        {
            InitializeComponent();
        }

        private void Bingo20_Load(object sender, EventArgs e)
        {
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";//資料來源.DataBase的名稱 @".\MSQL"  @表示忽略""內的特殊符號
            scsb.InitialCatalog = "csharp1";
            scsb.IntegratedSecurity = true;
        }

        private void btnCount2_Click(object sender, EventArgs e)
        {
            //取得資料筆數
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSQL = "select * from T3";//建立SQL字串
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

        private void btnSearch2_Click(object sender, EventArgs e)
        {
            if (tBox3.Text.Length > 0)
            {
                SqlConnection con = new SqlConnection(scsb.ToString());
                con.Open();
                string strSQL = "select * from T3 where 期別 like @SearchName";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@SearchName", "%" + tBox3.Text + "%");
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    tBox3.Text = string.Format("{0}", reader["期別"]);
                    dtpTime3.Text = string.Format("{0}", reader["時間"]);
                    tbBin1.Text = string.Format("{0}", reader["num1"]);
                    tbBin2.Text = string.Format("{0}", reader["num2"]);
                    tbBin3.Text = string.Format("{0}", reader["num3"]);
                    tbBin4.Text = string.Format("{0}", reader["num4"]);
                    tbBin5.Text = string.Format("{0}", reader["num5"]);
                    tbBin6.Text = string.Format("{0}", reader["num6"]);
                    tbBin7.Text = string.Format("{0}", reader["num7"]);
                    tbBin8.Text = string.Format("{0}", reader["num8"]);
                    tbBin9.Text = string.Format("{0}", reader["num9"]);
                    tbBin10.Text = string.Format("{0}", reader["num10"]);

                    
                }
                else
                {
                    MessageBox.Show("查無號碼");
                    tBox3.Text = "";
                    dtpTime3.Value = DateTime.Now;
                    tbBin1.Text = "";
                    tbBin2.Text = "";
                    tbBin3.Text = "";
                    tbBin4.Text = "";
                    tbBin5.Text = "";
                    tbBin6.Text = "";
                    tbBin7.Text = "";
                    tbBin8.Text = "";
                    tbBin9.Text = "";
                    tbBin10.Text = "";
                }
                reader.Close();
                con.Close();
            }
            else
            {
                MessageBox.Show("請輸入期別");
            }
        }

        private void btnModify2_Click(object sender, EventArgs e)
        {
            if (tBox3.Text.Length > 0)
            {
                SqlConnection con = new SqlConnection(scsb.ToString());
                con.Open();
                string strSQL = "update T3 set 時間=@NewPhone, num1=@NewAdderss, num2=@NewEmail, num3=@NewBirth, num4=@NewMarriage , num5=@NewMarry, num6=@NewNumber, num7=@NewNumber1, num8=@NewNumber2, num9=@NewNumber3, num10=@NewNumber4 where 期別=@SearchName";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@SearchName", tBox3.Text);
                cmd.Parameters.AddWithValue("@NewAdderss", tbBin1.Text);
                cmd.Parameters.AddWithValue("@NewPhone", dtpTime3.Value);
                cmd.Parameters.AddWithValue("@NewEmail", tbBin2.Text);
                cmd.Parameters.AddWithValue("@NewBirth", tbBin3.Text);
                cmd.Parameters.AddWithValue("@NewMarriage", tbBin4.Text);
                cmd.Parameters.AddWithValue("@NewMarry", tbBin5.Text);
                cmd.Parameters.AddWithValue("@NewNumber", tbBin6.Text);
                cmd.Parameters.AddWithValue("@NewNumber1", tbBin7.Text);
                cmd.Parameters.AddWithValue("@NewNumber2", tbBin8.Text);
                cmd.Parameters.AddWithValue("@NewNumber3", tbBin9.Text);
                cmd.Parameters.AddWithValue("@NewNumber4", tbBin10.Text);

                int rows = cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(string.Format("資料更新完畢，共影響{0}筆資料", rows));

            }
            else
            {
                MessageBox.Show("請輸入期別");
            }
        }

        private void btnNew2_Click(object sender, EventArgs e)
        {
            if (tBox3.Text.Length > 0)
            {
                SqlConnection con = new SqlConnection(scsb.ToString());
                con.Open();
                string strSQL = "insert  into T3 values ( @SearchName,@NewPhone,@NewAdderss,@NewEmail,@NewBirth,@NewMarriage ,@NewMarry,@NewNumber, @NewNumber1, @NewNumber2, @NewNumber3, @NewNumber4 )";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@SearchName", tBox3.Text);
                cmd.Parameters.AddWithValue("@NewPhone", dtpTime3.Value);
                cmd.Parameters.AddWithValue("@NewAdderss", tbBin1.Text);
                cmd.Parameters.AddWithValue("@NewEmail", tbBin2.Text);
                cmd.Parameters.AddWithValue("@NewBirth", tbBin3.Text);
                cmd.Parameters.AddWithValue("@NewMarriage", tbBin4.Text);
                cmd.Parameters.AddWithValue("@NewMarry", tbBin5.Text);
                cmd.Parameters.AddWithValue("@NewNumber", tbBin6.Text);
                cmd.Parameters.AddWithValue("@NewNumber1", tbBin7.Text);
                cmd.Parameters.AddWithValue("@NewNumber2", tbBin8.Text);
                cmd.Parameters.AddWithValue("@NewNumber3", tbBin9.Text);
                cmd.Parameters.AddWithValue("@NewNumber4", tbBin10.Text);


                int rows = cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(string.Format("資料更新完畢，共影響{0}筆資料", rows));

            }
            else
            {
                MessageBox.Show("請輸入期別");
            }
        }

        private void btnDel2_Click(object sender, EventArgs e)
        {
            if (tBox3.Text.Length > 0)
            {
                SqlConnection con = new SqlConnection(scsb.ToString());
                con.Open();
                string strSQL = "delete from T3 where 期別=@OldNum ";
                SqlCommand cmd = new SqlCommand(strSQL, con);

                cmd.Parameters.AddWithValue("@OldNum", tBox3.Text);


                int rows = cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(string.Format("資料更新完畢，共影響{0}筆資料", rows));
                tBox3.Text = "";
                dtpTime3.Value = DateTime.Now;
                tbBin1.Text = "";
                tbBin2.Text = "";
                tbBin3.Text = "";
                tbBin4.Text = "";
                tbBin5.Text = "";
                tbBin6.Text = "";
                tbBin7.Text = "";
                tbBin8.Text = "";
                tbBin9.Text = "";
                tbBin10.Text = "";

            }
            else
            {
                MessageBox.Show("請輸入期別");
            }
        }
    }
}
