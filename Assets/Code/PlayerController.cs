using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //TODO: Needs to know the grid values

    float initialY;

    // Start is called before the first frame update
    void Start()
    {
        initialY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y >= initialY)
        {
            //TODO: All the inputs should be a tile size worth of movement
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.Translate(0, 0, 1);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                transform.Translate(0, 0, -1);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.Translate(-1, 0, 0);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.Translate(1, 0, 0);
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
}
