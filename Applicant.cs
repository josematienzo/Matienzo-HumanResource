using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource
{
    public class Applicant
    {
        public string Name { get; private set; }
        public string DepartmentApplied { get; private set; }
        public string RoleApplied { get; private set; }
        public ApplicationStatus ApplicationStatus { get; private set; }
        public Dictionary<string, int> Skills;
        public List<string> Achievements;
        public Applicant(string name, string depApplied, string roleApplied, Dictionary<string, int> skills, List<string> achievements)
        {
            this.Name = name;
            this.DepartmentApplied = depApplied;
            this.RoleApplied = roleApplied;
            this.ApplicationStatus = ApplicationStatus.Pending;
            this.Skills = new Dictionary<string, int>();
            this.Achievements = new List<string>();
            foreach (var skill in skills)
                this.Skills.Add(skill.Key, skill.Value);
        }
        
        public Employee Hire(string department, string role, EmploymentStatus status, double salary)
        {
            if (status == EmploymentStatus.Fired || status == EmploymentStatus.Resigned || status == EmploymentStatus.Retired)
                throw new Exception("Invalid assignment of status to newly hired applicants");

            this.ApplicationStatus = ApplicationStatus.Accepted;
            return new Employee(this.Name, this.DepartmentApplied, this.RoleApplied, this.Skills, this.Achievements, department, role, status, salary);
        }

        public void Reject()
        {
            this.ApplicationStatus = ApplicationStatus.Rejected;
        }

        public void UpdateApplicationStatus(ApplicationStatus status)
        {
            this.ApplicationStatus = status;
        }

        public override string ToString()
        {
            string s = "Applicant Name: " + this.Name + "\nDepartment Applied For: " + this.DepartmentApplied + "\nSkills & YOE: ";

            if (this.Skills.Count > 0)
            {
                foreach (var skill in this.Skills)
                    s += skill.Key + ": " + skill.Value + " years\n";
            }
            else
                s += "None\n";

            s += "Achievemnts: ";

            if (this.Skills.Count > 0)
            {
                foreach (var skill in this.Skills)
                    s += skill.Key + ": " + skill.Value + " years\n";
            }
            else
                s += "None\n";

            s += "Status: " + this.ApplicationStatus;

            return s;
        }
    }
}
