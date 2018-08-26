using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace DataGridViewMultiColor
{
    public partial class Form1 : Form
    {
       // private DataGridView dataGridView1 = new DataGridView();
        private BindingSource bindingSource1 = new BindingSource();
        public SqlDataAdapter dataAdapter = new SqlDataAdapter();
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-4HQBJPL\\PHU;Initial Catalog=DataGirdView; Integrated Security=True");
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn.Open();
            dataGridView1.DataSource = bindingSource1;
            GetData("select * from Lop");
        }
        private void GetData(string selectCommand)
        {
            try
            {

                dataAdapter = new SqlDataAdapter(selectCommand, conn);

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                DataTable table = new DataTable();
                dataAdapter.Fill(table);
                bindingSource1.DataSource = table;
                ChangeColor(dataGridView1);

            }
            catch
            {
                MessageBox.Show("Bad connection");
            }
        }
        private void ChangeColor(DataGridView datagridview)
        {
            int _rowsInDataGrid = datagridview.Rows.Count;

            for (int i = 0; i < _rowsInDataGrid; i++)
            {
                if ((datagridview.Rows[i].Index) % 2 == 0)
                {
                    datagridview.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
                else 
                {
                    datagridview.Rows[i].DefaultCellStyle.BackColor = Color.Blue;
                }
            }
        }

    }
    
}
