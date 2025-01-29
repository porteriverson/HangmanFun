//  think of a word (get a random word)
// get the guess from the player
// check to see if the guess is valid. (not a number, only one letter, hasn't been guessed before)
// check to see if the letter is in the word
    // if yes, update the blanks to actual letters
    // if not, keep track of how many missed guesses (6 total wrong guesses)
// Let them know if they have won or lost
// Game flow    

using HangmanFun;

HangmanTools ht = new HangmanTools();
string solution = "";
string guess = "";
string lettersGuessed = "";
bool gameOver = false;
int incorrectGuesses = 0;

// Welcome the User
Console.WriteLine("Welcome to our Hangman simulation! Good Luck");

// Get the random word for the user to guess
Console.Write("Generating a random word");
Thread.Sleep(800);
Console.Write(".");
Thread.Sleep(800);
Console.Write(".");
Thread.Sleep(800);
Console.Write(".");

solution = ht.GetRandomWord();

Console.WriteLine();
Console.WriteLine("Alright, word is generated");

do
{
    // Get the users guess and validate it
    Console.WriteLine("Please enter a letter");
    do
    {
        guess = Console.ReadLine();
    } 
    while (!ht.ValidGuess(guess, lettersGuessed));
    
    lettersGuessed += guess; // update the list of letters guessed
    
    // Check if the letter is in the word
    if (solution.Contains(guess.ToLower()))
    {
        Console.WriteLine($"Yes, the letter {guess} is in the word!");
        Console.WriteLine("Word: " + ht.UpdateWord(lettersGuessed, solution));
        if (ht.UpdateWord(lettersGuessed, solution) == solution)
        {
            Console.WriteLine("Congratulations! You guessed the word!");
            Console.WriteLine($"The word was {solution}");
            gameOver = true;
        }
        
    }
    else // if the guess is incorrect, increment incorrect Guesses
    {
        Console.WriteLine($"Sorry, '{guess}' is not in the word!");
        incorrectGuesses++;

        if (incorrectGuesses < 6)
        {
            Console.WriteLine($"You have {6 - incorrectGuesses} guesses remaining.");
        }
        if (incorrectGuesses >= 6)
        {
            Console.WriteLine($"Sorry, you lost");
            Console.WriteLine($"The word was {solution}");
            gameOver = true;
        }
    }
} while (!gameOver && incorrectGuesses < 6);

Console.WriteLine("thank you for playing, please come again!");


