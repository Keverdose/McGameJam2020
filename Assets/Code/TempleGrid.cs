using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempleGrid : MonoBehaviour
{
    public List<List<GameObject>> grid;
    public GameObject tilePrefab;
    public int Height;
    public int Length;
    public int TileSize;

    // Start is called before the first frame update
    void Start()
    {
        //Quick implementation of the grid
        grid = new List<List<GameObject>>();
        for (int i = 0; i < Height; i++)
        {
            grid.Add(new List<GameObject>());
            for (int j = 0; j < Length; j++)
            {
                Vector3 gridOffset = new Vector3(transform.position.x, 0, transform.position.z);
                GameObject tile = (GameObject)Instantiate(tilePrefab, new Vector3(i, 0, j) + gridOffset, Quaternion.identity);
                grid[i].Add(tile);
            }
            grid.Add(grid[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
