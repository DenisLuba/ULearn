using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth;

internal static class Run
{
    public static void TraversingInDepth(Maze labyrinth)
    {
        var stack = new Stack<Point>();
        stack.Push(new Point { X = 0, Y = 0 });

        while (stack.Count > 0)
        {
            labyrinth.Iteration(stack);
        }
    }

    public static void TraversingInWidth(Maze labyrinth)
    {
        var queue = new Queue<Point>();
        queue.Enqueue(new Point { X = 0, Y = 0 });

        while (queue.Count > 0)
        {
            labyrinth.Iteration(queue);
        }
    }

    static void Iteration(this Maze labyrinth, ICollection collection)
    {
        Point? point = collection switch
        {
            Queue<Point> queue => queue.Dequeue() as Point ,
            Stack<Point> stack => stack.Pop() as Point,
            _ => throw new NotImplementedException()
        };

        if (point is null
            || point.X < 0
            || point.X >= labyrinth.labyrinthState.GetLength(0)
            || point.Y < 0
            || point.Y >= labyrinth.labyrinthState.GetLength(1)) return;

        if (labyrinth.labyrinthState[point.X, point.Y] != State.Empty) return;

        labyrinth.labyrinthState[point.X, point.Y] = State.Visited;

        labyrinth.Print();

        for (var dy = -1; dy <= 1; dy++)
        {
            for (var dx = -1; dx <= 1; dx++)
            {
                if (Math.Abs(dx) + Math.Abs(dy) != 1) continue;

                switch (collection)
                {
                    case Queue<Point> queue: 
                        queue.Enqueue(new Point { X = point.X + dx, Y = point.Y + dy });
                        collection = queue;
                        break;
                    case Stack<Point> stack: 
                        stack.Push(new Point { X = point.X + dx, Y = point.Y + dy });
                        collection = stack;
                        break;
                }
                
            }
        }
    }
}
