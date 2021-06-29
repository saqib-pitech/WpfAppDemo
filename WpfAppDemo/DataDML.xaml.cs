using DBLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfAppDemo
{
    /// <summary>
    /// Interaction logic for DataDML.xaml
    /// </summary>
    public partial class DataDML : Window
    {
        private EmpDataStore empDataStore = new EmpDataStore(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString);
        public DataDML()
        {
            InitializeComponent();
        }

        private void EmpDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            //SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString);
            //string sql = "SELECT * FROM EMP";
            //SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            //DataSet ds = new DataSet();
            //adapter.Fill(ds, "emp");

            //EmpDataGrid.DataContext = ds.Tables["emp"];
            EmpDataGrid.DataContext = empDataStore.GetEmps();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Emp emp = new Emp();
            emp.EmpNo = int.Parse(txtEmpNo.Text);
            emp.EmpName = txtEmpName.Text;
            emp.HireDate = Convert.ToDateTime(txtHiredate.Text);
            emp.Salary = decimal.Parse(txtSalary.Text);
            empDataStore.InsertEmp(emp);
            EmpDataGrid.DataContext = empDataStore.GetEmps();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            int eno = int.Parse(txtEmpNo.Text);
            try
            {
                Emp emp = empDataStore.GetEmp(eno);
                txtEmpName.Text = emp.EmpName;
                txtHiredate.Text = emp.HireDate.ToString();
                txtSalary.Text = emp.Salary.ToString();
            }
            catch(Exception)
            {
                Reset();
                MessageBox.Show("Emp No Doesn't Exist");
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Emp emp = new Emp();
            emp.EmpNo       = int.Parse(txtEmpNo.Text);
            emp.EmpName     = txtEmpName.Text;
            emp.HireDate    = Convert.ToDateTime(txtHiredate.Text);
            emp.Salary      = decimal.Parse(txtSalary.Text);
            empDataStore.UpdateEmp(emp);
            EmpDataGrid.DataContext = empDataStore.GetEmps();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            int eno = int.Parse(txtEmpNo.Text);
            empDataStore.DeleteEmp(eno);
            EmpDataGrid.DataContext = empDataStore.GetEmps();
        }

        private void Reset()
        {
            txtEmpNo.Clear();
            txtEmpName.Text = "";
            txtHiredate.Text = "";
            txtSalary.Text = "";
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
