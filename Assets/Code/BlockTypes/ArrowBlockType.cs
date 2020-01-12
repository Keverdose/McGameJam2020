using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBlockType : TempleBlock
{
    public GameObject ArrowPrefab;
    public List<GameObject> ArrowsInstantiated;

    public int tickCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        print("arrow block start");
    }

    public override void TickObject()
    {
        if(tickCount % 4 == 1)
        {
            InstantiateArrow();
        }
        foreach(GameObject arrow in ArrowsInstantiated)
        {
            print(this.transform.forward);
            arrow.transform.Translate(this.transform.forward);
            if(arrow.transform.position.x > 7.0f || arrow.transform.position.z > 7.0f ||
                arrow.transform.position.x < -7.0f || arrow.transform.position.z < -7.0f)
            {
                ArrowsInstantiated.Remove(arrow);
                Destroy(arrow);
            }
        }
        tickCount++;
    }

    public void InstantiateArrow()
    {
        Vector3 startingPos = this.transform.position +  new Vector3(0,1,0);
        GameObject arrow = Instantiate(ArrowPrefab, startingPos, Quaternion.identity);
        ArrowsInstantiated.Add(arrow);
    }
}