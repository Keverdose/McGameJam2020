using System.Collections;
using System.Collections.Generic;
using UnityEngine;      

public class EmptyBlockType : TempleBlock
{
    // Start is called before the first frame update
    new void Start()
    {
        print("empty block start");
        base.Start();
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }

    public override void TickObject()
    {
        print("Tick empty");
    }
}

