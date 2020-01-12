using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireController : MonoBehaviour
{
    public GameObject fire1;
    public GameObject fire2;
    public ParticleSystem firesystem1;
    public ParticleSystem firesystem2;
    void Start()
    {
        firesystem1 = fire1.GetComponent<ParticleSystem>();
        firesystem2 = fire2.GetComponent<ParticleSystem>();

        firesystem1.Play();
        fire1.GetComponent<BoxCollider>().enabled = true;
        firesystem2.Stop();
        fire2.GetComponent<BoxCollider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            swapFires();
        }
    }

    public void swapFires()
    {
        if(firesystem1.isPlaying)
        {
            firesystem1.Stop();
            fire1.GetComponent<BoxCollider>().enabled = false;
        }
        if(firesystem1.isStopped)
        {
            firesystem1.Play();
            fire1.GetComponent<BoxCollider>().enabled = true;
        }

        if (firesystem2.isPlaying)
        {
            firesystem2.Stop();
            fire2.GetComponent<BoxCollider>().enabled = false;
        }
        if (firesystem2.isStopped)
        {
            firesystem2.Play();
            fire2.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
