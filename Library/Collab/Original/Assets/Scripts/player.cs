using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 moveDelta;

    public Animator animator;

    private float x, y;

    public float speed;
    private bool isMove;

    Vector2 oldPos;

    private void Start()
    {
        // GetComponent "preleva" il componente attaccato all'oggetto, in questo caso preleva il componente BoxCollider2D dalla sprite del player_0
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        speed = 1.0f;
    }

    private void FixedUpdate()
    {
        // ritorna i valori di x e y
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        // reset moveDelta
        moveDelta = new Vector3(x, y, 0);


        // // Casting del box, che se ritorna null ci si può muovere perchè non ci sono collisioni (y)
        // hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Player", "Blocking"));

        // if (hit.collider == null)
        //     // movimento del player
        //     transform.Translate(0, moveDelta.y * Time.deltaTime, 0);

        // // Casting del box, che se ritorna null ci si può muovere perchè non ci sono collisioni (x)
        // hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Player", "Blocking"));

        // if (hit.collider == null)
        //     // movimento del player
        //     transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);

        rb.velocity = new Vector2(moveDelta.x, moveDelta.y) * speed;

        // se le vecchia posizione è diversa da quella nuova isMove viene impostata su true
        // e viene salvata la posizione corrente come vecchia posizione
        // in caso contrario isMove viene impostata su false
        if (isMove = (Vector3)oldPos != transform.position)
        {
            oldPos = transform.position;
        }

        animator.SetBool("isMove", isMove);
        animator.SetFloat("X", x);
        animator.SetFloat("Y", y);
    }
}