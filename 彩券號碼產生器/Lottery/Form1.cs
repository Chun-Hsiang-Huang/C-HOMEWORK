using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lottery
{
    public partial class Form1 : Form
    {
        List<Button> myDButtonList = new List<Button>();
        List<int> myIntList = new List<int>();
        List<int> myIntList2 = new List<int>();
        List<int> myIntList3 = new List<int>();
        List<int> range = new List<int>();
        int[] intArray3 = new int[10];
        int[] intTemp = new int[1];
        string[] temp = new string[1];
        int[] Sarray = new int[10];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            DynaimicButton1(8, 10);
            DynaimicButton2(5, 10);
            DynaimicButton3(4, 10);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            T539 myT539 = new T539();
            myT539.ShowDialog();
        }
        private void btnAdd2_Click(object sender, EventArgs e)
        {
            BH649 myBH649 = new BH649();
            myBH649.ShowDialog();
        }
        private void btnAdd3_Click(object sender, EventArgs e)
        {
            Bingo20 bin20 = new Bingo20();
            bin20.ShowDialog();
        }
        private void btnBingo_Click(object sender, EventArgs e)
        {
            TextBox[] tbx = new TextBox[] { tbBingo1, tbBingo2, tbBingo3, tbBingo4, tbBingo5,
                                            tbBingo6, tbBingo7, tbBingo8, tbBingo9, tbBingo10,
                                            };
            int[] aRRay = new int[10];
            int[] Sortarray = new int[10];
            Random myRnd = new Random();
            for (int k = 0; k <= aRRay.Length - 1; k++)
            {
                aRRay[k] = myRnd.Next(1, 81);
                while (Array.IndexOf(aRRay, aRRay[k], 0, k) > -1)
                {
                    aRRay[k] = myRnd.Next(1, 81);
                }
            }
            //開出順序  其中最後一個要在排序前顯示

            Sortarray[0] = aRRay[0]; Sortarray[1] = aRRay[1]; Sortarray[2] = aRRay[2];
            Sortarray[3] = aRRay[3]; Sortarray[4] = aRRay[4]; Sortarray[5] = aRRay[5];
            Sortarray[6] = aRRay[6]; Sortarray[7] = aRRay[7]; Sortarray[8] = aRRay[8];
            Sortarray[9] = aRRay[9];


            //排序後再顯示
            Array.Sort(Sortarray);
            foreach (int element in Sortarray) ;
            tbBingo1.Text = Sortarray[0].ToString(); tbBingo2.Text = Sortarray[1].ToString();
            tbBingo3.Text = Sortarray[2].ToString(); tbBingo4.Text = Sortarray[3].ToString();
            tbBingo5.Text = Sortarray[4].ToString(); tbBingo6.Text = Sortarray[5].ToString();
            tbBingo7.Text = Sortarray[6].ToString(); tbBingo8.Text = Sortarray[7].ToString();
            tbBingo9.Text = Sortarray[8].ToString(); tbBingo10.Text = Sortarray[9].ToString();
        }
        private void dButton1_Click(object sender, EventArgs e)
        {


            if (myIntList3.Count < 10)
            {
                Button myButton = (Button)sender;
                //myButton.Enabled = false;
                //MessageBox.Show(string.Format("{0}", myButton.Name));
                //int[] intArray3 = new int[10];
                TextBox[] manu = new TextBox[] { tbBinManu1, tbBinManu2, tbBinManu3, tbBinManu4, tbBinManu5, tbBinManu6, tbBinManu7, tbBinManu8, tbBinManu9, tbBinManu10 };
                int num2;
                //myButton.Enabled = false;
                num2 = Convert.ToInt32(myButton.Text);
                myIntList3.Add(num2);
                for (int i = 0; i < myIntList3.Count; i++)
                {

                    intArray3[i] = myIntList3[i];
                }
                tbBinManu1.Text = intArray3[0].ToString();
                tbBinManu2.Text = intArray3[1].ToString();
                tbBinManu3.Text = intArray3[2].ToString();
                tbBinManu4.Text = intArray3[3].ToString();
                tbBinManu5.Text = intArray3[4].ToString();
                tbBinManu6.Text = intArray3[5].ToString();
                tbBinManu7.Text = intArray3[6].ToString();
                tbBinManu8.Text = intArray3[7].ToString();
                tbBinManu9.Text = intArray3[8].ToString();
                tbBinManu10.Text = intArray3[9].ToString();

            }


            else if (myIntList3.Count >= 10)
            {
                MessageBox.Show("超過10個數字!");
            }

        }
        private void DynaimicButton1(int intCount, int intCount2)
        {

            for (int i = 0; i < intCount; i++)
            {
                for (int j = 0; j < intCount2; j++)
                {
                    if ((i == 8 && j == 9))
                    {
                        break;
                    }
                    else
                    {
                        int x = i * 10 + (j + 1);
                        Button dButton = new Button();//dButton是迴圈產生的按鈕
                        dButton.BackColor = Color.White;
                        dButton.ForeColor = Color.Black;
                        dButton.Location = new Point(100 + 60 * j, 200 + 40 * i);
                        dButton.Size = new Size(60, 40);
                        dButton.Text = x.ToString();
                        dButton.Name = "btn" + i.ToString() + "-" + j.ToString();
                        dButton.Font = new Font("微軟正黑體", 16);
                        //+=事件方法指定運算子
                        //-+事件方法解除運算子
                        dButton.Click += new EventHandler(dButton1_Click);
                        tabPage1.Controls.Add(dButton);
                        //Controls.Add(dButton);
                        myDButtonList.Add(dButton);//加到list陣列才可以使用
                    }

                }
            }

        }
        private void btnB649_Click(object sender, EventArgs e)
        {
            int[] array = new int[7];
            int[] SortArray = new int[6];
            TextBox[] sort = new TextBox[] { tbSort1, tbSort2, tbSort3, tbSort4,
                                             tbSort5, tbSort6 };
            TextBox[] big = new TextBox[] {  tbBig1, tbBig2, tbBig3, tbBig4, tbBig5,
                                             tbBig6};
            int j;
            Random Rnd = new Random();
            for (j = 0; j <= 6; j++)
            {

                array[j] = Rnd.Next(1, 50);
                while (Array.IndexOf(array, array[j], 0, j) > -1)
                {
                    array[j] = Rnd.Next(1, 50);
                }
            }
            //開出順序
            tbBig1.Text = array[0].ToString();
            tbBig2.Text = array[1].ToString();
            tbBig3.Text = array[2].ToString();
            tbBig4.Text = array[3].ToString();
            tbBig5.Text = array[4].ToString();
            tbBig6.Text = array[5].ToString();
            //tbBig7.Text = array[6].ToString();


            //大小順序
            SortArray[0] = array[0];
            SortArray[1] = array[1];
            SortArray[2] = array[2];
            SortArray[3] = array[3];
            SortArray[4] = array[4];
            SortArray[5] = array[5];

            Array.Sort(SortArray);
            foreach (int element in SortArray) ;

            tbSort1.Text = SortArray[0].ToString();
            tbSort2.Text = SortArray[1].ToString();
            tbSort3.Text = SortArray[2].ToString();
            tbSort4.Text = SortArray[3].ToString();
            tbSort5.Text = SortArray[4].ToString();
            tbSort6.Text = SortArray[5].ToString();
            //tbSort7.Text = array[6].ToString();
        }

        private void dButton2_Click(object sender, EventArgs e)
        {

            Button myButton = (Button)sender;
            myButton.Enabled = false;
            //MessageBox.Show(string.Format("{0}", myButton.Name));
            int[] intArray2 = new int[6];
            TextBox[] manu = new TextBox[] { tbBManu1, tbBManu2, tbBManu3, tbBManu4, tbBManu5, tbBManu6 };
            int num1;
            myButton.Enabled = false;
            num1 = Convert.ToInt32(myButton.Text);
            myIntList2.Add(num1);
            for (int i = 0; i < myIntList2.Count; i++)
            {

                intArray2[i] = myIntList2[i];
            }
            tbBManu1.Text = intArray2[0].ToString();
            tbBManu2.Text = intArray2[1].ToString();
            tbBManu3.Text = intArray2[2].ToString();
            tbBManu4.Text = intArray2[3].ToString();
            tbBManu5.Text = intArray2[4].ToString();
            tbBManu6.Text = intArray2[5].ToString();


        }

        private void DynaimicButton2(int intCount, int intCount2)
        {

            for (int i = 0; i < intCount; i++)
            {
                for (int j = 0; j < intCount2; j++)
                {
                    if ((i == 4 && j == 9))
                    {
                        break;
                    }
                    else
                    {
                        int x = i * 10 + (j + 1);
                        Button dButton = new Button();//dButton是迴圈產生的按鈕
                        dButton.BackColor = Color.White;
                        dButton.ForeColor = Color.Black;
                        dButton.Location = new Point(100 + 60 * j, 200 + 40 * i);
                        dButton.Size = new Size(60, 40);
                        dButton.Text = x.ToString();
                        dButton.Name = "btn" + i.ToString() + "-" + j.ToString();
                        dButton.Font = new Font("微軟正黑體", 16);
                        //+=事件方法指定運算子
                        //-+事件方法解除運算子
                        dButton.Click += new EventHandler(dButton2_Click);
                        tabPage2.Controls.Add(dButton);
                        //Controls.Add(dButton);
                        myDButtonList.Add(dButton);//加到list陣列才可以使用
                    }

                }
            }

        }
        private void btnT539_Click(object sender, EventArgs e)
        {
            //存開出順序
            TextBox[] txt = new TextBox[] { tbT53901, tbT53902, tbT53903, tbT53904, tbT53905 };
            //存大小順序
            TextBox[] tb = new TextBox[] { tbBTS1, tbBTS2, tbBTS3, tbBTS4, tbBTS5 };
            int[] array = new int[5];
            int[] SortArray = new int[5];
            Random random = new Random();


            for (int i = 0; i < 5; i++)
            {

                array[i] = random.Next(1, 40);
                while (Array.IndexOf(array, array[i], 0, i) > -1)
                {
                    array[i] = random.Next(1, 40);
                }
            }
            //開出順序
            tbT53901.Text = array[0].ToString();
            tbT53902.Text = array[1].ToString();
            tbT53903.Text = array[2].ToString();
            tbT53904.Text = array[3].ToString();
            tbT53905.Text = array[4].ToString();

            //大小順序
            SortArray[0] = array[0];
            SortArray[1] = array[1];
            SortArray[2] = array[2];
            SortArray[3] = array[3];
            SortArray[4] = array[4];

            Array.Sort(SortArray);
            foreach (int element in SortArray) ;
            tbBTS1.Text = SortArray[0].ToString();
            tbBTS2.Text = SortArray[1].ToString();
            tbBTS3.Text = SortArray[2].ToString();
            tbBTS4.Text = SortArray[3].ToString();
            tbBTS5.Text = SortArray[4].ToString();
        }

        private void dButton3_Click(object sender, EventArgs e)
        {
            int[] intArray = new int[5];
            TextBox[] manu = new TextBox[] { tbTmanu1, tbTmanu2, tbTmanu3, tbTmanu4, tbTmanu5 };
            int num;
            Button myButton = (Button)sender;
            myButton.Enabled = false;
            num = Convert.ToInt32(myButton.Text);
            myIntList.Add(num);
            for (int i = 0; i < myIntList.Count; i++)
            {

                intArray[i] = myIntList[i];
            }
            tbTmanu1.Text = intArray[0].ToString();
            tbTmanu2.Text = intArray[1].ToString();
            tbTmanu3.Text = intArray[2].ToString();
            tbTmanu4.Text = intArray[3].ToString();
            tbTmanu5.Text = intArray[4].ToString();
        }
        private void DynaimicButton3(int intCount, int intCount2)
        {

            for (int i = 0; i < intCount; i++)
            {
                for (int j = 0; j < intCount2; j++)
                {
                    if ((i == 3 && j == 9))
                    {
                        break;
                    }
                    else
                    {
                        int x = i * 10 + (j + 1);
                        Button dButton = new Button();//dButton是迴圈產生的按鈕
                        dButton.BackColor = Color.White;
                        dButton.ForeColor = Color.Black;
                        dButton.Location = new Point(1 + 60 * j, 200 + 40 * i);
                        dButton.Size = new Size(60, 40);
                        dButton.Text = x.ToString();
                        dButton.Name = "btn" + i.ToString() + "-" + j.ToString();
                        dButton.Font = new Font("微軟正黑體", 16);
                        //+=事件方法指定運算子
                        //-+事件方法解除運算子
                        dButton.Click += new EventHandler(dButton3_Click);
                        tabPage3.Controls.Add(dButton);
                        //Controls.Add(dButton);
                        myDButtonList.Add(dButton);//加到list陣列才可以使用
                    }

                }
            }

        }

       
    }
}
