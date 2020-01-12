using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public GameObject UITab;
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
            Invoke("Die", 1.0f);
        }
    }
    public void Respawn()
    {
        UITab.SetActive(false); 
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
        Time.timeScale = 1;
    }

    public void Die()
    {
        Time.timeScale = 0;
        UITab.SetActive(true);
    }

   

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Fire"))
        {
            Invoke("Die", 0.1f);
        }
    }

    // Given a direction,
    public bool Move(Vector3 moveDirection)     
    {
        Vector3 currentPosition = new Vector3(transform.position.x, transform.position.y / 2, transform.position.z);
        RaycastHit hitFront;

        // No Collision, proceed with the movement
        if (!Physics.Raycast(currentPosition, moveDirection, out hitFront, 1))
        {
            //if(!hitFront.transform.gameObject.CompareTag("Fire")) && (!hitFront.transform.gameObject.CompareTag("Arrow"))

            // Check for a tile below you to determine whether we can move or not
            // Walking into the void or falling tile should block all further movement
            RaycastHit hit;

            if (!Physics.Raycast(transform.position, -Vector3.up, out hit) || hit.distance > distanceToTile)
            {

                return false;


            }

            transform.Translate(moveDirection);
            Quaternion rotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            mesh.transform.rotation = rotation;
            return true;
        }

        else
        {
            if ((hitFront.transform.tag != "Fire") || (hitFront.transform.tag != "Arrow"))
            {
                return true;
            }
        }
        
        return false;
    }

}
