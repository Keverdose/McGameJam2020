﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //TODO: Needs to know the grid values

    float initialY;
    float distanceToTile; 

    // Start is called before the first frame update
    void Start()
    {
        initialY = transform.position.y;
        distanceToTile = 1.125f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= initialY)
        {
            Vector3 movementDirection = new Vector3(0, 0, 0);

            //TODO: All the inputs should be a tile size worth of movement
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                movementDirection.z = 1;
                // transform.Translate(0, 0, 1);

                // Check if there are any obstacle 
                Move(movementDirection);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                movementDirection.z = -1;
                // transform.Translate(0, 0, -1);

                // Check if there are any obstacle 
                Move(movementDirection);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                movementDirection.x = -1;
                //transform.Translate(-1, 0, 0);

                // Check if there are any obstacle 
                Move(movementDirection);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                movementDirection.x = 1;
                //transform.Translate(1, 0, 0);

                // Check if there are any obstacle 
                Move(movementDirection);
            }

            
            

        }
        else
        {
            //TODO: Dead
            Invoke("Respawn", 2.0f);
        }
    }
    void Respawn()
    {
        SceneManager.LoadScene("SC_Level1");
    }


    // Given a direction,
    bool Move(Vector3 moveDirection)     
    {
        Vector3 currentPosition = new Vector3(transform.position.x, transform.position.y / 2, transform.position.z);

        // No Collision, proceed with the movement
        if (!Physics.Raycast(currentPosition, moveDirection, 1)) 
        {
            
            // Check for a tile below you to determine whether we can move or not
            // Walking into the void or falling tile should block all further movement
            RaycastHit hit;
            
            if (!Physics.Raycast(transform.position, -Vector3.up, out hit) || hit.distance > distanceToTile) {
                return false;
            }

            transform.Translate(moveDirection);
            return true;
        }
        
        return false;
    }

}
