using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBlockType : TempleBlock
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        print("arrow block start");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void TickObject()
    {
        print("Tick arrow");
    }
}