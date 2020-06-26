using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityUrunDesktopApp
{
    public partial class FrmUrun : Form
    {
        public FrmUrun()
        {
            InitializeComponent();
        }
        DbEntityUrunEntities db = new DbEntityUrunEntities();
        private void FrmUrun_Load(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = db.TBL_URUN.ToList();
            var Kategoriler = (from x in db.TBL_KATEGORI
                               select new
                               { x.ID, x.AD }
            ).ToList();

            comboBox1.ValueMember = "ID";
            comboBox1.DisplayMember = "AD";
            comboBox1.DataSource = Kategoriler;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from x in db.TBL_URUN select new { x.URUNID, x.URUNAD, x.MARKA, x.STOK, x.FİYAT, x.TBL_KATEGORI.AD, x.DURUM }).ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TBL_URUN t = new TBL_URUN();
            t.URUNAD = TxtUrunAd.Text;
            t.MARKA = TxtMarka.Text;
            t.STOK = int.Parse(TxtStok.Text);
            t.KATEGORI = int.Parse(comboBox1.SelectedValue.ToString());
            t.FİYAT = decimal.Parse(TxtFiyat.Text);
            t.DURUM = true;
            db.TBL_URUN.Add(t);
            db.SaveChanges();
            MessageBox.Show("Sisteme Kaydedildi");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(TxtID.Text);
            var urun = db.TBL_URUN.Find(x);
            db.TBL_URUN.Remove(urun);
            db.SaveChanges();
            MessageBox.Show("Ürün Silindi...");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(TxtID.Text);
            var urun = db.TBL_URUN.Find(x);
            urun.URUNAD = TxtUrunAd.Text;
            urun.MARKA = TxtMarka.Text;
            urun.STOK = int.Parse(TxtStok.Text);
            urun.FİYAT = decimal.Parse(TxtFiyat.Text);
            urun.DURUM = true;
            urun.KATEGORI = int.Parse(comboBox1.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Ürün Güncellendi...");

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            TxtID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TxtUrunAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtMarka.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            TxtStok.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            TxtFiyat.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            TxtDurum.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();

        }
    }
}
