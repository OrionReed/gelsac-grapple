using System.Collections;
using UnityEngine;

public class Shootable : MonoBehaviour
{

  //The box's current health point total
  public int currentHealth = 10;
  public Gradient healthGradient;

  private Renderer ren;
  private int maxHealth;

  private void Start()
  {
    maxHealth = currentHealth;
    ren = gameObject.GetComponent<Renderer>();
  }

  public void Damage(int damageAmount)
  {
    //subtract damage amount when Damage function is called
    currentHealth -= damageAmount;
    ren.material.SetColor("_BaseColor", healthGradient.Evaluate(((float)currentHealth) / maxHealth));


    //Check if health has fallen below zero
    if (currentHealth <= 0)
    {
      //if health has fallen below zero, deactivate it 
      gameObject.SetActive(false);
    }
  }
}