using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBlockType : TempleBlock
{

    int tick;
    //public GameObject fireSpawner;
    public GameObject fire1;
    public GameObject fire2;
    public ParticleSystem firesystem1;
    public ParticleSystem firesystem2;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();

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
        
    }

    public override void TickObject()
    {
        tick++;
        if ((tick > 1)&&(tick % 2 == 1))
        {
            swapFires();
        }

    }

    public void swapFires()
    {
        if (firesystem1.isPlaying || firesystem2.isStopped)
        {
            firesystem1.Stop();
            fire1.GetComponent<BoxCollider>().enabled = false;
            firesystem2.Play();
            fire2.GetComponent<BoxCollider>().enabled = true;
        }
        else
        {
            firesystem2.Stop();
            fire2.GetComponent<BoxCollider>().enabled = false;
            firesystem1.Play();
            fire1.GetComponent<BoxCollider>().enabled = true;
        }
    }
}