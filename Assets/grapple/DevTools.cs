using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DevTools : MonoBehaviour
{
    [SerializeField] private KeyCode reload;

    void Update ()
    {
        if (Input.GetKeyDown (reload))
        {
            Reload ();
        }
    }

    void Reload ()
    {
        SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
    }
}