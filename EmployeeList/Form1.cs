using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void employeeBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.employeeBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.employeeDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'employeeDataSet.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.employeeDataSet.Employee);

        }

        private void detailViewButton_Click(object sender, EventArgs e)
        {
            // Show the Form2 Dialog here which contains the 
            DetailsForm detailsForm = new DetailsForm();
            detailsForm.ShowDialog();

            // Refresh Data Grid
            this.employeeTableAdapter.Fill(this.employeeDataSet.Employee);
        }

        private void sortAscButton_Click(object sender, EventArgs e)
        {
            this.employeeTableAdapter.FillByHourlyRateAscending(this.employeeDataSet.Employee);
        }

        private void sortDescButton_Click(object sender, EventArgs e)
        {
            this.employeeTableAdapter.FillByHourlyRateDescending(this.employeeDataSet.Employee);
        }

        private void minPayRateButton_Click(object sender, EventArgs e)
        {
            decimal? minHourlyPayRate = this.employeeTableAdapter.MinimumHourlyRate();
            MessageBox.Show($"Minimum Hourly Pay Rate: {minHourlyPayRate}");
        }

        private void maxPayRateButton_Click(object sender, EventArgs e)
        {
            //COULD NOT CREATE DUE TO CONSTANT CRASH
            //decimal? maxHourlyPayRate = this.employeeTableAdapter.MaximumHourlyRate();
            //MessageBox.Show($"Maximum Hourly Pay Rate: {maxHourlyPayRate}");
        }
    }
}
