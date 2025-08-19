class Day10Part1
{
    List<string> input;
    string path = "../../../day10/input.txt";
    int wynik = 0;
    List<List<int>> dir = new List<List<int>>();
    HashSet<(int, int)> szczyty = new HashSet<(int, int)>();
    public Day10Part1()
    { }


    public void setup()
    {
        input = Util.Parse(path);
        dir.Add(new List<int> { 0, 1 });
        dir.Add(new List<int> { 1, 0 });
        dir.Add(new List<int> { 0, -1 });
        dir.Add(new List<int> { -1, 0 });
    }

    public void run()
    {
        for (int x = 0; x < input.Count; x++) {
            for (int y = 0; y < input[x].Length; y++) {
                if (input[x][y] == '0') {
                    find_paths(x, y);
                    wynik += szczyty.Count;
                    szczyty.Clear();
                }
            }
        }
    }

    public void find_paths(int x, int y)
    {
        int current_num = int.Parse(input[x][y].ToString());
        if (current_num == 9) { 
            szczyty.Add((x, y));
            return;
        }
        foreach (List<int> i in dir) {
            try
            {
                if (int.Parse(input[x+i[0]][y+i[1]].ToString()) - current_num == 1)
                {
                    find_paths(x + i[0], y + i[1]);
                }
            }
            catch { }
        }
        return;
    }

    public void score()
    {
        Console.WriteLine(wynik);
    }

    public void show()
    {
     
    }
    public void result()
    {
        setup();
        run();
        score();
    }
}