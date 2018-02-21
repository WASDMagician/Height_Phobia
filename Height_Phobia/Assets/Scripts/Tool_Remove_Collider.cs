using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Tool_Remove_Collider : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Collider[] colliders = GetComponentsInChildren<Collider>();
        for(int i = 0; i < colliders.Length; i++)
        {
            DestroyImmediate(colliders[i]);
        }
        DestroyImmediate(this);
	}
}
