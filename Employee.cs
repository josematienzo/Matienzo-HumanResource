using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace HumanResource
{
    public class Employee : Applicant
    {
        public string CurrentDepartment { get; private set; }
        public string CurrentRole { get; private set; }
        public int YearsOfEmployment { get; private set; }
        public double Salary { get; private set; }
        public EmploymentStatus Status { get; private set; }
        public HashSet<Bonus> Bonuses;
        
        public Employee(string name, string depApplied, string roleApplied, Dictionary<string, int> skills, List<string> achievements, string dep, string role, EmploymentStatus status, double startingSalary) : base(name, depApplied, roleApplied, skills, achievements)
        {
            this.CurrentDepartment = dep;
            this.CurrentRole = role;
            this.Status = status;
            this.YearsOfEmployment = 0;
            this.Salary = startingSalary;
            this.Bonuses = new HashSet<Bonus>();
        }

        public void UpdateEmploymentStatus(EmploymentStatus status)
        {
            this.Status = status;
        }

        public void RaiseSalary(double newSalary)
        {
            if (newSalary > this.Salary)
                this.Salary = newSalary;
            else
                throw new Exception("New salary must be greater than current");
        }

        public void AddBonus(Bonus bonus)
        {
            this.Bonuses.Add(bonus);
        }

        public double CalculateBonus()
        {
            double total = 0;

            foreach (var bonus in this.Bonuses)
            {
                switch(bonus)
                {
                    case Bonus.Holiday:
                        total += this.Salary * 0.05;
                        break;
                    case Bonus.Signing:
                        total += this.Salary * 0.25;
                        break;
                    case Bonus.Retention:
                        total += this.Salary * 0.15;
                        break;
                    case Bonus.Referral:
                        total += 2000.00;
                        break;
                    case Bonus.Performance:
                        total += 0.075;
                        break;
                    case Bonus.Thirteenth_Month_Pay:
                        total += this.Salary;
                        break;
                }
            }

            return total;
        }

        public string AvailBonuses()
        {
            if (this.Bonuses.Count == 0)
                return this.Name + " has no bonuses available.";
            
            double bonus = this.CalculateBonus();
            this.Bonuses.Clear();
            return this.Name + " must be paid a total of P" + bonus + " worth of bonuses"; 
        }

        public override string ToString()
        {
            string s = "Employee Name: " + this.Name + "\nCurrent Department: " + this.CurrentDepartment + "\nCurrent Role: " + this.CurrentRole;
            s += "\nCurrent Status: " + this.Status + "\nYears of Employment: " + this.YearsOfEmployment + "\nSalary: " + this.Salary;

            return s;
        }
    }
}
