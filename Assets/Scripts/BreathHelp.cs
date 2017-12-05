using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreathHelp : MonoBehaviour
{
    public GameObject[] leaves;
    public MeshRenderer mr;
    public Material red;
    public Material yellow;
    public Material green;
    Material m;

	// Use this for initialization
	void Start ()
    {
        Invoke("ded", 195);
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
        var ma = GetComponent<Renderer>().materials;
        ma[0] = (count > 100) ? green : (count > 50) ? yellow : red;
        GetComponent<Renderer>().materials = ma;
        mr.enabled = (count > 10);
        float x = count / 101f;
        transform.localScale = new Vector3(x/18f, .001f, 0.005f);
	}

    void ded()
    {
        Application.Quit();
    }
}
