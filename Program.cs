using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Human Resources Functions
            //Finding
            //Screening
            //Recruiting
            //Hiring
            //Onboarding
            //Training
            //Performance Management
            //Benefits or Compensation
            //Firing

            Applicant a = new Applicant("Jose", "IT", "Intern", new Dictionary<string, int> { }, new List<string> { });

            Console.WriteLine(a + "\n");

            Employee e = a.Hire("IT", "Intern", EmploymentStatus.Casual, 500.00);

            Console.WriteLine(e);

            Console.ReadKey();
        }
    }
}
