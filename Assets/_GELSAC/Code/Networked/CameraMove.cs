using UnityEngine;

public class CameraMove : MonoBehaviour
{

  private Transform playerHead;

  public void SetPlayer(Transform playerHeadTransform)
  {
    playerHead = playerHeadTransform;
  }

  void Update()
  {
    transform.position = playerHead.transform.position;
  }
}