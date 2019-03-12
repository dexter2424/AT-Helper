using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;
using System.Xml;



namespace autotester
{
    public partial class Form1 : Form
    {
        string text;
        string eleje;
        string vege;
        string z;
        string s;
        string fileNev;
        string textTestCase;
        int sorszam = 0;
        int n = 0;
        int plusz = -1;
        int LevagIndex;
        int testcaseIndex;
        string tt;
        string ttn;
        int ttsorszam = 0;
        int tombHosszSzamlalo = 0;
        

        List<string> esetek = new List<string>();
        List<string> cimek = new List<string>();
        Writer2 w = new Writer2();
        HelperAchi ha = new HelperAchi();
        Warning war = new Warning();
        xmlLoad x = new xmlLoad();
        XmlDocument xmldoc = new XmlDocument();
        string[,] tapteruletekTomb;

        private void ElejeVegeHozzaAd()
            
        {
            try
            {
               //Ha nincs a kérésben SpecList, akkor a hagyományos megoldással módosítja a kérést.
                if (esetek[sorszam].IndexOf("<SpecList>") < 0)
                {
                    s = esetek[sorszam].Substring(esetek[sorszam].IndexOf("<VariableList>"));
                }
                //Ha van benne SpecList, akkor az szerint módosítsa a kérést.
                else
                {
                    s = esetek[sorszam].Substring(esetek[sorszam].IndexOf("<SpecList>"));
                }


                z = s.Substring(0, s.IndexOf("begin"));

                //Ha tartalmazza a Borz szót a kérés, automatikusan borz kérés AT kezdetet kap. 
                if (z.Contains("BORZ") == true)
                {
                    eleje = CsereModul.BorzEleje;
                }
                else
                {
                    eleje = CsereModul.eleje;
                }

                esetek[sorszam] = eleje + z + vege;
            }
            catch (Exception ex)
            {
                textBoxSQL.Text += ex.Message;
               // HibaUzenet(ex.Message);
                w.hiba = ex.Message;
                w.streamWriter(w.hiba);
            }

        }

        public Form1()
        {
            InitializeComponent();
            TapteruletXml();

            
          //  eleje = CsereModul.eleje;
          //  vege = CsereModul.vege;
        }

        private void TapteruletXml()
        {
            xmldoc.Load("AtHelperParameters.xml");
            //Először megnézi mennyi Tapterület van az XML fájlban, majd ezt követően egy akkora tömböt hoz létre.
            foreach (XmlNode node in xmldoc.SelectNodes("AtHelperParameters/Tapterulet"))
            {
                tombHosszSzamlalo++; 
                ttn = node.SelectSingleNode("ttn").InnerText;
                tt = node.SelectSingleNode("tt").InnerText;

            }

             tapteruletekTomb = new string[tombHosszSzamlalo, 2];

            //Másodszor átadja a tömbnek az XML elemeit. 
            foreach (XmlNode node in xmldoc.SelectNodes("AtHelperParameters/Tapterulet"))
            {
                tt = node.SelectSingleNode("tt").InnerText;
                ttn = "s:  " +  node.SelectSingleNode("tt").InnerText + " " + node.SelectSingleNode("ttn").InnerText;
                

                tapteruletekTomb[ttsorszam, 0] = ttn;
                tapteruletekTomb[ttsorszam, 1] = tt;
                
                ttsorszam++;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {                             //#################################################### FÁJL BEOLVASÁSA
            // Ha már lenne megnyitva fájl, akkor törli a listákban lévő értékeket, azaz előről kezdi
            try
            {
                esetek.Clear();
                cimek.Clear();
                sorszam = 0;
            }
            catch (Exception) { }

            //Megnyitja a fájl megnyitás menüpontot
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.InitialDirectory = "c:\\AT";
            ofd.Filter = Egyeb.ofdFilter;

            DialogResult result = ofd.ShowDialog();
           //fileNev = ofd.FileName;
            fileNev = ofd.SafeFileName;
            if (result == DialogResult.OK)
            {
                text = System.IO.File.ReadAllText(ofd.FileName, Encoding.Default);
                
                // Beszúrja az eleje és vége részeket
                vege = CsereModul.vege;

                textBoxFajlnev.Text = fileNev;
               

                try
                {
                    do
                    {  //A 'declare'-től kezdődően berakja a szöveget az 's' változóba
                        s = text.Substring(text.IndexOf("declare"));
                        //Az 'end'-ig tárolja a szöveget
                        z = s.Substring(0, s.IndexOf("end;") + 4);
                        //A textTestCase-be betöltöm az egy darab aktuális tesztesetet, hogy megvizsgálhassam a TestCase-en belüli paramétereket.
                        textTestCase = z;
                        ////////////////////////////////////////////// FOLYTATNI A TESTCASE-T//////////////////////////////
                        textTestCase = textTestCase.Substring(textTestCase.IndexOf("<TestCase"));
                        textTestCase = textTestCase.Substring(0, textTestCase.IndexOf('>') + 1);
                       // testcaseIndex = ()
                        //Megkeresi az 'end;'indexét, és hozzáad 4-et, hogy az end végéig levágja majd a szöveget. 
                        LevagIndex = (s.IndexOf("end;") + 4 + text.IndexOf("declare"));
                        //A declare-ig ami szöveget tartalmaz, azt hozzáadom a 'cimek' listához
                        cimek.Add(text.Substring(0, text.IndexOf("declare"))); 
                        //sorrend számít, mert először a cimeket kiszedem a nem Trimmel-t szövegből, mert amúgy az elsőt levágja és a másodikkal kezdi.
                        text = text.Substring(LevagIndex).Trim();
                        //az első cím ami megjelenik a címek textboxban.
                        cimTextBox2.Text = cimek[0];
                        //tooltip-ben megjeleníti a teljes címet, ha az egeret fölé visszük.
                        toolTip1.SetToolTip(cimTextBox2, cimTextBox2.Text);
                        //az esetekhez hozzáadom a 'declare' és 'end;' közötti szövegeket.
                        esetek.Add(z);
                        //'z'-t és 's'-t kiürítem
                        z = "";
                        s = ""; 
                        //addig csinálom, még el nem fogynak az 'end'-ek.
                    } while (text.IndexOf("end")>0);
                }
                catch (Exception ex)
                {   //Ha hibára megy, akkor megjelenítem a hibát, illetve kiíratom egy hibaüzenet text fájlba, hogy később visszakereshető legyen.
                    textBoxSQL.Text += ex.Message;
                    w.hiba = ex.Message;
                    w.streamWriter(w.hiba);
                }

            }

            try
            {
                ElejeVegeHozzaAd();
                textBoxSQL.Text = esetek[0];
                label3.Text = ("1" + "/" + esetek.Count() + ". Oldal");
            }
            catch (Exception ex)
            {
                w.hiba = ex.Message;
                w.streamWriter(w.hiba);
                textBoxSQL.Text += ex.Message;
               // HibaUzenet(ex.Message);
            }
        }
                               
        private void button2_Click(object sender, EventArgs e)
        {
            #region KicserélőModulok

            // Alap kicserélő modulok
            foreach (var mt_idLine in textBoxSQL.Lines)
            {
                if (mt_idLine.Contains("<Variable Name=\"MT_ID\" Value=\""))
                {
                    textBoxSQL.Text = textBoxSQL.Text.Replace(mt_idLine, CsereModul.mt_id);
                    XElement xe = XElement.Parse(mt_idLine);
                    var x = (string)xe.Attributes("Value").FirstOrDefault().Value;
                    xe.Attributes("Value").FirstOrDefault().Value = "1526";
                    textBoxSQL.Lines[5] = xe.ToString();
                }
            }
        
            
            foreach (var cu_nameLine in textBoxSQL.Lines)
            {
                if (cu_nameLine.Contains("<Variable Name=\"CU_NAME"))
                {
                    textBoxSQL.Text = textBoxSQL.Text.Replace(cu_nameLine, CsereModul.cu_name);
                }
            }

            foreach (var buildingLine in textBoxSQL.Lines)
            {
                if (buildingLine.Contains("<Variable Name=\"BUILDING"))
                {
                    textBoxSQL.Text = textBoxSQL.Text.Replace(buildingLine, CsereModul.building);
                }
            }

            foreach (var service_point_idLine in textBoxSQL.Lines)
            {
                if (service_point_idLine.Contains("<Variable Name=\"SERVICE_POINT_ID"))
                {
                    textBoxSQL.Text = textBoxSQL.Text.Replace(service_point_idLine, CsereModul.service_point_id);
                }
            }

            foreach (var premise_idLine in textBoxSQL.Lines)
            {
                if (premise_idLine.Contains("<Variable Name=\"PREMISE_ID"))
                {
                    textBoxSQL.Text = textBoxSQL.Text.Replace(premise_idLine, CsereModul.premise_id);
                }
            }

            foreach (var cufirstname_idLine in textBoxSQL.Lines)
            {
                if (cufirstname_idLine.Contains("<Variable Name=\"CU_FIRSTNAME"))
                {
                    textBoxSQL.Text = textBoxSQL.Text.Replace(cufirstname_idLine, CsereModul.cu_firstname);
                }
            }

            foreach (var culastname_idLine in textBoxSQL.Lines)
            {
                if (culastname_idLine.Contains("<Variable Name=\"CU_LASTNAME"))
                {
                    textBoxSQL.Text = textBoxSQL.Text.Replace(culastname_idLine, CsereModul.cu_lastname);
                }
            }
            esetekTry();
        }
#endregion

        // Order Id, Street Id, House Number kicserélő gomb
        private void button3_Click(object sender, EventArgs e)
        {
            string orderId = textBoxOrderId.Text;
            string streetId = textBoxStreetId.Text;
            string houseNr = textBoxHouseNr.Text;
            
            foreach (var order_idLine in textBoxSQL.Lines)
            {
                if (order_idLine.Contains("<Variable Name=\"ORDER_ID"))
                {
                    textBoxSQL.Text = textBoxSQL.Text.Replace(order_idLine, $"    <Variable Name=\"ORDER_ID\" Value=\"to_char(sysdate, ''YYYYMMDD'') || ''' || {orderId} || '''\"/>");
                }
            }

            // Street Id kicserélése 
            foreach (var street_idLine in textBoxSQL.Lines)
            {
                if (street_idLine.Contains("<Variable Name=\"STREET_ID"))
                {
                    textBoxSQL.Text = textBoxSQL.Text.Replace(street_idLine, $"    <Variable Name=\"STREET_ID\" Value=\"{streetId}\"/>");
                }
            }
            //####################################### House Number kicserélése
            foreach (var house_nrLine in textBoxSQL.Lines)
            {
                if (house_nrLine.Contains("<Variable Name=\"HOUSE_NR"))
                {
                    textBoxSQL.Text = textBoxSQL.Text.Replace(house_nrLine, $"    <Variable Name=\"HOUSE_NR\" Value=\"{houseNr}\"/>");
                    textBoxSQL.Text = textBoxSQL.Text.Replace(house_nrLine, $"    <Variable Name=\"HOUSE_NR\" Value=\"{houseNr}\"/>");
                }
            } 
            esetekTry();
        }

        private void esetekTry()
        {
            try
            {
                esetek[sorszam] = textBoxSQL.Text;
            }
            catch (Exception ex)
            {
                w.hiba = ex.Message;
                w.streamWriter(w.hiba); 
                textBoxSQL.Text = ex.Message;
            }  
        }
      
        private void textBoxHouseNr_TextChanged(object sender, EventArgs e)
        {
            // Megvizsgálja, hogy milyen számot írunk be, és kikeresi a hozzá tartozó tápterületet
            TextBox tb = sender as TextBox;
            for (int i = 0; i < tapteruletekTomb.Length/2; i++)
            {
                if (tb.Text == tapteruletekTomb[i, 0])
                {
                    this.textBoxHouseNr.Text = tapteruletekTomb[i, 1];
                }
            }

            if (textBoxHouseNr.Text == "chelsea" || textBoxHouseNr.Text == "Chelsea")
            {
                panelCFC.Visible = true;
                panel1.BackColor = Color.White;
                textBoxHouseNr.Clear();
            }
            if (textBoxHouseNr.Text == "nochelsea")
            {
                panelCFC.Visible = false;
                panel1.BackColor = Color.PaleTurquoise;
                textBoxHouseNr.Clear();
            }

            TapteruletSenderrelXml(tb);

        }
        #region TapterületSenderrelXML
        private void TapteruletSenderrelXml(TextBox tb)
        {
            try
            {
                while (tapteruletekTomb[n,1] != tb.Text || tapteruletekTomb.Length == n)
                {
                    n++;
                }
                textBoxTapterulet.Text =  tapteruletekTomb[n, 0];
                n = 0;
            }
            
            catch (Exception)
            {
                n = 0;
                textBoxTapterulet.Text = "Nincs definiált tápterület";
            }
#endregion
        }

        #region OrderIdPluszMinusz
        // Plusz gomb
        private void button5_Click(object sender, EventArgs e)
        {
            plusz++;
            if (plusz <=0)
            {
                textBoxOrderId.Text = " v_id ";
                plusz = 0;   
            }
            else
            {
                textBoxOrderId.Text = $" (v_id+{plusz}) ";
            }                                    
        }
        // Mínusz gomb
        private void button4_Click(object sender, EventArgs e)
        {
            plusz--;
            if (plusz <=0)
            {
                textBoxOrderId.Text = " v_id ";
                plusz = 0;
            }
            else
            {
                textBoxOrderId.Text = $" (v_id+{plusz}) ";  
            }
            
        }
        #endregion

        #region MouseEnters
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.FlatAppearance.BorderSize = 2;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.FlatAppearance.BorderSize = 0;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.FlatAppearance.BorderSize = 2;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.FlatAppearance.BorderSize = 0;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.FlatAppearance.BorderSize = 2;
        }
        
        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.FlatAppearance.BorderSize = 0;
        }

        private void button8_MouseEnter(object sender, EventArgs e)
        {
            button8.FlatAppearance.BorderSize = 2;
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            button8.FlatAppearance.BorderSize = 0;
        }

        private void button9_MouseEnter(object sender, EventArgs e)
        {
            button9.FlatAppearance.BorderSize = 2;

        }

        private void button9_MouseLeave(object sender, EventArgs e)
        {
            button9.FlatAppearance.BorderSize = 0;
        }
        private void button11_MouseEnter(object sender, EventArgs e)
        {
            button11.FlatAppearance.BorderSize = 2;
            ;
        }
        private void button11_MouseLeave(object sender, EventArgs e)
        {
            button11.FlatAppearance.BorderSize = 0;
        }
        private void button12_MouseEnter(object sender, EventArgs e)
        {
            button12.FlatAppearance.BorderSize = 2;
        }
        private void button12_MouseLeave(object sender, EventArgs e)
        {
            button12.FlatAppearance.BorderSize = 0;
        }
        private void button10_MouseEnter(object sender, EventArgs e)
        {
            button10.FlatAppearance.BorderSize = 2;
        }
        private void button10_MouseLeave(object sender, EventArgs e)
        {
            button10.FlatAppearance.BorderSize = 0;
        }
        private void buttonToDatabase_MouseEnter(object sender, EventArgs e)
        {
            buttonToDatabase.FlatAppearance.BorderSize = 2;
        }
        private void buttonToDatabase_MouseLeave(object sender, EventArgs e)
        {
            buttonToDatabase.FlatAppearance.BorderSize = 0;
        }
        private void buttonManuals_MouseEnter(object sender, EventArgs e)
        {
            buttonManuals.FlatAppearance.BorderSize = 2;
        }
        private void buttonManuals_MouseLeave(object sender, EventArgs e)
        {
            buttonManuals.FlatAppearance.BorderSize = 0;
        }
        private void button6_MouseEnter(object sender, EventArgs e)
        {
            button6.FlatAppearance.BorderSize = 2;
        }
        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.FlatAppearance.BorderSize = 0;
        }
        private void button7_MouseEnter(object sender, EventArgs e)
        {
            button7.FlatAppearance.BorderSize = 2;
        }
        private void button7_MouseLeave(object sender, EventArgs e)
        {
            button7.FlatAppearance.BorderSize = 0;
        }
        private void button4_MouseEnter(object sender, EventArgs e)
        {
            buttonMinus.FlatAppearance.BorderSize = 2;
        }
        private void button4_MouseLeave(object sender, EventArgs e)
        {
            buttonMinus.FlatAppearance.BorderSize = 0;
        }
        private void button5_MouseEnter(object sender, EventArgs e)
        {
            buttonPlus.FlatAppearance.BorderSize = 2;
        }
        private void button5_MouseLeave(object sender, EventArgs e)
        {
            buttonPlus.FlatAppearance.BorderSize = 0;
        }
        private void button13_MouseLeave(object sender, EventArgs e)
        {
            button13.FlatAppearance.BorderSize = 0;
        }
        private void button13_MouseEnter(object sender, EventArgs e)
        {
            button13.FlatAppearance.BorderSize = 2;
        }
        private void button4_MouseEnter_1(object sender, EventArgs e)
        {
            button4.FlatAppearance.BorderSize = 2;
        }

        private void button4_MouseLeave_1(object sender, EventArgs e)
        {
            button4.FlatAppearance.BorderSize = 0;
        }



        #endregion
        #region GombFelLe
        // Felfelé gomb
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                sorszam++;

                if (sorszam == esetek.Count())
                {
                    sorszam = 0;
                }

                ElejeVegeHozzaAd();

                textBoxSQL.Text = esetek[sorszam];
                cimTextBox2.Text = cimek[sorszam];
                //Ha hasszú a textboxban a szöveg, megjeleníti a teljeset, ha fölévisszük az egeret.
                toolTip1.SetToolTip(cimTextBox2, cimTextBox2.Text);
                label3.Text = ((sorszam + 1).ToString() + "/" + esetek.Count() + ". Oldal");

            }
            catch (Exception ex)
            {
                textBoxSQL.Text = ex.Message;
                w.hiba = ex.Message;
                w.streamWriter(w.hiba);
            }
           
        }

      
        // Lefelé Gomb
        private void button7_Click(object sender, EventArgs e) 
        {
            try
            {
                sorszam--;

                if (sorszam == -1)
                {
                    sorszam = esetek.Count() - 1;
                }
                ElejeVegeHozzaAd();

                textBoxSQL.Text = esetek[sorszam];
                cimTextBox2.Text = cimek[sorszam];
                label3.Text = ((sorszam + 1).ToString() + "/" + esetek.Count() + ". Oldal");
            }
            catch (Exception ex)
            {

                textBoxSQL.Text = ex.Message;
                w.hiba = ex.Message;
                w.streamWriter(w.hiba);
            }   
             
            
        
        }
#endregion

        // Kijelölés, másolás
        private void button8_Click(object sender, EventArgs e)
        {
            textBoxSQL.Focus();
            textBoxSQL.Copy();

        }
        // Csere mind gomb
        private void button9_Click(object sender, EventArgs e)
        {
            //achivementek
            
            ha.streamReader();
            ha.megvaltoztat++;
            ha.streamWriter(ha.megvaltoztat.ToString());

                //Ha üresen maradt kitöltendő mező, akkor jelzi, hogy töltsék ki. 
                war.hn = textBoxHouseNr.Text;
            war.si = textBoxStreetId.Text;
            war.oi = textBoxOrderId.Text;
            war.warning();
            labelWarning.Text = war.hn + war.si + war.oi;

            //Mindent egyszerre kicserél
            button2_Click(sender, e);
            button3_Click(sender, e);
            esetekTry();
        }
        //Kilépés
        private void button10_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Biztos be akarod zárni a programot?", "Kilépés", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                
                Application.Exit();
            }
            else if (dialog == DialogResult.No)
            {
                //don't do anything
            }
        }

        //Mentés mind
        private void button11_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = Egyeb.sfdFilter;
            sfd.FileName = fileNev;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(sfd.FileName);
                
                for (int i = 0; i < esetek.Count; i++)
                 {
                    sw.WriteLine("");
                    sw.Write(cimek[i]);
                    sw.WriteLine("");
                    sw.Write(esetek[i]);
                    sw.WriteLine("");
                }

                sw.Close();
            }

        }

        //Mentés 
        private void button12_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = Egyeb.sfdFilter;
            sfd.FileName = fileNev;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(sfd.FileName);

                sw.Write(textBoxSQL.Text);

                sw.Close();
            }

        }
        
        //Navigálás a manuals munkalapra
        private void button13_Click(object sender, EventArgs e)
        {
            Manuals man = new Manuals();
            man.ShowDialog();
        }

        //Navigálás az adatbázis munkalapra
        private void buttonToDatabase_Click(object sender, EventArgs e)
        {
            //Achivementek
            ha.streamReader();
            ha.bekuld++;
            ha.streamWriter(ha.bekuld.ToString());

            SPA_Database spa = new SPA_Database(ref esetek, ref cimek, ref fileNev);
            
            spa.Show();
        }

        //Lenyíló menü
        private void button13_Click_1(object sender, EventArgs e)
        {
            if (button2.Visible == true)
            {
                button2.Visible = false;
                button3.Visible = false;
                button8.Visible = false;
                button12.Visible = false;
                buttonManuals.Visible = false;
            }
            else if (button2.Visible == false)
            {
                button2.Visible = true;
                button3.Visible = true;
                button8.Visible = true;
                button12.Visible = true;
                buttonManuals.Visible = true;
            }
            

        }

        //Minden módosítás mentése
        private void button4_Click_1(object sender, EventArgs e)
        {
            esetekTry();
            button4.BackColor = Color.Transparent; 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBoxSQL_KeyPress(object sender, KeyPressEventArgs e)
        {
            button4.BackColor = Color.PaleVioletRed;
        }
    }
}
