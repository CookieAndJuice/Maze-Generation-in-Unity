using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private MazeGenerate mazeGenerate;

    enum blocks { NONE = -1, WALL = 0, FLOOR, DOOR, INTERACTIVE }

    int[,] maze;

    private void Awake()
    {
        mazeGenerate = new MazeGenerate();
    }

    // Start is called before the first frame update
    private void Start()
    {
        // 12 x 15 (За x ї­)
        maze = new int[12, 15];

        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 15; j++)
            {
                if (i % 2 == 0)
                    maze[i, j] = 0;
                else
                    maze[i, j] = 1;
            }
        }

        mazeGenerate.GenerateMaze(maze);
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
