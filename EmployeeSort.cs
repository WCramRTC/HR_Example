using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Example
{
    public static class EmployeeSort
    {

        public class FirstName : IComparer<Employee>
        {
            int IComparer<Employee>.Compare(Employee? x, Employee? y)
            {
                return x.FirstName.CompareTo(y.FirstName);
            }
        } // FirstName

        public class LastName : IComparer<Employee>
        {
            int IComparer<Employee>.Compare(Employee? x, Employee? y)
            {
                return x.LastName.CompareTo(y.LastName);
            }
        }

    }
}
