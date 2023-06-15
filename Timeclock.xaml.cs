using System;
using System.CodeDom.Compiler;
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

namespace HR_Example
{
    /// <summary>
    /// Interaction logic for Timeclock.xaml
    /// </summary>
    public partial class Timeclock : Window
    {

        Employee selected = Data.CurrentlySelected;
        Shift currentShift;

        public Timeclock()
        {
            InitializeComponent();

            // A new shift starts as soon as we go to the time clock
            selected.AddNewShift(new Shift());
            currentShift = selected.CurrentShift();

            FormattedDisplay();

        
        } // Timeclock

        public void FormattedDisplay()
        {
            rtbMainDisplay.Text = DateTime.Now.ToShortDateString() + "\n";
            rtbMainDisplay.Text += DateTime.Now.ToLongTimeString();
            rtbMainDisplay.Text += "-----------------------------------\n";
            
            if(selected != null)
            {
                rtbMainDisplay.Text += $"Employee : {selected.FullName()}\n";
            }


            if(currentShift.IsWorking || currentShift.ShiftEnded)
            {
                rtbMainDisplay.Text += currentShift.ShiftStarted() + "\n";
            }
            
            
            if (currentShift.ShiftEnded)
            {
                rtbMainDisplay.Text += $"{currentShift.ShiftEnds()}\n";
                rtbMainDisplay.Text += $"{currentShift.ShiftTotal()}";
            }

            if(!currentShift.IsWorking && !currentShift.ShiftEnded)
            {
                rtbMainDisplay.Text += "This user hasn't clocked in yet\n";
            }

            


        }

        private void btnClockIn_Click(object sender, RoutedEventArgs e)
        {
            currentShift.ClockIn();
            FormattedDisplay();
        }


        private void btnClockOut_Click(object sender, RoutedEventArgs e)
        {
            if(currentShift.IsWorking)
            {
                currentShift.ClockOut();
                FormattedDisplay();
            }

        }

 





        //public async void FormattedDisplay()
        //{

        //    await Task.Run(() =>
        //    {
        //        while (true)
        //        {
        //            rtbMainDisplay.Text = DateTime.Now.ToShortDateString();
        //            rtbMainDisplay.Text += DateTime.Now.ToLongTimeString();
        //            Task.Delay(1000);
        //        }

        //    }
        //    );   

        //}
    }
}
