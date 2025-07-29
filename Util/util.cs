public class Util
{
    public static List<string> Parse(string path)
    {
        string line;
        List<string> result = new List<string>();
        StreamReader sr = new StreamReader(path);
        line = sr.ReadLine();
        while (line != null)
        {
            result.Add(line);
            line = sr.ReadLine();
        }
    sr.Close();
        return result;
    }
}