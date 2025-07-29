class Day7Part2
{
    List<string> input;
    public Day7Part2()
    { }

    public void run()
    {
        input = Util.Parse("../../../day7/input.txt");
        double result = 0;
        foreach (string s in input)
        {
            Console.WriteLine(calculate(s));
            result += calculate(s);
        }
        Console.WriteLine(result);
    }


    public double calculate(string s)
    {
        double target = Double.Parse(s.Split(":")[0]);
        List<double> arguments = new List<double>();

        foreach (string a in s.Split(':')[1].Split(' '))
        {
            if (a == "") continue;
            arguments.Add(Int32.Parse(a));
        }

        double possibilities = Math.Pow(3, arguments.Count);

        for (int i = 0; i < possibilities; i++)
        {
            string binary = ToBaseN(i, 3);
            if (binary.Length < arguments.Count)
            {
                binary = binary.PadLeft(arguments.Count, '0');
            }
            double result = arguments[0];
            for (int j = 0; j < arguments.Count - 1; j++)
            {
                if (binary[j] == '0')
                {
                    result += arguments[j + 1];
                }
                else if (binary[j] == '1')
                {
                    result *= arguments[j + 1];
                }
                else if (binary[j] == '2')
                {
                    result = Double.Parse(result.ToString()+arguments[j + 1].ToString());
                }
                if (result > target) break;
            }
            if (result == target) return target;
        }

        return 0;
    }
    public void result()
    {
        run();
    }


    string ToBaseN(int value, int @base)
    {
        if (@base < 2 || @base > 36)
            throw new ArgumentException("Base must be between 2 and 36.");

        if (value == 0) return "0";

        string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string result = "";

        int num = value;
        while (num > 0)
        {
            result = chars[num % @base] + result;
            num /= @base;
        }

        return result;
    }
}