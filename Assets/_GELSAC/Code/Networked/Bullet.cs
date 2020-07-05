using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  [SerializeField] private ParticleSystem explosion;
  [SerializeField] private MeshRenderer meshRenderer;
  [SerializeField] private float destroyAfter = 10;
  private bool detonated = false;
  void Start()
  {
    Destroy(gameObject, destroyAfter);
  }
  void OnCollisionEnter()
  {
    meshRenderer.enabled = false;
    if (!detonated)
    {
      explosion.Play();
      detonated = true;
    }
  }
}