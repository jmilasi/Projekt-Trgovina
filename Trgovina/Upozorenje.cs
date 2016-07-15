using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trgovina
{
    public partial class Upozorenje : Form
    {
        public Admin adminForma;
        public Upozorenje()
        {
            InitializeComponent();
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                label1.Text = "Artkli koji imaju rok uporabe manje od zadano dana: ";
            }
            if (radioButton2.Checked == true)
            {
                label1.Text = "Artkli kojih ima manje od zadane količine na skladištu";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            izvrsiUpit();
        }

        private void numericUpDown1_KeyDown(object sender, KeyEventArgs e)
        {
             if (e.KeyCode.ToString() == Keys.Enter.ToString())
             {
                 izvrsiUpit();
             }
        }
        private void izvrsiUpit()
        {
            if (radioButton1.Checked == true)
            {
                string dana = numericUpDown1.Text;
                int brDana = Int32.Parse(dana);
                DateTime danas = DateTime.Now;
                DateTime trazeniDatum = danas.AddDays(brDana);
                string datumtmp = trazeniDatum.ToString("dd.MM.yyyy");
                string datum = trazeniDatum.ToString("yyyy-MM-dd");
                adminForma.stvoriGrid();
                adminForma.commandString = "SELECT * FROM Artikl WHERE rok_uporabe < #" + datum + "# ORDER BY rok_uporabe";
                adminForma.tableName = "Artikl";
                adminForma.Text = "Artikli kojima će rok uporabe isteći do " + datumtmp ;
                adminForma.ispuniGrid();
            }
            if (radioButton2.Checked == true)
            {
                string strKolicina = numericUpDown1.Text;
                int tmpKolicina = Int32.Parse(strKolicina);
                adminForma.stvoriGrid();
                adminForma.commandString = "SELECT * FROM Artikl WHERE kolicina < " + tmpKolicina + "";
                adminForma.tableName = "Artikl";
                adminForma.Text = "Artikli kojih ima manje od " + tmpKolicina + " komada";
                adminForma.ispuniGrid();
            }
            this.Close();
        }
    }
}
