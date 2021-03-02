using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Windows;

namespace GeneratorStref
{
    public class Licencja
    {
        private Rejestr rejestr;
        private readonly string RegNazwaApp = "SOFTWARE\\Kaspersky";
        private readonly string RegNazwaCzasNow = "Now";
        private readonly string RegNazwaCzasWaznosci = "Wichtig";
        private readonly string RegKluczGlowny = "HKEY_CURRENT_USER";
        public Licencja()
        {
            rejestr = new Rejestr();
            // test
        }

        private void ZapiszAktualnaDateDoKlucza()
        {
            rejestr.WriteString(RegKluczGlowny, RegNazwaApp, RegNazwaCzasNow, DateTime.Now.ToShortDateString());
        }
        private string OdczytajZrejestruDateWaznosci()
        {
            return rejestr.ReadString(RegKluczGlowny, RegNazwaApp, RegNazwaCzasWaznosci, "2900.01.01");
        }
        private void ZapiszDateWaznosciDoRejestru()
        {
            string dataZserwera = DisplayFileFromServer(new Uri("http://apponce.prv.pl/licencja.txt"));
            rejestr.WriteExString(RegKluczGlowny, RegNazwaApp, RegNazwaCzasWaznosci, dataZserwera);
        }
        private string OdczytajZrejestruDateNow()
        {
                return rejestr.ReadString(RegKluczGlowny, RegNazwaApp, RegNazwaCzasNow, null);   
        }
        private void ZastąpDateNowWrejestrze()
        {
            rejestr.WriteExString(RegKluczGlowny,RegNazwaApp, RegNazwaCzasNow, DateTime.Now.ToShortDateString());
        }
        private void ZastapDateWanosciWrejestrze()
        {
            string dataZserwera = DisplayFileFromServer(new Uri("http://apponce.prv.pl/licencja.txt"));
            rejestr.WriteExString(RegKluczGlowny, RegNazwaApp, RegNazwaCzasWaznosci, dataZserwera);
        }
        public bool SprawdzLicencje()
        {
            DateTime dataNowZrejestru;
            if (!(DateTime.TryParse(OdczytajZrejestruDateNow(), out dataNowZrejestru)))
            dataNowZrejestru = new DateTime(1900, 1, 1);

            DateTime dataWaznosciZrejestru;
            if (!(DateTime.TryParse(OdczytajZrejestruDateWaznosci(), out dataWaznosciZrejestru)))
                dataWaznosciZrejestru = new DateTime(2900, 1, 1);

            if (dataNowZrejestru != new DateTime(1900, 1, 1))
            {
                if (dataNowZrejestru > dataWaznosciZrejestru)
                {
                    return false;
                }
                else
                {
                    if (DateTime.Now > dataNowZrejestru)
                    {
                        ZapiszAktualnaDateDoKlucza();
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                ZapiszAktualnaDateDoKlucza();
            }
            if (dataWaznosciZrejestru != new DateTime(2900,1,1))
            {
                if (dataWaznosciZrejestru < dataNowZrejestru)
                {
                    return false;
                }
                else
                {                    
                    ZastapDateWanosciWrejestrze();
                }
            }
            else
            {
                ZapiszDateWaznosciDoRejestru();
            }
            return true;
        }
        public string DisplayFileFromServer(Uri serverUri)
        {
            string fileString = "";
            // The serverUri parameter should start with the ftp:// scheme.
            if (serverUri.Scheme != Uri.UriSchemeHttp)
            {
                return "false";
            }
            // Get the object used to communicate with the server.
            WebClient request = new WebClient();

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential("apponce.prv.pl", "Gienek84");
            try
            {
                byte[] newFileData = request.DownloadData(serverUri.ToString());
                fileString = System.Text.Encoding.UTF8.GetString(newFileData);                
            }
            catch (WebException e)
            {
                
            }
            return fileString;
        }
    }
}
