using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempleBlock : MonoBehaviour
{
    Rigidbody rb;
   
    public GameObject tileEffect;

    float playerOnTileTimerLimit = 4.0f;
    float playerOnTileTimer = 0.0f;
    bool isPlayerOnTile; 

    public virtual void TickObject()
    {

    }

    // Start is called before the first frame update
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        isPlayerOnTile = false;
    }

    // Update is called once per frame
    public void Update()
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

            Instantiate(tileEffect, this.gameObject.transform.position + new Vector3(0.0f, 1.0f, 0.0f), Quaternion.identity);
        }
    }

    private void DestroyTile() 
    {
        rb.isKinematic = false;
        Destroy(gameObject, 1f);
    }
}
