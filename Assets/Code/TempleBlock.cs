using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class TempleBlock : MonoBehaviour
{
    Rigidbody rb;

    public virtual void TickObject()
    {

    }

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
            rb.isKinematic = false;
            Destroy(gameObject,1f);
        }
    }
}
