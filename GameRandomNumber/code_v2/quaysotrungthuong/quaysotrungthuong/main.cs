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
        int countClick = 0;
        int viTriSoDaChonTrongMang = 0;
        int so;
        int[] so_da_chon = new int[150];
        bool checkButton = false;

        public main()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            //label_ChucMung.Text = "";
            //label_HenGapLai.Text = "";
            this.button_Start.Text = "MỜI QUAY SỐ";
            this.button_Start.BackColor = Color.Yellow;

            label_khuyenkhich1.Text = "";
            label_khuyenkhich2.Text = "";
            label_khuyenkhich3.Text = "";
            label_khuyenkhich4.Text = "";
            label_khuyenkhich5.Text = "";
            label_khuyenkhich6.Text = "";
            label_khuyenkhich7.Text = "";
            label_khuyenkhich8.Text = "";
            label_khuyenkhich9.Text = "";
            label_khuyenkhich10.Text = "";
            label_ba1.Text = "";
            label_ba2.Text = "";
            label_ba3.Text = "";
            label_nhi1.Text = "";
            label_nhi2.Text = "";
            label_nhat.Text = "";
        }
        void RandomNumber()
        {
            if (viTriSoDaChonTrongMang == countClick)//giải quyết việc đang quay mà nhấn tiếp cũng k làm gì
            {
                checkButton = false;
                countClick++;
                //----------------------------------------------------//
                Random quay = new Random();
                if (viTriSoDaChonTrongMang >= 16)
                {
                    //label_ChucMung.Text = "Chúc mừng";
                    //label_HenGapLai.Text = "Hẹn gặp lại!";
                }
                else
                {
                    so = quay.Next(1, 150);//giới hạn số quay ở đây
                    //kiểm tra số có bị trùng không, nếu trùng thì quay đến khi hết trùng mới ra kết quả//
                    for (int i = 0; i < so_da_chon.Length; i++)
                    {
                        if (so == so_da_chon[i])
                        {
                            so = quay.Next(1, 150);
                            i = 1;
                        }
                    }
                    //----------------------------------------------------------------------------------//

                    //-----------------------Hiển thị số quay chạy song song với ct random--------------------------------//
                    ThreadStart ts = new ThreadStart(show);
                    Thread thrd = new Thread(ts);
                    thrd.Start();
                    void show()
                    {
                        for (int i = 1; i < 10; i++)
                        {
                            this.button_Start.Text = "ĐANG QUAY SỐ";
                            this.button_Start.BackColor = Color.Silver;
                            Random quay1 = new Random();
                            int number = quay1.Next(1, 150);
                            label_ShowRandom.Text = number.ToString();
                            Thread.Sleep(100);
                        }

                        //-----------------Hiển thị kết quả----------------------------//
                        so_da_chon[viTriSoDaChonTrongMang] = so;
                        label_ShowRandom.Text = so_da_chon[viTriSoDaChonTrongMang].ToString();

                        //--------------------show danh sách trúng giải khuyến khích------------//
                        if (viTriSoDaChonTrongMang == 0) label_khuyenkhich1.Text = so_da_chon[0].ToString();
                        else if (viTriSoDaChonTrongMang == 1) label_khuyenkhich2.Text = so_da_chon[1].ToString();
                        else if (viTriSoDaChonTrongMang == 2) label_khuyenkhich3.Text = so_da_chon[2].ToString();
                        else if (viTriSoDaChonTrongMang == 3) label_khuyenkhich4.Text = so_da_chon[3].ToString();
                        else if (viTriSoDaChonTrongMang == 4) label_khuyenkhich5.Text = so_da_chon[4].ToString();
                        else if (viTriSoDaChonTrongMang == 5) label_khuyenkhich6.Text = so_da_chon[5].ToString();
                        else if (viTriSoDaChonTrongMang == 6) label_khuyenkhich7.Text = so_da_chon[6].ToString();
                        else if (viTriSoDaChonTrongMang == 7) label_khuyenkhich8.Text = so_da_chon[7].ToString();
                        else if (viTriSoDaChonTrongMang == 8) label_khuyenkhich9.Text = so_da_chon[8].ToString();
                        else if (viTriSoDaChonTrongMang == 9) label_khuyenkhich10.Text = so_da_chon[9].ToString();
                        else if (viTriSoDaChonTrongMang == 10) label_ba1.Text = so_da_chon[10].ToString();
                        else if (viTriSoDaChonTrongMang == 11) label_ba2.Text = so_da_chon[11].ToString();
                        else if (viTriSoDaChonTrongMang == 12) label_ba3.Text = so_da_chon[12].ToString();
                        else if (viTriSoDaChonTrongMang == 13) label_nhi1.Text = so_da_chon[13].ToString();
                        else if (viTriSoDaChonTrongMang == 14) label_nhi2.Text = so_da_chon[14].ToString();
                        else if (viTriSoDaChonTrongMang == 15) label_nhat.Text = so_da_chon[15].ToString();
                        //----------------------------------------------------//

                        this.button_Start.Text = "MỜI QUAY SỐ";
                        this.button_Start.BackColor = Color.Yellow;
                        this.button_Back.Size = new System.Drawing.Size(92, 29);//92, 29
                        this.button_Back.Text = "QUAY LẠI";
                        viTriSoDaChonTrongMang = viTriSoDaChonTrongMang + 1;
                        checkButton = true;
                        //------------------------------------------------------------//
                    }
                    //-----------------------------------------------------------------------//
                }
            }
        }
        private void startbutton_Click(object sender, EventArgs e)
        {
            RandomNumber();
        }

        private void Button_Back_Click(object sender, EventArgs e)
        {
            if (checkButton == true)//nếu đang quay thì không cho bấm quay lại
            {
                viTriSoDaChonTrongMang--;
                countClick--;
                RandomNumber();
                this.button_Back.Text = "";
                this.button_Back.Size = new System.Drawing.Size(0, 0);//92, 29
            }
            button_Back.Enabled = false;
            Thread.Sleep(300);
            Application.DoEvents();
            button_Back.Enabled = true;
        }
    }
}
