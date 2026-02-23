using System.Numerics;
using System.Threading;

namespace StaffHospitality
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<HospitalStaff> staff = new List<HospitalStaff>();

            string[] lines = File.ReadAllLines("input.txt");
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                var parts = line.Split(',');
                string type = parts[0].Trim();
                string firstName = parts[1].Trim();
                string lastName = parts[2].Trim();
                int age = int.Parse(parts[3].Trim());
                double salary = double.Parse(parts[4].Trim());

                switch (type)
                {
                    case "Doctor":
                        string spec = parts[5].Trim();
                        int patients = int.Parse(parts[6].Trim());
                        staff.Add(new Doctor(firstName, lastName, age, salary, spec, patients));
                        break;
                    case "Nurse":
                        string dept = parts[5].Trim();
                        int shifts = int.Parse(parts[6].Trim());
                        staff.Add(new Nurse(firstName, lastName, age, salary, dept, shifts));
                        break;
                    case "Janitor":
                        int area = int.Parse(parts[5].Trim());
                        staff.Add(new Janitor(firstName, lastName, age, salary, area));
                        break;
                }
            }

            // Sorted by age
            Console.WriteLine("Employees sorted by age:");
            foreach (var s in staff.OrderBy(s => s.Age))
                s.Info();
            Console.WriteLine();

            // Highest salary
            Console.WriteLine("Employee with the highest salary:");
            staff.OrderByDescending(s => s.Salary).First().Info();
            Console.WriteLine();

            // Doctor with most patients
            Console.WriteLine("Doctor with most patients treated:");
            staff.OfType<Doctor>().OrderByDescending(d => d.PatientsTreated).First().Info();
            Console.WriteLine();

            // Most hardworking nurse or janitor
            Console.WriteLine("Most hardworking employee (Nurse or Janitor):");
            HospitalStaff hardest = null;

            Nurse? topNurse = staff.OfType<Nurse>().OrderByDescending(n => n.ShiftsWorked).FirstOrDefault();
            Janitor? topJanitor = staff.OfType<Janitor>().OrderByDescending(j => j.AreaCovered).FirstOrDefault();

            if (topNurse != null && topJanitor != null)
                hardest = topNurse.ShiftsWorked >= topJanitor.AreaCovered ? (HospitalStaff)topNurse : topJanitor;
            else
                hardest = topNurse ?? (HospitalStaff)topJanitor;

            hardest?.Info();
        }
    }
}
