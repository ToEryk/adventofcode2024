class Day9Part2
{
    List<string> input;
    string disk = "";
    int empty_space = 0;
    List<string> disk_map = new List<string>();
    string current_id = "";
    int size = 0;
    string path = "../../../day9/input.txt";
    public Day9Part2()
    { }


    public void setup()
    {
        input = Util.Parse(path);
        disk = input[0];
        int id = 0;

        for (int i = 0; i < disk.Length; i++)
        {
            if (i % 2 == 0) //files
            {
                for (int j = 0; j < int.Parse(disk[i].ToString()); j++)
                {
                    disk_map.Add(id.ToString());
                }
                id++;
            }
            else //free space
            {
                for (int j = 0; j < int.Parse(disk[i].ToString()); j++)
                {
                    disk_map.Add(".");
                    empty_space++;
                }
            }
        }
        show();
    }

    public void run()
    {
        

        int increment = disk_map.Count()-1;
        while (increment > 0) 
        {
            int starting_point = increment;
            if (disk_map[increment] == ".")
            {
                increment--;
                continue;
            }

            size = 0;
            current_id = disk_map[increment];
            while (current_id == disk_map[increment])
            {
                size++;
                increment--;
                if (increment < 0) return;
            }
            int free_space = 0;
            for (int j = 0; j <= increment; j++)
            {
                
                    if (disk_map[j] == ".") 
                    {
                        free_space++;
                        if (free_space == size)
                        {
                        j++;
                            for (int k = 0; k < free_space; k++)
                            {
                                disk_map[j - k - 1] = current_id;
                            }
                            for (int point = 0; point < size; point++)
                            {
                                disk_map[starting_point - point] = ".";
                            }
                            break;
                        }
                    } 
                    else
                    {
                        free_space = 0;
                    }
                
            }

        }
    }

    public void score()
    {
        double result = 0;
        for (int i = 0; i < disk_map.Count; i++)
        {
            if (disk_map[i] == ".") continue;
            result += double.Parse(disk_map[i].ToString()) * i;
        }
        Console.WriteLine(result);
    }

    public void show()
    {
        Console.WriteLine();
        foreach (string key in disk_map)
        {
            Console.Write(key);
        }
    }
    public void result()
    {
        setup();
        //run();
        run();
        //show();
        Console.WriteLine();
        score();
    }
}