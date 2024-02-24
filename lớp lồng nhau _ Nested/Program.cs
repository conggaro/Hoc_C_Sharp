using System;

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // tạo đối tượng của lớp Program
            Program program = new Program();

            program.subProgram = new Program.SubProgram("Test 123");

            program.ShowMessage();



            // tạo đối tượng của lớp SubProgram
            SubProgram sp = new SubProgram("Sub Test 999");

            sp.SubShowMessage();
        }

        SubProgram? subProgram {  get; set; }

        public class SubProgram
        {
            private string message { get; set; }

            public SubProgram(string text)
            {
                this.message = text;
            }

            public void SubShowMessage()
            {
                Console.WriteLine("Message: " + this.message);
            }
        }

        public void ShowMessage()
        {
            this.subProgram?.SubShowMessage();
        }
    }
}