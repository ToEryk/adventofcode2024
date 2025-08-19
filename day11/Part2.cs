using static System.Runtime.InteropServices.JavaScript.JSType;

class Day11Part2
{
    Dictionary<(long, int), long> memo = new Dictionary<(long, int), long>();
    List<string> input;
    List<long> kamienie = new List<long>();
    long wynik = 0;
    string path = "../../../day11/input.txt";
    public Day11Part2()
    { }


    class State
    {
        public long Kamien;
        public int Depth;
        public State(long k, int d) { Kamien = k; Depth = d; }
    }



    public void setup()
    {
        input = Util.Parse(path);
        string[] linia = input[0].Split(' ');
        foreach (string line in linia)
        {
            kamienie.Add(long.Parse(line));
        }
    }

    public void run()
    {
        wynik = kamienie.Count;
        for (int i = 0; i < kamienie.Count; i++)//25 = 189167
        {
            wynik+= BlinkRecursive(kamienie[i],1,75);
        }
    }




    public long BlinkRecursive(long kamien, int depth, int maxDepth)
    {
        if (depth > maxDepth) return 0;

        if (memo.TryGetValue((kamien, depth), out long cached))
            return cached;

        long result = -1;

        if (kamien == 0)
        {
            result += 1;
            result += BlinkRecursive(1, depth + 1, maxDepth);
        }
        else
        {
            int len = (int)Math.Floor(Math.Log10(Math.Abs(kamien)) + 1);
            if (len % 2 == 0)
            {
                long left = kamien / (long)Math.Pow(10, len / 2);
                long right = kamien % (long)Math.Pow(10, len / 2);

                result += 2;
                result += BlinkRecursive(left, depth + 1, maxDepth);
                result += BlinkRecursive(right, depth + 1, maxDepth);
            }
            else
            {
                result += 1;
                result += BlinkRecursive(kamien * 2024, depth + 1, maxDepth);
            }
        }

        memo[(kamien, depth)] = result; // store result
        return result;
    }



    public void score()
    {
        Console.WriteLine();
        Console.WriteLine("Jest " + wynik + " kamieni");
    }

    public void show()
    {
        Console.WriteLine();
        foreach (int i in kamienie)
        {
            Console.Write(i.ToString() + " ");
        }
    }
    public void result()
    {
        setup();
        run();
        score();
    }
}