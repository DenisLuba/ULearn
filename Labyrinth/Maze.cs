using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth;

internal class Maze
{
    public State[,] labyrinthState;

    string[] labyrinth =
    {
        " X   X    ",
        " X XXXXX X",
        "      X   ",
        "XXXX XXX X",
        "         X",
        " XXX XXXXX",
        " X        ",
    };

    public Maze()
    {
        labyrinthState = new State[labyrinth[0].Length, labyrinth.Length];

        for (int x = 0; x < labyrinthState.GetLength(0); x++)
        {
            for (int y = 0; y < labyrinthState.GetLength(1); y++)
            {
                labyrinthState[x, y] = labyrinth[y][x] == ' ' ? State.Empty : State.Wall;
            }
        }
    }

    public void Print()
    {
        Console.CursorLeft = 0;
        Console.CursorTop = 0;

        for (int x = 0; x < labyrinthState.GetLength(0) + 2; x++)
            Console.Write('X');
        
        Console.WriteLine();

        for (int y = 0; y < labyrinthState.GetLength(1); y++)
        {
            Console.Write('X');

            for (int x = 0; x < labyrinthState.GetLength(0); x++)
            {
                switch (labyrinthState[x, y])
                {
                    case State.Wall: Console.Write('X'); break;
                    case State.Empty: Console.Write(' '); break;
                    case State.Visited: Console.Write('.'); break;
                }
            }
            Console.WriteLine('X');
        }

        for (int x = 0; x < labyrinthState.GetLength(0) + 2; x++)
            Console.Write('X');
    }
}
