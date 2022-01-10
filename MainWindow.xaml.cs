using Check.Reports.Framework;
using Check.Reports.Reports;
using Check.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;


namespace GeneratorStref
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string folderPorgramu = Directory.GetCurrentDirectory();

        private readonly ILicencja _licencja;

        public MainWindow(ILicencja licencja)
        {
            InitializeComponent();
            Dater.Text = DateTime.Today.ToShortDateString();
            if(!Directory.Exists(@"C:\Check\Raporty")) Directory.CreateDirectory(@"C:\Check\Raporty");
            OdtworzHistorie();
            _licencja = licencja;
        }

        private void OdtworzHistorie()
        {
            string[] content;
            using (StreamReader streamReader = new StreamReader(Path.Combine(folderPorgramu, "Historia.txt")))
            {
                content = streamReader.ReadToEnd().Split("\n");                
            }
            Filia.Text = content[0];
            P11_Wydrukowano.Text = content[1];
            P22_Wydrukowano.Text = content[2];
            P33_Wydrukowano.Text = content[3];
            P44_Wydrukowano.Text = content[4];
            P55_Wydrukowano.Text = content[5];
            P66_Wydrukowano.Text = content[6];
            P77_Wydrukowano.Text = content[7];
            P88_Wydrukowano.Text = content[8];
            P99_Wydrukowano.Text = content[9];

            P11_StrefaPoczatek.Text = (Convert.ToInt32(content[1]) + 1).ToString();
            P22_StrefaPoczatek.Text = (Convert.ToInt32(content[2]) + 1).ToString();
            P33_StrefaPoczatek.Text = (Convert.ToInt32(content[3]) + 1).ToString();
            P44_StrefaPoczatek.Text = (Convert.ToInt32(content[4]) + 1).ToString();
            P55_StrefaPoczatek.Text = (Convert.ToInt32(content[5]) + 1).ToString();
            P66_StrefaPoczatek.Text = (Convert.ToInt32(content[6]) + 1).ToString();
            P77_StrefaPoczatek.Text = (Convert.ToInt32(content[7]) + 1).ToString();
            P88_StrefaPoczatek.Text = (Convert.ToInt32(content[8]) + 1).ToString();
            P99_StrefaPoczatek.Text = (Convert.ToInt32(content[9]) + 1).ToString();
        }

        public ExportMethod exportMetod = ExportMethod.Print;

        private void Drukuj ( string nazwaButtonu)
        {
            if (!_licencja.CheckLicence()) return;
            int początkowaStrefa = 0;
            int liczbaStrefDoDruku = 0;
            string pomieszczenie = "";
            string prefix = "";
            List<Strefa> listaStrefDoDruku = new List<Strefa>();

            switch (nazwaButtonu)
            {
                case "P_11":
                    początkowaStrefa = Convert.ToInt32(P11_StrefaPoczatek.Text);
                    liczbaStrefDoDruku = Convert.ToInt32(P11_IloscStref.Text);
                    pomieszczenie = P11_Nazwa.Text;
                    prefix = 11.ToString();
                    P11_StrefaPoczatek.Text = (początkowaStrefa + liczbaStrefDoDruku).ToString();
                    P11_Wydrukowano.Text = (Convert.ToInt32(P11_Wydrukowano.Text) + liczbaStrefDoDruku).ToString();
                    ZapiszDoPliku();
                    break;
                case "P_22":
                    początkowaStrefa = Convert.ToInt32(P22_StrefaPoczatek.Text);
                    liczbaStrefDoDruku = Convert.ToInt32(P22_IloscStref.Text);
                    pomieszczenie = P22_Nazwa.Text;
                    prefix = 22.ToString();
                    P22_StrefaPoczatek.Text = (początkowaStrefa + liczbaStrefDoDruku).ToString();
                    P22_Wydrukowano.Text = (Convert.ToInt32(P22_Wydrukowano.Text) + liczbaStrefDoDruku).ToString();
                    ZapiszDoPliku();
                    break;
                case "P_33":
                    początkowaStrefa = Convert.ToInt32(P33_StrefaPoczatek.Text);
                    liczbaStrefDoDruku = Convert.ToInt32(P33_IloscStref.Text);
                    pomieszczenie = P33_Nazwa.Text;
                    prefix = 33.ToString();
                    P33_StrefaPoczatek.Text = (początkowaStrefa + liczbaStrefDoDruku).ToString();
                    P33_Wydrukowano.Text = (Convert.ToInt32(P22_Wydrukowano.Text) + liczbaStrefDoDruku).ToString();
                    ZapiszDoPliku();
                    break;
                case "P_44":
                    początkowaStrefa = Convert.ToInt32(P44_StrefaPoczatek.Text);
                    liczbaStrefDoDruku = Convert.ToInt32(P44_IloscStref.Text);
                    pomieszczenie = P44_Nazwa.Text;
                    prefix = 44.ToString();
                    P44_StrefaPoczatek.Text = (początkowaStrefa + liczbaStrefDoDruku).ToString();
                    P44_Wydrukowano.Text = (Convert.ToInt32(P44_Wydrukowano.Text) + liczbaStrefDoDruku).ToString();
                    ZapiszDoPliku();
                    break;
                case "P_55":
                    początkowaStrefa = Convert.ToInt32(P55_StrefaPoczatek.Text);
                    liczbaStrefDoDruku = Convert.ToInt32(P55_IloscStref.Text);
                    pomieszczenie = P55_Nazwa.Text;
                    prefix = 55.ToString();
                    P55_StrefaPoczatek.Text = (początkowaStrefa + liczbaStrefDoDruku).ToString();
                    P55_Wydrukowano.Text = (Convert.ToInt32(P55_Wydrukowano.Text) + liczbaStrefDoDruku).ToString();
                    ZapiszDoPliku();
                    break;
                case "P_66":
                    początkowaStrefa = Convert.ToInt32(P66_StrefaPoczatek.Text);
                    liczbaStrefDoDruku = Convert.ToInt32(P66_IloscStref.Text);
                    pomieszczenie = P66_Nazwa.Text;
                    prefix = 66.ToString();
                    P66_StrefaPoczatek.Text = (początkowaStrefa + liczbaStrefDoDruku).ToString();
                    P66_Wydrukowano.Text = (Convert.ToInt32(P66_Wydrukowano.Text) + liczbaStrefDoDruku).ToString();
                    ZapiszDoPliku();
                    break;
                case "P_77":
                    początkowaStrefa = Convert.ToInt32(P77_StrefaPoczatek.Text);
                    liczbaStrefDoDruku = Convert.ToInt32(P77_IloscStref.Text);
                    pomieszczenie = P77_Nazwa.Text;
                    prefix = 77.ToString();
                    P77_StrefaPoczatek.Text = (początkowaStrefa + liczbaStrefDoDruku).ToString();
                    P77_Wydrukowano.Text = (Convert.ToInt32(P77_Wydrukowano.Text) + liczbaStrefDoDruku).ToString();
                    ZapiszDoPliku();
                    break;
                case "P_88":
                    początkowaStrefa = Convert.ToInt32(P88_StrefaPoczatek.Text);
                    liczbaStrefDoDruku = Convert.ToInt32(P88_IloscStref.Text);
                    pomieszczenie = P88_Nazwa.Text;
                    prefix = 88.ToString();
                    P88_StrefaPoczatek.Text = (początkowaStrefa + liczbaStrefDoDruku).ToString();
                    P88_Wydrukowano.Text = (Convert.ToInt32(P88_Wydrukowano.Text) + liczbaStrefDoDruku).ToString();
                    ZapiszDoPliku();
                    break;
                case "P_99":
                    początkowaStrefa = Convert.ToInt32(P99_StrefaPoczatek.Text);
                    liczbaStrefDoDruku = Convert.ToInt32(P99_IloscStref.Text);
                    pomieszczenie = P99_Nazwa.Text;
                    prefix = 99.ToString();
                    P99_StrefaPoczatek.Text = (początkowaStrefa + liczbaStrefDoDruku).ToString();
                    P99_Wydrukowano.Text = (Convert.ToInt32(P99_Wydrukowano.Text) + liczbaStrefDoDruku).ToString();
                    ZapiszDoPliku();
                    break;
                default:
                    break;
            }

            for (int i = początkowaStrefa; i < początkowaStrefa + liczbaStrefDoDruku; i++)
            {

                string strefa = ((i).ToString()).PadLeft(4, '0');
                listaStrefDoDruku.Add(new Strefa("Check", pomieszczenie, Dater.SelectedDate.Value.ToShortDateString(), Filia.Text, prefix + "-" + strefa, prefix + strefa));
            }

            StrefyDoDruku barcodeReport = new StrefyDoDruku(listaStrefDoDruku);
            ReportService reportService = new ReportService();
            reportService.OrderReport(barcodeReport, exportMetod);
        }

        private void ZapiszDoPliku()
        {
            string folderPorgramu = Directory.GetCurrentDirectory();
            
            using (StreamWriter streamWriter = new StreamWriter(Path.Combine(folderPorgramu, "Historia.txt"),false))
            {
                string textDoZapisania = "";
                textDoZapisania += Filia.Text + Environment.NewLine;
                textDoZapisania += P11_Wydrukowano.Text + Environment.NewLine;
                textDoZapisania += P22_Wydrukowano.Text + Environment.NewLine;
                textDoZapisania += P33_Wydrukowano.Text + Environment.NewLine;
                textDoZapisania += P44_Wydrukowano.Text + Environment.NewLine;
                textDoZapisania += P55_Wydrukowano.Text + Environment.NewLine;
                textDoZapisania += P66_Wydrukowano.Text + Environment.NewLine;
                textDoZapisania += P77_Wydrukowano.Text + Environment.NewLine;
                textDoZapisania += P88_Wydrukowano.Text + Environment.NewLine;
                textDoZapisania += P99_Wydrukowano.Text;
                streamWriter.Write(textDoZapisania);
            }
            
        }

        private void P_11_Click(object sender, RoutedEventArgs e)
        {
            Drukuj("P_11");
        }

        private void P_22_Click(object sender, RoutedEventArgs e)
        {
            Drukuj("P_22");
        }
        private void P_33_Click(object sender, RoutedEventArgs e)
        {
            Drukuj("P_33");
        }

        private void P_44_Click(object sender, RoutedEventArgs e)
        {
            Drukuj("P_44");
        }

        private void P_55_Click(object sender, RoutedEventArgs e)
        {
            Drukuj("P_55");
        }

        private void P_66_Click(object sender, RoutedEventArgs e)
        {
            Drukuj("P_66");
        }

        private void P_77_Click(object sender, RoutedEventArgs e)
        {
            Drukuj("P_77");
        }

        private void P_88_Click(object sender, RoutedEventArgs e)
        {
            Drukuj("P_88");
        }

        private void P_99_Click(object sender, RoutedEventArgs e)
        {
            Drukuj("P_99");
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            string folderPorgramu = Directory.GetCurrentDirectory();

            using (StreamWriter streamWriter = new StreamWriter(Path.Combine(folderPorgramu, "Historia.txt"), false))
            {
                string textDoZapisania = "";
                textDoZapisania += "Sinsay" + "\n";
                textDoZapisania += 0 + "\n";
                textDoZapisania += 0 + "\n";
                textDoZapisania += 0 + "\n";
                textDoZapisania += 0 + "\n";
                textDoZapisania += 0 + "\n";
                textDoZapisania += 0 + "\n";
                textDoZapisania += 0 + "\n";
                textDoZapisania += 0 + "\n";
                textDoZapisania += 0 + "\n";
                streamWriter.Write(textDoZapisania);
            }
            P11_StrefaPoczatek.Text = "1";
            P22_StrefaPoczatek.Text = "1";
            P33_StrefaPoczatek.Text = "1";
            P44_StrefaPoczatek.Text = "1";
            P55_StrefaPoczatek.Text = "1";
            P66_StrefaPoczatek.Text = "1";
            P77_StrefaPoczatek.Text = "1";
            P88_StrefaPoczatek.Text = "1";
            P99_StrefaPoczatek.Text = "1";

            P11_IloscStref.Text = "33";
            P22_IloscStref.Text = "33";
            P33_IloscStref.Text = "33";
            P44_IloscStref.Text = "33";
            P55_IloscStref.Text = "33";
            P66_IloscStref.Text = "33";
            P77_IloscStref.Text = "33";
            P88_IloscStref.Text = "33";
            P99_IloscStref.Text = "33";

            P11_Wydrukowano.Text = "0";
            P22_Wydrukowano.Text = "0";
            P33_Wydrukowano.Text = "0";
            P44_Wydrukowano.Text = "0";
            P55_Wydrukowano.Text = "0";
            P66_Wydrukowano.Text = "0";
            P77_Wydrukowano.Text = "0";
            P88_Wydrukowano.Text = "0";
            P99_Wydrukowano.Text = "0";
        }
    }
}
