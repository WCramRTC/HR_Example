using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Example
{
    public static class Data
    {
        static Employee _currentlySelected;

        public static Employee CurrentlySelected { get => _currentlySelected; set => _currentlySelected = value; }


    }
}
