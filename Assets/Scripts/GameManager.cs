using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private MazeGenerate mazeGenerate;

    public static Action<int[,]> mapGenerate;

    enum blocks { NONE = -1, WALL = 0, FLOOR, DOOR, INTERACTIVE }

    int[,] maze;

    private void Awake()
    {
        mazeGenerate = new MazeGenerate();
    }

    private void Start()
    {
        // 15 x 12 (행 x 열) -> C/C++이랑 순서 같음
        // maze = new int[15, 12];

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
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        };
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
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
        for (int i = 0; i < 15; i++)
        {
            for (int j = 0; j < 12; j++)
            {
                if (maze[i, j] != -1)
                {
                    Debug.Log("좌표");
                    Debug.Log(maze[i, j]);
                    if (i % 2 == 0 && j % 2 == 0)
                        maze[i, j] = 0;
                    else
                        maze[i, j] = 1;
                }
            }
        }
    }
}
