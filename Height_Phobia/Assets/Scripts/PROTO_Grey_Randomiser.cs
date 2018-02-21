using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PROTO_Grey_Randomiser : MonoBehaviour {

    public GameObject[] items_to_grey;

	// Use this for initialization
	void Start () {
	    for(int i = 0; i < items_to_grey.Length; i++)
        {
            if(items_to_grey[i] != null)
            {
                MeshRenderer renderer = items_to_grey[i].GetComponent<MeshRenderer>();
                if(renderer != null)
                {
                    Material[] materials = renderer.materials;
                    for(int j = 0; j < materials.Length; j++)
                    {
                        float grey = Random.Range(0.0f, 1f);
                        Color color = new Color(grey, grey, grey);
                        materials[j].color = color;
                    }
                }
            }
        }
	}
	
}
