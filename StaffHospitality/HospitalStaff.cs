namespace StaffHospitality
{
    abstract class HospitalStaff
    {
        private int age;
        private double salary;

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Age
        {
            get => age;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Age must be a positive number.");
                age = value;
            }
        }

        public double Salary
        {
            get => salary;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Salary must be a positive number!");
                salary = value;
            }
        }

        public HospitalStaff(string firstName, string lastName, int age, double salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }

        public abstract void Info();
    }
}