﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController player;
    public TempleGrid grid;

    public float timeCount;
    public float tickTime = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        timeCount = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeCount >= tickTime) {

            //TODO: All the inputs should be a tile size worth of movement
            if (Input.GetKeyDown(KeyCode.UpArrow) && player.Move(new Vector3(0, 0, 1))) {
                grid.TickGrid();
                timeCount = 0.0f;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && player.Move(new Vector3(0, 0, -1))) {
                grid.TickGrid();
                timeCount = 0.0f;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && player.Move(new Vector3(-1, 0, 0))) {
                grid.TickGrid();
                timeCount = 0.0f;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && player.Move(new Vector3(1, 0, 0))) {
                grid.TickGrid();
                timeCount = 0.0f;
            }
        }

        timeCount += Time.deltaTime;
    }
}
