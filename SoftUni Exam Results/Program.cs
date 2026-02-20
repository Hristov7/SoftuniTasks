namespace SoftUni_Exam_Results
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> usernamesAndPoints = new();
            Dictionary<string, int> languageAndCount = new();
            string input;
            while ((input = Console.ReadLine()) != "exam finished")
            {
                string[] parts = input.Split('-', StringSplitOptions.RemoveEmptyEntries);
                if (parts[1] == "banned")
                {
                    usernamesAndPoints.Remove(parts[0]);
                }
                else
                {
                    if (!usernamesAndPoints.ContainsKey(parts[0]))
                    {
                        usernamesAndPoints[parts[0]] = int.Parse(parts[2]);
                    }
                    else
                    {
                        if (usernamesAndPoints[parts[0]] < int.Parse(parts[2]))
                        {
                            usernamesAndPoints[parts[0]] = int.Parse(parts[2]);
                        }
                    }
                    if (!languageAndCount.ContainsKey(parts[1]))
                    {
                        languageAndCount[parts[1]] = 1;
                    }
                    else
                    {
                        languageAndCount[parts[1]]++;
                    }
                }
            }
            Console.WriteLine("Results:");
            foreach (KeyValuePair<string, int> pair in usernamesAndPoints.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{pair.Key} | {pair.Value}");
            }
            Console.WriteLine("Submissions:");
            foreach (KeyValuePair<string, int> pair in languageAndCount.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{pair.Key} – {pair.Value}");
            }
        }
    }
}
/*
Peter-Java-84
George-C#-70
George-C#-84
Sam-C#-94
exam finished

Peter-Java-91
George-C#-84
Sam-JavaScript-90
Sam-C#-50
Sam-banned
exam finished

*/