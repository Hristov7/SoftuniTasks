namespace Vlogger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, (HashSet<string> followers, HashSet<string> following)> vloggers = new();

            string input;
            while ((input = Console.ReadLine()) != "Statistics")
            {
                if (input.EndsWith("joined The V-Logger"))
                {
                    string name = input.Split(" ")[0];
                    if (!vloggers.ContainsKey(name))
                    {
                        vloggers[name] = (new HashSet<string>(), new HashSet<string>());
                    }
                }
                else if (input.Contains(" followed "))
                {
                    string[] parts = input.Split(" followed ");
                    string follower = parts[0];
                    string followed = parts[1];

                    if (!vloggers.ContainsKey(follower) || !vloggers.ContainsKey(followed))
                        continue;
                    if (follower == followed)
                        continue;
                    if (vloggers[followed].followers.Contains(follower))
                        continue;

                    vloggers[followed].followers.Add(follower);
                    vloggers[follower].following.Add(followed);
                }
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            var ordered = vloggers
                .OrderByDescending(v => v.Value.followers.Count)
                .ThenBy(v => v.Value.following.Count)
                .ToList();

            for (int i = 0; i < ordered.Count; i++)
            {
                var vlogger = ordered[i];
                string name = vlogger.Key;
                int followersCount = vlogger.Value.followers.Count;
                int followingCount = vlogger.Value.following.Count;

                Console.WriteLine($"{i + 1}. {name} : {followersCount} followers, {followingCount} following");

                if (i == 0)
                {
                    foreach (string follower in vlogger.Value.followers.OrderBy(f => f))
                    {
                        Console.WriteLine($"* {follower}");
                    }
                }
            }
        }
    }
}
/*
EmilConrad joined The V-Logger
VenomTheDoctor joined The V-Logger
Saffrona joined The V-Logger
Saffrona followed EmilConrad
Saffrona followed VenomTheDoctor
EmilConrad followed VenomTheDoctor
VenomTheDoctor followed VenomTheDoctor
Saffrona followed EmilConrad
Statistics

JennaMarbles joined The V-Logger
JennaMarbles followed Zoella
AmazingPhil joined The V-Logger
JennaMarbles followed AmazingPhil
Zoella joined The V-Logger
JennaMarbles followed Zoella
Zoella followed AmazingPhil
Christy followed Zoella
Zoella followed Christy
JacksGap joined The V-Logger
JacksGap followed JennaMarbles
PewDiePie joined The V-Logger
Zoella joined The V-Logger
Statistics
 */