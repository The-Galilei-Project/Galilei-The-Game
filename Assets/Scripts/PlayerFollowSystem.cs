using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerFollowSystem : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    public Sprite[] directionSprite;
    public SpriteRenderer spriteRenderer;
    private Vector2 movement;
    private Rigidbody2D rb;

    public const int UP = 0;
    public const int LEFT = 1;
    public const int RIGHT = 2;
    public const int DOWN = 3;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.freezeRotation = true; // se lo si disattiva diventa diversemente storta
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y,direction.x) *Mathf.Rad2Deg;

        spriteRenderer.sprite = directionSprite[DetectDirection(angle)];
        // rb.rotation=angle; // la fa girare in modo storto

        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate() {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction){
        rb.MovePosition((Vector2)transform.position + (direction*moveSpeed*Time.deltaTime) );
    }

    public int DetectDirection(float angle){
        if (angle > -60 && angle <= 60) return UP;
        else if (angle > 60 && angle <= 120) return LEFT;
        else if (angle > -120 && angle <= -60) return RIGHT;
        else return DOWN;
    }
}
