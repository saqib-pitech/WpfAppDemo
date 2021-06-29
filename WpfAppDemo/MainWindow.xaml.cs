using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string root = @"C:\userdata";
        public MainWindow()
        {
            InitializeComponent();
            foreach (string f in Directory.GetFiles(root))
            {
                //Console.WriteLine(f);
                lstItems.Items.Add(f);
            }
        }

        private void btnsubmit_Click(object sender, RoutedEventArgs e)
        {            
            // If directory does not exist, create
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            using (StreamWriter sw = File.CreateText($"C://userdata//{txtUname.Text}.txt"))
            {
                sw.WriteLine(txtUname.Text);
                sw.WriteLine(txtAddress.Text);
                sw.WriteLine(cmbCountry.SelectedItem);
                sw.WriteLine(optMale.IsChecked);
                sw.WriteLine(optFemale.IsChecked);
                sw.WriteLine(chkReading.IsChecked);
                sw.WriteLine(chkMusic.IsChecked);
            }
        }
        public void Reset()
        {
            txtUname.Text = "";
            txtAddress.Text = "";
            cmbCountry.SelectedIndex = 1;
            optMale.IsChecked = false;
            optFemale.IsChecked = false;
            chkReading.IsChecked = false;
            chkMusic.IsChecked = false;
        }
        private void btncancel_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        private void lstItems_Selected(object sender, RoutedEventArgs e)
        {
            string file = lstItems.SelectedItem.ToString();
            using (StreamReader sr = File.OpenText(file))
            {
                string data=sr.ReadToEnd();
                rchBox.AppendText(data);
            }
        }
    }
}
