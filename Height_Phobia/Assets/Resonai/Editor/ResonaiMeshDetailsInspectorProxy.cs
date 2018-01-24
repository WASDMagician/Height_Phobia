using UnityEditor;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Ywz
{
  [CustomEditor(typeof(ResonaiMeshDetails))]
  public class ResonaiMeshDetailsInspectorProxy : Editor
  {
    ResonaiMeshDetailsInspector inspector;

    public ResonaiMeshDetailsInspectorProxy()
    {
      inspector = new ResonaiMeshDetailsInspector(this);
    }

    public void OnEnable()
    {
      inspector.SetTarget(target);
    }

    public override void OnInspectorGUI()
    {
      inspector.OnInspectorGUI();
    }
  }
}