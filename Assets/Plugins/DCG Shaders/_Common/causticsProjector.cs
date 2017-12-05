using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class causticsProjector : MonoBehaviour {

	public Texture2D[] images;
	public float Delay;
	public int curImage = 0;
	float curTime = 0;
	Projector p;
	public bool setParameters = true;
	public float CausticIntensity, HeightCut, UnderWaterCut, CausticsSize = 0.33f;
	public bool UpdateProjector;
    /*
    void Start()
    {

        if (p)
        {
            if (p.material ==null ) 
            {
                p.material = new Material(Shader.Find("DCG/Water Shader/Caustics"));
           //    instance.name = "Caustics Material";
                //  instance.hideFlags = HideFlags.HideAndDontSave;

               // p.material;

                p.material.SetTexture("_Caustic",images[0]);

                p.material.SetFloat("_CausticsScale",CausticsSize);
                p.material.SetFloat("_CausticIntensity",CausticIntensity);
                p.material.SetColor("_CausticColor",Color.white);

                p.material.SetFloat("_HeightCut",HeightCut);
                p.material.SetFloat("_UnderwaterCut",UnderWaterCut);
            }
        }
        
        UpdateProjector = true;
       // SetParameters();
    }

*/
	void Update () {

		if (p) 
		{

		curTime += Time.deltaTime;

			
			if(curTime >=Delay)
			{
				curTime = 0;
				p.material .SetTexture("_Caustic",images[curImage]);
				if (curImage < (images.Length -1)) 
				{
					curImage+=1;
				} 
				else 
				{
					curImage = 0;
				}
			}

            SetParameters();
		}
		else 
		{
			p = GetComponent<Projector> ();
//			print("Projector Found !");
		}
	}
    void SetParameters()
    {
        p.material .SetFloat("_HeightCut",HeightCut);
        p.material .SetFloat("_UnderwaterCut",UnderWaterCut);
        p.material .SetFloat("_CausticsScale",CausticsSize);
        p.material.SetFloat("_CausticIntensity",CausticIntensity);
        //print(CausticIntensity);
    }
}
