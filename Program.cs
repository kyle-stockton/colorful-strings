using System;

namespace StocktonKyle_CSharpCourseStep23m_MulticastDelegate
{
    // multicast delegate to store repeating color sequence
    public delegate void DisplayLetters();

    // handles storage/processing/display of user-defined messages
    class MessageHandler
    {
        // stores user-defined message
        string input;
        // displays first char in input string and any subsequent spaces
        void DisplayLetter(ConsoleColor c)
        {
            if (input != "")
            {
                Console.ForegroundColor = c;
                do
                {
                    Console.Write(input[0]);
                    input = input.Remove(0, 1);
                } while (input.StartsWith(" "));
            }
        }
        // call DisplayLetter passing appropriate color
        void Red()
        {
            DisplayLetter(ConsoleColor.Red);
        }
        void Yellow()
        {
            DisplayLetter(ConsoleColor.Yellow);
        }
        void Green()
        {
            DisplayLetter(ConsoleColor.Green);
        }
        void Cyan()
        {
            DisplayLetter(ConsoleColor.Cyan);
        }
        void Blue()
        {
            DisplayLetter(ConsoleColor.Blue);
        }
        void Magenta()
        {
            DisplayLetter(ConsoleColor.Magenta);
        }
        void White()
        {
            DisplayLetter(ConsoleColor.White);
        }
        // manages user interaction
        public void ProcessMessage()
        {
            // prompt user for message and store in string variable
            Console.Write("Type message and press Enter: ");
            input = Console.ReadLine();
            // loop until user just presses Enter at message prompt
            while (input != "")
            {
                // new multicast delegate
                DisplayLetters d = null;
                // prompt user for color sequence and store in string
                string sequence= "";
                do
                {
                    Console.WriteLine("\nSpecify repeating color sequence" +
                        " (example: rgb) and press Enter.");
                    Console.Write("[r]ed, [y]ellow, [g]reen, " +
                        "[c]yan, [b]lue, [m]agenta, [w]hite : ");
                    sequence = Console.ReadLine();
                    // remove any invalid characters from sequence string
                    for(int i = 0; i < sequence.Length; i++)
                    {
                        if ("rygcbmw".IndexOf(sequence[i]) == -1)
                        {
                            sequence = sequence.Remove(i, 1);
                            i--;
                        }
                    }
                } while (sequence == "");
                // display refined color sequence
                Console.WriteLine("Repeating color sequence: {0}\n", 
                    sequence);
                // loop for each letter in color sequence
                while (sequence != "")
                {
                    // interpret first char in sequence, add to multicast
                    switch (sequence[0])
                    {
                        case ('r'):
                            d += Red;
                            break;
                        case ('y'):
                            d += Yellow;
                            break;
                        case ('g'):
                            d += Green;
                            break;
                        case ('c'):
                            d += Cyan;
                            break;
                        case ('b'):
                            d += Blue;
                            break;
                        case ('m'):
                            d += Magenta;
                            break;
                        case ('w'):
                            d += White;
                            break;
                    }
                    // remove first char from sequence
                    sequence = sequence.Remove(0, 1);
                }
                // loop until all chars displayed/removed from input
                while (input != "")
                {
                    d();
                }
                // set text color to gray, prompt for new message/exit
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("\n\nEnter new message " + 
                    "or just press Enter to exit: ");
                input = Console.ReadLine();
            }
        }
    }
    // runs program
    class Program
    {
        static void Main()
        {
            new MessageHandler().ProcessMessage();
        }
    }
}
