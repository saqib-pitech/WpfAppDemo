using System;
using System.Collections.Generic;
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
    /// Interaction logic for LINQDemo.xaml
    /// </summary>
    public partial class LINQDemo : Window
    {
        List<Employee> empList;
        public LINQDemo()
        {
            InitializeComponent();
        }

        private void MainGrid_Loaded(object sender, RoutedEventArgs e)
        {
            empList = new List<Employee>();
            empList.Add(new Employee() { EmpNo = 101, EmpName = "Ross", Address = "New York", Dept = "mgr", Salary = 10000 });

            empList.Add(new Employee() { EmpNo = 101, EmpName = "bhavana", Address = "mumbai", Dept = "hr", Salary = 15000 });
            empList.Add(new Employee() { EmpNo = 102, EmpName = "amit", Address = "mumbai", Dept = "sales", Salary = 25000 });
            empList.Add(new Employee() { EmpNo = 103, EmpName = "vishal", Address = "pune", Dept = "sales", Salary = 20000 });
            empList.Add(new Employee() { EmpNo = 104, EmpName = "priya", Address = "mumbai", Dept = "hr", Salary = 30000 });
            empList.Add(new Employee() { EmpNo = 105, EmpName = "asha", Address = "mumbai", Dept = "sales", Salary = 30000 });
            empList.Add(new Employee() { EmpNo = 106, EmpName = "pankaj", Address = "pune", Dept = "hr", Salary = 35000 });
            empList.Add(new Employee() { EmpNo = 107, EmpName = "anil", Address = "mumbai", Dept = "sales", Salary = 18000 });
            empList.Add(new Employee() { EmpNo = 108, EmpName = "preeti", Address = "pune", Dept = "hr", Salary = 25000 });
        }

        private static bool FilterByAddress(Employee employee)
        {
            if (employee.Address == "mumbai")
                return true;
            return false;
        }
        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            
            richTextBox1.Document.Blocks.Clear();
            //IEnumerable<Employee> query1 = from emp in empList select emp;  // immediate execution, query will run everytime query1 is encountered
            //IEnumerable<Employee> query11 = empList.ToList();  // deferred execution, query will run once here and result is stored

            //IEnumerable<Employee> query2 = from emp in empList where emp.Address=="mumbai" select emp;
            //IEnumerable<Employee> query3 = empList.Where(FilterByAddress);
            //IEnumerable<Employee> query3 = empList.Where(emp => emp.Address == "mumbai");
            // sorting
            //IEnumerable<Employee> query4 = from emp in empList orderby emp.EmpName ascending select emp;
            //IEnumerable<Employee> query5 = empList.OrderBy(x => x.EmpName);
            //IEnumerable<Employee> query6 = from emp in empList orderby emp.Dept, emp.Address select emp;
            //IEnumerable<Employee> query7 = empList.OrderBy(x => x.Dept).ThenBy(y => y.Address);

            // single record
            // list record of amit
            //IEnumerable<Employee> query = empList.Where(x => x.EmpName == "amit");
            //Employee employee= (from emp in empList where emp.EmpName == "amit" select emp).First();
            //richTextBox1.AppendText("\n"+employee+"\n");
            // list all employees whosse name ends with 'a'
            //IEnumerable<Employee> query = empList.Where(x => x.EmpName[x.EmpName.Length-1]=='a');  // use EndsWIth

            // list all employees whosse name contains with 'i'
            //IEnumerable<Employee> query = empList.Where(x => x.EmpName.Contains('i'));

            // Anonymous type
            //var query = from emp in empList select new { emp.EmpName, emp.Address, Department = emp.Dept };
            //var query = empList.Select(emp => new { emp.EmpName, emp.Address, Department = emp.Dept });
            //var query = from emp in empList group emp by emp.Dept;
            //var query = empList.GroupBy(x => x.Dept, (key, g) => new { PersonId = key, Cars = g.ToList() });  // wrong
            //var query = (from emp in empList orderby emp.Salary descending select emp).Take(2); // top 2 highest paid salary
            //var query = from emp in empList
            //            let increment = emp.Salary*0.1
            //            select new { Empname = emp.EmpName, Salary = emp.Salary, IncrementAmt = increment, NetSalary = emp.Salary + increment };
            // Aggregate Function
            // Total Employee
            var queryCount = (from emp in empList select emp).Count();
            richTextBox1.AppendText(queryCount.ToString()+"\n");
            // Total Salary
            var querySum = (from emp in empList select emp).Sum(x=>x.Salary);
            richTextBox1.AppendText(queryCount.ToString());
            var queryMin = empList.Min(x => x.Salary);
            var query = from emp in empList
                        group emp by emp.Dept into empgrp
                        select new { grpname = empgrp.Key, salsum = empgrp.Sum(x => x.Salary), avgSum = empgrp.Average(x => x.Salary), minSal = empgrp.Min(x => x.Salary)};
            foreach (var item in query)
            {
                /*richTextBox1.AppendText("-->"+item.Key + "\r");
                foreach(var row in item)
                {
                    richTextBox1.AppendText("\t" + row.ToString() + "\n");
                }*/
                richTextBox1.AppendText(item.ToString()+"\r");
            }/*
            richTextBox1.AppendText("\n---------------------------\n");
            empList.Add(new Employee() { EmpNo = 202, EmpName = "Chandler", Address = "NYC", Dept = "hr", Salary = 17000 });
            foreach (Employee item in query)  // query gets exec again here
            {
                richTextBox1.AppendText(item + "\r");
            }*/
        }
    }
}
