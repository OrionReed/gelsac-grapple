using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ButtonEvent : UnityEvent<int> { }

public class InteractableButton : MonoBehaviour
{
  [SerializeField] private float pressTime = 1;
  [SerializeField] private Vector3 offset;
  [SerializeField] private ButtonEvent buttonEvent;
  [SerializeField] private int buttonID;

  private AudioSource sound;

  void Start()
  {
    if (buttonEvent == null)
      buttonEvent = new ButtonEvent();

    buttonEvent.AddListener(PressedButton);
    sound = GetComponent<AudioSource>();
  }
  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.E))
    {
      Press();
    }
  }
  // Update is called once per frame
  public void Press()
  {
    buttonEvent.Invoke(buttonID);
    StartCoroutine(AnimateButtonPress());
  }

  private IEnumerator AnimateButtonPress()
  {
    sound.Play();
    transform.position += offset;
    yield return new WaitForSeconds(pressTime);
    transform.position -= offset;
    sound.Play();
  }
  private void PressedButton(int id)
  {
    Debug.Log("the button event has been called and i am receiving it!");
    Debug.Log(id);
  }
}