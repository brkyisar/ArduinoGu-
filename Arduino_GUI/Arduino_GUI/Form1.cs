using System;
using System.Data;
using System.Data.SQLite;
using System.IO.Ports;
using System.Windows.Forms;

namespace ArduinoLEDControl
{
    public partial class Form1 : Form
    {
        private SQLiteConnection sqliteConnection;
        private bool systemOn = false;
        private SerialPort serialPort;

        public Form1()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
            InitializeSerialPortComboBox();
        }

        private void InitializeDatabaseConnection()
        {
            string dbPath = "Data Source=SensorData.sqlite;Version=3;";
            sqliteConnection = new SQLiteConnection(dbPath);
            try
            {
                sqliteConnection.Open();
                ClearDatabaseTable(); // Veritabanı tablosunu temizle
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database connection error: " + ex.Message);
            }
        }

        private void ClearDatabaseTable()
        {
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand("DELETE FROM SensorData", sqliteConnection))
                {
                    cmd.ExecuteNonQuery();
                }

                using (SQLiteCommand cmd = new SQLiteCommand("UPDATE SQLITE_SEQUENCE SET SEQ=0 WHERE NAME='SensorData'", sqliteConnection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error clearing database table: " + ex.Message);
            }
        }

        private void SaveDataToDatabase(string data)
        {
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand("INSERT INTO SensorData (Timestamp, Data) VALUES (@Timestamp, @Data)", sqliteConnection))
                {
                    cmd.Parameters.AddWithValue("@Timestamp", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Data", data);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data insertion error: " + ex.Message);
            }
        }

        private void ExportDataToExcel()
        {
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM SensorData", sqliteConnection))
                {
                    SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    using (ClosedXML.Excel.XLWorkbook wb = new ClosedXML.Excel.XLWorkbook())
                    {
                        wb.Worksheets.Add(dataTable, "SensorData");
                        SaveFileDialog saveFileDialog = new SaveFileDialog
                        {
                            Filter = "Excel Files|*.xlsx",
                            Title = "Save an Excel File"
                        };
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            wb.SaveAs(saveFileDialog.FileName);
                            MessageBox.Show("Data exported successfully to Excel.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data export error: " + ex.Message);
            }
        }

        private void InitializeSerialPortComboBox()
        {
            string[] ports = SerialPort.GetPortNames();
            comboBoxSerialPorts.Items.AddRange(ports);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Do nothing on form load
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            ExportDataToExcel();
        }

        private void btnSystemOn_Click(object sender, EventArgs e)
        {
            if (comboBoxSerialPorts.SelectedItem != null)
            {
                serialPort = new SerialPort(comboBoxSerialPorts.SelectedItem.ToString(), 9600);
                serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
                try
                {
                    serialPort.Open();
                    systemOn = true;
                    txtData.AppendText(DateTime.Now.ToString() + "        System On" + Environment.NewLine);
                    serialPort.WriteLine("System On");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error opening serial port: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a COM port first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSystemOff_Click(object sender, EventArgs e)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                systemOn = false;
                txtData.AppendText(DateTime.Now.ToString() + "        System Off" + Environment.NewLine);
                serialPort.WriteLine("System Off");
                serialPort.Close();
            }
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (systemOn)
            {
                string data = serialPort.ReadLine().Trim();
                this.Invoke(new MethodInvoker(delegate
                {
                    txtData.AppendText(DateTime.Now.ToString() + "        " + data + Environment.NewLine);
                    SaveDataToDatabase(data);
                }));
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.Close();
            }

            if (sqliteConnection != null && sqliteConnection.State == ConnectionState.Open)
            {
                sqliteConnection.Close();
            }
        }
    }
}
