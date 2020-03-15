using EmployeesDBService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesDBServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("++++++ Service Employees ++++++");

            using (ServiceHost serviceHost = new ServiceHost(typeof(EmployeesService)))
            {
                // Открыть хост и начать прослушивание входящих сообщений. 
                serviceHost.Open();
                // Оставить службу функционирующей до тех пор, 
                // пока не будет нажата клавиша <Enter>. 
                Console.WriteLine("Сервис работает...");
                Console.WriteLine("Нажмите Enter для прекращения работы сервиса.");
                Console.ReadLine();
            }
        }
    }
}
