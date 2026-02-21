namespace Rankings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> map = new();
            string input;
            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] parts = input.Split(':', StringSplitOptions.RemoveEmptyEntries);
                if (!map.ContainsKey(parts[0]))
                {
                    map[parts[0]] = parts[1];
                }
            }

            Dictionary<string, Dictionary<string,int>> users = new();
            while ((input = Console.ReadLine()) != "end of submissions")
            {
                string[] data = input.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                if (!users.ContainsKey(data[2]))
                {
                    if (map.ContainsKey(data[0]))
                    {
                        string password = map[data[0]];
                        if (password == data[1])
                        {
                            users[data[2]] = new()
                            {
                                { data[0], int.Parse(data[3]) }
                            };
                        }
                    }
                }
                else
                {
                    Dictionary<string, int> pairs = users[data[2]];
                    if (pairs.ContainsKey(data[0]))
                    {
                        if (pairs[data[0]] < int.Parse(data[3]))
                        {
                            pairs[data[0]] = int.Parse(data[3]);
                        }
                    }
                    else
                    {
                        users[data[2]].Add(data[0], int.Parse(data[3]));
                    }
                }
            }

            Dictionary<string, int> personWithMostPoints = new();
            foreach (KeyValuePair<string, Dictionary<string, int>> user in users)
            {
                int total = 0;
                foreach (KeyValuePair<string, int> pair in user.Value)
                {
                    total += pair.Value;
                }

                if (!personWithMostPoints.ContainsKey(user.Key))
                {
                    personWithMostPoints[user.Key] = total;
                }
            }
            int maxPoints = personWithMostPoints.Max(x => x.Value);
            string userWithMaxPoints = personWithMostPoints.FirstOrDefault(x => x.Value == maxPoints).Key;
            Console.WriteLine($"Best candidate is {userWithMaxPoints} with total {maxPoints} points.");
            Console.WriteLine("Ranking:");
            foreach (KeyValuePair<string, Dictionary<string, int>> user in users.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{user.Key}");
                foreach (KeyValuePair<string, int> pair in user.Value.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"# {pair.Key} -> {pair.Value}");
                }
            }
        }
    }
}
/*
Part One Interview:success
Js Fundamentals:JSFundPass
C# Fundamentals:fundPass
Algorithms:fun
end of contests
C# Fundamentals=>fundPass=>Tanya=>350
Algorithms=>fun=>Tanya=>380
Part One Interview=>success=>Nikola=>120
Java Basics Exam=>JSFundPass=>Parker=>400
Part One Interview=>success=>Tanya=>220
OOP Advanced=>password123=>BaiIvan=>231
C# Fundamentals=>fundPass=>Tanya=>250
C# Fundamentals=>fundPass=>Nikola=>200
Js Fundamentals=>JSFundPass=>Tanya=>400
end of submissions

Java Advanced:funpass
Part Two Interview:success
Math Concept:asdasd
Java Web Basics:forrF
end of contests
Math Concept=>ispass=>Monika=>290
Java Advanced=>funpass=>Simon=>400
Part Two Interview=>success=>Drago=>120
Java Advanced=>funpass=>Petyr=>90
Java Web Basics=>forrF=>Simon=>280
Part Two Interview=>success=>Petyr=>0
Math Concept=>asdasd=>Drago=>250
Part Two Interview=>success=>Simon=>200
end of submissions

 */