﻿using Board;
using Chess;

namespace ChessGame_Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessMatch match = new ChessMatch();

                while (!match.Ended)
                {
                    try
                    {
                        Console.Clear();
                        Screen.PrintMatch(match);

                        Console.WriteLine();
                        Console.Write("Origin: ");
                        Position origen = Screen.ReadChessPosition().ToPosition();
                        match.ValidaeOriginPosition(origen);

                        bool[,] possiblePositions = match.Board.Piece(origen).PossibleMovements();

                        Console.Clear();
                        Screen.PrintBoard(match.Board, possiblePositions);

                        Console.WriteLine();
                        Console.Write("Destination: ");
                        Position destination = Screen.ReadChessPosition().ToPosition();
                        match.ValidaeDesinationPos(origen, destination);

                        match.MakeAMove(origen, destination);
                    }
                    catch (BoardExcepition e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                Screen.PrintMatch(match);

            }
            catch (BoardExcepition e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();
        }
    }
}