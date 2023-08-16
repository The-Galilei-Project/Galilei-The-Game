using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PressurePlateSystemSecret : MonoBehaviour
{
    private SpriteRenderer sr;
    public Sprite actived;
    public Sprite deactivated;
    public AIPath aipath;

    // Start is called before the first frame update
    void Start()
    {
        aipath.canMove=false;
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        sr.sprite = actived;
        aipath.canMove=true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        sr.sprite = deactivated;
    }
}