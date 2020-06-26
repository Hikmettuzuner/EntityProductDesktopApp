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
    public partial class FrmKategori : Form
    {
        public FrmKategori()
        {
            InitializeComponent();
        }

        DbEntityUrunEntities db = new DbEntityUrunEntities();

        private void Form1_Load(object sender, EventArgs e)
        {

            var kategoriler = (from x in db.TBL_KATEGORI select new { x.ID, x.AD }).ToList();
            dataGridView1.DataSource = kategoriler;

        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            TBL_KATEGORI t = new TBL_KATEGORI();
            t.AD = textBox2.Text.ToString();
            db.TBL_KATEGORI.Add(t);
            db.SaveChanges();
            MessageBox.Show("Listeye Eklendi");

        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            var kategoriler = (from x in db.TBL_KATEGORI select new { x.ID, x.AD }).ToList();
            dataGridView1.DataSource = kategoriler;
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox3.Text);
            var ktgr = db.TBL_KATEGORI.Find(x);
            db.TBL_KATEGORI.Remove(ktgr);
            db.SaveChanges();
            MessageBox.Show("Silme Başarılı");
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox3.Text);
            var ktgr = db.TBL_KATEGORI.Find(x);
            ktgr.AD = textBox2.Text;
            db.SaveChanges();
            MessageBox.Show("Güncelleme Başarılı");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }
    }
}
