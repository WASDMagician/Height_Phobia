using UnityEngine;
using System.Collections.Generic;

namespace Ywz
{
  #if UNITY_EDITOR
  public class ResonaiMeshDetails : ResonaiMeshDetailsInternal
  {
  }
  #else
  public class ResonaiMeshDetails : MonoBehaviour
  {
  }
  #endif
}