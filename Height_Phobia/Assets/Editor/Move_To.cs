using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Move_To {
	[MenuItem("Tool/Move_GameObject")]
	public static void Move_Object_To()
	{
		GameObject[] selected_objects = Selection.gameObjects;
		GameObject active_object = Selection.activeGameObject;
		Vector3 position = active_object.transform.position;
		for(int i = 0; i < selected_objects.Length; i++)
		{
			if (selected_objects [i] != active_object) 
			{
				active_object.transform.position = selected_objects [i].transform.position;
			}
		}
	}
}
