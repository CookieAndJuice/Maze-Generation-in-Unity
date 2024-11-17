using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerate
{
    public int[,] GenerateMaze (int[,] map)
    {
        int[,] maze = (int[,]) map.Clone();
        int[,] visited = (int[,])map.Clone();
        int[] dx = { -2, 2, 0, 0 };
        int[] dy = { 0, 0, 2, -2 };
        int[] directionOrder = { 0, 1, 2, 3 };      // 탐색 방향 순서

        int mazeWidth = maze.GetLength(1);
        int mazeHeight = maze.GetLength(0);
        var startPos = (0, 0);
        var endPos = (mazeWidth - 1, mazeHeight - 1);

        var recursiveStack = new Stack<(int, int)>();
        recursiveStack.Push(startPos);
        visited[startPos.Item2, startPos.Item1] = 1;

        while(recursiveStack.Count != 0)
        {
            var nowPos = recursiveStack.Pop();      // 현재 위치
            Debug.Log(nowPos);
            ShuffleArray(directionOrder);           // 탐색 방향 순서 섞기

            for (int i = 0; i < 4; i++)
            {
                var visitPos = (nowPos.Item1 + dx[directionOrder[i]], nowPos.Item2 + dy[directionOrder[i]]);

                if (visitPos.Item1 >= 0 && visitPos.Item2 >= 0 && visitPos.Item1 < mazeWidth && visitPos.Item2 < mazeHeight)
                {
                    if (visited[visitPos.Item2, visitPos.Item1] == 0)
                    {
                        recursiveStack.Push(nowPos);
                        recursiveStack.Push(visitPos);
                        visited[visitPos.Item2, visitPos.Item1] = 1;
                    }
                }
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
