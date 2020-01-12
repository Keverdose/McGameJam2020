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
    }

    public override void TickObject()
    {
        if(tickCount % 3 == 1)
        {
            InstantiateArrow();
        }
        foreach(GameObject arrow in ArrowsInstantiated)
        {
            if (arrow != null)
            {
                arrow.transform.Translate(new Vector3(0,0,1));
                if (arrow.transform.position.x > 7.0f || arrow.transform.position.z > 7.0f ||
                    arrow.transform.position.x < -7.0f || arrow.transform.position.z < -7.0f)
                {
                    Destroy(arrow);
                }
            }
        }
        ArrowsInstantiated.RemoveAll(x => x == null);
        tickCount++;
    }

    public void InstantiateArrow()
    {
        AudioSource sound = this.GetComponent<AudioSource>();
        sound.Play();
        Vector3 startingPos = this.transform.position +  new Vector3(0,1,0);
        GameObject arrow = Instantiate(ArrowPrefab, startingPos, this.transform.rotation);
        ArrowsInstantiated.Add(arrow);
    }
}