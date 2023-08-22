using Entities;
using Entities.DataContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using uReclutmentWinForm.Control;
using Zuby.ADGV;

namespace uReclutmentWinForm.views
{
    public partial class Files : Form
    {
        public Files()
        {
            InitializeComponent();            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public async Task<bool> InitialTable()
        {
            string error = string.Empty;
            DataTable dataGet = await ApiControl<Entities.DataContext.Files>.GetDataTable(Program.BaseUrl + "Files/GetAllFiles");

            //first we create the first table of active and then we will sort that table of ids 
            DataTable dtActive= new DataTable();
            dtActive = dataGet.Clone();
            dtActive.Clear();
            DataTable dtNOActive = new DataTable();
            dtNOActive = dataGet.Clone();
            dtNOActive.Clear();
            foreach (DataRow dr in dataGet.Rows)
            {
                if ((bool)dr[3])
                    dtActive.ImportRow(dr);
                else
                    dtNOActive.ImportRow(dr);
            }
            dtActive.DefaultView.Sort = "FilesId desc";
            dtNOActive.DefaultView.Sort = "FilesId desc";

            dtActive.Merge(dtNOActive);
            
            DataTable.DataSource = dtActive;
            DataTable.Sort(DataTable.Columns[6], ListSortDirection.Descending);
            DataTable.ClearSelection();
      
            return true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void DataTable_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {            
        }

        private void DataTable_SelectionChanged(object sender, EventArgs e)
        {
            if (DataTable.SelectedRows.Count > 0)
            {
                string path = (string)DataTable.SelectedRows[0].Cells[4].Value;

                
            }
            
        }

    

        private void DataTable_SortStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.SortEventArgs e)
        {
            if (e.SortString.Length == 0)
            {
                return;
            }
            string[] strtok = e.SortString.Split(',');
            foreach (string str in strtok)
            {
                string[] columnorder = str.Split(']');
                ListSortDirection lds = ListSortDirection.Ascending;
                if (columnorder[1].Trim().Equals("DESC"))
                {
                    lds = ListSortDirection.Descending;
                }
                DataTable.Sort(DataTable.Columns[columnorder[0].Replace('[', ' ').Trim()], lds);
            }
        }        
    }
}
