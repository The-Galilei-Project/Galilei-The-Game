using UnityEngine;

public class DoorSystem : MonoBehaviour
{
    public Sprite open;
    public Sprite close;
    private SpriteRenderer current;


    private void Awake()
    {
        current = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        current.sprite = open;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        current.sprite = close;
    }
}
