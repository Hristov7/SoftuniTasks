namespace StaffHospitality
{
    class Janitor : HospitalStaff
    {
        public int AreaCovered { get; set; }

        public Janitor(string firstName, string lastName, int age, double salary, int areaCovered)
            : base(firstName, lastName, age, salary)
        {
            AreaCovered = areaCovered;
        }

        public override void Info()
        {
            Console.WriteLine($"Janitor: {FirstName} {LastName}");
            Console.WriteLine($"Salary: {Salary:F2} lv.");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Area covered: {AreaCovered} sqm");
        }
    }
}
