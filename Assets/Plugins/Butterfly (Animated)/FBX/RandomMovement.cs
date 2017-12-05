using UnityEngine;
using System.Collections;

public class RandomMovement : MonoBehaviour {

    int count = 50;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        float x, y, z;

        if (Random.value > .5)
        {
            x = 0.25f * Random.value;
        } 
        else
        {
            x = -0.25f * Random.value;
        }
        if (Random.value > .5)
        {
            y = 0.25f * Random.value;
        }
        else
        {
            y = 0.25f * Random.value;
        }
        if (Random.value > .5)
        {
            z = 0.25f * Random.value;
        }
        else
        {
            z = -0.25f * Random.value;
        }

        if (count == 60)
        {
            count = 0;
            GetComponent<Rigidbody>().velocity = new Vector3(x, y, z);
        }
        else
        {
            count++;
        }
           

    }
}
