using System;
using System.Collections.Generic;
using System.Globalization;
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
using CsvHelper;

namespace HR_Example
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Employee> _employees;

        public MainWindow()
        {
            InitializeComponent();

            LoadCSVList();

            lvEmployees.ItemsSource = _employees;

            

        } // MainWindow()

        // What expectations do I have when I run this code
        // It will read our Employee.csv file
        // It will load all the data from the csv into our employee list
        
        // Reality:
        // 
        //
        // 
        //
        // 

        public void LoadCSVList()
        {
            string filePath = "Employee.csv";

            using (StreamReader sr = new StreamReader(filePath))
            using (CsvReader csv = new CsvReader(sr, CultureInfo.InvariantCulture))
            {

                _employees = csv.GetRecords<Employee>().ToList();
            }
        }

        private void Sort(object sender, RoutedEventArgs e)
        {

            Button clicked = (Button)sender;

            switch (clicked.Content.ToString())
            {
                case "First":
                    EmployeeSort.FirstName firstNameSort = new EmployeeSort.FirstName();
                    _employees.Sort(firstNameSort);

                    break;
                case "Last":
                    _employees.Sort(new EmployeeSort.LastName());
                    break;
            }

            lvEmployees.Items.Refresh();
        }

        private void SortHeader(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader gvch = e.OriginalSource as GridViewColumnHeader;

            switch (gvch.Content.ToString())
            {
                case "First Name":
                    EmployeeSort.FirstName firstNameSort = new EmployeeSort.FirstName();
                    _employees.Sort(firstNameSort);

                    break;
                case "Last Name":
                    _employees.Sort(new EmployeeSort.LastName());
                    break;
            }

            lvEmployees.Items.Refresh();
        }
    } // class

} // namespace

// The WINNING GOAL here
// Import a premade list of employees
// Display Employees


// Data : A CSV of employees ( first and last names )
// Class : Employee
