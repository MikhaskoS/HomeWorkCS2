using FileService.ManualClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new TestClient(new BasicHttpBinding(), new EndpointAddress("http://localhost:8080/EmployeesService"));

            client.GetDepartmens();

            Console.WriteLine("Нажмите Enter для выхода...");
            Console.ReadLine();
        }
    }
}
