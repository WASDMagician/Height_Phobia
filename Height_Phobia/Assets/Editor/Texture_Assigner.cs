using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Texture_Assigner : MonoBehaviour {

    [MenuItem("Tool/Texture_Assigner/Assign_Textures")]
	public static void Assign_Textures()
    {
        Object[] all_objects = Selection.objects;
        List<Material> materials = Get_Materials(all_objects);
        List<Texture2D> textures = Get_Textures(all_objects);
        Assign_Textures_To_Materials(materials, textures);
    }

    public static List<Material> Get_Materials(Object[] _all_objects)
    {
        List<Material> materials = new List<Material>();
        for(int i= 0; i < _all_objects.Length; i++)
        {
            if(_all_objects[i].GetType() == typeof(Material))
            {
                materials.Add((Material)_all_objects[i]);
            }
        }
        return materials;
    }

    public static List<Texture2D> Get_Textures(Object[] _all_objects)
    {
        List<Texture2D> textures = new List<Texture2D>();
        for(int i = 0; i < _all_objects.Length; i++)
        {
            if(_all_objects[i].GetType() == typeof(Texture2D))
            {
                textures.Add((Texture2D)_all_objects[i]);
            }
        }
        return textures;
    }

    public static void Assign_Textures_To_Materials(List<Material> _materials, List<Texture2D> _textures)
    {
        for(int m = 0; m < _materials.Count; m++)
        {
            for(int t = 0; t < _textures.Count; t++)
            {
                if(_textures[t].name.Contains(_materials[m].name))
                {
                    if(_textures[t].name.Contains("Albedo"))
                    {
                        _materials[m].SetTexture("_MainTex", _textures[t]);
                    }
                    if(_textures[t].name.Contains("Metallic"))
                    {
                        _materials[m].SetTexture("_Metallic", _textures[t]);
                    }
                    if(_textures[t].name.Contains("Normal"))
                    {
                        _materials[m].SetTexture("_BumpMap", _textures[t]);
                    }
                }
            }
        }
    }
}
