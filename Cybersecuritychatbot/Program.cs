using System;
using System.Media;
using System.IO;
using System.Threading;
using System.Diagnostics;

public class CybersecurityChatbot
{   
    static void Main(string[] args)
    {
        // 1. Voice Greeting
        PlayVoiceGreeting("welcome.wav"); // Ensure "welcome.wav" is in the executable's directory

        // 2. Image Display
        DisplayAsciiArt();

        // 3. Text-Based Greeting and User Interaction
        string userName = GetUserName();
        GreetUser(userName);

        // 4. Basic Response System
        ChatLoop();
    }

    static void PlayVoiceGreeting(string audioFilePath)
    {
        try
        {
            SoundPlayer player = new SoundPlayer("Audio/Greetings.wav");
            player.PlaySync(); // Play the audio and wait for it to finish
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Error: Audio file not found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while playing the audio: {ex.Message}");
        }
    }

    static void DisplayAsciiArt()
    {
        // Choose which ASCII art to display
        DisplayCybersecurityLogo(); // Or DisplayCyberSymbol(); or DisplayHackerSymbol();
    }

    public static void DisplayCybersecurityLogo()
    {
        Console.ForegroundColor = ConsoleColor.Blue;

        string[] logoLines = new string[]
        {
        "  ██████╗  █████╗ ███╗    ██╗███████╗",
        "  ██╔══██╗██╔══██╗████╗  ██║██╔════╝",
        "  ██████╔╝███████║██╔██╗ ██║███████╗",
        "  ██╔══██╗██╔══██║██║╚██╗██║╚════██║",
        "  ██████╔╝██║  ██║██║ ╚████║███████║",
        "  ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═══╝╚══════╝",
        "  Cybersecurity Awareness Bot"
        };

        int consoleWidth = Console.WindowWidth;

        foreach (string line in logoLines)
        {
            int padding = consoleWidth - line.Length;
            if (padding < 0) padding = 0; // avoid negative values
            Console.WriteLine(new string(' ', padding) + line);
        }

        Console.ResetColor();
    }


    static string GetUserName()
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    static void GreetUser(string name)
    {
        Console.ForegroundColor = ConsoleColor.Green; // change welcome message color to green
        Console.WriteLine($"\nWelcome, {name}! I'm the Cybersecurity Awareness Bot. How can I help you today?");
        Console.ResetColor(); //reset color
    }

    static void ChatLoop()
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Green; // User question color
            Console.Write("\nYou: ");
            Console.ResetColor(); // Reset color
            string userInput = Console.ReadLine().ToLower();

            if (userInput == "exit" || userInput == "quit")
            {
                break;
            }

            string response = GetResponse(userInput);
            Console.ForegroundColor = ConsoleColor.Blue; // Bot response color
            Console.WriteLine($"Bot: {response}");
            Console.ResetColor(); // Reset color
        }
    }

    static string GetResponse(string userInput)
    {
        if (userInput.Contains("how are you"))
        {
            return "I'm doing well, thank you!";
        }
        else if (userInput.Contains("what's your purpose"))
        {
            return "My purpose is to educate you about cybersecurity and help you stay safe online.";
        }
        else if (userInput.Contains("what can i ask you"))
        {
            return "You can ask me about password safety, phishing, safe browsing, and other cybersecurity topics.";
        }
        else if (userInput.Contains("password safety"))
        {
            return "Use strong, unique passwords and consider a password manager. (Pieterse, 2021)";
        }
        else if (userInput.Contains("phishing"))
        {
            return "Be cautious of suspicious emails and links. Never share personal information unless you are certain of the site's legitimacy. (Pieterse, 2021)";
        }
        else if (userInput.Contains("safe browsing"))
        {
            return "Keep your browser updated, avoid suspicious websites, and use a reputable antivirus. ";
        }
        else if (userInput.Contains("malware"))
        {
            return "Malware is malicious software designed to harm your computer. Install antivirus software and avoid downloading files from untrusted sources.";
        }
        else if (userInput.Contains("firewall"))
        {
            return "A firewall helps protect your network by monitoring and controlling incoming and outgoing network traffic. Ensure your firewall is active.";
        }
        else if (userInput.Contains("two factor authentication") || userInput.Contains("2fa"))
        {
            return "Two-factor authentication adds an extra layer of security. Enable it wherever possible to protect your accounts.";
        }
        else if (userInput.Contains("update software"))
        {
            return "Keeping your software updated is crucial for security. Updates often include patches for known vulnerabilities.";
        }
        else if (userInput.Contains("data backup"))
        {
            return "Regularly backing up your data ensures you can recover important files in case of a system failure or cyberattack.";
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red; // Error response color
            string errorResponse = "I'm not sure how to respond to that. Could you please rephrase your question?";
            Console.ResetColor(); // Reset color
            return errorResponse;
        }
    }
}
