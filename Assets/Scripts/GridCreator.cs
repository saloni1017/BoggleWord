using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GridCreator : MonoBehaviour
{
    [System.Serializable]
    public class GridSize
    {
        public int x; // Columns
        public int y; // Rows
    }
    [System.Serializable]
    public class Tile
    {
        public int tileType;
        public string letter;
    }

    [System.Serializable]
    public class GridData
    {
        public int bugCount;
        public int wordCount;
        public int timeSec;
        public int totalScore;
        public GridSize gridSize;
        public List<Tile> gridData;
    }

    [System.Serializable]
    public class RootObject
    {
        public List<GridData> data;
    }
    private int row = 4;
    private int col = 4;
    public GameObject gridPrefeb;
    private int spacing = 220;
    public GameObject parent;
    private string json;
    RootObject root;
    private bool IsInitialised = false;
    // Start is called before the first frame update
    void Start()
    {
        string filePath = "C:\\My project (1)\\Assets\\LevelData.json";
        json = File.ReadAllText(filePath);
        root = JsonUtility.FromJson<RootObject>(json);
        IsInitialised = false;
        CreateGrid();
    }

    void CreateGrid()
    {
        //for (int i = 0; i < rows; i++)
        //{
        //    for (int j = 0; j < columns; j++)
        //    {
        //        Vector3 position = new Vector3(j * spacing, i * spacing, 0);

        //        var tile = Instantiate(gridPrefeb, position, Quaternion.identity);
        //        tile.transform.SetParent(parent.transform);
        //    }
        //}
        foreach (var grid in root.data)
        {
            int totalTiles = grid.gridSize.x * grid.gridSize.y;
            int rows = grid.gridSize.y;
            int cols = grid.gridSize.x;
            string[,] rowCol = new string[rows, cols];
            if (row == rows && col == cols)
            {
                for (int i = 0; i < grid.gridData.Count; i++)
                {
                    rowCol[i / col, i % col] = grid.gridData[i].letter;
                }
            }
            if (row == rows && col == cols && !IsInitialised)
            {
                IsInitialised = true;
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        Vector3 position = new Vector3(j * spacing, i * spacing, 0);

                        var tile = Instantiate(gridPrefeb, position, Quaternion.identity);
                        tile.GetComponentInChildren<TextMeshProUGUI>().text = rowCol[i,j];
                        tile.transform.SetParent(parent.transform);
                    }
                }
            }
        }
    }
}
