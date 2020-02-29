using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MkGame
{
    abstract class Employe : IComparable<Employe>
    {
        public string Name { get; set; }

        public  int CompareTo(Employe other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            return Salary.CompareTo(other.Salary);
        }
        public abstract decimal Salary { get; }
        public override string ToString()
        {
            return Name + $": {Salary}";
        }
    }
    class TimeWorker : Employe
    {
        private decimal salaryForTime = 5; // почасовая оплата
        private double workTime = 8; // часов отработано

        public decimal SalaryForTime { get => salaryForTime; set => salaryForTime = value; }
        public double WorkTime { get => workTime; set => workTime = value; }

        public override decimal Salary => (decimal)(20.8 * workTime) * salaryForTime;

    }
    class PermanentWorker : Employe
    {
        private decimal salaryMonth = 1000; // фикс месячная зарплата
        public decimal SalaryMonth { get => salaryMonth; set => salaryMonth = value; }

        public override decimal Salary => SalaryMonth;
    }
}
