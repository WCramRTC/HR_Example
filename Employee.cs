using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Example
{
    public class Employee
    {

        string _firstName;
        string _lastName;
        string _social;
        DateTime _start;
        DateTime _end;
        Departments.Department _department;
        string _id;
        double _totalHoursWorked;
        Positions.Position _position;
        List<Shift> _shiftsWorked;

        public Employee() {
            _shiftsWorked = new List<Shift>();
        }

        public void AddNewShift(Shift shift)
        {
            _shiftsWorked.Add(shift);
        }

        public Shift CurrentShift()
        {
            return _shiftsWorked[_shiftsWorked.Count - 1];
        }

        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string Social { get => _social; set => _social = value; }
        public DateTime Start { get => _start; set => _start = value; }
        public DateTime End { get => _end; set => _end = value; }

        public string ID { get => _id; set => _id = value; }
        public double TotalHoursWorked { get => _totalHoursWorked; set => _totalHoursWorked = value; }
        public Departments.Department Department { get => _department; set => _department = value; }
        public Positions.Position Position { get => _position; set => _position = value; }

        public string FullName()
        {
            return $"{FirstName} {LastName} : {Position}";
        }
    } // class

} // namespace
