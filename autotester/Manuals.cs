using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace autotester
{

    public partial class Manuals : Form
    {
        List<string> alapBeginEnd = new List<string>();
        HelperAchi ha = new HelperAchi();
        
        public Manuals()
        {
            InitializeComponent();
            achi();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string Beolvas (string csvpath)
        {
            StreamReader srMan = new StreamReader(csvpath,Encoding.Default);    
            textBoxBeginEnd.Text = srMan.ReadToEnd();
            srMan.Close();
            return textBoxBeginEnd.Text;   
        }

        public void button2_Click(object sender, EventArgs e)
        {
            Beolvas("srManAlapBegin.txt");
            textBoxSugo.Text = Sugo.noSpecList;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Beolvas("srManSVBegin.txt");
            textBoxSugo.Text = Sugo.SpecList;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Beolvas("srManEnd.txt");
            textBoxSugo.Text = Sugo.atVege;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Beolvas("AtHelperParameters.xml");
            textBoxSugo.Text = Sugo.tapteruletek;
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (panel2.Visible == false)
            {
                panel2.Visible = true;
                textBoxDeveloper.Text = Sugo.fejlesztette;
            }
            else
            {
                panel2.Visible = false;
                textBoxDeveloper.Text = "";
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Beolvas("info.txt");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Beolvas("hibaüzenet.txt");
        }

        private void achi()
        {
            ha.streamReader();

            if (ha.tesztParamter>100)
            {
                panel3.Visible = true;
                if (ha.tesztParamter > 500)
                {
                    panel4.Visible = true;
                }
            }

            if (ha.megvaltoztat > 50)
            {
                panel5.Visible = true;
                if (ha.megvaltoztat > 500)
                {
                    panel6.Visible = true;
                    if (ha.megvaltoztat > 2000)
                    {
                        panel7.Visible = true;
                    }
                }
            }

            if (ha.bekuld > 50)
            {
                panel8.Visible = true;
                if (ha.bekuld > 500)
                {
                    panel9.Visible = true;
                    if (ha.bekuld > 2000)
                    {
                        panel10.Visible = true;
                    }
                }
            }

            if (ha.csoportParameter > 50)
            {
                panel11.Visible = true;
                if (ha.csoportParameter > 250)
                {
                    panel12.Visible = true;
                }
            }
        }
        #region achik
        private void panel3_MouseEnter(object sender, EventArgs e)
        {
            label1.Text = "Több mint 100 beküldött teszt paraméter";
        }

        private void panel4_MouseEnter(object sender, EventArgs e)
        {
            label1.Text = "Több mint 500 beküldött teszt paraméter";
        }

        private void panel5_MouseEnter(object sender, EventArgs e)
        {
            label1.Text = "Több mint 50 módosítás";
        }

        private void panel6_MouseEnter(object sender, EventArgs e)
        {
            label1.Text = "Több mint 500 módosítás";
        }

        private void panel7_MouseEnter(object sender, EventArgs e)
        {
            label1.Text = "Több mint 2000 módosítás";
        }

        private void panel8_MouseEnter(object sender, EventArgs e)
        {
            label1.Text = "Több mint 50 beküldött teszteset";
        }

        private void panel9_MouseEnter(object sender, EventArgs e)
        {
            label1.Text = "Több mint 500 beküldött teszteset";
        }

        private void panel10_MouseEnter(object sender, EventArgs e)
        {
            label1.Text = "Több mint 2000 beküldött teszteset";
        }

        private void panel11_MouseEnter(object sender, EventArgs e)
        {
            label1.Text = "Több mint 50 beküldött csoport paraméter";
        }

        private void panel12_MouseEnter(object sender, EventArgs e)
        {
            label1.Text = "Több mint 250 beküldött csoport paraméter";
        }
        #endregion

        private void Manuals_Load(object sender, EventArgs e)
        {

        }
    }
}
