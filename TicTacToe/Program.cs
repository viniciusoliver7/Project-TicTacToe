using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Reflection.PortableExecutable;
using System.Security.Permissions;
using TicTacToePlay;
class Program()
{   

    static void ProcessTurn(TicTacToe player)
    {
        while (true)

        {   player.ShowGame();
            Console.WriteLine($"{player.Name} select your position");
            short move = Convert.ToSByte(Console.ReadLine());
            Boolean evaluateMove  = player.Add(move);


            if(evaluateMove == false)
            {   
                Console.Clear();
                Console.WriteLine("This move is invalid , try again");
            }
            else
            {
                break;
            }         
        }

    }

    static void Main(string[] args)
    {   
        TicTacToe? Player1 = null;
        TicTacToe? Player2= null;
        byte win;

        Console.WriteLine("========= TicTacToe =========");    
    
        char IconUser='\n';
        for(byte i =1 ; i < 3 ; i++)
        {   
            Console.WriteLine($"enter the Player{i} name");
            string NameUser = Console.ReadLine();

            while (true){
                Console.WriteLine($"{NameUser} type an icon , for example [#],[!],[O],[X]");
                char aliasIcon = Convert.ToChar(Console.ReadLine().ToUpper());
                if (aliasIcon != IconUser)
                {
                    IconUser=aliasIcon;
                    break;

                }
                else
                {   
                    Console.Clear();
                    Console.WriteLine("the icon's being used , try again");
                }
                
            }

            if(i == 1)
            {
                Player1 = new TicTacToe(IconUser,NameUser);
            }
            else
            {
                Player2 = new TicTacToe(IconUser,NameUser);
            }
        }

        Console.WriteLine("GREAT ! The players were defined, type any key to start the game...");
        Console.ReadKey();


        while (true){
        while(true){
            
            Console.Clear();
            ProcessTurn(Player1);
            win = Player1.endGame();
            if (win == 2){
                Console.WriteLine($"Congratulation {Player1.Name}😀 you win the game !!");
                break;
            }
            else if (win == 1)
            {
                Console.WriteLine($" DRAW !!! ");
                break; 
            }
            
            ProcessTurn(Player2);
            win = Player2.endGame();
            if (win == 2){
                Console.WriteLine($"Congratulation {Player2.Name}😀 you win the game !!");
                break;
            }
            else if (win == 1)
            {
                Console.WriteLine($"DRAW !!! ");
                break; 
            }
        }
        Console.ReadKey();
        Console.Clear();
        Console.WriteLine($"{Player1.Name} has [{Player1.geVictories()}] victories \n{Player2.Name} has [{Player2.geVictories()}] victories");
        Console.WriteLine("\n Do you wants to continue ? type [1] \n to close type [2]");
        int keyContinue = Convert.ToInt16(Console.ReadLine());
        if (keyContinue != 1){
            break;   
        }
        else{
            Player1.restarALLGame();
            Player1.restatPlayerGame();
            Player2.restatPlayerGame();
            Console.Clear();    
            }
        }
    }
    
}
