using System;

namespace OutGuess
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declaring Variables
            int guess = 0;
            int turns = 0;
            double money = 0.0;
            string playAgain;
            bool win = false;
            double roundBet = 0.0;
            int turnCount = 0;
            double roundCount = 0;
            double winCount = 0;
            int multiplier = 0;
            double winnings = 0;
            double roundWinnings = 0;
            double winRate;

            //Intro to the Game
            Console.WriteLine("Welcome to OutGuess!");
            Console.Write("Please enter how much you will be bringing to wager: $");
            money = double.Parse(Console.ReadLine());

            do
            {
                //Creating Random Number
                Random rnd_maker = new Random();
                int rndNum = 57;//rnd_maker.Next(1, 100);

                win = false;

                Console.WriteLine("You have {0:C} left to bet with at the table.", money);

                do
                {
                    Console.Write("How much do you want to bet this round: $");
                    roundBet = double.Parse(Console.ReadLine());

                    if (roundBet > money || roundBet <= 0)
                    {
                        Console.WriteLine("Invalid Bet. Try again.");
                    }


                } while (roundBet > money);

                money = money - roundBet;


                do
                {
                    Console.Write("How many guesses are you betting on? (max = 10) ");
                    turns = int.Parse(Console.ReadLine());

                    if (turns > 10 || turns < 0)
                    {
                        Console.WriteLine("Invalid. Please try again.");
                    }

                } while (turns > 10 || turns <= 0);


                turnCount = turns;

                Console.WriteLine("I've chosen a secret number between 1 and 100! Now guess it!");



                //Loop for turns
                while (turnCount > 0 && guess != rndNum)
                {
                    //User Input
                    do
                    {
                        Console.WriteLine();
                        Console.WriteLine("Enter a valid number 1-100.");
                        guess = int.Parse(Console.ReadLine());
                    } while (guess < 1 || guess > 100);

                    if (guess == rndNum)//Win Condition
                    {
                        Console.WriteLine("Congrats! You guessed my number! You Win!");
                        win = true;
                        winCount += 1;
                    }
                    else if (guess < rndNum)//Guess is too low
                    {
                        Console.WriteLine("Sorry too low! You have {0} guesses left!", turnCount - 1);
                    }
                    else if (guess > rndNum)//Guess is too high
                    {
                        Console.WriteLine("Sorry too high! You have {0} guesses left!", turnCount - 1);
                    }
                    turnCount -= 1;
                }
                if (guess != rndNum)//Lose Statement
                {
                    Console.WriteLine();
                    Console.WriteLine("You Lose! The correct number was {0}.", rndNum);

                }

                roundWinnings = 0;
                guess = 101;

                multiplier = DetermineMultiplier(turns, win);

                roundWinnings = multiplier * roundBet;

                money = money + roundWinnings;

                winnings = winnings + roundWinnings;

                roundCount += 1;

                if (roundWinnings > 0)
                {
                    Console.WriteLine("You won {0:C} this round.", roundWinnings);
                }
                else
                {
                    Console.WriteLine("You didn't win this round.");
                }

                if (money > 0)
                {
                    Console.WriteLine("Would you like to play again? (y/n) ");
                    playAgain = Console.ReadLine().ToLower().Substring(0, 1);
                }
                else playAgain = "n";

            } while (playAgain == "y" && money > 0);

            if (money <= 0) Console.WriteLine("You ran out of money.");

            //Calculating WinRate
            winRate = winCount / roundCount * 100.0;

            //Displaying Results
            Console.WriteLine("Your total winnings was: {0:C}.", winnings);

            Console.WriteLine("Your win rate was: {0:F2}%.", winRate);

            Console.WriteLine("You had {0:C} left to bet with.", money);
        }//End of Main

        //Starting Functions

        static int DetermineMultiplier(int turns, bool win)
        {
            if (turns == 10 && win == true) return 1;
            if (turns == 9 && win == true) return 2;
            if (turns == 8 && win == true) return 3;
            if (turns == 7 && win == true) return 4;
            if (turns == 6 && win == true) return 5;
            if (turns == 5 && win == true) return 6;
            if (turns == 4 && win == true) return 7;
            if (turns == 3 && win == true) return 8;
            if (turns == 2 && win == true) return 9;
            if (turns == 1 && win == true) return 10;
            else return 0;
        }

        //End of Functions
    }
}
