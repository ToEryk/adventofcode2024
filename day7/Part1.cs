class Day7Part1
{
    List<string> input;
    public Day7Part1()
    { }

    public void run()
    {
        input = Util.Parse("../../../day7/input.txt");
        double result = 0;
        foreach (string s in input) {
            Console.WriteLine(calculate(s));
            result += calculate(s);
        }
        Console.WriteLine(result);
    }


    public double calculate(string s)
    {
        double target = Double.Parse(s.Split(":")[0]);
        List<double> arguments = new List<double>();
        
        foreach(string a in s.Split(':')[1].Split(' '))
        {
            if (a == "") continue;
            arguments.Add(Int32.Parse(a));
        }

        double possibilities = Math.Pow(2, arguments.Count);

        for (int i = 0; i < possibilities; i++) {
            string binary = Convert.ToString(i,2);
            if (binary.Length < arguments.Count)
            {
                binary = binary.PadLeft(arguments.Count,'0');
            }
            double result = arguments[0];
            for (int j = 0; j < arguments.Count-1; j++)
            {
                if (binary[j] == '0')
                {
                    result += arguments[j + 1];
                }
                else if (binary[j] == '1')
                {
                    result *= arguments[j + 1];
                }
                if (result > target) break;
            }
            if(result==target) return target;
        }

        return 0;
    }
    public void result()
    {
        run();
    }
}