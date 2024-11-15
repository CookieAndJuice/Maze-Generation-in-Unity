using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private MazeGenerate mazeGenerate;

    enum blocks { NONE = -1, WALL = 0, FLOOR, DOOR, INTERACTIVE }

    List<List<int>> maze;

    private void Awake()
    {
        mazeGenerate = new MazeGenerate();
    }

    // Start is called before the first frame update
    private void Start()
    {
        // 15 x 12 (��ȿ �� �ִ밪��)                                   ��ȿ �� ��
        maze = new List<List<int>>()
        {
            new List<int> { -1, -1, 0, 0, 0, 0, 0, 0, 0, 0, -1 -1 },    // 8
            new List<int> { -1, -1, 0, 1, 1, 1, 1, 1, 1, 1, 0, -1 },    // 9
            new List<int> { 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, -1 },      // 11
            new List<int> { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },       // 12
            new List<int> { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },       // 12
            new List<int> { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, -1 },      // 11
            new List<int> { -1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, -1 },     // 10
            new List<int> { -1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, -1 },     // 10
            new List<int> { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, -1 },      // 11
            new List<int> { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },       // 12
            new List<int> { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },       // 12
            new List<int> { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },       // 12
            new List<int> { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },       // 12
            new List<int> { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },       // 12
            new List<int> { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },       // 12
        };

        mazeGenerate.GenerateMaze(maze);
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
