namespace StaffHospitality
{
    class Doctor : HospitalStaff
    {
        public string Specialization { get; set; }
        public int PatientsTreated { get; set; }

        public Doctor(string firstName, string lastName, int age, double salary,
                      string specialization, int patientsTreated)
            : base(firstName, lastName, age, salary)
        {
            Specialization = specialization;
            PatientsTreated = patientsTreated;
        }

        public override void Info()
        {
            Console.WriteLine($"Doctor: {FirstName} {LastName} - {Specialization}");
            Console.WriteLine($"Salary: {Salary:F2} lv.");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Patients treated: {PatientsTreated}");
        }
    }
}
