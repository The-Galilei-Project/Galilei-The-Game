using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateSystem : MonoBehaviour
{
    private SpriteRenderer sr;
    public Sprite actived;
    public Sprite deactivated;
    public Transform toSpwanPosition;
    public GameObject toCopyObject;

    private GameObject createdObject;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        sr.sprite = actived;
        createdObject = Instantiate(toCopyObject, toSpwanPosition.position, toSpwanPosition.rotation);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Destroy(createdObject);
        sr.sprite = deactivated;
    }
}
