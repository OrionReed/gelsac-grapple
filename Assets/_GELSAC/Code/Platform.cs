using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Vector3 startMarker;
    public Vector3 endMarker;

    public float speed = 1.0f;

    private float journeyFraction = 0;
    
    void Update()
    {   
        journeyFraction += Time.deltaTime * speed;

        if (journeyFraction >= 1){ speed = speed * -1; };
        if (journeyFraction <= 0){ speed = speed * -1; };

        transform.position = Vector3.Lerp(startMarker, endMarker, journeyFraction);
    }
}
