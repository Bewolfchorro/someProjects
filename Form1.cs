using System;
using System.Collections;
using System.Data;
using System.Net.NetworkInformation;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using Symbol.RFID3;
using static Symbol.RFID3.Events;
using Newtonsoft.Json;
using System.Data.SqlClient;
using static Receber_tags_tabela_01.configJSON;
using System.Diagnostics.Eventing.Reader;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace Receber_tags_tabela_01
{
    public partial class Form1 : Form
    {
        internal ConnectForm connectionForm;
        private string jsonPath = @".\config_DB_JSON.json";
        //private ReaderManagement _ReaderManagement;
        private bool _IsConnecting = false;
        private bool _ISConnected = false;
        public RFIDReader _RFIDReaderAPI;
        private bool _IsReading = false;

        //--Tag Count--//
        private int readCount = 0;
        private int tagCount = 0;

        private STATUS_EVENT_TYPE _RFIDEventStatus;
        //private Thread _ThreadDeviceStatusChecking;

        //--Event Status--//
        private delegate void _UpdateStatus(Events.StatusEventData e);
        private delegate void _UpdateReader(Events.ReadEventData e);
        private _UpdateReader _UpdateReaderHandler;
        private Hashtable _TagTable;

        private TriggerInfo _TriggerInfo;
        private TagStorageSettings _TagStorageSettings;
        //private bool _IsDetectedTag;
        //private bool _IsTrigger;

        public bool IsReading { get; private set; }
        public int RSSIValueSet { get; set; }
        public bool RSSIEnable { get; set; }

        internal class TagModel
        {
            public string EPCCode { get; set; }
            public string AntennaID { get; set; }
            public string TIDCode { get; set; }
            public sbyte RSSIValue { get; set; }
        }

        public Form1()
        {
            InitializeComponent(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LerConfiguracoes(jsonPath);
            read_button.Enabled = false;
            clearDB_button.Enabled = false;
            optionsEnabled();
        }

        public Rootobject LerConfiguracoes(string filePath)
        {
            string fileName = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<Rootobject>(fileName);
        }

        private void optionsEnabled()
        {
            if (_ISConnected)
            {
                connectionToolStripMenuItem.Enabled = false;
                disconnectToolStripMenuItem.Enabled = true;
            }
            else if (_ISConnected == false)
            {
                connectionToolStripMenuItem.Enabled = true;
                disconnectToolStripMenuItem.Enabled = false;
            }
        }

        public bool Connect()
        {
            if (!_IsConnecting)
            {
                try
                {
                    _IsConnecting = true;
                    read_button.Enabled = true;
                    clearDB_button.Enabled = true;

                    _RFIDReaderAPI = new RFIDReader(connectionForm.IpText, uint.Parse(connectionForm.PortText), 0);

                    if (_RFIDReaderAPI != null)
                    {
                        _RFIDReaderAPI.Connect();
                        if (!_RFIDReaderAPI.IsConnected)
                        {
                            IsReading = false;
                            return false;
                        }

                        _RFIDReaderAPI.Events.ReadNotify += new Events.ReadNotifyHandler(Events_ReadNotify);
                        _RFIDReaderAPI.Events.AttachTagDataWithReadEvent = false;
                        _RFIDReaderAPI.Events.StatusNotify += new Events.StatusNotifyHandler(Events_StatusNotify);
                        _RFIDReaderAPI.Events.ReadNotify += Events_ReadNotify;
                        _RFIDReaderAPI.Events.AttachTagDataWithReadEvent = false;
                        _RFIDReaderAPI.Events.NotifyReaderDisconnectEvent = true;
                        _RFIDReaderAPI.Events.NotifyGPIEvent = true;
                        _RFIDReaderAPI.Events.NotifyBufferFullEvent = true;
                        _RFIDReaderAPI.Events.NotifyBufferFullWarningEvent = true;
                        _RFIDReaderAPI.Events.NotifyReaderDisconnectEvent = true;
                        _RFIDReaderAPI.Events.NotifyReaderExceptionEvent = true;
                        _RFIDReaderAPI.Events.NotifyAccessStartEvent = true;
                        _RFIDReaderAPI.Events.NotifyAccessStopEvent = true;
                        _RFIDReaderAPI.Events.NotifyInventoryStartEvent = true;
                        _RFIDReaderAPI.Events.NotifyInventoryStopEvent = true;
                        _RFIDReaderAPI.Events.NotifyAntennaEvent = true;

                        _ISConnected = true;

                        optionsEnabled();

                        return _RFIDReaderAPI.IsConnected;


                    }
                    return false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("CONNECTION ERROR: " + ex.Message);
                    read_button.Enabled = false;
                    clearDB_button.Enabled = false;
                    return false;
                    
                }
                finally
                {
                    _IsConnecting = false;
                }
            }
            return false;
        }

        public bool Disconnect()
        {
            if (_RFIDReaderAPI == null) return true;
            try
            {
                if (_RFIDReaderAPI.Actions.TagAccess.OperationSequence.Length > 0)
                {
                    _RFIDReaderAPI.Actions.TagAccess.OperationSequence.StopSequence();
                }
                else
                {
                    _RFIDReaderAPI.Actions.Inventory.Stop();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("DISCONNECTION ERRORS: " + ex.Message);
            }
            try
            {
                _RFIDReaderAPI.Disconnect();
                bool temp = _RFIDReaderAPI.IsConnected;
                _RFIDReaderAPI = null;
                read_button.Enabled = false;
                read_button.Text = "Start Reading";
                clearDB_button.Enabled = true;
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine("DISCONNECTION ERRORS: " + ex.Message);
                return false;
            }
            finally
            {
                _ISConnected = false;
                optionsEnabled();
            }
        }

        private void Events_ReadNotify(object sender, Events.ReadEventArgs e)
        {
            _UpdateReaderHandler.Invoke(e.ReadEventData);
        }

        public void Events_StatusNotify(object sender, Events.StatusEventArgs statusEventArgs)
        {
            try
            {
                _RFIDEventStatus = statusEventArgs.StatusEventData.StatusEventType;
                switch (_RFIDEventStatus)
                {
                    case STATUS_EVENT_TYPE.INVENTORY_START_EVENT:
                        UpdateRichTextBox("Inventory Start Event");
                        break;
                    case STATUS_EVENT_TYPE.INVENTORY_STOP_EVENT:
                        UpdateRichTextBox("Inventory Stop Event");
                        break;
                    case STATUS_EVENT_TYPE.ACCESS_START_EVENT:
                        UpdateRichTextBox("Access Start Event");
                        break;
                    case STATUS_EVENT_TYPE.ACCESS_STOP_EVENT:
                        UpdateRichTextBox("Access Stop Event");
                        break;
                    case STATUS_EVENT_TYPE.BUFFER_FULL_WARNING_EVENT:
                        UpdateRichTextBox("Buffer Full Warning Event");
                        break;
                    case STATUS_EVENT_TYPE.BUFFER_FULL_EVENT:
                        UpdateRichTextBox("Buffer Full Event");
                        break;
                    case STATUS_EVENT_TYPE.DISCONNECTION_EVENT:
                        UpdateRichTextBox("Disconnection Event");
                        break;
                    case STATUS_EVENT_TYPE.READER_EXCEPTION_EVENT:
                        UpdateRichTextBox("Reader Exception Event");
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("STATUS NOTIFY ERRORS: " + ex.Message);
            }

        }


        private void UpdateRichTextBox(string message)
        {
            if (textBox1.InvokeRequired)
            {
                textBox1.BeginInvoke(new Action(() => { textBox1.Text = message; }));
            }
            else
            {
                textBox1.Text = message;
            }
        }

        public bool StartReadding()
        {
            _IsReading = false;
            try
            {
                if (_RFIDReaderAPI != null && _RFIDReaderAPI.IsConnected)
                {
                    //Setting Memorybank
                    if (_RFIDReaderAPI.Actions.TagAccess.OperationSequence.Length <= 0)
                    {
                        _RFIDReaderAPI.Actions.TagAccess.OperationSequence.DeleteAll();
                        var operation = new TagAccess.Sequence.Operation
                        {
                            AccessOperationCode = ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ
                        };
                        operation.ReadAccessParams.MemoryBank = MEMORY_BANK.MEMORY_BANK_TID;
                        _RFIDReaderAPI.Actions.TagAccess.OperationSequence.Add(operation);
                    }
                    //
                    //Start operation
                    if (_RFIDReaderAPI.Actions.TagAccess.OperationSequence.Length > 0)
                    {
                        _RFIDReaderAPI.Actions.PurgeTags();
                        _RFIDReaderAPI.Actions.TagAccess.OperationSequence.PerformSequence(new AccessFilter(), _TriggerInfo, new AntennaInfo());
                        IsReading = true;
                        //_IsTrigger = false;//MinhChau.Nguyen: Reset trigger params
                        Console.WriteLine("Start Read: " + IsReading);

                        return true;


                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Start Readding Fail: " + ex.Message);
                return false;
            }
        }

        private void ActionRead(Events.ReadEventData e)
        {

            //_IsDetectedTag = true;
            var tagData = _RFIDReaderAPI.Actions.GetReadTags(1);
            if (tagData != null)
            {
                for (int i = 0; i < tagData.Length; i++)
                {
                    if (tagData[i].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_NONE ||
                       (tagData[i].OpCode == ACCESS_OPERATION_CODE.ACCESS_OPERATION_READ &&
                        tagData[i].OpStatus == ACCESS_OPERATION_STATUS.ACCESS_SUCCESS))
                    {
                        var tag = tagData[i];
                        var tagID = tag.TagID;
                        var keyTag = tagID;
                        var isFound = false;

                        Console.WriteLine("===> " + tag.MemoryBankData.ToString() + "+_TagTable: " + _TagTable.Count);
                        lock (_TagTable.SyncRoot) // lock sync access to hashtable
                        {
                            keyTag = tag.TagID + tag.MemoryBankData.ToString();
                            isFound = _TagTable.ContainsKey(keyTag);
                        }

                        if (isFound)
                        {

                            var item = new TagModel
                            {
                                EPCCode = tagID,
                                AntennaID = tag.AntennaID.ToString(),
                                TIDCode = tag.MemoryBankData.ToString(),
                                RSSIValue = tag.PeakRSSI,
                            };
                            if (RSSIEnable && tag.PeakRSSI >= RSSIValueSet)
                            {
                                lock (_TagTable.SyncRoot)
                                {
                                    _TagTable.Remove(keyTag);
                                    _TagTable.Add(keyTag, item);
                                }
                            }
                            else if (!RSSIEnable)
                            {
                                lock (_TagTable.SyncRoot)
                                {
                                    _TagTable.Remove(keyTag);
                                    _TagTable.Add(keyTag, item);
                                }
                            }
                        }
                        else
                        {
                            var item = new TagModel
                            {
                                EPCCode = tagID,
                                AntennaID = tag.AntennaID.ToString(),
                                TIDCode = tag.MemoryBankData.ToString(),
                                RSSIValue = tag.PeakRSSI,
                            };
                            if (RSSIEnable && tag.PeakRSSI >= RSSIValueSet)
                            {
                                lock (_TagTable.SyncRoot)
                                {
                                    _TagTable.Add(keyTag, item);
                                }
                                new Thread(() => ProccessReceivedMessage(item)).Start();
                            }
                            else if (!RSSIEnable)
                            {
                                lock (_TagTable.SyncRoot)
                                {
                                    _TagTable.Add(keyTag, item);
                                }
                                new Thread(() => ProccessReceivedMessage(item)).Start();
                            }
                        }
                    }
                }
            }
        }

        private void ProccessReceivedMessage(TagModel item)
        {
          Console.WriteLine("EPC: " + item.EPCCode + "\n" + "Antenna: " + item.AntennaID + "\n" + "TID: " + item.TIDCode + "\n" + "RSSI: " + item.RSSIValue);
          SendToDB();
          UpdateDataGridView();
        }

        public bool StopReadding()
        {
            _IsReading = true;
            try
            {
                if (_RFIDReaderAPI != null && _RFIDReaderAPI.IsConnected)
                {
                    if (_RFIDReaderAPI.Actions.TagAccess.OperationSequence.Length > 0)
                    {
                        _RFIDReaderAPI.Actions.TagAccess.OperationSequence.StopSequence();


                        Console.WriteLine("Stop Read: " + !IsReading);

                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {

                Console.WriteLine("Stop Readding Fail: " + ex.Message);

                return false;
            }
        }

        private void SendToDB()
        {
            var dbconfig = LerConfiguracoes(jsonPath);
            try
            {
                Hashtable tagTableCopy;

                lock (_TagTable.SyncRoot)
                {
                    tagTableCopy = new Hashtable(_TagTable);
                    _TagTable.Clear(); // Limpa a Hashtable original
                }

                using (SqlConnection conn = new SqlConnection($"Data Source={dbconfig.dataSource};Initial Catalog={dbconfig.DBname};User Id={dbconfig.userID};Password={dbconfig.password}"))
                {
                    conn.Open();

                    foreach (DictionaryEntry item in tagTableCopy)
                    {
                        TagModel tag = (TagModel)item.Value;

                        // Verificar se o EPC_Id já existe na base de dados
                        bool epcExists = false;
                        using (SqlCommand checkCmd = new SqlCommand($"SELECT COUNT(*) FROM {dbconfig.tableNames.table1} WHERE EPC_Id = @EPC", conn))
                        {
                            checkCmd.Parameters.AddWithValue("@EPC", tag.EPCCode);
                            epcExists = (int)checkCmd.ExecuteScalar() > 0;
                            readCount++;
                            updateTagCountLabel();
                        }

                        if (!epcExists)
                        {
                            // O EPC_Id não existe, então inserir novo registro
                            using (SqlCommand insertCmd = new SqlCommand($"INSERT INTO {dbconfig.tableNames.table1} (EPC_Id, Atenna_ID, T_ID, RSSI) VALUES (@EPC, @Antenna, @TID, @RSSI)", conn))
                            {
                                insertCmd.Parameters.Add("@EPC", SqlDbType.VarChar).Value = tag.EPCCode;
                                insertCmd.Parameters.Add("@Antenna", SqlDbType.VarChar).Value = tag.AntennaID;
                                insertCmd.Parameters.Add("@TID", SqlDbType.VarChar).Value = tag.TIDCode;
                                insertCmd.Parameters.Add("@RSSI", SqlDbType.Int).Value = tag.RSSIValue;
                                insertCmd.ExecuteNonQuery();
                                tagCount++;
                                updateTagCountLabel();
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Registro com EPC_Id {tag.EPCCode} já existe na base de dados.");
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SendToDB ERROR: " + ex.Message);
            }
        }

        private void updateTagCountLabel()
        {
            readCountLabel.Invoke((MethodInvoker)delegate
            {
                readCountLabel.Text = $"Nº of readings: {readCount}";
                tagCountLabel.Text = $"Nº of tags: {tagCount}";
            });
        }

        private void limparDB()
        {
            var dbconfig = LerConfiguracoes(jsonPath);
            try
            {
                using (SqlConnection conn = new SqlConnection($"Data Source={dbconfig.dataSource};Initial Catalog={dbconfig.DBname};User Id={dbconfig.userID};Password={dbconfig.password}"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand($"DELETE FROM {dbconfig.tableNames.table1}", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void UpdateDataGridView()
        {
            try
            {
                var dbconfig = LerConfiguracoes(jsonPath);
                using (SqlConnection conn = new SqlConnection($"Data Source={dbconfig.dataSource};Initial Catalog={dbconfig.DBname};User Id={dbconfig.userID};Password={dbconfig.password}"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand($"SELECT * FROM {dbconfig.tableNames.table1}", conn))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(dr);
                            dataGridView1.Invoke((MethodInvoker)delegate {
                                dataGridView1.DataSource = dt;
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void read_button_Click(object sender, EventArgs e)
        {
            if (read_button.Text == "Start Reading")
            {
                _UpdateReaderHandler = new _UpdateReader(ActionRead);
                _TagTable = new Hashtable();
                StartReadding();
                read_button.Text = "Stop Reading";
                //---color---//
                pictureBox1.BackColor = System.Drawing.Color.Green;
            }
            else if (read_button.Text == "Stop Reading")
            {
                StopReadding();
                read_button.Text = "Start Reading";
                //---color---//
                pictureBox1.BackColor = System.Drawing.Color.Red;
            }
            else if (!_RFIDReaderAPI.IsConnected)
            {
                Console.WriteLine("Please connect to the reader first!");
            }
        }


        private void connectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            connectionForm = new ConnectForm(this);
            connectionForm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Disconnect();
            limparDB();
            Form1.ActiveForm.Close();
        }

        private void clearDB_button_Click(object sender, EventArgs e)
        {
           limparDB();
            UpdateDataGridView();
            readCount = 0;
            tagCount = 0;
            updateTagCountLabel();
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Disconnect();
        }
    }
}
