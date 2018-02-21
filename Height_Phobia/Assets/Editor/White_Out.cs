using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class White_Out : MonoBehaviour {

    [MenuItem("Tool/White_Out/Single")]
    public static void White_Out_Single()
    {
        White_Materials(Selection.activeGameObject);
    }

    [MenuItem("Tool/White_Out/All")]
    public static void White_Out_Multi()
    {
        for(int i = 0; i < Selection.gameObjects.Length; i++)
        {
            White_Materials(Selection.gameObjects[i]);
        }
    }


    public static void White_Materials(GameObject _object)
    {
        MeshRenderer[] renderers = _object.GetComponents<MeshRenderer>();
        for(int i = 0; i < renderers.Length; i++)
        {
            Material[] materials = renderers[i].sharedMaterials;
            for(int j = 0; j < materials.Length; j++)
            {
                materials[j].color = Color.white;
            }
        }
    }
}
