class Day6Part1
{
    public static int liczba = 6;
    public static List<string> input;
    public char[,] map;
    public Dictionary<int, int[]> dir = new Dictionary<int, int[]>();
    int cur_dir = 0;
    public int[] start_pos;
    int[] cur_pos;
    public Day6Part1()
    { }

    public void setup()
    {
        input = Util.Parse("../../../day6/input.txt");
        map = new char[input.Count+2, input[0].Length+2];
        for (int i = 0; i < input.Count+2; i++)
        {
            for (int j = 0; j < input[0].Length + 2; j++)
            {
                if (i == 0 || j == 0) map[i, j] = '*';
                if (i == input.Count+1 || j == input[0].Length+1) map[i, j] = '*';
            }
        }
        for (int i = 0; i < input.Count; i++)
        {
            for (int j = 0; j < input[i].Length; j++)
            {
                map[i + 1, j + 1] = input[i][j];
                if (map[i, j] == '^') {
                    start_pos = [i, j];//i = y, j = x
                } 
            }
        }

        dir.Add(0, new int[] { -1, 0 });
        dir.Add(1, new int[] { 0, 1 });
        dir.Add(2, new int[] { 1, 0 });
        dir.Add(3, new int[] { 0, -1 });
    }

    public void run()
    {
        cur_pos = (int[])start_pos.Clone();

        while (!check_exit()){
            map[cur_pos[0], cur_pos[1]] = 'X';
            if (check_obstacle())
            {
                cur_dir++;
                if(cur_dir==4)cur_dir = 0;
            }
            else
            {
                
                cur_pos[0] = cur_pos[0] + dir[cur_dir][0];
                cur_pos[1] = cur_pos[1] + dir[cur_dir][1];
            }

        }
        map[cur_pos[0], cur_pos[1]] = 'X';
    }


    public bool check_exit()
    {
        int[] next_step = new int[]{ cur_pos[0] + dir[cur_dir][0], cur_pos[1] + dir[cur_dir][1]};
        return map[next_step[0], next_step[1]] == '*';//true if exit

    }

    public bool check_obstacle()
    {
        int[] next_step = new int[] { cur_pos[0] + dir[cur_dir][0], cur_pos[1] + dir[cur_dir][1] };
        return map[next_step[0], next_step[1]] == '#';//true if obstacle

    }
    public void show_map()
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

    public int count_x()
    {
        int score = 0;
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                if (map[i, j] == 'X') score++;
                    
            }
        }

        return score;
    }
    public void result()
    {
        setup();
        run();
        Console.WriteLine(count_x());
    }
}