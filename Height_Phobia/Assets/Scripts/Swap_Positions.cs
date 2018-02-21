using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swap_Positions : MonoBehaviour {
	public GameObject[] buildings;

	void Start()
	{
		Switch_Building_Positions ();
	}

	public void Switch_Building_Positions()
	{
		for (int i = 0; i < buildings.Length - 1; i++) {
			GameObject one = buildings [i];
			GameObject two = buildings [i + 1];
			Transform temp = one.transform;
			one.transform.position = two.transform.position;
			one.transform.rotation = two.transform.rotation;
			one.transform.localScale = two.transform.localScale;
			two.transform.position = temp.transform.position;
			two.transform.rotation = temp.transform.rotation;
			two.transform.localScale = temp.transform.localScale;
		}
	}
}
