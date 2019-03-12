using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace autotester
{
    /// <summary>
    /// ez a look up-ban a megjelenítendő érték szöveg és ID párosokat tárolni.
    /// </summary>
    /// 
    public class ComboboxItem
    {
        public string DisplayValue { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return DisplayValue;
        }
    }

    //Kiírja fájlba a hibaüzenetet
     class Writer2
    {
        public string hiba;

        public void streamWriter(string hiba)
        {
            using (StreamWriter sw = new StreamWriter("hibaüzenet.txt",true))
            {
                string time = DateTime.Now.ToString("yyyy-MM-dd;HH:mm:ss");
                sw.WriteLine(time);
                sw.WriteLine(hiba);
                sw.WriteLine();
            }
        }
    }

    class HelperAchi
    {
        public int bekuld;
        public int megvaltoztat;
        public int csoportParameter;
        public int tesztParamter;
        XElement t = XElement.Load("AtHelperParameters.xml");

        public void xmlAchi(string v)
        {
            t.Element("AtHelperParameters").Element("Achi").Value = "2";
            t.Save("AtHelperParameters");
        }

        public void streamWriter(string valtozo)
        {
            using (StreamWriter sw = new StreamWriter("achi.txt"))
            {
                sw.WriteLine(bekuld);
                sw.WriteLine(megvaltoztat);
                sw.WriteLine(csoportParameter);
                sw.WriteLine(tesztParamter);
            }
        }

        public void streamReader()
        {
            try
            {
                using (StreamReader sr = new StreamReader("achi.txt"))
                {
                    bekuld = Convert.ToInt32(sr.ReadLine());
                    megvaltoztat = Convert.ToInt32(sr.ReadLine());
                    csoportParameter = Convert.ToInt32(sr.ReadLine());
                    tesztParamter = Convert.ToInt32(sr.ReadLine());
                }
            }
            catch (Exception ex)
            {

            }
           
        }
    }


    class Warning
    {
        public string hn;
        public string si;
        public string oi;
       
        public void warning()
        {
            //if (i < 10) i = 10; else i = 1;
            if (hn == string.Empty) hn = "A kérés nem tartalmaz HouseNr-t \r\n"; else hn = string.Empty;
            if (si == string.Empty) si = "A kérés nem tartalmaz StreetID-t \r\n"; else si = string.Empty;
            if (oi == string.Empty) oi = "A kérés nem tartalmaz OrderID-t \r\n"; else oi = string.Empty;

        }
    }
   
}
