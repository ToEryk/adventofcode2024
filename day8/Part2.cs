class Day8Part2
{
    List<string> input;
    string path = "../../../day8/input.txt";
    public char[][] map;
    public char[][] antinode_map;
    public Dictionary<char, List<int[]>> anthenas = new Dictionary<char, List<int[]>>();
    public Day8Part2()
    { }


    public void setup()
    {
        input = Util.Parse(path);

        map = new char[input.Count][];
        for (int i = 0; i < map.Length; i++)
        {
            map[i] = new char[input[0].Length];
        }
        
        for (int i = 0; i < input.Count; i++)
        {
            for (int j = 0; j < input[i].Length; j++)
            {
                map[i][j] = input[i][j];
                if (input[i][j] != '.')
                {
                    if (!anthenas.ContainsKey(input[i][j]))
                    {
                        anthenas.Add(input[i][j], new List<int[]>());
                        anthenas[input[i][j]].Add(new int[] { i, j });
                    }
                    else
                    {
                        anthenas[input[i][j]].Add(new int[] { i, j });
                    }
                }
            }
        }

        antinode_map = new char[input.Count][];
        for (int i = 0; i < antinode_map.Length; i++)
        {
            antinode_map[i] = new char[input[0].Length];
        }
        for (int i = 0; i < input.Count; i++)
        {
            for (int j = 0; j < input[i].Length; j++)
            {
                antinode_map[i][j] = '.';
            }
        }

    }
    public void run()
    {
        foreach (char type in anthenas.Keys)
        {
            foreach (int[] base_antena in anthenas[type])
            {
                foreach (int[] druga_antena in anthenas[type])
                {
                    if (base_antena[0] == druga_antena[0] && base_antena[1] == druga_antena[1])
                    {
                        map[base_antena[0]][base_antena[1]] = '#';
                        antinode_map[base_antena[0]][base_antena[1]] = '#';
                        continue;
                    }
                    int[] wektor = new int[] { base_antena[0] - druga_antena[0], base_antena[1] - druga_antena[1]};
                    try
                    {
                        if (antinode_map[base_antena[0] + wektor[0]][base_antena[1] + wektor[1]] == '*') continue;
                        int i = 1;
                        while (true)
                        {
                            if (!(antinode_map[base_antena[0] + wektor[0] * i][base_antena[1] + wektor[1] * i] == '*'))
                            {
                                map[base_antena[0] + wektor[0] * i][base_antena[1] + wektor[1] * i] = '#';
                                antinode_map[base_antena[0] + wektor[0] * i][base_antena[1] + wektor[1] * i] = '#';
                            }
                            i++;
                        }
                        
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