using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Xml;


namespace autotester
{
    public partial class SPA_Database : Form
    {
        DataSet1 db = new DataSet1();
        List<string> from = new List<string>();
        List<int> to = new List<int>();
        List<int> szabad = new List<int>();
        List<ComboboxItem> csoport = new List<ComboboxItem>();  // sorbarendezem és ebbe töltöm be a megjelenítendő értéket és háttér értéket (ID)
        List<string> esetekHelyi = new List<string>();
        List<string> cimekHelyi = new List<string>();
        List<string> ownerList = new List<string>();
        Writer2 w = new Writer2();
        HelperAchi ha = new HelperAchi();
        OracleConnection _con = new OracleConnection(); //kapcsolat létrehozása az adatbázissal
        XmlDocument xmldoc = new XmlDocument();

        int szamlalo = 0;
        int szamlaloFromTo = 0;
        int sorszam = 0;
        string logIn_ID;
        string password;
        string s;
        string owner;
        string currentOwner;
        int PriorParameter;
        int tesztesetIDfrom;
        int prioritas = 0;
        int mennyi =1;
        int MaxPrior;
        int priorOsszeg = 0;
        string tesztesetNeve;

        public SPA_Database(ref List<string> esetek, ref List<string> cimek, ref string fileNev) //átadom a form1-en mentett esetek osztályt, a módosított folyamatot. --ref List<string> esetek--
        {
            InitializeComponent();
            Parameters("AtHelperParameters.xml");
            OwnerXML();
            textBoxFileNev.Text = fileNev;
           
            kezdoErtekek();

            for (int i = 0; i < esetek.Count; i++)
            {
                esetekHelyi.Add(esetek[i]);
            }

            for (int i = 0; i < cimek.Count; i++)
            {
                cimekHelyi.Add(cimek[i]);
            }
            try
            {
                textBoxTitle.Text = cimekHelyi[0];
                textBoxEsetek.Text = esetekHelyi[0];
                labelFelLe.Text = ((sorszam + 1).ToString() + "/" + esetekHelyi.Count() + ". Oldal");
            }
            catch (Exception ex)
            {
                textBoxConnection.ForeColor = Color.Red;
                textBoxConnection.Text = ex.Message + ex.InnerException;
                w.hiba = ex.Message + ex.InnerException;
                w.streamWriter(w.hiba);
            }

        }



        private void kezdoErtekek()
        {
            string nem = "Nem";
            textBox_Password.PasswordChar = '*';
            textBox_ID_LENGHT.Enabled = true;
            comboBoxTestZaras.Items.Add(TesztesetCsoportParameter("I", nem));
            comboBoxTestZaras.Items.Add(TesztesetCsoportParameter("N", nem));
            comboBoxTestZaras.SelectedIndex = 0;
            comboBoxTestAktiv.Items.Add("I");
            comboBoxTestAktiv.Items.Add("N");
            comboBoxTestAktiv.SelectedIndex = 0;
            comboBoxTestRollback.Items.Add("I");
            comboBoxTestRollback.Items.Add("N");
            comboBoxTestRollback.Items.Add("");

        }
        
        private void OwnerXML()
        {
            xmldoc.Load("AtHelperOwners.xml");
            foreach (XmlNode node in xmldoc.SelectNodes("AtHelperOwners/Owner"))
            {
                owner = node.InnerText;
                ownerList.Add(owner);
                comboBoxTulajdonos.Items.Add(owner);
            }
             currentOwner = xmldoc.SelectSingleNode("AtHelperOwners/COwner/CurrentName").InnerText;
            // A CurrentOwner a program használóját definiálja az XML-ben, így ezt a paramétert nem kell mindig megadni, csak ha más használja a programot.
            comboBoxTulajdonos.SelectedItem = currentOwner;
        }


        /// <summary>
        /// </summary>
        /// <param name="displayValue">55555555555</param>
        /// <param name="value">999999999999</param>
        /// <returns></returns>
        private ComboboxItem TesztesetCsoportParameter(string displayValue, object value)
        {
            ComboboxItem valasztas = new ComboboxItem() { DisplayValue = displayValue, Value = value };
            return valasztas;
        }

        #region OracleCommands   
        private void Command(string sql)
        {
            using (OracleCommand comm = new OracleCommand(sql, _con))
            {
                try
                {
                    using (OracleDataReader rdr = comm.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                        }
                        textBoxConnection.ForeColor = Color.Green;
                        // textBoxFromTo.Text = comm.Parameters[":id"].Value.ToString();
                        rdr.Close();
                        textBoxConnection.Text = "\n Sikeres csoport paraméter küldés: " + DateTime.Now.ToString("yyyy MMMdd /HH:mm:ss") + "\r\n " + textBox_ATG_NAME.Text;


                    }
                }
                catch (Exception ex)
                {
                    textBoxConnection.ForeColor = Color.Red;
                    textBoxConnection.Text = "Elképzelhető, hogy már létezik: " + ex.Message + ex.InnerException;
                    w.hiba = ex.Message + ex.InnerException;
                    w.streamWriter(w.hiba);

                }
            }
        }

        private string Command2(string sql)
        {
            string id = String.Empty;
            using (OracleCommand comm = new OracleCommand(sql, _con))
            {
                try
                {
                    comm.Parameters.Add(new OracleParameter
                    {
                        ParameterName = ":id",
                        OracleDbType = OracleDbType.Int32,
                        Direction = ParameterDirection.Output
                    });
                    comm.ExecuteNonQuery();
                    id = comm.Parameters[":id"].Value.ToString();

                }
                catch (Exception ex)
                {
                    textBoxConnection.ForeColor = Color.Red;
                    textBoxConnection.Text = "Elképzelhető, hogy már létezik: " + ex.Message + ex.InnerException;
                    w.hiba = ex.Message + ex.InnerException;
                    w.streamWriter(w.hiba);
                }
            }
            return id;
        }

        private void Command3(string sql, OracleParameter par)
        {
            string id = String.Empty;
            using (OracleCommand comm = new OracleCommand(sql, _con))
            {
                try
                {
                    comm.Parameters.Add(par);
                    comm.ExecuteNonQuery();
                    textBoxConnection.ForeColor = Color.Green;
                    textBoxConnection.Text = "\n Sikeres paraméter küldés: " + DateTime.Now.ToString("yyyy MMMdd / HH:mm:ss") + "\r\n " + textBoxTestNev.Text;
                }
                catch (Exception ex)
                {
                    textBoxConnection.ForeColor = Color.Red;
                    textBoxConnection.Text = "Elképzelhető, hogy már létezik: " + ex.Message + ex.InnerException;
                    w.hiba = ex.Message + ex.InnerException;
                    w.streamWriter(w.hiba);
                }
            }
        }

        #endregion

        #region Connection
        private void button1_Click(object sender, EventArgs e)
        {

            logIn_ID = textBox_LogIn_ID.Text;
            password = textBox_Password.Text;

            try
            {
                if (_con.State.ToString() == "Open")
                {
                    _con.Close();
                }

                string conString = string.Format("User Id={0};Password={1};Data Source=192.168.0.191:1870/TTKTE11;", logIn_ID, password);
                _con.ConnectionString = conString;
                _con.Open();
                textBoxConnection.Text = "A kapcsolódás sikeres: " + _con.State.ToString();
                textBoxConnection.ForeColor = Color.ForestGreen;
               // panelHide.Visible = false;

                CreateMyOracleDataReaderTest(_con, SqlLekerdezesek.idAndTestcase);
                

            }
            catch (Exception ex)
            {
                _con.Close();
                textBoxConnection.ForeColor = Color.Red;
                textBoxConnection.Text = "A kapcsolódás sikertelen. " + ex.Message + ex.InnerException;
                w.hiba = ex.Message + ex.InnerException;
                w.streamWriter(w.hiba);
              //  panelHide.Visible = true;
            }

        }

        private void button_Show_MouseDown(object sender, MouseEventArgs e)
        {
            textBox_Password.PasswordChar = '\0';
        }

        private void button_Show_MouseUp(object sender, MouseEventArgs e)
        {
            textBox_Password.PasswordChar = '*';
        }
        #endregion

        
        public void CreateMyOracleDataReaderTest(OracleConnection connection, string queryString)//string connectionString)
        {
            csoport.Clear();
            comboBox1.Items.Clear();
            OracleCommand command = new OracleCommand(queryString, connection);
            OracleDataReader reader = command.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    csoport.Add(TesztesetCsoportParameter(reader.GetValue(0).ToString(), reader.GetValue(1))); // DisplayValue , ID páros
                    
                }
            }
            finally
            {
                reader.Close();
            }

            for (int i = 0; i < csoport.Count; i++)
            {
                comboBox1.Items.Add(csoport[i]);
            }
            // A kiválasztott Index a beküldött teszteset nevével megegyezőt választja ki. 
            comboBox1.SelectedIndex = comboBox1.FindStringExact(tesztesetNeve);
            int last = csoport.Count - 1;
            

        }

        public void CreateMyOracleDataReader(OracleConnection connection, string queryString)//string connectionString)
        {
            OracleCommand command = new OracleCommand(queryString, connection);

            OracleDataReader reader = command.ExecuteReader();
            from.Clear();
            szabad.Clear();
            to.Clear();
            szamlalo = 0;

            try
            {
                while (reader.Read())
                {
                    //Kezdeti ID-tól Végződő ID-ig beolvasás, és hozzáadás listához
                    from.Add(reader.GetValue(0).ToString());
                    //  textBoxFromTo.Text += from[szamlalo] + " : \n ";
                    from.Add(reader.GetValue(1).ToString());
                    //  textBoxFromTo.Text += from[szamlalo+1] + " : \n ";             
                    szamlalo = szamlalo + 2;
                }
            }
            finally
            {
                reader.Close();
            }
        }

        public void CreateMyOracleDataReaderPriority(OracleConnection connection, string queryString)//string connectionString)
        {
            OracleCommand command = new OracleCommand(queryString, connection);
            OracleDataReader reader = command.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    mennyi = Convert.ToInt32(reader.GetValue(0).ToString());  
                }
            }
            finally
            {
                reader.Close();
            }
        }

        public void CreateMyOracleDataReaderPriorityMax(OracleConnection connection, string queryString)//string connectionString)
        {
            OracleCommand command = new OracleCommand(queryString, connection);
            OracleDataReader reader = command.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    //Ha még nincs teszteset a csoport paraméteren, akkor null-t dobna eredményül, de akkor automatikusan 1-re növeljük, hogy később biztos számot kapjon meg.
                    if (reader.GetValue(0).ToString() == string.Empty)
                    {
                        MaxPrior=0;
                    }
                    else
                    {
                        MaxPrior = Convert.ToInt32(reader.GetValue(0).ToString());
                    }
                }
            }
            finally
            {
                reader.Close();
            }
        }

        public void HelyVizsgalat()
        {

            from.Sort(); //Sorbarendezés
            for (int i = 0; i < szamlalo; i++)
            {
                //Ha üres, nem adja hozzá a "to" listához, ha nem üres, hozzáadja. 
                if (from[i] == string.Empty) { }
                else
                {
                    to.Add(Convert.ToInt32(from[i]));
                }
            }

            ;
            xmldoc.Load("AtHelperParameters.xml");
            tesztesetIDfrom = Convert.ToInt32(xmldoc.DocumentElement["TestIdFrom"].InnerText);
            


            // szabad From -To ID keresése -Egy Textboxban megnézi a szabad területeket, ahova lehet foglalni csoport paramétert
            szamlaloFromTo = 0;
            for (int i = tesztesetIDfrom; i < 9999; i = i + 10)
            {
                for (int k = szamlaloFromTo; k < to.Count; k++)
                {
                    if (i <= to[k] && i + 10 > to[k]) //Ha a listában lévő szám a vizsgált 'i' és 'i+9' közé esik, akkor onnatól nem vizságljuk tovább, mert foglalt lesz az a tizes intervallum, így a következő futásnál csak a "szamlalo"tól kezdjük vizsgálni.
                    {
                        szamlaloFromTo = k;
                        break;
                    }
                    else if (to[k] > i + 10) //Ha viszont a keresett intervallumnál nagyobb számot realizálunk, az intervallumot üresnek tekintjük, és hozzáadjuk a szabad listához, majd kilépünk, és növeljük az 'i'-t. 
                    {
                        szabad.Add(i);
                        break;
                    }
                }
            }
        }

        public void RegexpCsoport(string re, TextBox tb, string s)
        {
            //Gépelés közben megvizsgálja, hogy megfelelő e a mező bemeneti értéke. Amennyiben igen, az adatbázis még mindig visszadobhatja, de kisebb valószínűséggel
            Regex regex = new Regex(re);
            if (regex.IsMatch(tb.Text))
            {
                tb.BackColor = Color.PaleTurquoise;

                //megvizsgálja, hogy adott teszteset név már létezik e
                for (int i = 0; i < csoport.Count - 1; i++)
                {
                    if (textBox_ATG_TESTCASE_NAME.Text == csoport[i].DisplayValue)
                    {
                        textBox_ATG_TESTCASE_NAME.BackColor = Color.LightCoral;
                        textBoxHelp.Text = RegexHelper.letezik;
                    }
                }

                if (((textBox_ATG_TC_ID_FROM.BackColor == Color.PaleTurquoise &&
                    textBox_ATG_TC_ID_TO.BackColor == Color.PaleTurquoise) ||
                    textBox_ID_LENGHT.BackColor == Color.PaleTurquoise) &&
                    textBox_ATG_RUN_ID.BackColor == Color.PaleTurquoise &&
                    textBox_ATG_TESTCASE_NAME.BackColor == Color.PaleTurquoise &&
                    textBox_ATG_NAME.BackColor == Color.PaleTurquoise &&
                    textBox_ATG_TEST_TYPE.BackColor == Color.PaleTurquoise)
                {
                    Button_send.Enabled = true;
                }
            }
            else
            {
                tb.BackColor = Color.LightCoral;
                this.s = s;
                Button_send.Enabled = false;
            }
        }

        public void RegexpTest(string re, TextBox tb, string s, bool b = false)
        {
            Regex regex = new Regex(re);
            if (regex.IsMatch(tb.Text))
            {
                tb.BackColor = Color.PaleTurquoise;
                if (textBoxTestNev.BackColor == Color.PaleTurquoise && b)
                {
                    buttonTestSend.Enabled = true;
                }
                else if (!b)
                {
                    buttonTestSend.Enabled = false;
                }
            }
            else
            {
                tb.BackColor = Color.LightCoral;
                this.s = s;
                buttonTestSend.Enabled = false;
            }
        }

        private void CheckBox()
        {
            textBox_ATG_TC_ID_FROM.Enabled = !checkBox1.Checked;
            textBox_ATG_TC_ID_TO.Enabled = !checkBox1.Checked;
            textBox_ID_LENGHT.Enabled = checkBox1.Checked;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox();

            if (textBox_ATG_TC_ID_FROM.BackColor == Color.LightCoral)
            {
                textBox_ATG_TC_ID_FROM_TextChanged(sender, e);
            }
            if (textBox_ATG_TC_ID_TO.BackColor == Color.LightCoral)
            {
                textBox_ATG_TC_ID_TO_TextChanged(sender, e);
            }
            else if (textBox_ID_LENGHT.BackColor == Color.LightCoral)
            {
                textBox_ID_LENGHT_TextChanged(sender, e);
            }

        }
        #region Regex

        private void textBox_ATG_TC_ID_FROM_TextChanged(object sender, EventArgs e)
        {
            RegexpCsoport(RegexHelper.haromjegyu, textBox_ATG_TC_ID_FROM, RegexHelper.ATG_TC_ID_FROM);
        }

        private void textBox_ATG_TC_ID_TO_TextChanged(object sender, EventArgs e)
        {
            RegexpCsoport(RegexHelper.haromjegyu, textBox_ATG_TC_ID_TO, RegexHelper.ATG_TC_ID_TO);
        }

        private void textBox_ID_LENGHT_TextChanged(object sender, EventArgs e)
        {
            RegexpCsoport(RegexHelper.tizig, textBox_ID_LENGHT, RegexHelper.ID_LENGHT );
        }

        private void textBox_ATG_RUN_ID_TextChanged(object sender, EventArgs e)
        {
            RegexpCsoport(RegexHelper.negyjegyu, textBox_ATG_RUN_ID, RegexHelper.ATG_RUN_ID);
        }

        private void textBox_ATG_TESTCASE_NAME_TextChanged(object sender, EventArgs e)
        {
            RegexpCsoport(RegexHelper.huszonot, textBox_ATG_TESTCASE_NAME, RegexHelper.ATG_TESTCASE_NAME);
        }

        private void textBox_ATG_NAME_TextChanged(object sender, EventArgs e)
        {
            RegexpCsoport(RegexHelper.ketszaz, textBox_ATG_NAME, RegexHelper.ATG_NAME);
        }

        private void textBox_ATG_TEST_TYPE_TextChanged(object sender, EventArgs e)
        {
            RegexpCsoport(RegexHelper.otven, textBox_ATG_TEST_TYPE, RegexHelper.ATG_TEST_TYPE);
        }

        private void textBoxTestNev_TextChanged(object sender, EventArgs e)
        {
            RegexpTest(RegexHelper.Reg, textBoxTestNev, RegexHelper.RegHiba, comboBox1.SelectedItem != null);
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            RegexpTest(RegexHelper.Reg, textBoxTestNev, RegexHelper.RegHiba, comboBox1.SelectedItem != null);
        }

        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            textBoxHelp.Text = "A legutóbbi hibás mező: " + s;
        }

        private void Button_send_Click(object sender, EventArgs e)
        {
 
            //achivementek
            ha.streamReader();
            ha.csoportParameter++;
            ha.streamWriter(ha.csoportParameter.ToString());

            CreateMyOracleDataReader(_con, SqlLekerdezesek.idTartomany);
            HelyVizsgalat();

            if (checkBox1.Checked == true)
            {
                string sendFrom = szabad[0].ToString(); // a szabad lista első elemét konvertáljuk szöveggé. és küldjük be.
                int hossz = 0;
                hossz = szabad[0] + (Convert.ToInt32(textBox_ID_LENGHT.Text) - 1); // hossz = a kezdeti id, és a Lenght mezőben megadott érték összege.
                string sendTo = hossz.ToString(); //sendTo értéke megegyezik a hosszéval, viszont string típusú és átláthatóbb.

                string sql_send = String.Format("INSERT INTO pch.autotester_groups(ATG_RUN_ID, ATG_TESTCASE_NAME, ATG_TC_ID_FROM, ATG_TC_ID_TO, ATG_NAME, ATG_TEST_TYPE, ATG_OWNER) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')"
                , textBox_ATG_RUN_ID.Text, textBox_ATG_TESTCASE_NAME.Text, sendFrom, sendTo, textBox_ATG_NAME.Text, textBox_ATG_TEST_TYPE.Text, comboBoxTulajdonos.SelectedItem);
                Command(sql_send);

            }
            else if (checkBox1.Checked == false)
            {
                string sql_send = String.Format("INSERT INTO pch.autotester_groups(ATG_RUN_ID, ATG_TESTCASE_NAME, ATG_TC_ID_FROM, ATG_TC_ID_TO, ATG_NAME, ATG_TEST_TYPE, ATG_OWNER) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')"
               , textBox_ATG_RUN_ID.Text, textBox_ATG_TESTCASE_NAME.Text, textBox_ATG_TC_ID_FROM.Text, textBox_ATG_TC_ID_TO.Text, textBox_ATG_NAME.Text, textBox_ATG_TEST_TYPE.Text, comboBoxTulajdonos.SelectedItem);
                Command(sql_send);
            }

            // A teszteset neve megjegyzi a testcase textbox nevét, és beküldés után automatikusan az lesz a selectedItem a legördülő listában
            tesztesetNeve = textBox_ATG_TESTCASE_NAME.Text;
            CreateMyOracleDataReaderTest(_con, SqlLekerdezesek.idAndTestcase);

            //Miután beküldte, törli a test_case_name szövegét.
            
            textBox_ATG_TESTCASE_NAME.Text = string.Empty;
            
        }

        private void aUTOTESTER_GROUPSBindingNavigatorSaveItem_Click(object sender, EventArgs e) //Autotester Binding Navigátora
        {
            this.Validate();
            this.aUTOTESTER_GROUPSBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSet1);
        }

        private void button4_Click_1(object sender, EventArgs e) // Frissíti a Teszteset paraméter táblát és a Teszteset csoport paraméter táblát.
        {
            try
            {
                if (textBox_futasCsoport.Text == "")
                {
                    // TODO: This line of code loads data into the 'dataSet1.AUTOTESTER_TESTS' table. You can move, or remove it, as needed.
                    this.aUTOTESTER_TESTSTableAdapter.Fill(this.dataSet1.AUTOTESTER_TESTS);
                    // TODO: This line of code loads data into the 'dataSet1.AUTOTESTER_GROUPS' table. You can move, or remove it, as needed.
                    this.aUTOTESTER_GROUPSTableAdapter.Fill(this.dataSet1.AUTOTESTER_GROUPS);
                }
                else if (true)
                {

                }
            }
            catch (Exception ex)
            {
                textBoxConnection.ForeColor = Color.Red;
                textBoxConnection.Text = ex.Message + ex.InnerException;
                w.hiba = ex.Message + ex.InnerException;
                w.streamWriter(w.hiba);
            }
        }

        private void buttonFel_Click(object sender, EventArgs e)
        {
            try
            {
                sorszam++;
                if (sorszam == esetekHelyi.Count())
                {
                    sorszam = 0;
                }
                textBoxEsetek.Text = esetekHelyi[sorszam];
                textBoxTitle.Text = cimekHelyi[sorszam];
                labelFelLe.Text = ((sorszam + 1).ToString() + "/" + esetekHelyi.Count() + ". Oldal");
            }
            catch (Exception ex)
            {
                textBoxConnection.ForeColor = Color.Red;
                textBoxConnection.Text = ex.Message + ex.InnerException;
                w.hiba = ex.Message + ex.InnerException;
                w.streamWriter(w.hiba);
            }

        }

        private void buttonLe_Click(object sender, EventArgs e)
        {
            try
            {
                sorszam--;
                if (sorszam == -1)
                {
                    sorszam = esetekHelyi.Count() - 1;
                }
                textBoxEsetek.Text = esetekHelyi[sorszam];
                textBoxTitle.Text = cimekHelyi[sorszam];
                labelFelLe.Text = ((sorszam + 1).ToString() + "/" + esetekHelyi.Count() + ". Oldal");
            }
            catch (Exception ex)
            {
                textBoxConnection.ForeColor = Color.Red;
                textBoxConnection.Text = ex.Message + ex.InnerException;
                w.hiba = ex.Message + ex.InnerException;
                w.streamWriter(w.hiba);
            }

        }

        private void buttonTestSend_Click(object sender, EventArgs e)
        {
            PrioritasVizsgalat();

            //achivementek
            ha.streamReader();
            ha.tesztParamter++;
            ha.streamWriter(ha.tesztParamter.ToString());

            //Az oracle adatbázis clob-ot vár, még mi string-et küldünk be
            String input = textBoxEsetek.Text;
            OracleParameter parm = new OracleParameter();// "ATR_SQL", OracleDbType.Clob);
                                                         //  parm.Direction = ParameterDirection.Input;
                                                         //  parm.Value = input.ToCharArray();
            parm.ParameterName = ":id";
            parm.OracleDbType = OracleDbType.Int32;
            parm.Direction = ParameterDirection.Output;
            //Mivel a ComboBox-ba ComboBoxItem-et pakoltunk (megjelenítési név, id) ezért a ComboBoxban ha lekérjük a kiválasztott elemet ComboBoxItem-et fogunk visszakapni. 
            //Mivel a SelectedItem egy object-et ad vissza, ezért típuskényszeríteni kell ComboBoxItem-re, hogy ki tudjam olvasni az ID-t
            ComboboxItem selectedItem = (ComboboxItem)comboBox1.SelectedItem;

            //Beküldi a teszteset paramétert ATR_SQL nélkül
            string sql_sendTest = String.Format("INSERT INTO pch.autotester_tests(ATR_TESTCASE_PRIORITY, ATR_NAME, ATR_ATG_ID, ATR_CHECK_DONE, ATR_IS_ACTIVE, ATR_ROLLBACK) VALUES('{0}', '{1}', {2}, '{3}', '{4}', '{5}') returning ATR_ID into :id"
, priorOsszeg, textBoxTestNev.Text, selectedItem.Value, comboBoxTestZaras.SelectedItem, comboBoxTestAktiv.SelectedItem, comboBoxTestRollback.SelectedItem);
            //Command2(sql_sendTest);

            // textBoxFromTo.Text += sql_sendTest;
            string id = Command2(sql_sendTest);
            //TODO Ellenőrizni, hogy az ID üres e
            sql_sendTest = SqlLekerdezesek.updateClob + id;
            OracleParameter parm2 = new OracleParameter();
            parm2.Direction = ParameterDirection.Input;
            parm2.Value = input.ToCharArray();
            parm2.ParameterName = ":clob";
            Command3(sql_sendTest, parm2);
        }

        /// <summary>
        /// Megvizsgálja a prioritásokat a benne foglaltak alapján
        /// </summary>
        private void PrioritasVizsgalat()
        {
            //A kiválasztott csoport ATR_ATG_ID-ját adja vissza
            int valueMember = Convert.ToInt32(((ComboboxItem)comboBox1.SelectedItem).Value.ToString());
            //Megkeresi a kiválasztott csoportban a legmagasabb Prioritást
            string sql_priorityMax = string.Format("select max(ATR_Testcase_priority) from pch.autotester_tests where ATR_ATG_ID = {0}", valueMember);
            CreateMyOracleDataReaderPriorityMax(_con, sql_priorityMax);

            //A kezdetben 0 prioritást megnöveli, a priorösszeg a maxPrior és prioritás összege, mivel ha a MaxPrior+1 szabad, de a futáscsoportban több van,
            //mint a PriorParameter (amennyi az XML-ben meg van adva) tovább növeli
            do
            {
                prioritas++;
                priorOsszeg = MaxPrior + prioritas;
                //Megnézi az adott prioron több teszteset van e mint a PriorParameter-ben (xml) megadott maximális érték
                string sql_priority = string.Format("select spa.PRIORITY_CHECKER({0}, {1}) priority from dual", valueMember, priorOsszeg);
                CreateMyOracleDataReaderPriority(_con, sql_priority);
                //Egyszer mindenképp lefut, és addig megy, még olyan priort nem talál, ahol a futáscsoport < mint a PriorParameter-ben foglalt érték. 
            } while (mennyi > PriorParameter); //A PriorParameter az "AtHelperParameters.xml fájlban található, ott lehet módosítani
            //Miután talált egyet, kinullázzuk a prioritást, mert már a priorösszeg fogja tartalmazni a legmagasabb értéket. 
            prioritas = 0;
        }

        public void Parameters(string filename)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load("AtHelperParameters.xml");
            //string text = xmldoc.InnerText; //A teljes xml-ben lévő belső értékek kiolvasása
            PriorParameter = Convert.ToInt32(xmldoc.DocumentElement["MaxPrior"].InnerText); // a max prior elementben lévő paraméterek kiolvasása, NEM attribútum

        }

        #region MouseEnters

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.FlatAppearance.BorderSize = 3;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.FlatAppearance.BorderSize = 0;
        }

        private void buttonTestSend_EnabledChanged(object sender, EventArgs e)
        {
            buttonTestSend.FlatAppearance.BorderColor = buttonTestSend.Enabled == true ? Color.DodgerBlue : Color.LightGray;
            buttonTestSend.ForeColor = buttonTestSend.Enabled == true ? Color.DodgerBlue : Color.LightGray;
        }

        private void Button_send_EnabledChanged(object sender, EventArgs e)
        {
            Button_send.FlatAppearance.BorderColor = Button_send.Enabled == true ? Color.DodgerBlue : Color.LightGray;
            Button_send.ForeColor = Button_send.Enabled == true ? Color.DodgerBlue : Color.LightGray;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.FlatAppearance.BorderSize = 3;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.FlatAppearance.BorderSize = 1;
        }

        #endregion

        private void SPA_Database_Load(object sender, EventArgs e)
        {

        }

        private void comboBoxTulajdonos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}