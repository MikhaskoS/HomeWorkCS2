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
            if (other == null) return 1;
            return (Salary().CompareTo(other.Salary()));
        }
        public abstract float Salary();
    }
    class TimeWorker : Employe
    {
        private float salaryForTime = 5; // почасовая оплата
        private float workTime = 8; // часов отработано

        public float SalaryForTime { get => salaryForTime; set => salaryForTime = value; }
        public float WorkTime { get => workTime; set => workTime = value; }

        public override float Salary()
        {
            return 20.8f * workTime * salaryForTime;
        }
    }
    class PermanentWorker : Employe
    {
        private float salaryMonth = 1000; // фикс месячная зарплата
        public float SalaryMonth { get => salaryMonth; set => salaryMonth = value; }

        public override float Salary()
        {
            return SalaryMonth;
        }
    }
}
