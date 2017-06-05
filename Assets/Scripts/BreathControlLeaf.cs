using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreathControlLeaf : MonoBehaviour
{
    private const float MAX_HEIGHT = 20;
    private const float yMultiplier = 25;
    private bool grounded = false;
    private Vector3 defaultScale;
    private Rigidbody rb;
    
    
	// Update is called once per frame
	void Update ()
    {
        decideBlowForce();
        if (this.transform.position.y > MAX_HEIGHT)
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    private void decideBlowForce()
    {
        if(grounded)
        {
            if (MicInput.micReading > 0.001f)
            {
                this.GetComponent<Rigidbody>().AddForce((Random.value - 0.5f) * 0.5f, yMultiplier * ((MicInput.micReading > 0.1f) ? 0.1f : MicInput.micReading) + (MicInput.micReading > 0.001f ? Random.value : 0), (Random.value - 0.5f) * 0.5f, ForceMode.Impulse);
                transform.Rotate(new Vector3(Random.value + 0.3f, Random.value + 0.3f, Random.value + 0.3f));
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "ground")
        {
            this.grounded = true;
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "ground")
        {
            this.grounded = false;
        }
    }
}
