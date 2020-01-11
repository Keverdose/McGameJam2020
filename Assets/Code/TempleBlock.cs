using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempleBlock : MonoBehaviour
{
    Rigidbody rb;
   
    public GameObject tileEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionExit(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            Instantiate(tileEffect, this.gameObject.transform.position + new Vector3(0.0f, 1.0f, 0.0f), Quaternion.identity);
            
            rb.isKinematic = false;
            Destroy(gameObject,1f);
        }
    }
}
