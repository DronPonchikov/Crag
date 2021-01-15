using System;
using System.Collections.Generic;
using System.Threading;

namespace Crag
{
    class Dice
    {

        public static int score = 0;
        public int[,] matrix = new int[10, 10];

        public int X0; // coordinates of dices
        public int Y0;
        public Dice(int x, int y)
        {
            X0 = x;
            Y0 = y;
        }
        public int Value { get; set; }
        public int ThrowDice()
        {

            Random r = new Random();
            Value = r.Next(1, 7);

            //Console.WriteLine(Value+" " );

            return Value;

        }
        public void PrintDice()
        {
            switch (Value)
            {
                case 1:

                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            matrix[i, j] = 0;
                            if ((i == 4 || i == 5)
                                && (j == 4 || j == 5))
                            {
                                matrix[i, j] = 1;
                            }

                        }
                    }


                    break;
                case 2:

                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            matrix[i, j] = 0;
                            if (((i == 1 || i == 2)
                                && (j == 1 || j == 2))
                                || ((i == 7 || i == 8)
                                && (j == 7 || j == 8)))
                            {
                                matrix[i, j] = 1;
                            }

                        }
                    }

                    break;
                case 3:

                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            matrix[i, j] = 0;
                            if (((i == 4 || i == 5)
                                && (j == 4 || j == 5))
                                || ((i == 1 || i == 2)
                                && (j == 1 || j == 2))
                                || ((i == 7 || i == 8)
                                && (j == 7 || j == 8)))
                            {
                                matrix[i, j] = 1;
                            }

                        }
                    }

                    break;
                case 4:

                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            matrix[i, j] = 0;
                            if (((i == 7 || i == 8) && (j == 1 || j == 2))
                                || ((i == 1 || i == 2) && (j == 1 || j == 2))
                                || ((i == 7 || i == 8) && (j == 7 || j == 8))
                                || ((i == 1 || i == 2) && (j == 7 || j == 8)))
                            {
                                matrix[i, j] = 1;
                            }

                        }
                    }

                    break;
                case 5:

                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            matrix[i, j] = 0;
                            if (((i == 4 || i == 5) && (j == 4 || j == 5))
                                || ((i == 7 || i == 8) && (j == 1 || j == 2))
                                || ((i == 1 || i == 2) && (j == 1 || j == 2))
                                || ((i == 7 || i == 8) && (j == 7 || j == 8))
                                || ((i == 1 || i == 2) && (j == 7 || j == 8)))
                            {
                                matrix[i, j] = 1;
                            }

                        }
                    }

                    break;
                case 6:

                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            matrix[i, j] = 0;
                            if (((i == 7 || i == 8) && (j == 1 || j == 2))
                                || ((i == 1 || i == 2) && (j == 1 || j == 2))
                                || ((i == 7 || i == 8) && (j == 7 || j == 8))
                                || ((i == 1 || i == 2) && (j == 7 || j == 8))
                                || ((i == 4 || i == 5) && (j == 1 || j == 2))
                                || ((i == 4 || i == 5) && (j == 7 || j == 8)))
                            {
                                matrix[i, j] = 1;
                            }

                        }
                    }

                    break;
            }

            for (int i = 0; i < 10; i++)
            {


                for (int j = 0; j < 10; j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }

                    Console.SetCursorPosition(X0 + 2 * j, Y0 + i);
                    Console.Write("  ");

                }
            }

            Console.BackgroundColor = ConsoleColor.Black;


        }

    }
    class Program
    {
        public static int[] dice_values = new int[3];
        public static List<string> categoryVocabular = new List<string>(13) { "1", "2", "3", "4", "5", "6", "13", "even", "odd", "low", "high", "same", "crag" };
        
        static void Main(string[] args)
        {
            Console.WindowHeight = Console.LargestWindowHeight;
            Console.WindowWidth = Console.LargestWindowWidth;
            int round = 0;

            Dice dice1 = new Dice(15, 15);
            Dice dice2 = new Dice(40, 15);
            Dice dice3 = new Dice(65, 15);
            while (round != 13)
            {
                ShowInfo();
                dice_values[0] = dice1.ThrowDice();
                dice1.PrintDice();
                dice_values[1] = dice2.ThrowDice();
                dice2.PrintDice();
                dice_values[2] = dice3.ThrowDice();
                dice3.PrintDice();
                Reroll(dice1, dice2, dice3);
                CategoryChecker();
                Thread.Sleep(2000);
                round++;
                Console.Clear();
                
            }


            Console.ReadLine();
        }

        private static void ShowInfo()
        {
            Legend();
            Console.SetCursorPosition(90, 5);
            Console.WriteLine("Available categories of counting:");
            for (int i = 0; i < categoryVocabular.Count; i++)
            {
                Console.SetCursorPosition(90, 6 + i);
                Console.WriteLine(categoryVocabular[i]);
            }
            Console.SetCursorPosition(45, 27);
            Console.WriteLine($"Score is {Dice.score}");
        }

        private static void Legend()
        {

            string[] legend = {
            "You can play each category only once in game",
                "1 - summ of combination of num 1",
                "2 - summ of combination of num 2",
                "3 - summ of combination of num 3 ",
                "4 - summ of combination of num 4 ",
                "5 - summ of combination of num 5",
                "6 - summ of combination of num 6",
                "13 - any combination totalling 13 = 26 points",
                "even - 2-4-6 = 20 points",
                "odd - 1-3-5 = 20 points",
                "low - 1-2-3 = 20 points",
                "high - 4-5-6 = 20 points",
                "same - three dice showing the same face = 25 points",
                "crag - any combination containing a pair and totalling 13 = 50 points",
                "If a category is chosen but the dice do not match the requirements" ,
                "of the category the player scores 0 in that category",
               "The maximum possible score is 244."};
            for (int i = 0; i < legend.Length; i++)
            {
                Console.SetCursorPosition(130, 5 + i);
                Console.Write(legend[i]);
            }
            Console.WriteLine();

        }

        private static void CategoryChecker() 
        {
            string category;

            Console.SetCursorPosition(15, 13);

            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Choose the category of counting");
            Console.BackgroundColor = ConsoleColor.Black;
            do
            {
                category = Console.ReadLine().ToLower();
            } while (!categoryVocabular.Contains(category));          
                if (categoryVocabular.Contains(category))
                {

                    switch (category)
                    {

                        case "1":
                            for (int y = 0; y < 3; y++)
                            {
                                if (dice_values[y] == 1)
                                {
                                    Dice.score += dice_values[y];
                                }

                            }
                            break;
                        case "2":
                            for (int y = 0; y < 3; y++)
                            {

                                if (dice_values[y] == 2)
                                {
                                    Dice.score += dice_values[y];
                                }

                            }

                            break;
                        case "3":
                            for (int y = 0; y < 3; y++)
                            {
                                if (dice_values[y] == 3)
                                {
                                    Dice.score += dice_values[y];
                                }

                            }

                            break;
                        case "4":
                            for (int y = 0; y < 3; y++)
                            {
                                if (dice_values[y] == 4)
                                {
                                    Dice.score += dice_values[y];
                                }

                            }

                            break;
                        case "5":
                            for (int y = 0; y < 3; y++)
                            {
                                if (dice_values[y] == 5)
                                {
                                    Dice.score += dice_values[y];
                                }

                            }
                            break;
                        case "6":
                            for (int y = 0; y < 3; y++)
                            {
                                if (dice_values[y] == 6)
                                {
                                    Dice.score += dice_values[y];
                                }

                            }

                            break;
                        case "low":



                            if ((dice_values[0] == 1 || dice_values[0] == 2 || dice_values[0] == 3)
                                && ((dice_values[1] == 1 || dice_values[1] == 2 || dice_values[1] == 3)
                                && dice_values[1] != dice_values[0]) //not equal to first
                                && ((dice_values[2] == 1 || dice_values[2] == 2 || dice_values[2] == 3)
                                && (dice_values[2] != dice_values[0] && dice_values[2] != dice_values[1]))) // not equal to first and second
                            {
                                Dice.score += 20;
                            }


                            break;
                        case "high":



                            if ((dice_values[0] == 4 || dice_values[0] == 5 || dice_values[0] == 6)
                                && ((dice_values[1] == 4 || dice_values[1] == 5 || dice_values[1] == 6)
                                && dice_values[1] != dice_values[0]) //not equal to first
                                && ((dice_values[2] == 4 || dice_values[2] == 5 || dice_values[2] == 6)
                                && (dice_values[2] != dice_values[0] && dice_values[2] != dice_values[1]))) // not equal to first and second
                            {
                                Dice.score += 20;
                            }


                            break;
                        case "even":



                            if ((dice_values[0] == 4 || dice_values[0] == 2 || dice_values[0] == 6)
                                && ((dice_values[1] == 4 || dice_values[1] == 2 || dice_values[1] == 6)
                                && dice_values[1] != dice_values[0]) //not equal to first
                                && ((dice_values[2] == 4 || dice_values[2] == 2 || dice_values[2] == 6)
                                && (dice_values[2] != dice_values[0] && dice_values[2] != dice_values[1]))) // not equal to first and second
                            {
                                Dice.score += 20;
                            }


                            break;
                        case "odd":



                            if ((dice_values[0] == 1 || dice_values[0] == 5 || dice_values[0] == 3)
                                && ((dice_values[1] == 1 || dice_values[1] == 5 || dice_values[1] == 3)
                                && dice_values[1] != dice_values[0]) //not equal to first
                                && ((dice_values[2] == 1 || dice_values[2] == 5 || dice_values[2] == 3)
                                && (dice_values[2] != dice_values[0] && dice_values[2] != dice_values[1]))) // not equal to first and second
                            {
                                Dice.score += 20;
                            }


                            break;
                        case "same":


                            if ((dice_values[0] == dice_values[1]) && (dice_values[1] == dice_values[2]))
                            {
                                Dice.score += 25;

                            }

                            break;
                        case "13":


                            if (dice_values[0] + dice_values[1] + dice_values[2] == 13)
                            {
                                Dice.score += 26;

                            }

                            break;
                        case "crag":


                            if (((dice_values[0] == dice_values[1])
                                || (dice_values[1] == dice_values[2])
                                || (dice_values[0] == dice_values[2]))
                                && (dice_values[0] + dice_values[1] + dice_values[2] == 13))
                            {
                                Dice.score += 50;

                            }

                            break;
                          

                    }


                    categoryVocabular.Remove(category);

                }
              

        }

        public static void Reroll(Dice dice1, Dice dice2, Dice dice3)
        {
            Console.SetCursorPosition(15, 5);
            Console.WriteLine("Which dice you'd like to reroll? (1, 2, 3, 12, 13, 23, 123)");
            Console.SetCursorPosition(15, 6);
            Console.WriteLine("If none -- press Enter");

            string rerollingDice = Console.ReadLine();

            while (rerollingDice != "1" || rerollingDice != "2" || rerollingDice != "3" || rerollingDice != "12" || rerollingDice != "13" || rerollingDice != "23" || rerollingDice != "123" || rerollingDice != "")
            {

                if (rerollingDice == "1")
                {
                    dice_values[0] = dice1.ThrowDice();
                    dice1.PrintDice();
                    break;

                }
                else if (rerollingDice == "2")
                {

                    dice_values[1] = dice2.ThrowDice();
                    dice2.PrintDice();
                    break;

                }
                else if (rerollingDice == "3")
                {
                    dice_values[2] = dice3.ThrowDice();
                    dice3.PrintDice();
                    break;
                }
                else if (rerollingDice == "12")
                {
                    dice_values[0] = dice1.ThrowDice();
                    dice_values[1] = dice2.ThrowDice();
                    dice1.PrintDice();
                    dice2.PrintDice();
                    break;

                }
                else if (rerollingDice == "23")
                {
                    dice_values[1] = dice2.ThrowDice();
                    dice_values[2] = dice3.ThrowDice();
                    dice2.PrintDice();
                    dice3.PrintDice();
                    break;

                }
                else if (rerollingDice == "13")
                {
                    dice_values[0] = dice1.ThrowDice();
                    dice_values[2] = dice3.ThrowDice();
                    dice1.PrintDice();
                    dice3.PrintDice();
                    break;

                }
                else if (rerollingDice == "123")
                {
                    dice_values[0] = dice1.ThrowDice();
                    dice_values[1] = dice2.ThrowDice();
                    dice_values[2] = dice3.ThrowDice();
                    dice1.PrintDice();
                    dice2.PrintDice();
                    dice3.PrintDice();
                    break;

                }
                else if (rerollingDice == "")
                {
                    Console.SetCursorPosition(15, 12);
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Playing without reroll");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

                }
                if (rerollingDice != "1" || rerollingDice != "2" || rerollingDice != "3" || rerollingDice != "12" || rerollingDice != "13" || rerollingDice != "23" || rerollingDice != "123" || rerollingDice != "")
                {
                    Console.SetCursorPosition(16, 12);

                    Console.WriteLine("Input correct dice num");
                    rerollingDice = Console.ReadLine();

                }

            }





        }
    }
}