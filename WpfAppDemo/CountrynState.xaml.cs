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
    /// Interaction logic for CountrynState.xaml
    /// </summary>
    public partial class CountrynState : Window
    {
        List<Country> countries;
        List<State> states;
        Country sCountry;
        State sState;
        public CountrynState()
        {
            InitializeComponent();
        }
        private void StackPanel_Loaded(object sender, RoutedEventArgs e)
        {
            countries = new List<Country>();
            countries.Add(new Country { id = 1, name = "India", capital = "New Delhi" });
            countries.Add(new Country { id = 2, name = "Palestine", capital = "Jerusalem" });
            states = new List<State>();
            states.Add(new State { id = 1, name = "Maharashtra",    capital = "Mumbai",     CountryId = 1 });
            states.Add(new State { id = 2, name = "Uttar Pradesh",  capital = "Lucknow",    CountryId = 1 });
            states.Add(new State { id = 3, name = "West Bank",      capital = "Jerusalemm", CountryId = 2 });
            states.Add(new State { id = 4, name = "Ghaza Strip",    capital = "Ghaza City", CountryId = 2 });
            var qry = countries.ToList();
            foreach(var item in qry)
            {
                cmbCountry.Items.Add(item.name);
            }
        }

        private void cmbCountry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmbState.Items.Clear();
            var preQry = countries.Where(x=>x.name.ToString()==cmbCountry.SelectedItem.ToString()).First();
            sCountry = preQry;
            var qry = states.Where(x => x.CountryId == preQry.id).ToList();
            foreach (var item in qry)
            {
                cmbState.Items.Add(item.name);
            }
            //Console.WriteLine(preQry.id);
        }

        private void cmbState_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var preQry = states.Where(x => x.name.ToString() == cmbState.SelectedItem.ToString()).First();
            sState = preQry;
            stateCapital.Clear();
            stateCapital.Text = sState.capital;
        }
    }
}
