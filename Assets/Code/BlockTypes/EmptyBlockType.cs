using System.Collections;
using System.Collections.Generic;
using UnityEngine;      

public class EmptyBlockType : TempleBlock
{
    // Start is called before the first frame update
    void Start()
    {
        print("empty block start");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void TickObject()
    {
        print("Tick empty");
    }
}

