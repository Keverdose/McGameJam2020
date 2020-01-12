using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //TODO: Needs to know the grid values

    float initialY;
    float distanceToTile;
    GameObject mesh;

    // Start is called before the first frame update
    void Start()
    {
        initialY = transform.position.y;
        distanceToTile = 1.125f;
        mesh = transform.GetChild(0).gameObject;//quick hack
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= initialY)
        {
        }
        else
        {
            //TODO: Dead
            Invoke("Respawn", 2.0f);
        }
    }
    void Respawn()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Arrow") || (collision.gameObject.CompareTag("Fire")))
        {
            Invoke("Respawn", 0.1f);
        }
    }

    // Given a direction,
    public bool Move(Vector3 moveDirection)     
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
            Quaternion rotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            mesh.transform.rotation = rotation;
            return true;
        }
        
        return false;
    }

}
