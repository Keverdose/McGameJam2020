using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        Destroy(this.gameObject);
        if(collider.gameObject.name == "Player")
        {
            PlayerController pc = collider.gameObject.GetComponent<PlayerController>();

            if (pc) { pc.Die(); }
        }
    }
}
