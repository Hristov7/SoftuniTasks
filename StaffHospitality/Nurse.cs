namespace StaffHospitality
{
    class Nurse : HospitalStaff
    {
        public string Department { get; set; }
        public int ShiftsWorked { get; set; }

        public Nurse(string firstName, string lastName, int age, double salary,
                     string department, int shiftsWorked)
            : base(firstName, lastName, age, salary)
        {
            Department = department;
            ShiftsWorked = shiftsWorked;
        }

        public override void Info()
        {
            Console.WriteLine($"Nurse: {FirstName} {LastName} - {Department}");
            Console.WriteLine($"Salary: {Salary:F2} lv.");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Shifts worked: {ShiftsWorked}");
        }
    }
}
