class Day6Part2
{
    public static int liczba = 6;
    public static List<string> input;
    public char[,] start_map;
    public Dictionary<int, int[]> dir = new Dictionary<int, int[]>();
    public List<int[]> exes = new List<int[]>();
    int cur_dir = 0;
    public int[] start_pos;
    int[] cur_pos;
    public Day6Part2()
    { }

    public void setup()
    {
        dir.Add(0, new int[] { -1, 0 });
        dir.Add(1, new int[] { 0, 1 });
        dir.Add(2, new int[] { 1, 0 });
        dir.Add(3, new int[] { 0, -1 });

        for (int i = 0; i < start_map.GetLength(0); i++)
        {
            for (int j = 0; j < start_map.GetLength(1); j++)
            {
                if (start_map[i, j] == 'X')
                {
                    exes.Add(new int[] { i, j });
                    start_map[i, j] = '.';
                }
            }
        }
    }

    public char[,] set_obstacle(int x, int y)
    {
        char[,] new_map = (char[,])start_map.Clone();
        new_map[x, y] = '#';        
        return new_map;
    }

    public bool does_loop(char[,] map)
    {
        HashSet<(int, int, int)> steps = new HashSet<(int, int, int)>();
        cur_dir = 0;
        cur_pos = (int[])start_pos.Clone();
        //show_map(map);
        while (!check_exit(map))
        {
            if (check_obstacle(map))
            {
                cur_dir++;
                if (cur_dir == 4) cur_dir = 0;
            }
            else
            {
                map[cur_pos[0], cur_pos[1]] = 'X';
                if (steps.Contains((cur_pos[0], cur_pos[1], cur_dir))) return true;
                steps.Add((cur_pos[0], cur_pos[1], cur_dir));
                cur_pos[0] = cur_pos[0] + dir[cur_dir][0];
                cur_pos[1] = cur_pos[1] + dir[cur_dir][1];
            }
                
                      
        }

        return false;
    }




    public bool check_exit(char[,] map)
    {
        int[] next_step = new int[] { cur_pos[0] + dir[cur_dir][0], cur_pos[1] + dir[cur_dir][1] };
        return map[next_step[0], next_step[1]] == '*';//true if exit

    }

    public bool check_obstacle(char[,] map)
    {
        int[] next_step = new int[] { cur_pos[0] + dir[cur_dir][0], cur_pos[1] + dir[cur_dir][1] };
        return map[next_step[0], next_step[1]] == '#';//true if obstacle

    }

    public void show_map(char[,] map)
    {
        if (map == null) return;
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                Console.Write(map[i, j]);
            }
            Console.WriteLine();
        }
    }


    public void result()
    {
        setup();
        int result = 0;
        foreach (int[] x in exes) {
            if(does_loop(set_obstacle(x[0], x[1])))result++;
        }

        Console.WriteLine(result);
    }
}