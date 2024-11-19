using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerate
{
    public int[,] GenerateMaze (int[,] map)
    {
        int[,] maze = (int[,]) map.Clone();
        int[,] visited = (int[,])map.Clone();
        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, 1, -1 };
        int[] directionOrder = { 0, 1, 2, 3 };      // 탐색 방향 순서

        // 미로 가로, 세로 길이
        int mazeWidth = maze.GetLength(1);
        int mazeHeight = maze.GetLength(0);

        // 시작점, 끝점
        var startPos = (0, 0);
        var endPos = (mazeWidth - 1, mazeHeight - 1);

        // 좌표 임시 저장할 변수들
        var nowPos = (0, 0);
        var stackTopPos = (0, 0);

        // DFS 스택
        var recursiveStack = new Stack<(int, int)>();
        recursiveStack.Push(startPos);
        visited[startPos.Item2, startPos.Item1] = 1;

        while(recursiveStack.Count != 0)
        {
            nowPos = recursiveStack.Pop();      // 현재 위치
            visited[nowPos.Item2, nowPos.Item1] = 1;
            
            ShuffleArray(directionOrder);           // 탐색 방향 순서 섞기

            for (int i = 0; i < 4; i++)
            {
                var visitPos = (nowPos.Item1 + dx[directionOrder[i]]*2, nowPos.Item2 + dy[directionOrder[i]]*2);

                // 맵 범위 내에 있는지 확인
                if (visitPos.Item1 >= 0 && visitPos.Item2 >= 0 && visitPos.Item1 < mazeWidth && visitPos.Item2 < mazeHeight)
                {
                    // 방문 여부 확인
                    if (visited[visitPos.Item2, visitPos.Item1] == 0)
                    {
                        recursiveStack.Push(nowPos);
                        recursiveStack.Push(visitPos);
                        break;
                    }
                }
            }

            // 방문 예정 스택에 새로 추가한 것이 아니라 이전에 방문했던 블럭이 있다면 통로 만들어주기
            if (recursiveStack.Count != 0)
            {
                stackTopPos = recursiveStack.Peek();
                
                if (visited[stackTopPos.Item2, stackTopPos.Item1] == 1)
                {
                    var tempPos = ((nowPos.Item1 + stackTopPos.Item1) / 2, (nowPos.Item2 + stackTopPos.Item2) / 2);
                    maze[tempPos.Item2, tempPos.Item1] = 0;
                }
            }
        }

        // 문으로 향하는 부분 길 뚫어주기
        if (maze[endPos.Item2, endPos.Item1] == 1)
            maze[endPos.Item2, endPos.Item1] = 0;

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
