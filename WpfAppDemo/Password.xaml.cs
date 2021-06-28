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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppDemo
{
    /// <summary>
    /// Interaction logic for Password.xaml
    /// </summary>
    public partial class Password : Window
    {
        int chances = 3;
        public Password()
        {
            InitializeComponent();
        }

        private void btnsubmit_Click(object sender, RoutedEventArgs e)
        {
            if (chances == 0)
            {
                Close();
            }
            --chances;
            string uname = txtUname.Text;
            string pwd = txtPwd.Text;
            if(uname=="admin" && pwd == "123")
            {
                // navigation code
            }
        }

        private void btncancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
