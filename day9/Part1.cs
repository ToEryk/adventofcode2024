class Day9Part1
{
    List<string> input;
    string disk = "";
    int empty_space = 0;
    List<string> disk_map = new List<string>();
    string path = "../../../day9/input.txt";
    public Day9Part1()
    { }


    public void setup()
    {
        input = Util.Parse(path);
        disk = input[0];
    }

    public void run()
    {        
        int id = 0;

        for (int i = 0; i < disk.Length; i++)
        {
            if (i % 2 == 0) //files
            {
                for(int j = 0; j < int.Parse(disk[i].ToString()); j++)
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

        for (int i = disk_map.Count()-1; i > 0; i--) {
            if (disk_map[i] == ".") continue;

            for (int j = 0; j < i; j++) {
                if (disk_map[j] == ".")
                {
                    disk_map[j]=disk_map[i];
                    disk_map[i] = ".";
                    break;
                }
            }
        }
        
    }

    public void score()
    {
        double result = 0;
        for (int i = 0; i < disk_map.Count; i++) {
            if (disk_map[i] == ".") break;
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
        run();
        show();
        score();
    }
}