using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class TempleGrid : MonoBehaviour
{
    [SerializeField]
    public TextAsset csvFile;

	
	public List<List<GameObject>> grid;
    public GameObject emptyTilePrefab;
	public GameObject startTilePrefab;
	public GameObject endTilePrefab;
	public GameObject fireTilePrefab;
	public GameObject arrowTilePrefab;
	public GameObject staticBoulderTilePrefab;
	public int Height;
    public int Length;
    public int TileSize;


	

	// Start is called before the first frame update
	void Start()
    {
		string[,] importGrid = SplitCsvGrid(csvFile.text);
		Height = importGrid.GetUpperBound(1) - 1;
		Length = importGrid.GetUpperBound(0) - 1;
		//Quick implementation of the grid

		grid = new List<List<GameObject>>();
		for (int i = 0; i < Height; i++)	
		{
			
		    grid.Add(new List<GameObject>());
			var row = grid[i];
		    for (int j = 0; j < Length; j++)
		    {
		        Vector3 gridOffset = new Vector3(transform.position.x, 0, transform.position.z);
				GameObject tile;
				string ch = importGrid[j, i];
				Vector3 tilePosition = new Vector3(j, 0, Length - i - 1) + gridOffset;

				// Empty block type
				if (ch == "0")
                {
					 tile = (GameObject)Instantiate(emptyTilePrefab, tilePosition, Quaternion.identity);
				}
				// Fire block type
				else if (ch == "f")
				{
					tile = (GameObject)Instantiate(fireTilePrefab, tilePosition, Quaternion.identity);
				}
				// Arrow/Rolling boulder block type
				else if (ch == "a")
				{
					tile = (GameObject)Instantiate(arrowTilePrefab, tilePosition, Quaternion.identity);
				}
				// Static Boulder block type
				else if (ch == "r")
				{
					tile = (GameObject)Instantiate(staticBoulderTilePrefab, tilePosition, Quaternion.identity);
				}
				// Start block type
				else if (ch == "S")
				{
					tile = (GameObject)Instantiate(startTilePrefab, tilePosition, Quaternion.identity);
				}
				// End block type
				else if (ch == "E")
				{
					tile = (GameObject)Instantiate(endTilePrefab, tilePosition, Quaternion.identity);
				} else
                {
					tile = (GameObject)Instantiate(emptyTilePrefab, tilePosition, Quaternion.identity);
				}
				row.Add(tile);
		    }
		}
		TickGrid();
	}

    // Update is called once per frame
    void Update()
    {
        
    }
	public void TickGrid()
	{
		foreach (List<GameObject> row in grid)
		{
			foreach (GameObject obj in row)
            {
				if(obj)
					obj.GetComponent<TempleBlock>().TickObject();
			}
		}
	}

	// splits a CSV file into a 2D string array
	static public string[,] SplitCsvGrid(string csvText)
	{
		string[] lines = csvText.Split("\n"[0]);

		// finds the max width of row
		int width = 0;
		for (int i = 0; i < lines.Length; i++)
		{
			string[] row = SplitCsvLine(lines[i]);
			width = Mathf.Max(width, row.Length);
		}

		// creates new 2D string grid to output to
		string[,] outputGrid = new string[width + 1, lines.Length + 1];
		for (int y = 0; y < lines.Length; y++)
		{
			string[] row = SplitCsvLine(lines[y]);
			for (int x = 0; x < row.Length; x++)
			{
				outputGrid[x, y] = row[x];

				// This line was to replace "" with " in my output. 
				// Include or edit it as you wish.
				outputGrid[x, y] = outputGrid[x, y].Replace("\"\"", "\"");
			}
		}

		return outputGrid;
	}

	// splits a CSV row 
	static public string[] SplitCsvLine(string line)
	{
		return (from System.Text.RegularExpressions.Match m in System.Text.RegularExpressions.Regex.Matches(line,
		@"(((?<x>(?=[,\r\n]+))|""(?<x>([^""]|"""")+)""|(?<x>[^,\r\n]+)),?)",
		System.Text.RegularExpressions.RegexOptions.ExplicitCapture)
				select m.Groups[1].Value).ToArray();
	}

}
