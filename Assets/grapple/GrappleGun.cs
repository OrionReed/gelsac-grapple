using UnityEngine;

public class GrappleGun : MonoBehaviour
{

  [SerializeField] private LayerMask whatIsGrappleable;
  [SerializeField] private Transform gunTip, camera, player;
  [SerializeField] private float reelSpeed = 1;
  [SerializeField] private float maxDistance = 200f;
  [SerializeField] private GameObject bullet;
  [SerializeField] private float bulletForce;
  private LineRenderer lr;
  private Vector3 grapplePoint;
  private SpringJoint joint;
  private float reelFactor = 1;

  void Awake()
  {
    lr = GetComponent<LineRenderer>();
  }

  void Update()
  {
    if (Input.GetKey(KeyCode.LeftShift))
      ReelIn();

    if (Input.GetMouseButtonDown(1))
      StartGrapple();

    else if (Input.GetMouseButtonUp(1))
      StopGrapple();
  }

  void LateUpdate()
  {
    if (Input.GetMouseButtonDown(0))
      FireGun();
    DrawRope();
  }

  void ReelIn()
  {
    if (joint != null)
    {
      joint.maxDistance -= reelSpeed * Time.deltaTime;
      joint.minDistance -= reelSpeed * Time.deltaTime;
      joint.spring += reelSpeed * 0.3f * Time.deltaTime;
    }
  }

  void FireGun()
  {
    GameObject instance = Instantiate(bullet, gunTip.position + (gunTip.forward * 0.5f), gunTip.rotation);
    instance.GetComponent<Rigidbody>().AddForce(bulletForce * gunTip.forward, ForceMode.Impulse);
  }

  void StartGrapple()
  {
    RaycastHit hit;
    if (Physics.Raycast(camera.position, camera.forward, out hit, maxDistance, whatIsGrappleable))
    {
      grapplePoint = hit.point;
      joint = player.gameObject.AddComponent<SpringJoint>();
      joint.autoConfigureConnectedAnchor = false;
      joint.connectedAnchor = grapplePoint;

      float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

      joint.maxDistance = distanceFromPoint * 0.8f;
      joint.minDistance = distanceFromPoint * 0.25f;

      joint.spring = 4.5f;
      joint.damper = 7f;
      joint.massScale = 4.5f;

      lr.positionCount = 2;
      currentGrapplePosition = gunTip.position;
    }
  }

  void StopGrapple()
  {
    lr.positionCount = 0;
    Destroy(joint);
  }

  private Vector3 currentGrapplePosition;

  void DrawRope()
  {
    if (!joint) return;

    currentGrapplePosition = Vector3.Lerp(currentGrapplePosition, grapplePoint, Time.deltaTime * 8f);

    lr.SetPosition(0, gunTip.position);
    lr.SetPosition(1, currentGrapplePosition);
  }

  public bool IsGrappling()
  {
    return joint != null;
  }

  public Vector3 GetGrapplePoint()
  {
    return grapplePoint;
  }
}