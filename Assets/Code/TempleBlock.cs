﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempleBlock : MonoBehaviour
{
    Rigidbody rb;

    float playerOnTileTimerLimit = 4.0f;
    float playerOnTileTimer = 0.0f;
    bool isPlayerOnTile; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isPlayerOnTile = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerOnTile) 
        {
            playerOnTileTimer += Time.deltaTime;

            if(playerOnTileTimer > playerOnTileTimerLimit) 
            {
                DestroyTile();
            }
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Player")
        {
            isPlayerOnTile = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            isPlayerOnTile = false;
            DestroyTile();
        }
    }

    private void DestroyTile() 
    {
        rb.isKinematic = false;
        Destroy(gameObject, 1f);
    }
}
