using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace quaysotrungthuong
{
    public partial class main : Form
    {
        int a = 0;
        int dem = 0;
        int so;
        int[] so_da_chon = { 66, 60, 53, 102, 96, 177, 125, 172, 64, 86, 110, 57, 133, 62, 49 };
        public main()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void main_Click(object sender, EventArgs e)
        {
            if (dem == a)
            {
                a++;
                //----------------------------------------------------//
                Random quay = new Random();
                if (dem >= 16)
                {
                    label2.Text = "Chúc mừng\r\n" +
                        "hẹn gặp lại!";
                }
                else
                {
                    so = quay.Next(1, 180);
                    //kiểm tra số có bị trùng không, nếu trùng thì quay đến khi hết trùng mới ra kết quả//
                    for (int i = 0; i < so_da_chon.Length; i++)
                    {
                        if (so == so_da_chon[i])
                        {
                            so = quay.Next(1, 180);
                            i = 1;
                        }
                    }
                    //----------------------------------------------------------------------------------//

                    //-----------------------Hiển thị số quay--------------------------------//
                    ThreadStart ts = new ThreadStart(show);
                    Thread thrd = new Thread(ts);
                    thrd.Start();
                    void show()
                    {
                        for (int i = 1; i < 40; i++)
                        {
                            //this.label_start.Text = "ĐANG QUAY SỐ";
                            Random quay1 = new Random();
                            int number = quay1.Next(1, 180);
                            showlabel.Text = number.ToString();
                            Thread.Sleep(100);
                        }

                        //-----------------Hiển thị kết quả----------------------------//
                        so_da_chon[dem] = so;
                        showlabel.Text = so_da_chon[dem].ToString();

                        //--------------------show danh sách trúng giải khuyến khích------------//

                        //----------------------------------------------------//

                        //this.label_start.Text = "MỜI QUAY SỐ";
                        dem = dem + 1;
                        //------------------------------------------------------------//
                    }
                    //-----------------------------------------------------------------------//
                }
            }
        }
    }
}
