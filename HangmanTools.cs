using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace HangmanFun;

public class HangmanTools
{
    public string GetRandomWord()
    {
        Random random = new Random();
        string word = "";
        List<string> words = new List<string>()
        {
            "maid",
            "stranger",
            "offbeat",
            "bleach",
            "laugh"
        };
        // get a random word
        word = words[random.Next(words.Count)];
        return word;
    }

    public bool ValidGuess(string guess, string lettersGuessed)
    {
        bool result = true; // default to a valid guess

        if (guess.Length != 1) // check that it is just 1 character
        {
            Console.WriteLine("Invalid Guess: guess must be only 1 letter. Try again.");
            result = false;
        }
        else if (!Char.IsLetter(guess[0])) // check if guess is a letter
        {
            Console.WriteLine("Invalid Guess: guess needs to be a letter. Try again.");
            result = false;
        }
        else if (lettersGuessed.Contains(guess.ToLower())) // check if guess has been guessed before
        {
            Console.WriteLine("Invalid Guess: you already guessed that letter. Try again.");
            result = false;
        }
        return result;
    }

    public string UpdateWord(string lettersGuessed, string solution)
    {
        string result = "";
        for (int i = 0; i < solution.Length; i++)
        {
            if (lettersGuessed.Contains(solution[i])) // is the  guessed letter in the solution word
            {
                result += solution[i];
            }
            else
            {
                result += "_";
            }
        }
        return result;
    }
}