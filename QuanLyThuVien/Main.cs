using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        public static string TenDN, MatKhau, Quyen;
        SqlCommand sqlCommand;
        public Object layGiaTri(string sql) //lay gia tri cua  cot dau tien trong bang 
        {
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = sql;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = Con;

            //CHi can lay ve gia tri cua mot truong thoi thi dung pt nao ? - ExecuteScalar
            Object obj = sqlCommand.ExecuteScalar(); //neu co loi thi phai xem lai cua lenh SQL o ben kia
            return obj;
            //Ket qua de dau ? - de trong obj
        }
        private void button1_Click(object sender, EventArgs e)
        {
            TenDN = tbAccountMain.Text;
            MatKhau = tbPasswordMain.Text;
            if (TenDN != "")
            {
                object Q = layGiaTri("select QuyenHan from tblNhanVien where TaiKhoan='" + TenDN + "' and MatKhau='" + MatKhau + "'");
                if (Q == null)
                {
                    MessageBox.Show("Sai tài khoản");
                }
                else
                {
                    MessageBox.Show("Đăng nhập thành công");
                    Quyen = Convert.ToString(Q);
                    if (Quyen == "user")
                    {
                        quảnLyToolStripMenuItem.Enabled = true;
                        tìmKiếmToolStripMenuItem.Enabled = true;
                        tìmKiếmSáchToolStripMenuItem.Enabled = true;
                        tìmKiếmĐGToolStripMenuItem.Enabled = true;
                        cậpNhậtToolStripMenuItem.Enabled = true;
                        mượnSáchToolStripMenuItem.Enabled = true;
                        báoCáoToolStripMenuItem.Enabled = true;
                        cậpNhậtSáchToolStripMenuItem.Enabled = true;
                        cậpNhậtTácGiảToolStripMenuItem.Enabled = true;
                        cậpNhậtToolStripMenuItem1.Enabled = true;
                        cậpNhậtLĩnhVựcToolStripMenuItem.Enabled = true;
                        cậpNhậtNhàXuấtBảnToolStripMenuItem.Enabled = true;
                        cậpNhậtThôngTinMượnToolStripMenuItem.Enabled = true;
                        tácGiảToolStripMenuItem.Enabled = true;
                        nhàXuấtBảnToolStripMenuItem.Enabled = true;
                        lĩnhVựcToolStripMenuItem.Enabled = true;
                        độcGiảToolStripMenuItem.Enabled = true;
                        sáchToolStripMenuItem.Enabled = true;
                        tạoTàiKhoảnToolStripMenuItem.Enabled = false;
                        cậpNhậtNhânViênToolStripMenuItem.Enabled = true;
                        đổiMậtKhẩuToolStripMenuItem.Enabled = true;
                    }
                    if (Quyen == "admin")
                    {
                        quảnLyToolStripMenuItem.Enabled = true;
                        tìmKiếmToolStripMenuItem.Enabled = true;
                        tìmKiếmSáchToolStripMenuItem.Enabled = true;
                        KiêmTratoolStripMenuItem1.Enabled = true;
                        tìmKiếmĐGToolStripMenuItem.Enabled = true;
                        cậpNhậtToolStripMenuItem.Enabled = true;
                        mượnSáchToolStripMenuItem.Enabled = true;
                        báoCáoToolStripMenuItem.Enabled = true;
                        cậpNhậtSáchToolStripMenuItem.Enabled = true;
                        cậpNhậtTácGiảToolStripMenuItem.Enabled = true;
                        cậpNhậtToolStripMenuItem1.Enabled = true;
                        cậpNhậtLĩnhVựcToolStripMenuItem.Enabled = true;
                        cậpNhậtNhàXuấtBảnToolStripMenuItem.Enabled = true;
                        cậpNhậtThôngTinMượnToolStripMenuItem.Enabled = true;
                        tácGiảToolStripMenuItem.Enabled = true;
                        nhàXuấtBảnToolStripMenuItem.Enabled = true;
                        lĩnhVựcToolStripMenuItem.Enabled = true;
                        độcGiảToolStripMenuItem.Enabled = true;
                        sáchToolStripMenuItem.Enabled = true;
                        tạoTàiKhoảnToolStripMenuItem.Enabled = true;
                        cậpNhậtNhânViênToolStripMenuItem.Enabled = true;
                        đổiMậtKhẩuToolStripMenuItem.Enabled = true;
                    }
                    tbAccountMain.Text = "";
                    tbPasswordMain.Text = "";
                    groupBox1.Enabled = false;
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát khỏi chương trình không ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                e.Cancel = false;
            else
                e.Cancel = true;
        }

        private void thoátToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        SqlConnection Con;
        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                Con = new SqlConnection();
                Con.ConnectionString = @"server=LAPTOP-3HNJNCEK\SQLEXPRESS; database=Library; user=sa; password=12345678";
                Con.Open();
            }
            catch { MessageBox.Show("Không thể kết nối"); }
        }

        private void cậpNhậtSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            capnhatsach cnsach = new capnhatsach();
            cnsach.Show();
        }

        private void cậpNhậtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            capnhatdocgia cndocgia = new capnhatdocgia();
            cndocgia.Show();

        }

        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void cậpNhậtNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            capnhatnhanvien cnnhanvien = new capnhatnhanvien();
            cnnhanvien.Show();
        }

        private void cậpNhậtTácGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            capnhatTG cnTG = new capnhatTG();
            cnTG.Show();
        }

        private void cậpNhậtNhàXuấtBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            capnhatNXB cnNXB = new capnhatNXB();
            cnNXB.Show();
        }

        private void cậpNhậtLĩnhVựcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            capnhatLv cnLV = new capnhatLv();
            cnLV.Show();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoiMatKhau doimatkhau = new DoiMatKhau();
            doimatkhau.Show();
        }

        private void cậpNhậtThôngTinMượnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            thongtinmuon T = new thongtinmuon();
            T.Show();
        }

        private void tạoTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaoTaiKhoan TAO = new TaoTaiKhoan();
            TAO.Show();
        }

        private void tìnhTrạngSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BCTinhTrangSach BCTTS = new BCTinhTrangSach();
            BCTTS.Show();
        }

        private void sốĐộcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BCDocGia BCDG = new BCDocGia();
            BCDG.Show();
        }
        private void tácGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ttTacgia ttTG = new ttTacgia();
            ttTG.Show();
        }

        private void nhàXuấtBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ttNXB ttnxb = new ttNXB();
            ttnxb.Show();
        }

        private void lĩnhVựcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ttLinhVuc ttlv = new ttLinhVuc();
            ttlv.Show();
        }

        private void sáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ttSach ttsach = new ttSach();
            ttsach.Show();
        }

        private void độcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ttDocgia ttDG = new ttDocgia();
            ttDG.Show();
        }
        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            quảnLyToolStripMenuItem.Enabled = false;
            tìmKiếmToolStripMenuItem.Enabled = false;
            tìmKiếmSáchToolStripMenuItem.Enabled = false;
            KiêmTratoolStripMenuItem1.Enabled = false;
            tìmKiếmĐGToolStripMenuItem.Enabled = false;
            cậpNhậtToolStripMenuItem.Enabled = false;
            mượnSáchToolStripMenuItem.Enabled = false;
            báoCáoToolStripMenuItem.Enabled = false;
            cậpNhậtSáchToolStripMenuItem.Enabled = false;
            cậpNhậtTácGiảToolStripMenuItem.Enabled = false;
            cậpNhậtToolStripMenuItem1.Enabled = false;
            cậpNhậtLĩnhVựcToolStripMenuItem.Enabled = false;
            cậpNhậtNhàXuấtBảnToolStripMenuItem.Enabled = false;
            cậpNhậtThôngTinMượnToolStripMenuItem.Enabled = false;
            tácGiảToolStripMenuItem.Enabled = false;
            nhàXuấtBảnToolStripMenuItem.Enabled = false;
            lĩnhVựcToolStripMenuItem.Enabled = false;
            độcGiảToolStripMenuItem.Enabled = false;
            sáchToolStripMenuItem.Enabled = false;
            tạoTàiKhoảnToolStripMenuItem.Enabled = false;
            cậpNhậtNhânViênToolStripMenuItem.Enabled = false;
            đổiMậtKhẩuToolStripMenuItem.Enabled = false;
        }

        private void tìmKiếmSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timkiem Sach = new timkiem();
            Sach.Show();
        }

        private void cậpNhậtToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tìmKiếmĐGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimkiemDG Dg = new TimkiemDG();
            Dg.Show();
        }

        private void KiêmTratoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            KiemTraTTNhanVien K = new KiemTraTTNhanVien();
            K.Show();
        }

    }
}
