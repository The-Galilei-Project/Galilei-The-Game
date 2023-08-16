using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    float velocity = -2;
    float startPosition = 13.50f;
    float endPosition = -13.75f;

    void Update()
    {
        transform.position += new Vector3(velocity * Time.deltaTime, 0);

        if (transform.position.x < endPosition)
            transform.position = new Vector3(startPosition, transform.position.y, 0);
    }
}
