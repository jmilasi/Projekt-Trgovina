using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Trgovina
{
    public partial class Admin : Form
    {
        public string connectionString;
        public DataSet dataSetOriginal; // ovdje cuvam lokalnu kopiju baze
        public DataGridView dataGrid1;
        public string commandString;
        public string tableName;
        bool trazi = false;

        public Form1 loginForma;

        public Admin()
        {
            InitializeComponent();
            this.Text = "Početna stranica";
            connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                                  @"Data source=C:\Users\Jure\Documents\Baza\Trgovina.mdb";
            dataSetOriginal = new DataSet();
            stvoriControle();
            label4.Text += "admine";
            label5.Text = "Datum: " + DateTime.Now.ToString("dd.MM.yyyy. HH:mm:ss tt");
            timer1.Enabled = true;
        }

        private void stanjeNaSkladištuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stvoriGrid();
            commandString = "SELECT * FROM Artikl";
            tableName = "Artikl";
            this.Text = "Stanje na skladištu";
            ispuniGrid();
        }

        private void listaSvihZaposlenikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stvoriGrid();
            commandString = "SELECT id, ime, prezime FROM Djelatnik";
            tableName = "Djelatnik";
            if (dataSetOriginal.Tables.Contains(tableName))
                dataSetOriginal.Tables.Remove(tableName);
            this.Text = listaSvihZaposlenikaToolStripMenuItem.Text;
            ispuniGrid();
            spremi.Visible = false;
            napomena.Visible = false;
        }

        private void popustToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stvoriGrid();
            commandString = "SELECT * FROM Artikl WHERE popust > 0";
            tableName = "Artikl";
            this.Text = popustToolStripMenuItem.Text;
            ispuniGrid();
        }

        private void upozorenjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            spremi.Visible = false;
            napomena.Visible = false;
            this.Controls.Remove(dataGrid1);       
            Upozorenje upozorenjeForma = new Upozorenje();
            upozorenjeForma.adminForma = this;
            upozorenjeForma.ShowDialog();
        }

        private void promijenaKorisnickiPodatakaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stvoriGrid();
            commandString = "SELECT * FROM Djelatnik WHERE id = '" + loginForma.employeeID + "'";
            tableName = "Djelatnik";
            this.Text = promijenaKorisnickiPodatakaToolStripMenuItem.Text;
            ispuniGrid();
        }

        private void pronađiZaposlenikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            spremi.Visible = false;
            napomena.Visible = false;
            this.Text = pronađiZaposlenikaToolStripMenuItem.Text;
            trazi = false;
            this.Controls.Remove(dataGrid1);
            label1.Text = "Id";
            label2.Text = "Ime";
            label3.Text = "Prezime";
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            timer1.Enabled = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void textBox1_TextChanged(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == Keys.Enter.ToString())
            {
                string tmp1 = textBox1.Text;
                string tmp2 = textBox2.Text;
                string tmp3 = textBox3.Text;

                this.Controls.Remove(dataGrid1);
                this.dataGrid1 = new DataGridView();
                ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
                this.SuspendLayout();
                this.dataGrid1.DataMember = "";
                this.dataGrid1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                this.dataGrid1.Location = new System.Drawing.Point(5, textBox3.Top + textBox3.Height + 10);
                this.dataGrid1.Name = "dataGridView1";
                this.dataGrid1.Size = new System.Drawing.Size(this.ClientSize.Width -10, 0);
                this.dataGrid1.MaximumSize = new Size(this.ClientSize.Width - 10, this.ClientSize.Height - 300 );
                this.Controls.Add(dataGrid1);
                ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
                this.ResumeLayout(false);

                if (trazi == false)
                {
                    commandString = "SELECT * FROM Djelatnik WHERE id LIKE '%" + tmp1 + "%' AND ime LIKE '" + tmp2 + "%' AND prezime LIKE '" + tmp3 + "%'";
                    tableName = "Djelatnik";
                    ispuniGrid();
                    spremi.Visible = false;
                    napomena.Visible = false;
                }
                else
                {
                    commandString = "SELECT * FROM Artikl WHERE barkod LIKE '%" + tmp1 + "%' AND ime LIKE '" + tmp2 + "%' AND kategorija LIKE '" + tmp3 + "%'";
                    tableName = "Artikl";
                    ispuniGrid();
                }
                

                ;
                e.SuppressKeyPress = true;
            }
        }

        private void početnaStranicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            spremi.Visible = false;
            napomena.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            timer1.Enabled = true;
            this.Controls.Remove(dataGrid1);
            this.Text = početnaStranicaToolStripMenuItem.Text;
        }

        public void stvoriGrid()
        {
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            timer1.Enabled = false;
            this.Controls.Remove(dataGrid1);
            this.dataGrid1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            this.dataGrid1.DataMember = "";
            this.dataGrid1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGrid1.Location = new System.Drawing.Point(5, 32);
            this.dataGrid1.Name = "dataGridView1";
            this.dataGrid1.Size = new System.Drawing.Size(this.ClientSize.Width - 10, 0);
            this.dataGrid1.MaximumSize = new Size(this.ClientSize.Width - 10, this.ClientSize.Height - 100);
            this.Controls.Add(dataGrid1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
        }

        public void ispuniGrid()
        {
            try
            {
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(commandString, connectionString);
                dataSetOriginal.Clear(); // sprjecavanje duplikata u tablici ako se vise puta klikne gumb za ucitavanje
                dataAdapter.Fill(dataSetOriginal, tableName);
                dataGrid1.DataSource = dataSetOriginal.Tables[tableName];
                setDataGridViewSize(dataGrid1);
                napomena.Location = new Point(5, this.ClientSize.Height - 15);
                napomena.Visible = true;
                spremi.Location = new Point(this.ClientSize.Width / 2 - spremi.Width / 2, dataGrid1.Top + dataGrid1.Height + 15);
                spremi.Visible = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private void spremiPromjene(object sender, EventArgs e)
        {
            try
            {
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(commandString, connectionString);
                DataSet dataSetChanges = dataSetOriginal.GetChanges();
                if (dataSetChanges != null)
                {
                    OleDbCommandBuilder commandBuilder = new OleDbCommandBuilder(dataAdapter);
                    dataAdapter.UpdateCommand = commandBuilder.GetUpdateCommand();
                    dataAdapter.Update(dataSetChanges, tableName);
                    dataSetOriginal.AcceptChanges();
                }
                else
                {
                    MessageBox.Show("Nema promjena!");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private void stvoriControle()
        {
            this.SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(94, 32);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(100, 20);
            textBox1.TabIndex = 0;
            textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 35);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(19, 13);
            label1.TabIndex = 1;
            label1.Text = "Id:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(12, 69);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(27, 13);
            label2.TabIndex = 2;
            label2.Text = "Ime:";
            // 
            // textBox2
            // 
            textBox2.Location = new System.Drawing.Point(94, 66);
            textBox2.Name = "textBox2";
            textBox2.Size = new System.Drawing.Size(100, 20);
            textBox2.TabIndex = 3;
            textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(13, 97);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(47, 13);
            label3.TabIndex = 4;
            label3.Text = "Prezime:";
            // 
            // textBox3
            // 
            textBox3.Location = new System.Drawing.Point(94, 94);
            textBox3.Name = "textBox3";
            textBox3.Size = new System.Drawing.Size(100, 20);
            textBox3.TabIndex = 5;
            textBox3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_TextChanged);
            // 
            // toolTip
            // 
            toolTip1.ToolTipTitle = "Obavijest:";
            toolTip1.IsBalloon = false;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(textBox1, "Pritisnite Enter za rezultat upita");
            toolTip1.SetToolTip(textBox2, "Pritisnite Enter za rezultat upita");
            toolTip1.SetToolTip(textBox3, "Pritisnite Enter za rezultat upita");
            //
            // form 1
            //
            this.Controls.Add(textBox3);
            this.Controls.Add(label3);
            this.Controls.Add(textBox2);
            this.Controls.Add(label2);
            this.Controls.Add(label1);
            this.Controls.Add(textBox1);
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            this.ResumeLayout(false);
        }
      
        private void nađiArtiklToolStripMenuItem_Click(object sender, EventArgs e)
        {
            spremi.Visible = false;
            napomena.Visible = false;
            trazi = true;
            this.Controls.Remove(dataGrid1);
            label1.Text = "Barkod";
            label2.Text = "Ime";
            label3.Text = "Kategorija";
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            this.Text = nađiArtiklToolStripMenuItem.Text;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label5.Text = "Datum: " + DateTime.Now.ToString("dd.MM.yyyy. HH:mm:ss tt");
        }

        private void setDataGridViewSize(DataGridView dataGridView)
        {
            int height = dataGridView.ColumnHeadersHeight + SystemInformation.HorizontalScrollBarHeight;
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                height += row.Height;
            }
            dataGridView.Height = height;
        }
       
        public void zavrsiSRadomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loginForma.Show();
            this.Close();
        }

        private void Admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            loginForma.Show();
        }

        private TextBox textBox1 = new TextBox();
        private TextBox textBox2 = new TextBox();
        private TextBox textBox3 = new TextBox();
        private Label label1 = new Label();
        private Label label2 = new Label();
        private Label label3 = new Label();

    }
}
