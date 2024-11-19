using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapGenerate : MonoBehaviour
{
    [SerializeField] private GameObject TileMap;
    [SerializeField] private List<GameObject> prefabList;

    private GameObject prefab;

    private void Awake()
    {
        GameManager.mapGenerate += GenerateMap;
    }

    public void GenerateMap(int[,] maze)
    {
        foreach (Transform child in TileMap.transform)
        {
            Destroy(child.gameObject);
        }

        var nowPos = 0;
        for (int height = 0;  height < maze.GetLength(0); height++)
        {
            for (int width = 0; width < maze.GetLength(1); width++)
            {
                nowPos = maze[height, width];

                switch (nowPos)
                {
                    case -1:
                        Debug.Log("-1이다! 빈공간이다!");
                        break;
                    case 0:
                        prefab = Instantiate(prefabList[nowPos], TileMap.transform);
                        prefab.transform.localPosition = new Vector3(1 + height * 2, -0.5f, 1 + width * 2);
                        break;
                    case 1:
                        prefab = Instantiate(prefabList[nowPos], TileMap.transform);
                        prefab.transform.localPosition = new Vector3(1 + height * 2, 3, 1 + width * 2);
                        break;
                }
                
            }
        }
    }
}
