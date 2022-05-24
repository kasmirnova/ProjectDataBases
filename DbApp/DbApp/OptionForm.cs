using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace DbApp
{
    /// <summary>
    /// Main class to OptionForm view.
    /// </summary>
    public partial class OptionForm : Form
    {
        /// <summary>
        /// Data set
        /// </summary>
        private DataSet ds;

        /// <summary>
        /// Controls collection
        /// </summary>
        private List<TextBox> controls;

        /// <summary>
        /// Labels collection
        /// </summary>
        private List<Label> labels;

        /// <summary>
        /// Data base proxy
        /// </summary>
        private DbHeaderProxy Proxy;

        /// <summary>
        /// Initialize <see cref="OptionForm"/>
        /// </summary>
        /// <param name="proxy">Proxy</param>
        public OptionForm(DbHeaderProxy proxy)
        {
            InitializeComponent();
            Proxy = proxy;
        }

        /// <summary>
        /// Load data to Option Form
        /// </summary>
        private void OptionForm_Load(object sender, EventArgs e)
        {
            ds = Proxy.updateDataSet;
            constructForm();
            sizebox.Text = Convert.ToString(Proxy.size);
        }

        /// <summary>
        /// Construction OptionForm
        /// </summary>
        private void constructForm(bool clearOption = false)
        {
            if (clearOption)
            {
                Controls.Clear();
                InitializeComponent();
            }
            label1.Text = ds.Tables["Workers"].Columns[0].ColumnName;
            controls = new List<TextBox>();
            labels = new List<Label>();
            controls.Add(textbox);
            var columns = ds.Tables["Workers"].Columns;
            var columnsCount = ds.Tables["Workers"].Columns.Count;

            for(int i = 0; i < columnsCount - 1; i++)
            {
                if(i == 0)
                {
                    var textBox = new TextBox() {
                        Location = new System.Drawing.Point(textbox.Location.X + textbox.Width + 10, textbox.Location.Y),
                        Name = "textbox" + i,
                        Width = textbox.Width,
                    };
                    var label = new Label()
                    {
                        Location = new System.Drawing.Point(label1.Location.X + textbox.Width + 10, label1.Location.Y),
                        Text = columns[i+1].ColumnName,
                        Name = "label" + i,
                        Width = textbox.Width,
                    };
                    labels.Add(label);
                    controls.Add(textBox);
                    this.Controls.Add(textBox);
                    this.Controls.Add(label);

                }
                else
                {
                    var textBox = new TextBox()
                    {
                        Location = new System.Drawing.Point(controls[i].Location.X + textbox.Width + 10, controls[i].Location.Y),
                        Name = "textbox" + i,
                        Width = textbox.Width,
                    };
                    var label = new Label()
                    {
                        Location = new System.Drawing.Point(controls[i].Location.X + textbox.Width + 10, labels[i - 1].Location.Y),
                        Text = columns[i + 1].ColumnName,
                        Name = "label" + i,
                        Width = textbox.Width,
                    };
                    labels.Add(label);
                    controls.Add(textBox);
                    this.Controls.Add(textBox);
                    this.Controls.Add(label);
                }
            }

            var c = 0;
            foreach(var ob in controls)
            {
                ob.Text = columns[c].ColumnName;
                c++;
            }
        }

        /// <summary>
        /// Reaction to cancel click
        /// </summary>
        private void cancelbutton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// Reaction to Ok button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okbutton_Click(object sender, EventArgs e)
        {
            Proxy.Header.Clear();
            try
            {
                Proxy.size = Convert.ToInt32(sizebox.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Размер может быть только числом", ex.Message, MessageBoxButtons.OKCancel);
                return;
            }
            DialogResult result = DialogResult.None;
            var columns = ds.Tables["Workers"].Columns;
            for(int i = 0;i < columns.Count; i++)
            {
                Proxy.AddToList(controls[i].Text);
            }
            for (int i = 0; i < Proxy.Header.Count; i++)
            {
                for (int q = 0; q < Proxy.Header.Count; q++)
                {
                    if (Proxy.Header[i] == Proxy.Header[q] && i != q)
                    {
                        result = MessageBox.Show("Столбцы не могут быть с одинаковым именем", "Error", MessageBoxButtons.OKCancel);
                    }
                    if (result != DialogResult.None)
                    {
                        Proxy.updateHeaders = true;
                        break;
                    }
                }
                if (result != DialogResult.None)
                {
                    break;
                }
            }
            if (result != DialogResult.None)
            {
                foreach(var ob in controls)
                {
                    ob.Text = "";
                }
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// Add column to database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addcolumnbut_Click(object sender, EventArgs e)
        {
            if (Proxy.counter > 2)
            {
                MessageBox.Show("Нельзя добавить больше столбцов", "Error", MessageBoxButtons.OKCancel);
            }
            else
            {
                OleDbConnection con = new OleDbConnection("PROVIDER=SQLOLEDB;server="+Proxy.connection);
                var name = "New" + Proxy.counter;
                for(int i = 0;i< ds.Tables["Workers"].Columns.Count;i++)
                {
                    if(name == ds.Tables["Workers"].Columns[i].ColumnName)
                    {
                        name = "Example" + i;
                    }
                }
                OleDbCommand dcom = new OleDbCommand();
                dcom.Connection = con;
                dcom.CommandText = "ALTER TABLE "+name+" (pole char(10))";             
                ds.Tables["Workers"].Columns.Add(new DataColumn() {    
                    ColumnName = name,
                    DataType = System.Type.GetType("System.String"),
                    AllowDBNull = false,
                    Caption = name

                });
                constructForm();
                Proxy.counter++;
                Proxy.updateDataSet = ds;
                Proxy.updateColumns = true;
            }
        }

        /// <summary>
        /// Remove column in database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removecolumbut_Click(object sender, EventArgs e)
        {
            if (ds.Tables["Workers"].Columns.Count > 1)
            {
                var number = ds.Tables["Workers"].Columns.Count - 1;
                ds.Tables["Workers"].Columns.Remove(ds.Tables["Workers"].Columns[number]);
                this.Controls.Remove(controls[number]);
                this.Controls.Remove(labels[number - 1]);
                labels.Remove(labels[labels.Count - 1]);
                controls.Remove(controls[controls.Count - 1]);
                constructForm(true);
                Proxy.counter--;
                Proxy.updateDataSet = ds;
                Proxy.updateColumns = true;
            }
            else
            {
                MessageBox.Show("В БД не может быть меньше 1 столбика", "Error", MessageBoxButtons.OKCancel);
            }
        }
    }
}
