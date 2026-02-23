namespace Forcebooks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            string input;
            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {
                if (input.Contains(" | "))
                {
                    string[] parts = input.Split(" | ");
                    string forceSide = parts[0];
                    string forceUser = parts[1];

                    if (!dictionary.ContainsKey(forceUser))
                    {
                        dictionary[forceUser] = forceSide;
                    }
                }
                else if (input.Contains(" -> "))
                {
                    string[] parts = input.Split(" -> ");
                    string forceUser = parts[0];
                    string forceSide = parts[1];

                    dictionary[forceUser] = forceSide;
                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }
            }

            var grouped = dictionary
                .GroupBy(x => x.Value)
                .Where(g => g.Any())
                .OrderByDescending(g => g.Count())
                .ThenBy(g => g.Key);

            foreach (var group in grouped)
            {
                Console.WriteLine($"Side: {group.Key}, Members: {group.Count()}");
                foreach (var user in group.OrderBy(x => x.Key))
                {
                    Console.WriteLine($"! {user.Key}");
                }
            }
        }
    }
}
/*
Light | George
Dark | Peter
Lumpawaroo

Lighter | Royal
Darker | DCay
John Johnys -> Lighter
DCay -> Lighter
Lumpawaroo

*/