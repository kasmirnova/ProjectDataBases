using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace DbApp
{
    /// <summary>
    /// Main class to Form1 view.
    /// </summary>
    public partial class Form1 : Form
    {       
        /// <summary>
        /// Data set
        /// </summary>
        private DataSet ds;

        /// <summary>
        /// Data base proxy
        /// </summary>
        private DbHeaderProxy Proxy;

        /// <summary>
        /// Initialize <see cref="Form1"/>
        /// </summary>
        /// <param name="proxy">Data base proxy</param>
        public Form1(DbHeaderProxy proxy)
        {
            InitializeComponent();
            Proxy = proxy;
        }

        /// <summary>
        /// Initialize data to Form1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            ds = Proxy.updateDataSet;
            using (var reader = new StreamReader(@"D:\University\Kate\ApplicationDb\DbApp\DbApp\db.txt", System.Text.Encoding.Default))
            {
                if (reader.ReadLine() != "")
                {
                    Read_As();
                }
                dataGridView1.DataSource = ds.Tables["Workers"];
                SizeColumn();
            }
        }

        /// <summary>
        /// Set column width
        /// </summary>
        public void SizeColumn()
        {
            for(int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].Width = Proxy.size;
            }
        }

        /// <summary>
        /// Update grid view data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void update_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = ds.Tables["Workers"];
                Read_As();
                SizeColumn();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OKCancel);
                return;
            }
        }

        /// <summary>
        /// Save data to data base and copy data to file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void save_Click(object sender, EventArgs e)
        {
            try
            {
                Proxy.adapter.Update(ds.Tables["Workers"]);
                Save_As();
            }
            catch(Exception ex)
            {
                MessageBox.Show("ID не могут быть одинаковыми.И должны быть только типа INT", ex.Message, MessageBoxButtons.OKCancel);
            }
        }

        /// <summary>
        /// Clear data base data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clear_Click(object sender, EventArgs e)
        {
            ds.Tables["Workers"].Clear();
            Proxy.adapter.Update(ds.Tables["Workers"]);
            Save_As();
        }

        /// <summary>
        /// Initialize and open option form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void option_Click(object sender, EventArgs e)
        {
            var option = new OptionForm(Proxy);
            option.Show();
        }

        /// <summary>
        /// Reaction to click save as
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveas_Click(object sender, EventArgs e)
        {
            Save_As();
        }

        /// <summary>
        /// Save data to file
        /// </summary>
        private void Save_As()
        {
            using (var writer = new StreamWriter(@"D:\University\Kate\ApplicationDb\DbApp\DbApp\db.txt"))
            {
                var columns = ds.Tables["Workers"].Columns;
                var rows = ds.Tables["Workers"].Rows;
                for (int q = 0; q < columns.Count; q++)
                {
                    writer.Write(columns[q].ColumnName + "-");
                }
                writer.WriteLine();
                for (int i = 0; i < rows.Count; i++)
                {
                    var row = rows[i];
                    for (int q = 0; q < columns.Count; q++)
                    {
                        writer.Write(row[q] + "-");
                    }
                    writer.WriteLine();
                }
            }
        }

        /// <summary>
        /// Read db from txt file
        /// </summary>
        private void Read_As()
        {
            var list = new List<string>();
            var finishLine = new List<string[]>();
            using (var reader = new StreamReader(@"D:\University\Kate\ApplicationDb\DbApp\DbApp\db.txt", System.Text.Encoding.Default))
            {
                while(!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    list.Add(line);
                    finishLine.Add(line.Split('-'));
                }
            }

            var columns = ds.Tables["Workers"].Columns;
            var rows = ds.Tables["Workers"].Rows;
            var ob = finishLine[0];
            if (finishLine[0].Length-1>columns.Count)
            {
                for(int i = finishLine[0].Length - 1 - columns.Count; i>0;i--)
                {
                    if (ob[ob.Length - 1 - i] != " ")
                    {
                            columns.Add(new DataColumn(ob[ob.Length - 1 - i]));
                    }
                }
            }
            for (int q = 0; q < columns.Count; q++)
            {
                if (ob[q] == "") continue;
                columns[q].ColumnName = ob[q];
            }

            for (int i = 0; i < rows.Count; i++)
            {
                var row = rows[i];
                var liner = i+1<finishLine.Count?finishLine[i+1]:new string[0];
                if (liner.Length == 0)
                {
                    liner = new string[columns.Count];
                    for(int l = 0; l < columns.Count; l++)
                    {
                        liner[l] = "";
                    }
                }
                for (int q = 0; q < columns.Count; q++)
                {
                    //if (liner[q] == "") continue;
                    try
                    {
                        row[q] = liner[q];
                    }
                    catch
                    {
                        if (liner[q] == "") row[q] = "1";
                        else row[q] = Convert.ToInt32(Convert.ToDouble(liner[q]));
                    }
                }
            }
        }
    }
}
