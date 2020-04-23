using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour
{
  [SerializeField] private float bulletForce = 10;
  [SerializeField] private float fireRate = 10;
  [SerializeField] private float aimSpeed = 10;
  [SerializeField] private float accuracy = 10;
  [SerializeField] private GameObject bullet;
  [SerializeField] private Transform gunTip;
  [SerializeField] private Transform player;
  private float timeSinceLastShot = 0;

  void Update()
  {
    Quaternion targetRotation = Quaternion.LookRotation(player.position - transform.position);
    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, aimSpeed * Time.deltaTime);
    timeSinceLastShot += Time.deltaTime;
    if (timeSinceLastShot > (60 / fireRate))
    {
      Fire();
      timeSinceLastShot = 0;
    }
  }
  void Fire()
  {
    GameObject instance = Instantiate(bullet, gunTip.position + gunTip.forward, gunTip.rotation);
    instance.GetComponent<Rigidbody>().AddForce(bulletForce * gunTip.forward, ForceMode.Impulse);
  }
}
