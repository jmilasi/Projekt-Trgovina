using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trgovina {
    public partial class Form1 : Form {
        Button buttonBillCreate, buttonDeleteEntries;
        Label labelBarcodeSearch, labelNameSearch, labelMoney, labelSumNotification, labelSumResult;
        TextBox textBoxBarcodeInput, textBoxNameInput, textBoxMoney;
        DataGridView dataGridViewResult;
        GroupBox groupBoxPaymentMethod;
        RadioButton radioButtonCard, radioButtonCash;
        public string employeeID;

        public Form1() {
            InitializeComponent();
            this.Size = new Size(300, 300);
            this.Text = "Prijava";
        }

        private void createFormAdmin() {
            Admin adminForma = new Admin();
            adminForma.loginForma = this;
            adminForma.FormClosed += AdminForma_FormClosed;
            adminForma.Show();
        }

        private void AdminForma_FormClosed(object sender, FormClosedEventArgs e) {
            this.Show();
        }

        private void createFormNonAdmin() {
            Form formNonAdmin = new Form();
            formNonAdmin.Size = new Size(700, 600);
            formNonAdmin.Text = "Za djelatnike";
            formNonAdmin.MaximizeBox = formNonAdmin.MinimizeBox = false;
            formNonAdmin.FormClosed += NonAdminForm_FormClosed;
            formNonAdmin.Show();

            buttonBillCreate = new Button();
            buttonDeleteEntries = new Button();
            labelBarcodeSearch = new Label();
            textBoxBarcodeInput = new TextBox();
            labelNameSearch = new Label();
            textBoxNameInput = new TextBox();
            dataGridViewResult = new DataGridView();
            labelSumNotification = new Label();
            labelSumResult = new Label();
            groupBoxPaymentMethod = new GroupBox();
            radioButtonCard = new RadioButton();
            radioButtonCash = new RadioButton();
            labelMoney = new Label();
            textBoxMoney = new TextBox();

            autoComplete();

            formNonAdmin.Controls.AddRange(new Control[] {
                buttonBillCreate, buttonDeleteEntries, labelBarcodeSearch, textBoxBarcodeInput, labelNameSearch,
                textBoxNameInput, dataGridViewResult, labelSumNotification, labelSumResult, groupBoxPaymentMethod,
                labelMoney, textBoxMoney
            });

            foreach (Control c in formNonAdmin.Controls) {
                c.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            }

            buttonBillCreate.Text = "Izradi račun";
            buttonBillCreate.AutoSize = true;
            buttonBillCreate.Location = new Point(10, 10);
            buttonBillCreate.Click += ButtonBillCreate_Click;

            buttonDeleteEntries.Text = "Poništi sve unose";
            buttonDeleteEntries.AutoSize = true;
            buttonDeleteEntries.Location = new Point(10 + buttonBillCreate.Left + buttonBillCreate.Width, 10);
            buttonDeleteEntries.Click += ButtonDeleteEntries_Click;

            labelBarcodeSearch.Text = "Pretraži prema barkodu:";
            labelBarcodeSearch.AutoSize = true;
            labelBarcodeSearch.Location = new Point(10, buttonBillCreate.Top + buttonBillCreate.Height + 10);

            textBoxBarcodeInput.Location = new Point(10, labelBarcodeSearch.Top + labelBarcodeSearch.Height + 10);
            textBoxBarcodeInput.KeyUp += showResult;

            labelNameSearch.Text = "Pretraži prema imenu:";
            labelNameSearch.AutoSize = true;
            labelNameSearch.Location = new Point(10, textBoxBarcodeInput.Top + textBoxBarcodeInput.Height + 10);

            textBoxNameInput.Location = new Point(10, labelNameSearch.Top + labelNameSearch.Height + 10);
            textBoxNameInput.KeyUp += showResult;

            dataGridViewResult.Location = new Point(10, textBoxNameInput.Top + textBoxNameInput.Height + 20);
            dataGridViewResult.Width = formNonAdmin.ClientSize.Width - 20;
            dataGridViewResult.ColumnCount = 5;
            foreach (DataGridViewColumn column in dataGridViewResult.Columns) {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            dataGridViewResult.Columns[0].Name = "IME";
            dataGridViewResult.Columns[1].Name = "CIJENA";
            dataGridViewResult.Columns[2].Name = "POPUST";
            dataGridViewResult.Columns[3].Name = "KOLIČINA";
            dataGridViewResult.Columns[4].Name = "UKUPNO";
            dataGridViewResult.ReadOnly = true; // nema smisla da se rezultat pretrage moze mijenjati
            dataGridViewResult.RowHeadersVisible = false; // makni predredak
            dataGridViewResult.AllowUserToAddRows = false; // onemoguci da se dodaje novi redak
            dataGridViewResult.CellDoubleClick += DataGridView_CellDoubleClick;

            labelSumNotification.Location = new Point(10, dataGridViewResult.Bottom + 20);
            labelSumNotification.Text = "Iznos računa (u kunama):";
            labelSumNotification.AutoSize = true;

            labelSumResult.Location = new Point(labelSumNotification.Right + 10, labelSumNotification.Top);
            labelSumResult.Text = "0.0";
            labelSumResult.AutoSize = true;

            groupBoxPaymentMethod.Location = new Point(10, labelSumNotification.Bottom + 20);
            groupBoxPaymentMethod.Text = "Odaberi način plaćanja";
            groupBoxPaymentMethod.Controls.AddRange(new Control[] { radioButtonCard, radioButtonCash });
            radioButtonCard.Location = new Point(10, 20);
            radioButtonCard.Text = "Kartica";
            radioButtonCard.CheckedChanged += radioButtonCheckedChanged;
            radioButtonCash.Location = new Point(10, radioButtonCard.Top + radioButtonCard.Height + 10);
            radioButtonCash.Text = "Gotovina";
            radioButtonCash.CheckedChanged += radioButtonCheckedChanged;

            labelMoney.Location = new Point(10, groupBoxPaymentMethod.Top + groupBoxPaymentMethod.Height + 10);
            labelMoney.AutoSize = true;

            textBoxMoney.Hide();
        }

        private void radioButtonCheckedChanged(object sender, EventArgs e) {
            RadioButton radioButton = (RadioButton)sender;

            if (radioButton.Checked) {
                if (radioButton == radioButtonCard) {
                    labelMoney.Text = "Unesite broj kartice:";
                }
                else if (radioButton == radioButtonCash) {
                    labelMoney.Text = "Unesite primljeni iznos:";
                }
                textBoxMoney.Location = new Point(labelMoney.Right + 10, labelMoney.Top);
                textBoxMoney.Show();
            }
        }

        private void setDataGridViewHeight(DataGridView dataGridView) {
            int maxNumberOfVisibleRows = 8;
            int height = dataGridView.ColumnHeadersHeight + SystemInformation.HorizontalScrollBarHeight;
            
            for (int i = 0; i < dataGridView.Rows.Count && i < maxNumberOfVisibleRows; ++i) {
                height += dataGridView.Rows[0].Height;
            }
            dataGridView.Height = height;
            
            if (dataGridView == dataGridViewResult) {
                labelSumNotification.Location = new Point(10, dataGridViewResult.Bottom + 20);
                labelSumResult.Location = new Point(labelSumNotification.Right + 10, labelSumNotification.Top);
                groupBoxPaymentMethod.Location = new Point(10, labelSumNotification.Bottom + 20);
                labelMoney.Location = new Point(10, groupBoxPaymentMethod.Bottom + 10);
            }
        }

        private void ButtonDeleteEntries_Click(object sender, EventArgs e) {
            dataGridViewResult.Rows.Clear();
            dataGridViewResult.Refresh();
            textBoxMoney.Clear();
            labelSumResult.Text = "0.0";
        }

        private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            // ne zelim da ovo radi za header, dakle treba izbjeci redak s indeksom -1
            if (e.RowIndex != -1) {
                // azuriraj iznos racuna
                double wholeSum = Convert.ToDouble(labelSumResult.Text);
                wholeSum -= Convert.ToDouble(dataGridViewResult[4, e.RowIndex].Value);
                wholeSum = Math.Round(wholeSum, 2);
                labelSumResult.Text = wholeSum.ToString();

                // ukloni redak koji je dvokliknut
                dataGridViewResult.Rows.RemoveAt(e.RowIndex);

                // postavi visinu DataGrid objekta tako da odgovara broju redaka
                setDataGridViewHeight(dataGridViewResult);
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e) {
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                                      @"Data source=C:\Users\Jure\Documents\Baza\Trgovina.mdb";
            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbDataReader reader = null;

            try {
                connection.Open();
                string commandString = "SELECT LOZINKA FROM DJELATNIK WHERE ID=@parameter";
                OleDbCommand command = new OleDbCommand(commandString, connection);
                OleDbParameter parameter = new OleDbParameter("@parameter", textBoxUsername.Text);
                command.Parameters.Add(parameter);
                reader = command.ExecuteReader();

                while (reader.Read()) {
                    if (reader.GetString(0) == textBoxPassword.Text) {
                        employeeID = textBoxUsername.Text;
                        this.Hide(); // sakrij glavnu formu
                        if (employeeID[0] == '0') {
                            createFormAdmin();
                        }
                        else {
                            createFormNonAdmin();
                        }
                    }
                    else {
                        MessageBox.Show("Neispravna lozinka!");
                    }
                    return; // da se ne bi dosegao dio koji ispisuje poruku o neispravnom korisnickom imenu
                }

                MessageBox.Show("Neispravno korisničko ime!");
            }
            catch (Exception exception) {
                MessageBox.Show(exception.ToString());
            }
            finally {
                if (reader != null) {
                    reader.Close();
                }
                if (connection != null) {
                    connection.Close();
                }
            }
        }

        private int getTax(string category) {
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                                            @"Data source=C:\Users\Jure\Documents\Baza\Trgovina.mdb";
            string commandString = "SELECT IZNOS FROM PDV WHERE KATEGORIJA='" + category + "'"; 
            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbDataReader reader = null;
            int tax = 0;

            try {
                connection.Open();
                OleDbCommand command = new OleDbCommand(commandString, connection);
                reader = command.ExecuteReader();
                while (reader.Read()) {
                    tax = Convert.ToInt32(reader["IZNOS"]);
                }
            }
            catch (Exception exception) {
                MessageBox.Show(exception.ToString());
            }
            finally {
                if (reader != null) {
                    reader.Close();
                }
                if (connection != null) {
                    connection.Close();
                }
            }

            return tax;
        }
        
        private void showResult(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                                            @"Data source=C:\Users\Jure\Documents\Baza\Trgovina.mdb";
                OleDbConnection connection = new OleDbConnection(connectionString);
                OleDbDataReader reader = null;
                TextBox textBox = (TextBox)sender;
                string commandString = "";

                if (textBox == textBoxBarcodeInput) {
                    commandString = "SELECT * FROM ARTIKL WHERE BARKOD=@parameter";
                }
                else if (textBox == textBoxNameInput) {
                    commandString = "SELECT * FROM ARTIKL WHERE IME=@parameter";
                }
                
                try {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand(commandString, connection);
                    OleDbParameter parameter = new OleDbParameter("@parameter", textBox.Text);
                    command.Parameters.Add(parameter);
                    reader = command.ExecuteReader();

                    while (reader.Read()) {
                        bool exists = false;
                        double finalPrice = 0.0;

                        for (int i = 0; i < dataGridViewResult.RowCount; ++i) {
                            if (dataGridViewResult[0, i].Value.ToString() == reader["IME"].ToString()) {
                                int baseQuantity = Convert.ToInt32(reader["KOLICINA"]);
                                int increasedTableQuantity = Convert.ToInt32(dataGridViewResult[3, i].Value) + 1;
                                if (baseQuantity < increasedTableQuantity) {
                                    MessageBox.Show("Nema više toga artikla u skladištu!");
                                }
                                else {
                                    // inace povecaj kolicinu toga artikla u tablici i ukupan iznos za taj artikl
                                    double linePrice = Convert.ToDouble(dataGridViewResult[1, i].Value);
                                    double discount = Convert.ToDouble(dataGridViewResult[2, i].Value);
                                    finalPrice = ((1 - discount / 100) * linePrice);
                                    finalPrice = Math.Round(finalPrice, 2);
                                    double lineSum = finalPrice * increasedTableQuantity;
                                    lineSum = Math.Round(lineSum, 2);
                                    dataGridViewResult[3, i].Value = increasedTableQuantity;
                                    dataGridViewResult[4, i].Value = lineSum;
                                }
                                exists = true;
                                break;
                            }
                        }

                        // ako artikl ne postoji u DataGrid objektu, dodaj novi redak u DataGrid objekt
                        if (!exists) {
                            int tax = getTax(reader["KATEGORIJA"].ToString());
                            double basePrice = Convert.ToDouble(reader["CIJENA"]);
                            double linePrice = basePrice + ((double)tax / 100) * basePrice;
                            linePrice = Math.Round(linePrice, 2); // zaokruzi na dva decimalna mjesta
                            double discount = Convert.ToDouble(reader["POPUST"]);
                            finalPrice = (1 - discount / 100) * linePrice;
                            finalPrice = Math.Round(finalPrice, 2);
                            dataGridViewResult.Rows.Add(reader["IME"], linePrice, reader["POPUST"], 1, finalPrice);
                        }

                        // azuriraj iznos racuna
                        double wholeSum = Convert.ToDouble(labelSumResult.Text);
                        wholeSum += finalPrice;
                        wholeSum = Math.Round(wholeSum, 2);
                        labelSumResult.Text = wholeSum.ToString();
                    }

                    // postavi visinu DataGrid objekta tako da odgovara broju redaka
                    setDataGridViewHeight(dataGridViewResult);
                    
                    // pocisti odgovarajuci TextBox objekt
                    textBox.Clear();
                }
                catch (Exception exception) {
                    MessageBox.Show(exception.ToString());
                }
                finally {
                    if (reader != null) {
                        reader.Close();
                    }
                    if (connection != null) {
                        connection.Close();
                    }
                }
            }
        }

        private void autoComplete() {
            textBoxBarcodeInput.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBoxBarcodeInput.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collBarcode = new AutoCompleteStringCollection();

            textBoxNameInput.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBoxNameInput.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collName = new AutoCompleteStringCollection();

            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                                      @"Data source=C:\Users\Jure\Documents\Baza\Trgovina.mdb";
            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbDataReader reader = null;

            try {
                connection.Open();
                string commandString = "SELECT * FROM ARTIKL";
                OleDbCommand command = new OleDbCommand(commandString, connection);
                reader = command.ExecuteReader();
                while (reader.Read()) {
                    string barcode = reader.GetString(0);
                    collBarcode.Add(barcode);

                    string name = reader.GetString(1);
                    collName.Add(name);
                }
            }
            catch (Exception exception) {
                MessageBox.Show(exception.ToString());
            }
            finally {
                if (reader != null) {
                    reader.Close();
                }
                if (connection != null) {
                    connection.Close();
                }
            }

            textBoxBarcodeInput.AutoCompleteCustomSource = collBarcode;
            textBoxNameInput.AutoCompleteCustomSource = collName;
        }

        private void ButtonBillCreate_Click(object sender, EventArgs e) {
            if (dataGridViewResult.RowCount == 0) {
                MessageBox.Show("Račun je prazan!");
                return;
            }
            
            if (radioButtonCard.Checked == false && radioButtonCash.Checked == false) {
                MessageBox.Show("Nije odabran način plaćanja!");
                return;
            }

            int cardNumber = 0;
            double sum = 0.0;
            if (radioButtonCard.Checked) {
                if (!int.TryParse(textBoxMoney.Text, out cardNumber)) {
                    MessageBox.Show("Neispravan broj kartice!");
                    return;
                }
                for (int i = 0; i < dataGridViewResult.RowCount; ++i) {
                    sum += Convert.ToDouble(dataGridViewResult[4, i].Value);
                }
                sum = Math.Round(sum, 2);
            }

            double moneyReceived = 0.0;
            if (radioButtonCash.Checked) {
                if (!double.TryParse(textBoxMoney.Text, out moneyReceived)) {
                    MessageBox.Show("Neispravan iznos novca!");
                    return;
                }
                moneyReceived = Math.Round(moneyReceived, 2);
                sum = Convert.ToDouble(labelSumResult.Text);
                sum = Math.Round(sum, 2);
                if (moneyReceived < sum) {
                    MessageBox.Show("Primljeni novac nije dovoljan!");
                    return;
                }
            }

            Form formBill = new Form();
            formBill.Size = new Size(700, 600);
            formBill.MaximizeBox = formBill.MinimizeBox = false;
            formBill.Text = "Izrada računa";
            formBill.Show();

            Label labelDate = new Label();
            formBill.Controls.Add(labelDate);
            labelDate.Location = new Point(10, 10);
            labelDate.AutoSize = true;
            labelDate.Text = "Datum: " + DateTime.Now.ToString("d");

            Label labelTime = new Label();
            formBill.Controls.Add(labelTime);
            labelTime.Location = new Point(10, 10 + labelDate.Top + labelDate.Height);
            labelTime.AutoSize = true;
            labelTime.Text = "Vrijeme: " + DateTime.Now.ToString("HH:mm:ss");

            Label labelEmployee = new Label();
            formBill.Controls.Add(labelEmployee);
            labelEmployee.Location = new Point(10, 10 + labelTime.Top + labelTime.Height);
            labelEmployee.AutoSize = true;

            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                                      @"Data source=C:\Users\Jure\Documents\Baza\Trgovina.mdb";
            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbDataReader reader = null;

            try {
                connection.Open();
                string commandString = "SELECT IME, PREZIME FROM DJELATNIK WHERE ID='" + employeeID + "'";
                OleDbCommand command = new OleDbCommand(commandString, connection);
                reader = command.ExecuteReader();
                while (reader.Read()) {
                    labelEmployee.Text = "Djelatnik: " + reader["IME"] + " " + reader["PREZIME"];
                }
            }
            catch (Exception exception) {
                MessageBox.Show(exception.ToString());
            }
            finally {
                if (reader != null) {
                    reader.Close();
                }
                if (connection != null) {
                    connection.Close();
                }
            }

            // kreiraj DataGridView objekt koji predstavlja racun
            DataGridView dataGridViewBill = new DataGridView();
            formBill.Controls.Add(dataGridViewBill);
            dataGridViewBill.Location = new Point(10, labelEmployee.Top + labelEmployee.Height + 20);
            dataGridViewBill.Width = formBill.ClientSize.Width - 20;
            dataGridViewBill.ColumnCount = dataGridViewResult.ColumnCount;
            for (int i = 0; i < dataGridViewBill.ColumnCount; ++i) {
                dataGridViewBill.Columns[i].Name = dataGridViewResult.Columns[i].Name;
                dataGridViewBill.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewBill.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewBill.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            dataGridViewBill.ReadOnly = true;
            dataGridViewBill.RowHeadersVisible = false;
            dataGridViewBill.AllowUserToAddRows = false;

            // popuni racun prema unesenim artiklima
            for (int i = 0; i < dataGridViewResult.RowCount; ++i) {
                object[] values = new object[dataGridViewResult.ColumnCount];
                for (int j = 0; j < dataGridViewResult.ColumnCount; ++j) {
                    values[j] = dataGridViewResult[j, i].Value;
                }
                dataGridViewBill.Rows.Add(values);
            }

            // postavi visinu DataGrid objekta tako da odgovara broju redaka
            setDataGridViewHeight(dataGridViewBill);

            // smanji kolicinu odgovarajucih artikala u bazi
            try {
                connection.Open();
                for (int i = 0; i < dataGridViewResult.RowCount; ++i) {
                    string commandString = "UPDATE ARTIKL SET KOLICINA=KOLICINA-@quantity WHERE IME=@name";
                    OleDbCommand command = new OleDbCommand(commandString, connection);
                    int tableQuantity = Convert.ToInt32(dataGridViewResult[3, i].Value);
                    OleDbParameter quantity = new OleDbParameter("@quantity", tableQuantity);
                    OleDbParameter name = new OleDbParameter("@name", dataGridViewResult[0, i].Value.ToString());
                    command.Parameters.AddRange(new OleDbParameter[] { quantity, name });
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception exception) {
                MessageBox.Show(exception.ToString());
            }
            finally {
                if (connection != null) {
                    connection.Close();
                }
            }

            // ispisi iznos cijeloga racuna
            Label labelSum = new Label();
            formBill.Controls.Add(labelSum);
            labelSum.Text = "Iznos računa: ";
            labelSum.AutoSize = true;
            labelSum.Location = new Point(10, dataGridViewBill.Top + dataGridViewBill.Height + 10);
            labelSum.Text += sum.ToString() + " kn";

            // ispisi nacin placanja
            Label labelPaying = new Label();
            formBill.Controls.Add(labelPaying);
            labelPaying.Text = "Način plaćanja: ";
            if (radioButtonCard.Checked) {
                labelPaying.Text += "KARTICA\n";
                labelPaying.Text += "Broj kartice: " + cardNumber.ToString();
            } 
            else if (radioButtonCash.Checked) {
                labelPaying.Text += "GOTOVINA\n";
                labelPaying.Text += "Primljeno: " + moneyReceived.ToString() + " kn\n";
                double toReturn = Math.Round(moneyReceived - sum, 2);
                labelPaying.Text += "Za vratiti: " + toReturn + " kn"; 
            }
            labelPaying.AutoSize = true;
            labelPaying.Location = new Point(10, 10 + labelSum.Top + labelSum.Height);
        }

        private void NonAdminForm_FormClosed(object sender, FormClosedEventArgs e) {
            this.Show(); // ponovno pokazi glavnu formu
        }
    }
}
