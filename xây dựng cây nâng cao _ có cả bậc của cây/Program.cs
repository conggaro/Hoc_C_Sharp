namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                WorkTree.DisplayTreeOnConsole();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}