using System;
using System.Threading;
using System.Speech.Synthesis;
using System.Media;

class CybersecurityBot
{
    private static string userName = "";
    private static readonly SoundPlayer beepSound = new SoundPlayer("https://www.soundjay.com/buttons/beep-01a.wav"); // Simple beep sound

    private static readonly string botAscii = @"
               .-""""""""-.
      .'  **  **  '.
     /  **    **    \
    :  ,  ****    :
    `._ CYBER BOT _.'  
     | `.   ***  .' |
     :   `.  * .'   :
     `._*** _.'  
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
        SpeechSynthesizer talk = new SpeechSynthesizer();
        talk.Volume = 100;
        talk.Rate = 1;

        try
        {
            beepSound.Load(); // Load the sound file
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Sound loading failed: {ex.Message}");
        }

        talk.Speak("Welcome to the Cybersecurity Awareness Bot!");
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

            switch (input)
            {
                case "1":
                case "how are you":
                    Respond(talk, $"I'm doing great, {userName}! How are you today?");
                    break;

                case "2":
                case "what is your purpose":
                    Respond(talk, $"I'm here to help you, {userName}, stay secure online with cybersecurity tips!");
                    break;

                case "3":
                case "what can i ask you":
                    Respond(talk, $"You can ask me about password safety, phishing, safe browsing, or just chat with me!");
                    break;

                case "4":
                case "password safety":
                    Respond(talk, "Password Safety Tips:\n1. Use at least 12 characters.\n2. Mix letters, numbers, and symbols.\n3. Avoid personal information.\n4. Use unique passwords for each site.");
                    break;

                case "5":
                case "phishing":
                case "phishing awareness":
                    Respond(talk, "Phishing Awareness:\n1. Check sender emails carefully.\n2. Avoid clicking on suspicious links.\n3. Look for grammar errors.\n4. Be cautious of urgent requests.");
                    break;

                case "6":
                case "safe browsing":
                case "safe browsing tips":
                    Respond(talk, "Safe Browsing Tips:\n1. Always use HTTPS websites.\n2. Keep your browser updated.\n3. Use a good antivirus program.\n4. Avoid public Wi-Fi for sensitive transactions.");
                    break;

                case "7":
                case "exit":
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

    static void Respond(SpeechSynthesizer talk, string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n{message}");
        Console.ResetColor();
        try
        {
            beepSound.Play(); // Play sound with each response
            talk.Speak(message); // Speak the response
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Sound error: {ex.Message}");
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("\n═════════════════ OPTIONS ═════════════════");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("What would you like to explore? (Enter number or type the full question)");
        Console.WriteLine("1. How are you?");
        Console.WriteLine("2. What is your purpose?");
        Console.WriteLine("3. What can I ask you?");
        Console.WriteLine("4. Password safety");
        Console.WriteLine("5. Phishing awareness");
        Console.WriteLine("6. Safe browsing tips");
        Console.WriteLine("7. Exit");
        Console.ResetColor();
        Console.Write("Your choice: ");
    }
}