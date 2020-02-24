using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MkGame
{
    class Program
    {
        static void Main()
        {
            List<Employe> empl = new List<Employe>() {
                new TimeWorker { Name = "Вася", SalaryForTime = 5, WorkTime = 15 },
                new TimeWorker { Name = "Прохор", SalaryForTime = 8, WorkTime = 20 },
                new PermanentWorker { Name = "Паштет", SalaryMonth = 300 },
                new PermanentWorker { Name = "Витек", SalaryMonth = 400 },
                new PermanentWorker { Name = "Ржавый", SalaryMonth = 800 },
            };

            empl.Sort();

            foreach (Employe w in empl)
            {
                Console.WriteLine(w.Name + $": {w.Salary()}");
            }

            //--------------------------------
            // Класс Employes
            //--------------------------------
            Console.WriteLine("---------------------------");

            Employe[] em = new Employe[] {
            new TimeWorker {Name = "Вася", SalaryForTime = 5, WorkTime = 15 },
            new TimeWorker { Name = "Прохор", SalaryForTime = 8, WorkTime = 20 },
            new PermanentWorker { Name = "Витек", SalaryMonth = 400 },
            new PermanentWorker { Name = "Ржавый", SalaryMonth = 800 }};

            Employes employes = new Employes(em);

            foreach (Employe _e in employes)
                Console.WriteLine(_e.Name + $": {_e.Salary()}");

            // после реализации ндексатора можно и так
            for (int i = 0; i < employes.Lenght; i++)
                Console.WriteLine(employes[i].Name + $": {employes[i].Salary()}");


            Console.Read();
        }
    }
}
