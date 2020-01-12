using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController player;
    public TempleGrid grid;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 offset = new Vector3(0, 2, 0);
        player.transform.position = grid.startPosition + offset;
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: All the inputs should be a tile size worth of movement
        if (Input.GetKeyDown(KeyCode.UpArrow) && player.Move(new Vector3(0,0,1)))
        {
            grid.TickGrid();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && player.Move(new Vector3(0, 0, -1)))
        {
            grid.TickGrid();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && player.Move(new Vector3(-1, 0, 0)))
        {
            grid.TickGrid();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && player.Move(new Vector3(1, 0, 0)))
        {
            grid.TickGrid();
        }
    }
}
