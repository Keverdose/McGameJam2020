using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBlockType : TempleBlock
{
    // Start is called before the first frame update
    void Start()
    {
        print("start block start");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void TickObject()
    {
        print("Tick start");
    }
}
