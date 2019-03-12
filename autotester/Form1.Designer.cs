namespace autotester
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBoxSQL = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.buttonMinus = new System.Windows.Forms.Button();
            this.buttonPlus = new System.Windows.Forms.Button();
            this.textBoxOrderId = new System.Windows.Forms.TextBox();
            this.textBoxStreetId = new System.Windows.Forms.TextBox();
            this.textBoxHouseNr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxTapterulet = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.cimTextBox2 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.buttonToDatabase = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.buttonManuals = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelCFC = new System.Windows.Forms.Panel();
            this.labelWarning = new System.Windows.Forms.Label();
            this.textBoxFajlnev = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxSQL
            // 
            this.textBoxSQL.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxSQL.BackColor = System.Drawing.Color.AliceBlue;
            this.textBoxSQL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSQL.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxSQL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxSQL.ForeColor = System.Drawing.Color.Black;
            this.textBoxSQL.Location = new System.Drawing.Point(129, 58);
            this.textBoxSQL.Multiline = true;
            this.textBoxSQL.Name = "textBoxSQL";
            this.textBoxSQL.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxSQL.Size = new System.Drawing.Size(1214, 863);
            this.textBoxSQL.TabIndex = 7;
            this.toolTip1.SetToolTip(this.textBoxSQL, "SQL lekérdezés");
            this.textBoxSQL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSQL_KeyPress);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 70);
            this.button1.TabIndex = 8;
            this.toolTip1.SetToolTip(this.button1, "Megnyitás");
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            this.button1.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Perpetua Titling MT", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(4, 614);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(109, 42);
            this.button3.TabIndex = 16;
            this.button3.Text = "Változó cserék";
            this.toolTip1.SetToolTip(this.button3, "\"STREET_ID, HOUSENUMBER, ORDER ID cserék\"");
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            this.button3.MouseEnter += new System.EventHandler(this.button3_MouseEnter);
            this.button3.MouseLeave += new System.EventHandler(this.button3_MouseLeave);
            // 
            // buttonMinus
            // 
            this.buttonMinus.BackColor = System.Drawing.Color.CornflowerBlue;
            this.buttonMinus.FlatAppearance.BorderColor = System.Drawing.Color.Snow;
            this.buttonMinus.FlatAppearance.BorderSize = 0;
            this.buttonMinus.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.buttonMinus.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.buttonMinus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.buttonMinus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonMinus.Location = new System.Drawing.Point(853, 6);
            this.buttonMinus.Name = "buttonMinus";
            this.buttonMinus.Size = new System.Drawing.Size(38, 23);
            this.buttonMinus.TabIndex = 4;
            this.buttonMinus.Text = "-";
            this.buttonMinus.UseVisualStyleBackColor = false;
            this.buttonMinus.Click += new System.EventHandler(this.button4_Click);
            this.buttonMinus.MouseEnter += new System.EventHandler(this.button4_MouseEnter);
            this.buttonMinus.MouseLeave += new System.EventHandler(this.button4_MouseLeave);
            // 
            // buttonPlus
            // 
            this.buttonPlus.BackColor = System.Drawing.Color.CornflowerBlue;
            this.buttonPlus.FlatAppearance.BorderColor = System.Drawing.Color.Snow;
            this.buttonPlus.FlatAppearance.BorderSize = 0;
            this.buttonPlus.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.buttonPlus.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.buttonPlus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.buttonPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonPlus.Location = new System.Drawing.Point(897, 6);
            this.buttonPlus.Name = "buttonPlus";
            this.buttonPlus.Size = new System.Drawing.Size(38, 23);
            this.buttonPlus.TabIndex = 5;
            this.buttonPlus.Text = "+";
            this.buttonPlus.UseVisualStyleBackColor = false;
            this.buttonPlus.Click += new System.EventHandler(this.button5_Click);
            this.buttonPlus.MouseEnter += new System.EventHandler(this.button5_MouseEnter);
            this.buttonPlus.MouseLeave += new System.EventHandler(this.button5_MouseLeave);
            // 
            // textBoxOrderId
            // 
            this.textBoxOrderId.BackColor = System.Drawing.Color.AliceBlue;
            this.textBoxOrderId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxOrderId.Location = new System.Drawing.Point(784, 7);
            this.textBoxOrderId.Name = "textBoxOrderId";
            this.textBoxOrderId.Size = new System.Drawing.Size(63, 21);
            this.textBoxOrderId.TabIndex = 3;
            // 
            // textBoxStreetId
            // 
            this.textBoxStreetId.BackColor = System.Drawing.Color.AliceBlue;
            this.textBoxStreetId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxStreetId.Location = new System.Drawing.Point(180, 6);
            this.textBoxStreetId.Name = "textBoxStreetId";
            this.textBoxStreetId.Size = new System.Drawing.Size(63, 21);
            this.textBoxStreetId.TabIndex = 1;
            this.textBoxStreetId.Text = "2297";
            // 
            // textBoxHouseNr
            // 
            this.textBoxHouseNr.AutoCompleteCustomSource.AddRange(new string[] {
            "s:  21 EWSD Réz (DSL) [SAM porttal]",
            "s:  19 BBMSAN Réz",
            "s:  23 Koax (KábelNet)",
            "s:  25 Gpon (OptiNet)",
            "s:  20 ISDN2",
            "s:  189 SV Koax",
            "s:  49 MicroNet (M)",
            "s:  67 MetroNet (N) I.",
            "s:  70 MetroNet (N) II."});
            this.textBoxHouseNr.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxHouseNr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxHouseNr.BackColor = System.Drawing.Color.AliceBlue;
            this.textBoxHouseNr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxHouseNr.Location = new System.Drawing.Point(325, 6);
            this.textBoxHouseNr.Name = "textBoxHouseNr";
            this.textBoxHouseNr.Size = new System.Drawing.Size(111, 21);
            this.textBoxHouseNr.TabIndex = 2;
            this.toolTip1.SetToolTip(this.textBoxHouseNr, "Nyomj \'s\' betűt a súgóhoz");
            this.textBoxHouseNr.TextChanged += new System.EventHandler(this.textBoxHouseNr_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(107, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "Street ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(248, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 15;
            this.label2.Text = "House Nr.";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Perpetua Titling MT", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(4, 558);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 50);
            this.button2.TabIndex = 15;
            this.button2.Text = "Alap cserék";
            this.toolTip1.SetToolTip(this.button2, "\"MT_ID, CU_NAME, CUFIRSTNAME, CULASTNAME, BUILDING, SEVICE_POINT_ID, PREMISE_ID c" +
        "serék\"");
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.button2.MouseEnter += new System.EventHandler(this.button2_MouseEnter);
            this.button2.MouseLeave += new System.EventHandler(this.button2_MouseLeave);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Transparent;
            this.button6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button6.BackgroundImage")));
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button6.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.button6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button6.Location = new System.Drawing.Point(4, 388);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(109, 50);
            this.button6.TabIndex = 12;
            this.toolTip1.SetToolTip(this.button6, "Fel");
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            this.button6.MouseEnter += new System.EventHandler(this.button6_MouseEnter);
            this.button6.MouseLeave += new System.EventHandler(this.button6_MouseLeave);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Transparent;
            this.button7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button7.BackgroundImage")));
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button7.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.button7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.button7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button7.Location = new System.Drawing.Point(4, 444);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(109, 50);
            this.button7.TabIndex = 13;
            this.toolTip1.SetToolTip(this.button7, "Le");
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            this.button7.MouseEnter += new System.EventHandler(this.button7_MouseEnter);
            this.button7.MouseLeave += new System.EventHandler(this.button7_MouseLeave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label3.Location = new System.Drawing.Point(1138, 884);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "Oldal";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.Color.DarkBlue;
            this.label4.Location = new System.Drawing.Point(713, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "Order ID:";
            // 
            // textBoxTapterulet
            // 
            this.textBoxTapterulet.BackColor = System.Drawing.Color.PaleTurquoise;
            this.textBoxTapterulet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTapterulet.Enabled = false;
            this.textBoxTapterulet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxTapterulet.Location = new System.Drawing.Point(442, 9);
            this.textBoxTapterulet.Name = "textBoxTapterulet";
            this.textBoxTapterulet.Size = new System.Drawing.Size(250, 14);
            this.textBoxTapterulet.TabIndex = 30;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Transparent;
            this.button8.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.button8.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.button8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Perpetua Titling MT", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Location = new System.Drawing.Point(4, 662);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(109, 37);
            this.button8.TabIndex = 17;
            this.button8.Text = "Másolás";
            this.toolTip1.SetToolTip(this.button8, "\"Teszteset kijelölése és Vágólapra másolása\"");
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Visible = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            this.button8.MouseEnter += new System.EventHandler(this.button8_MouseEnter);
            this.button8.MouseLeave += new System.EventHandler(this.button8_MouseLeave);
            // 
            // cimTextBox2
            // 
            this.cimTextBox2.BackColor = System.Drawing.Color.AliceBlue;
            this.cimTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cimTextBox2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cimTextBox2.Location = new System.Drawing.Point(180, 32);
            this.cimTextBox2.Name = "cimTextBox2";
            this.cimTextBox2.Size = new System.Drawing.Size(455, 21);
            this.cimTextBox2.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Location = new System.Drawing.Point(1262, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(64, 55);
            this.panel1.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.Color.DarkBlue;
            this.label5.Location = new System.Drawing.Point(144, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "Név:";
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.Transparent;
            this.button10.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button10.BackgroundImage")));
            this.button10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button10.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.button10.FlatAppearance.BorderSize = 0;
            this.button10.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.button10.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.button10.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Location = new System.Drawing.Point(4, 800);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(109, 50);
            this.button10.TabIndex = 20;
            this.toolTip1.SetToolTip(this.button10, "Kilépés");
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            this.button10.MouseEnter += new System.EventHandler(this.button10_MouseEnter);
            this.button10.MouseLeave += new System.EventHandler(this.button10_MouseLeave);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.Transparent;
            this.button11.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button11.BackgroundImage")));
            this.button11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button11.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.button11.FlatAppearance.BorderSize = 0;
            this.button11.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.button11.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.button11.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Location = new System.Drawing.Point(4, 227);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(109, 70);
            this.button11.TabIndex = 11;
            this.toolTip1.SetToolTip(this.button11, "Mentés mind");
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            this.button11.MouseEnter += new System.EventHandler(this.button11_MouseEnter);
            this.button11.MouseLeave += new System.EventHandler(this.button11_MouseLeave);
            // 
            // buttonToDatabase
            // 
            this.buttonToDatabase.BackColor = System.Drawing.Color.Transparent;
            this.buttonToDatabase.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonToDatabase.BackgroundImage")));
            this.buttonToDatabase.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonToDatabase.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.buttonToDatabase.FlatAppearance.BorderSize = 0;
            this.buttonToDatabase.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.buttonToDatabase.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.buttonToDatabase.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonToDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonToDatabase.Location = new System.Drawing.Point(4, 153);
            this.buttonToDatabase.Name = "buttonToDatabase";
            this.buttonToDatabase.Size = new System.Drawing.Size(109, 70);
            this.buttonToDatabase.TabIndex = 10;
            this.toolTip1.SetToolTip(this.buttonToDatabase, "Beküldés SPA-ba");
            this.buttonToDatabase.UseVisualStyleBackColor = false;
            this.buttonToDatabase.Click += new System.EventHandler(this.buttonToDatabase_Click);
            this.buttonToDatabase.MouseEnter += new System.EventHandler(this.buttonToDatabase_MouseEnter);
            this.buttonToDatabase.MouseLeave += new System.EventHandler(this.buttonToDatabase_MouseLeave);
            // 
            // button13
            // 
            this.button13.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button13.BackgroundImage")));
            this.button13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button13.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.button13.FlatAppearance.BorderSize = 0;
            this.button13.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.button13.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button13.Location = new System.Drawing.Point(4, 500);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(109, 50);
            this.button13.TabIndex = 14;
            this.toolTip1.SetToolTip(this.button13, "Egyéb lehetőségek");
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click_1);
            this.button13.MouseEnter += new System.EventHandler(this.button13_MouseEnter);
            this.button13.MouseLeave += new System.EventHandler(this.button13_MouseLeave);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.Transparent;
            this.button9.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button9.BackgroundImage")));
            this.button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button9.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.button9.FlatAppearance.BorderSize = 0;
            this.button9.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.button9.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.button9.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button9.Location = new System.Drawing.Point(4, 78);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(109, 70);
            this.button9.TabIndex = 9;
            this.toolTip1.SetToolTip(this.button9, "Az összes paraméter megváltoztatása");
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            this.button9.MouseEnter += new System.EventHandler(this.button9_MouseEnter);
            this.button9.MouseLeave += new System.EventHandler(this.button9_MouseLeave);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(3, 303);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(109, 70);
            this.button4.TabIndex = 21;
            this.toolTip1.SetToolTip(this.button4, "Mentés mind");
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            this.button4.MouseEnter += new System.EventHandler(this.button4_MouseEnter_1);
            this.button4.MouseLeave += new System.EventHandler(this.button4_MouseLeave_1);
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.Transparent;
            this.button12.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.button12.FlatAppearance.BorderSize = 0;
            this.button12.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.button12.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.button12.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button12.Font = new System.Drawing.Font("Perpetua Titling MT", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button12.Location = new System.Drawing.Point(3, 705);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(109, 34);
            this.button12.TabIndex = 18;
            this.button12.Text = "Mentés";
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Visible = false;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            this.button12.MouseEnter += new System.EventHandler(this.button12_MouseEnter);
            this.button12.MouseLeave += new System.EventHandler(this.button12_MouseLeave);
            // 
            // buttonManuals
            // 
            this.buttonManuals.BackColor = System.Drawing.Color.Transparent;
            this.buttonManuals.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.buttonManuals.FlatAppearance.BorderSize = 0;
            this.buttonManuals.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.buttonManuals.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.buttonManuals.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonManuals.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonManuals.Font = new System.Drawing.Font("Perpetua Titling MT", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonManuals.Location = new System.Drawing.Point(4, 745);
            this.buttonManuals.Name = "buttonManuals";
            this.buttonManuals.Size = new System.Drawing.Size(109, 50);
            this.buttonManuals.TabIndex = 19;
            this.buttonManuals.Text = "Súgó";
            this.buttonManuals.UseVisualStyleBackColor = false;
            this.buttonManuals.Visible = false;
            this.buttonManuals.Click += new System.EventHandler(this.button13_Click);
            this.buttonManuals.MouseEnter += new System.EventHandler(this.buttonManuals_MouseEnter);
            this.buttonManuals.MouseLeave += new System.EventHandler(this.buttonManuals_MouseLeave);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.button13);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.button10);
            this.panel2.Controls.Add(this.buttonToDatabase);
            this.panel2.Controls.Add(this.button9);
            this.panel2.Controls.Add(this.button7);
            this.panel2.Controls.Add(this.button6);
            this.panel2.Controls.Add(this.button11);
            this.panel2.Controls.Add(this.button8);
            this.panel2.Controls.Add(this.button12);
            this.panel2.Controls.Add(this.buttonManuals);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Location = new System.Drawing.Point(3, 58);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(120, 863);
            this.panel2.TabIndex = 29;
            // 
            // panelCFC
            // 
            this.panelCFC.BackColor = System.Drawing.Color.Transparent;
            this.panelCFC.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelCFC.BackgroundImage")));
            this.panelCFC.Location = new System.Drawing.Point(3, 1);
            this.panelCFC.Name = "panelCFC";
            this.panelCFC.Size = new System.Drawing.Size(1355, 55);
            this.panelCFC.TabIndex = 33;
            this.panelCFC.Visible = false;
            // 
            // labelWarning
            // 
            this.labelWarning.AutoSize = true;
            this.labelWarning.ForeColor = System.Drawing.Color.Red;
            this.labelWarning.Location = new System.Drawing.Point(950, 10);
            this.labelWarning.Name = "labelWarning";
            this.labelWarning.Size = new System.Drawing.Size(0, 13);
            this.labelWarning.TabIndex = 32;
            // 
            // textBoxFajlnev
            // 
            this.textBoxFajlnev.BackColor = System.Drawing.Color.AliceBlue;
            this.textBoxFajlnev.Enabled = false;
            this.textBoxFajlnev.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxFajlnev.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textBoxFajlnev.Location = new System.Drawing.Point(704, 32);
            this.textBoxFajlnev.Name = "textBoxFajlnev";
            this.textBoxFajlnev.Size = new System.Drawing.Size(231, 21);
            this.textBoxFajlnev.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.ForeColor = System.Drawing.Color.DarkBlue;
            this.label6.Location = new System.Drawing.Point(641, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 15);
            this.label6.TabIndex = 14;
            this.label6.Text = "Fájl név:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1349, 561);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxFajlnev);
            this.Controls.Add(this.labelWarning);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cimTextBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxTapterulet);
            this.Controls.Add(this.textBoxHouseNr);
            this.Controls.Add(this.textBoxStreetId);
            this.Controls.Add(this.textBoxOrderId);
            this.Controls.Add(this.buttonPlus);
            this.Controls.Add(this.buttonMinus);
            this.Controls.Add(this.textBoxSQL);
            this.Controls.Add(this.panelCFC);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1365, 962);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSQL;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button buttonMinus;
        private System.Windows.Forms.Button buttonPlus;
        private System.Windows.Forms.TextBox textBoxOrderId;
        private System.Windows.Forms.TextBox textBoxStreetId;
        private System.Windows.Forms.TextBox textBoxHouseNr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxTapterulet;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox cimTextBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button buttonManuals;
        private System.Windows.Forms.Button buttonToDatabase;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Label labelWarning;
        private System.Windows.Forms.Panel panelCFC;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBoxFajlnev;
        private System.Windows.Forms.Label label6;
    }
}

