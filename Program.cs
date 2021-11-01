using System;

Board board = new Board();
Player player1 = new Player(Symbol.X);
Player player2 = new Player(Symbol.O);
int input;
int turnNumber = 1;
board.PrintBoard();

while (true)
{
    
    Player currentTurn = player1;
    MakeMove(currentTurn);
    Console.Clear();
    board.PrintBoard();
    if (board.CheckWin(currentTurn))
    {
        Console.WriteLine($"{ currentTurn.Icon} Wins!");
        return;
    }
    if (turnNumber > 9) break;
    currentTurn = player2;
    MakeMove(currentTurn);
    Console.Clear();
    board.PrintBoard();
    if (board.CheckWin(currentTurn))
    {
        Console.WriteLine($"{ currentTurn.Icon} Wins!");
        return;
    }
    if (turnNumber > 9) break;

}

void MakeMove(Player currentTurn)
{
    while (true)
    {
        Console.WriteLine($"\n{currentTurn.Icon} - Where do you want to play?");
        input = Convert.ToInt32(Console.ReadLine());
        if (board.CheckMove(currentTurn, input)) break;
        else continue;
    }
    turnNumber++;
}

Console.WriteLine("Its a Tie!");





public class Board
{
    public Symbol[,] Cell = new Symbol[3, 3];

    public void PrintBoard()
    {
        for (int i = 0; i < Cell.GetLength(0); i++)
        {
            if (i == 1 | i == 2) Console.WriteLine("---------------");
            for (int j = 0; j < Cell.GetLength(1); j++)
            {
                if (j == 2) Console.WriteLine(Cell[i, j]);
                else Console.Write(" " + Cell[i, j] + " " + " | ");
            }
        }
    }

    public bool CheckMove(Player currentTurn, int input)
    {
        
            if (input == 7 && Cell[0, 0] == Symbol.E)
            {
                Cell[0, 0] = currentTurn.Icon;
                return true;
            }
            else if (input == 8 && Cell[0, 1] == Symbol.E)
            {
                Cell[0, 1] = currentTurn.Icon;
                return true;
        }
            else if (input == 9 && Cell[0, 2] == Symbol.E)
            {
                Cell[0, 2] = currentTurn.Icon;
                return true;
        }
            else if (input == 4 && Cell[1, 0] == Symbol.E)
            {
                Cell[1, 0] = currentTurn.Icon;
                return true;
        }
            else if (input == 5 && Cell[1, 1] == Symbol.E)
            {
                Cell[1, 1] = currentTurn.Icon;
                return true;
        }
            else if (input == 6 && Cell[1, 2] == Symbol.E)
            {
                Cell[1, 2] = currentTurn.Icon;
                return true;
        }
            else if (input == 1 && Cell[2, 0] == Symbol.E)
            {
                Cell[2, 0] = currentTurn.Icon;
                return true;
        }
            else if (input == 2 && Cell[2, 1] == Symbol.E)
            {
                Cell[2, 1] = currentTurn.Icon;
                return true;
        }
            else if (input == 3 && Cell[2, 2] == Symbol.E)
            {
                Cell[2, 2] = currentTurn.Icon;
                return true;
        }
            else
            {
                Console.WriteLine("Invalid Move. Try Again");
                return false;
            }
        
        


        
    }


    public bool CheckWin(Player currentTurn)
    {
        // Check Row
        if (Cell[0, 0] == currentTurn.Icon && Cell[0, 1] == currentTurn.Icon && Cell[0, 2] == currentTurn.Icon) return true;
        if (Cell[1, 0] == currentTurn.Icon && Cell[1, 1] == currentTurn.Icon && Cell[1, 2] == currentTurn.Icon) return true;
        if (Cell[2, 0] == currentTurn.Icon && Cell[2, 1] == currentTurn.Icon && Cell[2, 2] == currentTurn.Icon) return true;

        //Check Column
        if (Cell[0, 0] == currentTurn.Icon && Cell[1, 0] == currentTurn.Icon && Cell[2, 0] == currentTurn.Icon) return true;
        if (Cell[0, 1] == currentTurn.Icon && Cell[1, 1] == currentTurn.Icon && Cell[2, 1] == currentTurn.Icon) return true;
        if (Cell[0, 2] == currentTurn.Icon && Cell[1, 2] == currentTurn.Icon && Cell[2, 2] == currentTurn.Icon) return true;

        //Check Diagonals
        if (Cell[0, 0] == currentTurn.Icon && Cell[1, 1] == currentTurn.Icon && Cell[2, 2] == currentTurn.Icon) return true;
        if (Cell[2, 0] == currentTurn.Icon && Cell[1, 1] == currentTurn.Icon && Cell[0, 2] == currentTurn.Icon) return true;

        else return false;
        
    }
}

public class Player
{
    public Symbol Icon { get;}

    public Player(Symbol icon)
    {
        Icon = icon;
    }
    

}


public enum Symbol { E, X, O }
