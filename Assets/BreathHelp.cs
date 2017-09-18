using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreathHelp : MonoBehaviour
{

    public GameObject[] leaves;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        float count = 0;
        foreach(GameObject g in leaves)
        {
            if (g.transform.position.y < 0.5f)
            {
                count++;
            }
        }
        float x = count / 151f;
        Debug.Log(x);
        transform.localScale = new Vector3(x, 0.25f, 0.1f);
        if (count == 150)
            Debug.Log("oh hey");
	}
}
