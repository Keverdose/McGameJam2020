using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndBlockType : TempleBlock
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void TickObject()
    {
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.LogWarning("next scene");

            if(SceneManager.GetActiveScene().name == "SC_Level1")
            {
                SceneManager.LoadScene("SC_Level2");
            }
            else if (SceneManager.GetActiveScene().name == "SC_Level2")
            {
                SceneManager.LoadScene("SC_Level3");
            }
            else if (SceneManager.GetActiveScene().name == "SC_Level3")
            {
                SceneManager.LoadScene("SC_Level4");
            }
            else if (SceneManager.GetActiveScene().name == "SC_Level4")
            {
                SceneManager.LoadScene("SC_Level5");
            }
        }
    }
}
