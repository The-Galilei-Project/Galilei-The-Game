using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    float velocity = -200;
    float startPosition = 1245f;
    float endPosition = -500f;

    void Update()
    {
        transform.position += new Vector3(velocity * Time.deltaTime, 0);

        if (transform.position.x < endPosition)
            transform.position = new Vector3(startPosition, transform.position.y, 0);
    }
}
