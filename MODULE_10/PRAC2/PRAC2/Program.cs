using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAC2
{
    public abstract class OrganizationComponent
    {
        public string Name { get; set; }
        public virtual void Add(OrganizationComponent component) { }
        public virtual void Remove(OrganizationComponent component) { }
        public virtual void DisplayHierarchy(int indent = 0) { }
        public virtual decimal GetBudget() => 0;
        public virtual int GetEmployeeCount() => 0;
        public virtual OrganizationComponent FindEmployee(string name) => null;
    }

    public class Employee : OrganizationComponent
    {
        public string Position { get; set; }
        public decimal Salary { get; set; }

        public Employee(string name, string position, decimal salary)
        {
            Name = name;
            Position = position;
            Salary = salary;
        }

        public override void DisplayHierarchy(int indent = 0)
        {
            Console.WriteLine($"{new string(' ', indent)}- {Position}: {Name} (${Salary})");
        }

        public override decimal GetBudget() => Salary;
        public override int GetEmployeeCount() => 1;

        public override OrganizationComponent FindEmployee(string name)
        {
            return Name.Equals(name, StringComparison.OrdinalIgnoreCase) ? this : null;
        }
    }

    public class Department : OrganizationComponent
    {
        private List<OrganizationComponent> _components = new List<OrganizationComponent>();

        public Department(string name)
        {
            Name = name;
        }

        public override void Add(OrganizationComponent component)
        {
            _components.Add(component);
        }

        public override void Remove(OrganizationComponent component)
        {
            _components.Remove(component);
        }

        public override void DisplayHierarchy(int indent = 0)
        {
            Console.WriteLine($"{new string(' ', indent)}+ Department: {Name}");
            foreach (var component in _components)
            {
                component.DisplayHierarchy(indent + 2);
            }
        }

        public override decimal GetBudget()
        {
            return _components.Sum(c => c.GetBudget());
        }

        public override int GetEmployeeCount()
        {
            return _components.Sum(c => c.GetEmployeeCount());
        }

        public override OrganizationComponent FindEmployee(string name)
        {
            foreach (var component in _components)
            {
                var found = component.FindEmployee(name);
                if (found != null) return found;
            }
            return null;
        }
    }

    public class Contractor : Employee
    {
        public Contractor(string name, string position, decimal fixedFee)
            : base(name, position, fixedFee) { }

        public override decimal GetBudget() => 0;
    }

    public class Program
    {
        public static void Main()
        {
            var emp1 = new Employee("Alice", "Engineer", 70000);
            var emp2 = new Employee("Bob", "Designer", 60000);
            var emp3 = new Contractor("Charlie", "Consultant", 50000);
            var emp4 = new Employee("Daisy", "Manager", 90000);

            var designDepartment = new Department("Design");
            designDepartment.Add(emp2);

            var engineeringDepartment = new Department("Engineering");
            engineeringDepartment.Add(emp1);
            engineeringDepartment.Add(emp3);

            var mainDepartment = new Department("Head Department");
            mainDepartment.Add(emp4);
            mainDepartment.Add(designDepartment);
            mainDepartment.Add(engineeringDepartment);

            mainDepartment.DisplayHierarchy();

            Console.WriteLine($"\nОбщий бюджет отдела: ${mainDepartment.GetBudget()}");
            Console.WriteLine($"Общее количество сотрудников: {mainDepartment.GetEmployeeCount()}");

            var foundEmployee = mainDepartment.FindEmployee("Alice");
            if (foundEmployee != null)
            {
                Console.WriteLine("\nСотрудник найден:");
                foundEmployee.DisplayHierarchy();
            }
            else
            {
                Console.WriteLine("\nСотрудник не найден.");
            }
        }
    }
}
