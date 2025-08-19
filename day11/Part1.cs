class Day11Part1
{
    List<string> input;
    List<double> kamienie = new List<double>();
    string path = "../../../day11/test_input.txt";
    public Day11Part1()
    { }


    public void setup()
    {
        input = Util.Parse(path);
        string[] linia = input[0].Split(' ');
        foreach (string line in linia)
        {
            kamienie.Add(double.Parse(line));
        }
    }

    public void run()
    {
        for (int i = 0; i < 6; i++) {
            blink();
            show();
        }
    }

    public void blink()
    {
        for (int i = 0; i < kamienie.Count; i++) {
            if (kamienie[i]==0)
            {
                kamienie[i] = 1;
            }else if (kamienie[i].ToString().Length%2==0)
            {
                int dlugosc = kamienie[i].ToString().Length;
                double lewy = double.Parse(kamienie[i].ToString().Substring(0, dlugosc/2));
                double prawy = double.Parse(kamienie[i].ToString().Substring(dlugosc/2, dlugosc/2));

                kamienie[i] = lewy;
                kamienie.Insert(i + 1, prawy);
                i++;
            }
            else
            {
                kamienie[i] = kamienie[i] * 2024;
            }
        }
    }
   

    public void score()
    {
        Console.WriteLine();
        Console.WriteLine("Jest "+kamienie.Count+" kamieni");
    }

    public void show()
    {
        Console.WriteLine();
        foreach (int i in kamienie) { 
        Console.Write(i.ToString()+" ");
        }
    }
    public void result()
    {
        setup();
        run();
        score();
    }
}