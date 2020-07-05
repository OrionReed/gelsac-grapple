using UnityEngine;
using System;

public static class Gelsac
{
  public static void ChangeLayersRecursively(this Transform trans, string name)
  {
    trans.gameObject.layer = LayerMask.NameToLayer(name);
    foreach (Transform child in trans)
    {
      child.ChangeLayersRecursively(name);
    }
  }
}