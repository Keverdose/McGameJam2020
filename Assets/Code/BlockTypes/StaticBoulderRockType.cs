﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticBoulderRockType : TempleBlock
{
    GameObject attachedStaticBoulder; 

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        print("static boulder block start");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void TickObject()
    {
        print("Tick static boulder");
    }
}