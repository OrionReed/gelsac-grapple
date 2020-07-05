using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu (fileName = "NewEyeSequence", menuName = "Gelsac/Eye Sequence")]
public class EyeSequence : ScriptableObject
{
  public List<EyeMovement> movements;
}

[CreateAssetMenu (fileName = "NewEyeMovement", menuName = "Gelsac/Eye Movement")]
public class EyeMovement : ScriptableObject
{
  public Eyes chooseEye;
  [SerializeField]
  [Utils.MinMaxSlider (0.01f, 0.4f)]
  public Utils.MinMax eyeSizeRange = new Utils.MinMax (0.05f, 0.2f);
  [Range (0f, 1f)]
  public float similarity = 0.5f;
  public LeanTweenType easeType = LeanTweenType.easeOutQuad;

  [SerializeField]
  [Utils.MinMaxSlider (0f, 2f)]
  public Utils.MinMax waitTime = new Utils.MinMax (0.1f, 1f);

  public float targetScale ()
  {
    Debug.Log (Mathf.Lerp (eyeSizeRange.RandomValue, eyeSizeRange.Max - ((eyeSizeRange.Max - eyeSizeRange.Min) / 2), similarity));
    return Mathf.Lerp (eyeSizeRange.RandomValue, eyeSizeRange.Max - ((eyeSizeRange.Max - eyeSizeRange.Min) / 2), similarity);
  }
}

public enum Eyes
{
  Both,
  Left,
  Right
}

public class EyesController : MonoBehaviour
{
  [SerializeField] private GameObject leftEye;
  [SerializeField] private GameObject rightEye;

  [SerializeField] private List<EyeMovement> examples;
  [SerializeField] private EyeSequence sequence;

  private KeyCode[] keyCodes = {
    KeyCode.Alpha0,
    KeyCode.Alpha1,
    KeyCode.Alpha2,
    KeyCode.Alpha3,
    KeyCode.Alpha4,
    KeyCode.Alpha5,
    KeyCode.Alpha6,
    KeyCode.Alpha7,
    KeyCode.Alpha8,
    KeyCode.Alpha9
  };

  // Only here to debug animations
  void Update ()
  {
    if (Input.GetKeyDown (KeyCode.S))
      StartCoroutine (PlaySequence (sequence));

    int n = NumericKeyDown ();
    if (n > -1)
      PlayMovement (examples[n - 1]);
  }

  public void EaseLeft (EyeMovement movement) => LeanTween.scaleY (leftEye, movement.targetScale (), movement.waitTime.RandomValue).setEase (movement.easeType);
  public void EaseRight (EyeMovement movement) => LeanTween.scaleY (rightEye, movement.targetScale (), movement.waitTime.RandomValue).setEase (movement.easeType);

  private int NumericKeyDown ()
  {
    for (int i = 0; i < keyCodes.Length; i++)
    {
      if (Input.GetKeyDown (keyCodes[i]))
        return i + 1;
    }
    return -1;
  }

  private void PlayMovement (EyeMovement movement)
  {
    if (movement.chooseEye != Eyes.Left)
      EaseRight (movement);

    if (movement.chooseEye != Eyes.Right)
      EaseLeft (movement);
  }

  private IEnumerator PlaySequence (EyeSequence seq)
  {
    foreach (EyeMovement move in seq.movements)
    {
      PlayMovement (move);
      while (LeanTween.isTweening ())
      {
        yield return new WaitForSeconds (0.05f);
      }
    }
  }

}