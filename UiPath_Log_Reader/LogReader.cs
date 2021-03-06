using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;


namespace LogReader
{
    public partial class LogReader : Form
    {
        String strLn, strActivityInfo,strFilePath;
        Int32 ColCnt = -1, RowCnt = -1;
        JavaScriptSerializer js = new JavaScriptSerializer();
        String JobID;
        DataTable LogTable = new DataTable("LogTable"), dtFilteredLogTable = new DataTable("dtFilteredLogTable");
        List<String> ProcessList = new List<string>(), PListTime = new List<string>();

        OpenFileDialog ofd = new OpenFileDialog();

        public LogReader(){InitializeComponent();}

        public LogReader(string FilePath)
        {
            InitializeComponent();
            MainSeq(FilePath);
            this.FileList.Items.Add(Path.GetFileName(FilePath));
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < CheckedListBox1.Items.Count; i++) { CheckedListBox1.SetItemChecked(i, true); }
            String[] FileList = Directory.GetFiles((Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).ToString().Replace(@"\Roaming", @"") + @"\Local\UiPath\Logs\","*Execution*.log");
            foreach (String FL in FileList.Reverse()) { this.FileList.Items.Add(Path.GetFileName(FL)); }
        }

        public void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String FilePath = (Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).ToString().Replace(@"\Roaming", @"") + @"\Local\UiPath\Logs\" + FileList.Text;
            MainSeq(FilePath);
        }

        public void MainSeq(String FilePath)
        {
            strFilePath = FilePath;
            try
            {
            LogTable.Dispose();
            LogTable = new DataTable("LogTable");
            if (!LogTable.Columns.Contains("ActivityInfo"))
            { LogTable.Columns.Add("ActivityInfo"); }
            if (!LogTable.Columns.Contains("Row#"))
            { LogTable.Columns.Add("Row#"); }

                RowCnt = -1;
                String strTxt = System.IO.File.ReadAllText(FilePath, Encoding.UTF8);
                String[] ArrayStr = strTxt.Split(Environment.NewLine.ToCharArray());

                foreach (String Ln in ArrayStr)
                {
                    try
                    {
                        if (!String.IsNullOrEmpty(Ln))
                        {
                            RowCnt = ++RowCnt;
                            LogTable.Rows.Add();
                            if (Ln.Contains("activityInfo"))
                            {
                                strActivityInfo = Ln.Remove(0, Ln.IndexOf("activityInfo") + 14);
                                strActivityInfo = strActivityInfo.Split("}".ToCharArray())[0]+ "}";
                            }
                                strLn = Ln.Remove(0, Ln.ToString().IndexOf("{")-1).Trim() ;

                            if (strLn.Substring(0, 2) == "{m")
                            { strLn = strLn.Insert(1, ((char)34).ToString()); }
                            js.MaxJsonLength = 2147483647;
                            dynamic LogInfo = js.Deserialize<dynamic>(strLn);
                                foreach (var keyValPair in LogInfo)
                                {
                                    if (!String.IsNullOrEmpty(keyValPair.Value.ToString()))
                                    {
                                        if (!LogTable.Columns.Contains(keyValPair.Key)){ LogTable.Columns.Add(CultureInfo.InvariantCulture.TextInfo.ToTitleCase(keyValPair.Key.ToLower()) );}
                                        ColCnt = ++ColCnt;
                                            if (keyValPair.Key == "activityInfo")
                                            { LogTable.Rows[RowCnt][keyValPair.Key.ToString()] = strActivityInfo; }
                                            else
                                            { LogTable.Rows[RowCnt][keyValPair.Key.ToString()] = keyValPair.Value.ToString(); }
                                        LogTable.Rows[RowCnt]["Row#"] = RowCnt + 1;
                                    }
                                }
                        }
                    }   
                    catch (Exception ex)
                    {
                        Console.WriteLine(strLn);
                        Console.WriteLine(Ln);
                        MessageBox.Show("Invalid Log file>>" + ex.Message.ToString());
                        return;
                    }
                }

                if (LogTable.Columns.Contains("agentSessionId"))
                { LogTable.Columns.Remove("agentSessionId"); }
                if (LogTable.Columns.Contains("Fingerprint"))
                { LogTable.Columns.Remove("Fingerprint"); }
                if (LogTable.Columns.Contains("LogType"))
                { LogTable.Columns.Remove("LogType"); }
                LogTable.Columns["Row#"].SetOrdinal(0);
                LogTable.Columns["level"].SetOrdinal(1);
                LogTable.Columns["FileName"].SetOrdinal(4);
                LogTable.Columns["ActivityInfo"].SetOrdinal(6);

                //format datetime column
                foreach (DataRow rw in LogTable.Rows){ rw["TimeStamp"] = rw["TimeStamp"].ToString().Split((Char)46)[0]; }

                foreach (var column in LogTable.Columns.Cast<DataColumn>().ToArray())
                {
                    if (LogTable.AsEnumerable().All(dr => dr.IsNull(column)))
                    { LogTable.Columns.Remove(column);}
                }

                strTxt = String.Empty;
                dtFilteredLogTable = LogTable;
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dtFilteredLogTable;
                RecordCount_Refresh();
                PList();
                dataGridView1.Select();

            }
                catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Refresh2_Click(object sender, EventArgs e)
        {
            MainSeq(strFilePath);

            //if (LogTable.Rows.Count > 0)
            //{
            //    dtFilteredLogTable = null;
            //    dtFilteredLogTable = (from row in LogTable.AsEnumerable().OrderBy(r => r.Field<String>("timestamp")) select row).CopyToDataTable();
            //    if (dtFilteredLogTable.Columns.Contains("ActivityInfo"))
            //    {
            //        dtFilteredLogTable.Columns["ActivityInfo"].SetOrdinal(6);
            //    }

            //    dataGridView1.DataSource = null;
            //    dataGridView1.DataSource = dtFilteredLogTable;
            //    PList();
            //    dataGridView1.Select();
            //    RecordCount_Refresh();
            //}
        }

        private void RecordCount_Refresh()
        {
            RowCount.Text = "Showing " + ((DataTable)dataGridView1.DataSource).Rows.Count.ToString() + "/" + LogTable.Rows.Count.ToString() ;
            statusStrip1.Refresh();     
        }

        private void SearchButton(object sender, EventArgs e)
        {
            if (MessageFilterValue.Text.Length > 0)
            {
                if (dtFilteredLogTable.Select("Message Like '%" + System.Text.RegularExpressions.Regex.Replace(MessageFilterValue.Text, @"[\$']", @"*") + @"%'").Count() > 0)
                {
                    
                    dataGridView1.DataSource = dtFilteredLogTable.Select("Message Like '%" + System.Text.RegularExpressions.Regex.Replace(MessageFilterValue.Text, @"[\$']", @"*") + "%'").CopyToDataTable(); 
                }
                else { MessageBox.Show("No data row contains keyword:" + MessageFilterValue.Text + Environment.NewLine + "Please try different keyword."); this.ActiveControl = MessageFilterValue;  MessageFilterValue.SelectionStart = 0; MessageFilterValue.SelectionLength = MessageFilterValue.Text.Length; return; }
            }
            else
            { dataGridView1.DataSource = dtFilteredLogTable; }
            dataGridView1.Select();
            RecordCount_Refresh();
        }

        private void Goto_Click(object sender, EventArgs e)
        {
            if (GotoVal.Text == "" || GotoVal.Text is null) { return; }

            var GotoRow = (Convert.ToInt32(GotoVal.Text.ToString())-1).ToString();
            if (Convert.ToInt32(GotoRow) > LogTable.Rows.Count) { MessageBox.Show("Entered row index is out of range." + Environment.NewLine + "Kindly select row index from 1 to " + LogTable.Rows.Count);return; }

            dataGridView1.ClearSelection();

            if (GotoVal.Text.ToString().All(char.IsDigit) && GotoVal.Text.Length > 0)
            {
                dtFilteredLogTable = LogTable.Copy();
                dataGridView1.DataSource = dtFilteredLogTable;
                dataGridView1.Rows[Convert.ToInt32(GotoRow)].Selected = true;
                dataGridView1.FirstDisplayedScrollingRowIndex = Convert.ToInt32(GotoRow);
                dataGridView1.Focus();
                RecordCount_Refresh();
            }
            else
            {
                MessageBox.Show("Enter valid number only");
            }
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            GotoVal.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            Goto_Click(this, new EventArgs());
        }

        private void ProcessTimeStamp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PListDropDown.Text != "" | ProcessTimeStamp.Text != "")
            {
                FilterByProcess_Click(this, new EventArgs());
                RecordCount_Refresh();
            }
        }

        private void MessageValueFilter_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs k) { if (k.KeyChar == (Char)13) { SearchButton(this, new EventArgs()); } }

        private void CopyHeader_CheckedChanged(object sender, EventArgs e)
        {
            if (CopyHeader.Checked)
            { this.dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText; }
            else
            { this.dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText; }

        }

        private void CheckedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<String> lst = new List<string>();
            //for (int i = 0; i < CheckedListBox1.Items.Count; i++)
            //{CheckedListBox1.SetItemChecked(i, true); }
            foreach (String item in CheckedListBox1.CheckedItems){ lst.Add(item.ToString()); }
            if ((from rw in dtFilteredLogTable.AsEnumerable() where lst.Any(val=> rw["Level"].ToString().ToLower().Trim() == val.ToLower().Trim()) select rw).Count() > 0)
            { dataGridView1.DataSource = (from rw in dtFilteredLogTable.AsEnumerable() where lst.Contains(rw["Level"].ToString()) select rw).CopyToDataTable(); }
            else
            { dataGridView1.DataSource = dtFilteredLogTable.Clone(); }
            RecordCount_Refresh();
        }

        private void GotoVal_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs k) { if (k.KeyChar == (Char)13) { Goto_Click(this, new EventArgs()); } }

        private void CopyToClipboad(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            if (e.Control && e.KeyCode == Keys.C)
            {
                if (this.dataGridView1.GetCellCount(DataGridViewElementStates.Selected) > 0)
                { 
                    Clipboard.SetDataObject(this.dataGridView1.GetClipboardContent(),true);
                }
            }
        }

        private void Browse_Click(object sender, EventArgs e)
        {
            ofd.Filter = "LOG|*.log";
            if (ofd.ShowDialog() == DialogResult.OK){MainSeq(ofd.FileName);}
        }

        private void FilterByProcess_Click(object sender, EventArgs e)
        {
            try
            {

                //if (CheckedListBox1.GetItemCheckState(1) == CheckState.Unchecked) { throw new Exception("Must include Information logs to filter the table by processes."); }

                if (PListDropDown.Text != "" && ProcessTimeStamp.Text != "")
                {
                    JobID = LogTable.Select("Message Like '" + PListDropDown.Text + "%' and TimeStamp = '" + ProcessTimeStamp.Text + "'")[0]["jobID"].ToString();
                    dataGridView1.DataSource = null;
                    dtFilteredLogTable = LogTable.Select("jobId ='" + JobID + "'").CopyToDataTable();
                    dataGridView1.DataSource = dtFilteredLogTable;
                    dataGridView1.Select();
                    RecordCount_Refresh();
                    for (int i = 0; i < CheckedListBox1.Items.Count; i++)
                    { CheckedListBox1.SetItemChecked(i, true); }
                }

            }
            catch(Exception ex) { MessageBox.Show(ex.Message); dataGridView1.DataSource = LogTable; return; }
        }

        public void PList()
        {
            try
            {
                ProcessList.Clear();
                PListDropDown.DataSource = null;
                LogTable.CaseSensitive = true;
                DataTable dt = new DataTable();
                dt = LogTable.DefaultView.ToTable(true, "ProcessName");
                foreach (DataRow rw in dt.Rows){ if (!ProcessList.Contains(rw["ProcessName"])) { ProcessList.Add(rw["ProcessName"].ToString()); } }
                LogTable.CaseSensitive = false;
                PListDropDown.DataSource = ProcessList;
            }
            catch (Exception ex) { MessageBox.Show("Selected log file is incomplete:" + ex.Message.ToString()); }
        }

        private void PListDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            PListTime.Clear();
            ProcessTimeStamp.DataSource = null;
            LogTable.CaseSensitive = true;
            foreach (DataRow rw in LogTable.Select("message = '" + PListDropDown.SelectedValue + " execution started'"))
            {
                if (!PListTime.Contains(rw["TimeStamp"])){PListTime.Add(rw["TimeStamp"].ToString());}
            }
            LogTable.CaseSensitive = false;
            ProcessTimeStamp.DataSource = PListTime.AsEnumerable().Reverse().ToList();
        }
    }
}
