
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace proje2
{
    public partial class UcakOyun : Form
    {
        // Düşman ve mermi tanımlandı       
        Image resDusman = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "dusman.png");
        Image resMermi = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "mermi.png");

        public UcakOyun()
        {
            InitializeComponent();
        }

        private void ucak_Click(object sender, EventArgs e)
        { }

        private void UcakOyun_Load(object sender, EventArgs e)
        {
            //Klavyeyi algılaması, düsmanların olsuması ve düsmanların yokedilmesi, ayrıca ekranı kilitleme
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            dOlZmn.Start();
            yokEtZmn.Start();
            this.KeyDown += new KeyEventHandler(UcakOyun_KeyDown);
        }

        // Klavye tuşlarının ayarlandığı yer
        private void UcakOyun_KeyDown(object sender, KeyEventArgs e)
        {
            int x = ucak.Location.X;

            if (e.KeyCode == Keys.Right) x += 20;

            else if (e.KeyCode == Keys.Left) x -= 20;


            if (x > 280)
                ucak.Location = new Point(280, 421);
            else if (x < 0)
                ucak.Location = new Point(0, 421);
            else
                ucak.Location = new Point(x, 421);
            //merminin oluşturulduğu yer. resmi, boyutu, hızı
            if (e.KeyCode == Keys.Space)
            {
                PictureBox mermi = new PictureBox();
                mermi.BackgroundImage = resMermi;
                mermi.SetBounds(ucak.Location.X + 17, ucak.Location.Y - 20, 8, 12);
                this.Controls.Add(mermi);
                mermi.Visible = true;
                mHarZmn.Start();
            }
        }

        // merminin nasıl gideceğinin ayarlandığı yer
        private void mHarZmn_Tick(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                PictureBox mermi = c as PictureBox;
                if (mermi.Height == 12)
                {
                    if (mermi.Location.Y > 0)
                    {
                        mermi.SetBounds(mermi.Location.X, mermi.Location.Y - 3, 8, 12);
                    }
                    else
                    {
                        mermi.Dispose();
                    }
                }
            }
        }

        //Düşman bilgileri yer alıyor. Rastgele oluşumu, resmi, boyutu, hareket zamanlayıcısı
        public void dusmanOlustur()
        {
            Random rand = new Random();
            PictureBox dusman = new PictureBox();            
            int konumX = rand.Next(0, 294);
            dusman.BackgroundImage = resDusman;
            dusman.BackgroundImageLayout = ImageLayout.Zoom;
            dusman.SetBounds(konumX, 5, 40, 40);
            this.Controls.Add(dusman);
            dusman.Visible = true;
            dHarZmn.Start();
        }

        // Düşmanın nasıl gideceğinin ayarlandığı yer
        private void dHarZmn_Tick(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                PictureBox dusman = c as PictureBox;
                if (dusman.Height == 40)
                {
                    // Düşman belirlenen koordinatlara geldiğinde oyun sona erer
                    if (dusman.Location.Y == ucak.Location.Y + 1)
                    {
                        dHarZmn.Stop();
                        dOlZmn.Stop();
                        mHarZmn.Stop();
                        //mesaj kutusu oluşturur.                        
                        DialogResult dr = MessageBox.Show("Devam etmek istiyor musunuz?", "Oyun Bitti!!!", MessageBoxButtons.YesNo);
                        //yeni form tanımlar. formu gösterir. son form dısındakileri kaldırır
                        if (dr == DialogResult.Yes)
                        {
                            UcakOyun form = new UcakOyun();
                            form.Show();
                            this.Dispose(false);
                        }
                        else
                            Application.Exit();
                    }
                    // Düşman hareketini ayarlar
                    dusman.SetBounds(dusman.Location.X, dusman.Location.Y + 3, 40, 40);
                }
            }
        }

        //Düşmanın oluşturulma sıklığı için zamanlayıcı      
        private void dOlZmn_Tick(object sender, EventArgs e)
        {
            dusmanOlustur();
        }        

        // İmha zamanlayıcısı
        private void yokEtZmn_Tick(object sender, EventArgs e)
        {
            imhaKontrol();
        }
        //Düşmanın imhasını kontrol eder
        public bool imhaKontrol()
        {
            List<PictureBox> mermiList = new List<PictureBox>();
            List<PictureBox> dusmanList = new List<PictureBox>();

            // atılan mermi ve çıkan düşmanları listbox ekler
            foreach (Control c in this.Controls)
            {
                if (c.Height == 12)
                {
                    mermiList.Add((PictureBox)c);
                }
                else if (c.Height == 40)
                {
                    dusmanList.Add((PictureBox)c);
                }
            }
            for (int i = 0; i < dusmanList.Count; i++)
            {
                for (int j = 0; j < mermiList.Count; j++)
                {
                    if (yokEdildi(dusmanList[i], mermiList[j]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        
        // Mermi konumu ile düşmanın konumunu eşleştirir. gereklı koşul sağlandığında iki cisimde kaybolur
        public bool yokEdildi(PictureBox dusman, PictureBox mermi)
        {
            try
            {               
                if ((mermi.Location.Y >= dusman.Location.Y - 18 && mermi.Location.Y <= dusman.Location.Y + 40) && (mermi.Location.X >= dusman.Location.X && mermi.Location.X <= dusman.Location.X + 40))
                {
                    if (mermi.BackgroundImage.Width == resMermi.Width)
                    {
                        mermi.Dispose();
                        dusman.Dispose();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }
    }
}

