using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerate
{
    public List<List<int>> GenerateMaze (List<List<int>> map)
    {
        List<List<int>> maze = new List<List<int>>(map);
        int[] dx = { -2, 2, 0, 0 };
        int[] dy = { 0, 0, 2, -2 };
        int[] directionOrder = { 0, 1, 2, 3 };

        int mazeWidth = maze[0].Count;
        int mazeHeight = maze.Count;
        var startPos = (0, 0);
        var endPos = (mazeWidth - 1, mazeHeight - 1);

        var recursiveQueue = new Queue<(int, int)>();
        recursiveQueue.Enqueue(startPos);

        while(recursiveQueue.Count != 0)
        {
            var nowPos = recursiveQueue.Dequeue();
            ShuffleArray(directionOrder);

            for (int i = 0; i < 4; i++)
            {
                var visitPos = (nowPos.Item1 + dx[directionOrder[i]], nowPos.Item2 + dy[directionOrder[i]]);

                Debug.Log(visitPos);
            }
        }

        return maze;
    }

    // Fisher-Yates Shuffle
    private void ShuffleArray<T>(T[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            var randomIndex = Random.Range(i, array.Length);
            Swap(array, i, randomIndex);
        }
    }

    private void Swap<T>(T[] array, int a, int b)
    {
        var temp = array[a];
        array[a] = array[b];
        array[b] = temp;
    }
}
