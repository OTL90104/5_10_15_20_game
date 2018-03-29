using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_10_15_20_game
{
    class Program
    {


        public enum Status
        {
            USERWIN,
            COMWIN
        }
        static void Main(string[] args)
        {
            int play = 0;
            while (play != 1 || play != 2)
            {
                Console.WriteLine("Do you want to play a game? (1：Yes/2：No)");
                String playAgame = Console.ReadLine();
                if (playAgame == "1")
                {
                    play = 1;
                }
                else if (playAgame == "2")
                {
                    play = 2;
                    break;
                }
                else
                {
                    play = 0;
                }
                while (play == 1)
                {
                    Random rndNum = new Random();
                    int order = rndNum.Next(0, 2);
                    int usercounter = 0;
                    int comcounter = 0;
                    int userNum1 = 0;
                    int userNum2 = 0;
                    int userAns = 0;
                    Status gameStatus = Status.USERWIN;
                    Console.WriteLine("=====GAME START=====");

                    if (order == 0)
                    {
                        gameStatus = Status.USERWIN;
                        Console.WriteLine("You First");
                    }
                    else if (order == 1)
                    {
                        gameStatus = Status.COMWIN;
                        Console.WriteLine("COM First");
                    }
                    while (!(usercounter == 2 || comcounter == 2))
                    {
                        int comNum1 = rndNum.Next(0, 2);
                        comNum1 *= 5;
                        int comNum2 = rndNum.Next(0, 2);
                        comNum2 *= 5;
                        int comAns = rndNum.Next(0, 5);
                        comAns *= 5;

                        if (gameStatus == Status.USERWIN)
                        {
                            Console.WriteLine("Please Guess");
                            Console.WriteLine("Please input left number (0/5)：");
                            userNum1 = int.Parse(Console.ReadLine());
                            Console.WriteLine("Please input right number (0/5)：");
                            userNum2 = int.Parse(Console.ReadLine());
                            Console.WriteLine("Please input the number you guess (0/5/10/15/20)：");
                            userAns = int.Parse(Console.ReadLine());
                            if ((userNum1 + userNum2 + comNum1 + comNum2) == userAns)
                            {
                                Console.WriteLine($"Your number：{userNum1}，{userNum2}");
                                Console.WriteLine($"COM's number：{comNum1}，{comNum2}");
                                Console.WriteLine($"Your answer：{userAns}");
                                Console.WriteLine("=====YOU WIN!!=====");
                                Console.WriteLine("");
                                gameStatus = Status.USERWIN;
                                usercounter++;
                                comcounter = 0;
                            }
                            else
                            {
                                Console.WriteLine($"Your number：{userNum1}，{userNum2}");
                                Console.WriteLine($"COM's number：{comNum1}，{comNum2}");
                                Console.WriteLine($"Your answer：{userAns}");
                                Console.WriteLine("=====It's COM's turn!!=====");
                                Console.WriteLine("");
                                usercounter = 0;
                                comcounter = 0;
                                gameStatus = Status.COMWIN;
                            }
                        }
                        if (gameStatus == Status.COMWIN)
                        {
                            Console.WriteLine("Computer Guess");
                            Console.WriteLine("Please input left number (0/5)：");
                            userNum1 = int.Parse(Console.ReadLine());
                            Console.WriteLine("Please input right number (0/5)：");
                            userNum2 = int.Parse(Console.ReadLine());
                            if ((userNum1 + userNum2 + comNum1 + comNum2) == comAns)
                            {
                                Console.WriteLine($"Your number：{userNum1}，{userNum2}");
                                Console.WriteLine($"COM's number：{comNum1}，{comNum2}");
                                Console.WriteLine($"COM's answer：{comAns}");
                                Console.WriteLine("=====YOU LOSE!!=====");
                                Console.WriteLine("");
                                gameStatus = Status.COMWIN;
                                usercounter = 0;
                                comcounter++;
                            }
                            else
                            {
                                Console.WriteLine($"Your number：{userNum1}，{userNum2}");
                                Console.WriteLine($"COM's number：{comNum1}，{comNum2}");
                                Console.WriteLine($"COM's answer：{comAns}");
                                Console.WriteLine("=====It's your turn!!=====");
                                Console.WriteLine("");
                                usercounter = 0;
                                comcounter = 0;
                                gameStatus = Status.USERWIN;
                            }
                        }
                        if (usercounter == 2)
                        {
                            Console.WriteLine("******MISSION COMPLETED!!!******");
                            play = 0;
                        }
                        else if (comcounter == 2)
                        {
                            Console.WriteLine("******GAME OVER!!!******");
                            play = 0;
                        }
                    }
                }
            }
            Console.WriteLine("");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
