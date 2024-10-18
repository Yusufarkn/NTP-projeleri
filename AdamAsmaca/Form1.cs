using System;
using System.Linq;
using System.Windows.Forms;


namespace AdamAsmaca
{
    public partial class Form1 : Form
    {   
       private string[] Sehirler = {
        "ADANA", "ADIYAMAN", "AFYONKARAHİSAR", "AĞRI", "AMASYA", "ANKARA", "ANTALYA",
        "ARTVİN", "AYDIN", "BALIKESİR", "BİLECİK", "BİNGÖL", "BİTLİS", "BOLU", "BURDUR",
        "BURSA", "ÇANAKKALE", "ÇANKIRI", "ÇORUM", "DENİZLİ", "DİYARBAKIR", "EDİRNE",
        "ELAZIĞ", "ERZİNCAN", "ERZURUM", "ESKİŞEHİR", "GAZİANTEP", "GİRESUN", "GÜMÜŞHANE",
        "HAKKARİ", "HATAY", "ISPARTA", "MERSİN", "İSTANBUL", "İZMİR", "KARS", "KASTAMONU",
        "KAYSERİ", "KIRKLARELİ", "KIRŞEHİR", "KOCAELİ", "KONYA", "KÜTAHYA", "MALATYA",
        "MANİSA", "KAHRAMANMARAŞ", "MARDİN", "MUĞLA", "MUŞ", "NEVŞEHİR", "NİĞDE",
        "ORDU", "RİZE", "SAKARYA", "SAMSUN", "SİİRT", "SİNOP", "SİVAS", "TEKİRDAĞ",
        "TOKAT", "TRABZON", "TUNCELİ", "ŞANLIURFA", "UŞAK", "VAN", "YOZGAT", "ZONGULDAK",
        "AKSARAY", "BAYBURT", "KARAMAN", "KIRIKKALE", "BATMAN", "ŞIRNAK", "BARTIN",
        "ARDAHAN", "IĞDIR", "YALOVA", "KARABÜK", "KİLİS", "OSMANİYE", "DÜZCE"
        };
    
        private string secilenSehir; // Rastgele seçilen şehir
        private string gizliSehir;   // Şehrin _ ile gizlenmiş hali
        private char[] kapalıHali; // Alt tireler ve bulunan harfler için dizi
        private int kalanHak = 5;    // Başlangıçta 5 hak veriyoruz
        private string kullanilanHarfler = ""; // Kullanılan harfleri tutacağız


        public Form1()
        {
            InitializeComponent();           
            RastgeleSehirSec();
            HarfTireEkle();
            kalanHak = 5; 
            kullanilanHarfler = ""; 
            label4.Text = "Kullanılan Harfler: ";
            KalanHakGoster(); 
        }

        // Rastgele bir şehir seçiyoruz
        private void RastgeleSehirSec()
        {
                Random rnd = new Random();
                int rastgeleIndex = rnd.Next(Sehirler.Length); // 0 ile 80 arasında bir değer oluşturma şehir dizisinden 
                secilenSehir = Sehirler[rastgeleIndex];

                // Seçilen şehrin uzunluğuna göre kapalıHali'i başlatıyoruz
                kapalıHali = new string('_', secilenSehir.Length).ToCharArray(); 
            }



        // Seçilen şehrin harf sayısı kadar alt tire ekle
        private void HarfTireEkle() 
        {
            // kapalıHali dizisini boşluklarla birleştirip label5'e yazdırıyoruz
            gizliSehir = string.Join(" ", kapalıHali);
            label5.Text = gizliSehir;
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter; //Ortalama işlemi
        }

        // TextBoxa girilen harfi kontrol etmek
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string girilenHarf = textBox1.Text.ToUpper(); // girilen harfleri büyük alma
            textBox1.Text = ""; // TextBoxı temizlemek

            if (string.IsNullOrEmpty(girilenHarf)) return; // Boş giriş olursa işlem yapma

            if (kullanilanHarfler.Contains(girilenHarf))
            {
                MessageBox.Show("Bu harfi zaten kullandınız!");
                return;
            }

            kullanilanHarfler += girilenHarf + " "; // Kullanılan harfleri al ve göster
            label4.Text = "Kullanılan Harfler: " + kullanilanHarfler;

            bool dogruMu = false;

            // Şehir için girilen harfi kontrol et
            for (int i = 0; i < secilenSehir.Length; i++)
            {
                if (secilenSehir[i] == girilenHarf[0]) // Harf doğru mu kontrol
                {
                    kapalıHali[i] = secilenSehir[i]; // Doğru harfi alt tire yerine koyma kısmı
                    dogruMu = true;
                }
            }

            if (dogruMu)
            {
                HarfTireEkle(); // Doğru harfleri gösterme
                if (!kapalıHali.Contains('_'))
                {
                    MessageBox.Show("Kazandınızzz");
                }
            }
            else
            {
                kalanHak--; // Yanlış harf girildiğine deneme hakkını azaltır
                KalanHakGoster(); // Kalan hakları güncelleme işlemi
                if (kalanHak == 0)
                {
                    MessageBox.Show("Kaybettin! aranan şehir:  " + secilenSehir);
                    RastgeleSehirSec(); // Yeni şehir seçme
                    HarfTireEkle();
                    kalanHak = 5; // Hakları yenileme
                    kullanilanHarfler = ""; // Kullanılan harfleri sıfırlamak
                    label4.Text = "Kullanılan Harfler: ";
                    KalanHakGoster(); // Kalan hakları güncelleme
                }
            }
        }


        private void KalanHakGoster()
        {
            label3.Text = "Kalan Hakkınız: " + kalanHak;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Formu ekrana gösterme
        }

 
        private void button1_Click(object sender, EventArgs e)
        {
            RastgeleSehirSec();   // yeni şehir
            HarfTireEkle();       // Yeni şehrin alt tire kısmı

            kalanHak = 5;         // Kalan hakları sıfırla (ilk hale çevirmek)
            kullanilanHarfler = ""; // Kullanılan harfleri sıfırla
            label4.Text = "Kullanılan Harfler: ";  // Kullanılan harfler label'ını sıfırla

            KalanHakGoster();     // Kalan hakları ekranda güncelle
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

    }
}
