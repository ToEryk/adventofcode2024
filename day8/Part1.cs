class Day8Part1
{
    List<string> input;
    string path = "../../../day8/input.txt";
    public char[][] map;
    public char[][] antinode_map;
    public Dictionary<char, List<int[]>> anthenas = new Dictionary<char, List<int[]>>();
    public Day8Part1()
    { }


    public void setup()
    {
        input = Util.Parse(path);

        map = new char[input.Count + 2][];
        for (int i = 0; i < map.Length; i++)
        {
            map[i] = new char[input[0].Length + 2];
        }
        for (int i = 0; i < input.Count + 2; i++)
        {
            for (int j = 0; j < input[0].Length + 2; j++)
            {
                if (i == 0 || j == 0) map[i][j] = '*';
                if (i == input.Count + 1 || j == input[0].Length + 1) map[i][j] = '*';
            }
        }
        for (int i = 0; i < input.Count; i++)
        {
            for (int j = 0; j < input[i].Length; j++)
            {
                map[i + 1][j + 1] = input[i][j];
                if (input[i][j] != '.')
                {
                    if (!anthenas.ContainsKey(input[i][j]))
                    {
                        anthenas.Add(input[i][j], new List<int[]>());
                        anthenas[input[i][j]].Add(new int[] {i,j});
                    }
                    else
                    {
                        anthenas[input[i][j]].Add(new int[] { i, j });
                    }
                }
            }
        }

        antinode_map = new char[input.Count + 2][];
        for (int i = 0; i < antinode_map.Length; i++)
        {
            antinode_map[i] = new char[input[0].Length + 2];
        }
        for (int i = 0; i < input.Count + 2; i++)
        {
            for (int j = 0; j < input[0].Length + 2; j++)
            {
                if (i == 0 || j == 0) antinode_map[i][j] = '*';
                if (i == input.Count + 1 || j == input[0].Length + 1) antinode_map[i][j] = '*';
            }
        }
        for (int i = 0; i < input.Count; i++)
        {
            for (int j = 0; j < input[i].Length; j++)
            {
                antinode_map[i + 1][j + 1] = '.';
            }
        }

    }
    public void run()
    {
        foreach (char type in anthenas.Keys) {
            foreach (int[] base_antena in anthenas[type]) {
                foreach (int[] druga_antena in anthenas[type])
                {
                    if (base_antena[0] == druga_antena[0] && base_antena[1] == druga_antena[1]) continue;
                    int[] wektor = new int[] { base_antena[0] - druga_antena[0]+1, base_antena[1] - druga_antena[1]+1};
                    try
                    {
                        if(antinode_map[base_antena[0] + wektor[0]][base_antena[1] + wektor[1]] == '*')continue;
                        map[base_antena[0] + wektor[0]][base_antena[1] + wektor[1]] = '#';
                        antinode_map[base_antena[0] + wektor[0]][base_antena[1] + wektor[1]] = '#';
                    }
                    catch (Exception e) { }

                }
            }   
        }
        Console.WriteLine();
        show_map(map);
        Console.WriteLine();
        show_map(antinode_map);
    }

    public void show_map(char[][] map)
    {
        if (map == null) return;
        for (int i = 0; i < map.Length; i++)
        {
            for (int j = 0; j < map[i].Length; j++)
            {
                Console.Write(map[i][j]);
            }
            Console.WriteLine();
        }
    }

    public int count_score()
    {
        int score = 0;
        for (int i = 0; i < map.Length; i++)
        {
            for (int j = 0; j < map[i].Length; j++)
            {
                if (map[i][j] == '#') score++;

            }
        }

        return score;
    }

    public void result()
    {
        setup();
        show_map(map);
        Console.WriteLine();   
        show_map(antinode_map);
        run();
        Console.WriteLine(count_score());
    }
}