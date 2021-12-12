namespace First_task;

class Program
{
    private const string FILE_NAME = "Test.data";

    public static void Main()
    {
        if (File.Exists(FILE_NAME))
        {
            Console.WriteLine($"{FILE_NAME} already exists!");
            return;
        }

        using (FileStream fs = new FileStream(FILE_NAME, FileMode.CreateNew))
        {
            using (BinaryWriter w = new BinaryWriter(fs))
            {
                for (int i = 2; i < 11; i++)
                {
                    w.Write(Convert.ToInt32(Math.Pow(3,i)));
                }
            }
        }

        using (FileStream fs = new FileStream(FILE_NAME, FileMode.Open, FileAccess.Read))
        {
            using (BinaryReader r = new BinaryReader(fs))
            {
                for (int i = 2; i < 11; i++)
                {
                    if (i % 2 == 0)
                        Console.WriteLine(r.ReadInt32());
                }
            }
        }
    }
}