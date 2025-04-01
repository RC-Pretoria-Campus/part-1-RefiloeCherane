using System;
using System.Threading;
using System.Speech.Synthesis;

class CybersecurityBot
{
    private static string userName = "";

    // ASCII art for the bot
    private static readonly string botAscii = @"
        .-""""""""-.
      .'  **  **  '.
     /  **    **    \
    :  ,  **  **    :
    `._  CYBER BOT _.'  
     | `.   ***  .' |
     :   `.  * .'   :
     `._   ***   _.'  
    _/|_`. *** .' _/|_
   /    \   * *  /    \
   |    |        |    |
   |    |        |    |
    \  /          \  /
     ||            ||
     ||            ||
    ";

    static void Main(string[] args)
    {
        // Create a SpeechSynthesizer instance
        SpeechSynthesizer talk = new SpeechSynthesizer();
        talk.Volume = 100;
        talk.Rate = 1;

        // Speak the welcome message
        talk.Speak("Welcome to the Cybersecurity Awareness Bot!");

        // Initialize and start the chatbot
        InitializeChatbot(talk);
        StartConversation(talk);
    }

    static void InitializeChatbot(SpeechSynthesizer talk)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(botAscii);
        Console.WriteLine("╔════════════════════════════════════╗");
        Console.WriteLine("║   Cybersecurity Awareness Bot     ║");
        Console.WriteLine("╚════════════════════════════════════╝");
        Console.ResetColor();
        Thread.Sleep(1000);

        // Greet the user and ask for their name
        GetUserName(talk);
    }

    static void GetUserName(SpeechSynthesizer talk)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("\nPlease enter your name: ");
        Console.ResetColor();

        userName = Console.ReadLine()?.Trim();
        while (string.IsNullOrEmpty(userName))
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Name cannot be empty. Please enter your name: ");
            Console.ResetColor();
            userName = Console.ReadLine()?.Trim();
        }

        // Speak confirmation after name entry
        talk.Speak($"Hello, {userName}! Welcome to the Cybersecurity Awareness Bot!");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"\nHello, {userName}! Welcome to the Cybersecurity Awareness Bot!");
        Console.ResetColor();
    }

    static void StartConversation(SpeechSynthesizer talk)
    {
        bool running = true;
        while (running)
        {
            DisplayMenu();
            string input = Console.ReadLine()?.ToLower().Trim() ?? "";

            // Speak selection confirmation for valid input
            if (!string.IsNullOrEmpty(input))
            {
                talk.Speak("You selected an option.");
            }

            switch (input)
            {
                case "1":
                case "how are you":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nI'm doing fantastic, {userName}! How are you feeling today?");
                    Console.ResetColor();
                    Console.Write("Your answer: ");
                    string mood = Console.ReadLine();
                    Console.WriteLine($"Glad to hear that, {userName}!");
                    break;

                case "2":
                case "what is your purpose":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nI'm here to help you, {userName}, stay secure online with tips and advice!");
                    Console.ResetColor();
                    break;

                case "3":
                case "what can i ask you":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nYou can ask me anything, {userName}! Try these:\n- Password safety\n- Phishing info\n- Safe browsing\n- Or just chat!");
                    Console.ResetColor();
                    break;

                case "4":
                case "password safety":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nPassword Tips for {userName}:\n1. Use 12+ characters\n2. Mix letters, numbers, symbols\n3. No personal info\n4. Unique passwords per site");
                    Console.ResetColor();
                    Console.Write("Got a password question? ");
                    Console.ReadLine();
                    break;

                case "5":
                case "phishing":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nPhishing Tips for {userName}:\n1. Check sender emails\n2. Avoid odd links\n3. Spot typos\n4. Question urgent requests");
                    Console.ResetColor();
                    Console.Write("Seen any phishing lately? ");
                    Console.ReadLine();
                    break;

                case "6":
                case "safe browsing":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nBrowsing Tips for {userName}:\n1. Stick to HTTPS\n2. Update software\n3. Use antivirus\n4. Avoid public Wi-Fi for sensitive stuff");
                    Console.ResetColor();
                    Console.Write("Any browsing concerns? ");
                    Console.ReadLine();
                    break;

                case "7":
                case "exit":
                    // Speak exit message
                    talk.Speak($"See you later, {userName}! Stay cyber-safe!");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"\nSee you later, {userName}! Stay cyber-safe!");
                    Console.ResetColor();
                    running = false;
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nI didn't quite understand that. Could you rephrase?");
                    Console.ResetColor();
                    break;
            }
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("\n═════════════════ OPTIONS ═════════════════");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("What would you like to explore?");
        Console.WriteLine("1. How are you?");
        Console.WriteLine("2. What is your purpose?");
        Console.WriteLine("3. What can I ask you?");
        Console.WriteLine("4. Password safety tips");
        Console.WriteLine("5. Phishing awareness");
        Console.WriteLine("6. Safe browsing tips");
        Console.WriteLine("7. Exit");
        Console.ResetColor();
        Console.Write("Your choice: ");
    }
}
