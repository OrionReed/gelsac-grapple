using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PlatformViewer : MonoBehaviour
{

    [SerializeField] private Vector3 platformSize;
    [SerializeField] private bool loop = true;

    [SerializeField] private List<Vector3> positions;
    private Platform platform;

    void Awake ()
    {
        platform = GetComponent<Platform> ();
    }

    void OnDrawGizmosSelected ()
    {
        for (int i = 0; i < positions.Count; i++)
        {
            if (i > 0)
            {
                Gizmos.color = Color.cyan;
                Gizmos.DrawCube (positions[i], platformSize);
                Gizmos.DrawLine (positions[i], positions[i - 1]);
                if (i == positions.Count - 1 && loop)
                {
                    Gizmos.color = Color.yellow;
                    Gizmos.DrawLine (positions[i], positions[0]);
                }
            }
        }
    }
}