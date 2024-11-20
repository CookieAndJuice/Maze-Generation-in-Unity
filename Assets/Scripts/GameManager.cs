using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private MazeGenerate mazeGenerate;

    public static Action<int[,]> mapGenerate;

    int[,] maze;
    int mazeWidth;
    int mazeHeight;

    private void Awake()
    {
        mazeGenerate = new MazeGenerate();
        mazeWidth = 12;
        mazeHeight = 15;
    }

    private void Start()
    {
        // 15 x 12 (행 x 열) -> C/C++이랑 순서 같음
        // maze = new int[mazeHeight, mazeWidth];

        maze = new int[,]
        {
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, -1 },
            { -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, -1 },
            { -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { -1, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { -1, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { -1, -1, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { -1, -1, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { -1, -1, -1, 0, 0, 0, 0, 0, -1, -1, 0, 0 },
            { -1, -1, -1, 0, 0, 0, 0, 0, -1, -1, 0, 0 },
            { -1, -1, 0, 0, 0, 0, 0, 0, -1, -1, -1, -1 },
            { -1, -1, 0, 0, 0, 0, 0, 0, -1, -1, -1, -1 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
        };
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            InitializeMaze();

            Debug.Log("GenerateMaze!");
            maze = mazeGenerate.GenerateMaze(maze);
            mapGenerate(maze);
        }
    }

    private void InitializeMaze()
    {
        // 직사각형
        for (int i = 0; i < mazeHeight; i++)
        {
            for (int j = 0; j < mazeWidth; j++)
            {
                if (maze[i, j] != -1)
                {
                    if (i % 2 == 0 && j % 2 == 0)
                        maze[i, j] = 0;
                    else
                        maze[i, j] = 1;
                }
            }
        }
    }
}
