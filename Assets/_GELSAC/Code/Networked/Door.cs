using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Quaternion openRotation;
    [SerializeField] private float openTime = 1;
    [SerializeField] private float waitTime = 0.5f;

    private AudioSource audioSource;
    private Quaternion initialRotation;
    private ButtonEvent buttonEvent;
    void Start ()
    {
        initialRotation = transform.rotation;
        if (buttonEvent == null)
            buttonEvent = new ButtonEvent ();

        buttonEvent.AddListener (Open);
        audioSource = GetComponent<AudioSource> ();
    }

    private void Update ()
    {
        if (Input.GetKeyDown (KeyCode.E))
        {
            Open (1);
        }
    }

    private void Open (int id)
    {
        StartCoroutine (OpenAnimation ());
    }

    private IEnumerator OpenAnimation ()
    {
        audioSource.Play ();
        transform.localRotation = openRotation;
        yield return new WaitForSeconds (waitTime);
        transform.localRotation = initialRotation;
        audioSource.Play ();
    }
}