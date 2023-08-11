using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 moveDelta;
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
        this.transform.position = PlayerState.getPosition();
    }

    private void Update()
    {
        speed = PlayerState.speed;
        // ritorna i valori di x e y
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        // reset moveDelta
        moveDelta = new Vector2(x, y);

        this.Move();
        this.Animate();
    }

    private void Move()
    {
        rb.velocity = moveDelta * speed;
    }

    private void Animate()
    {
        //    se le vecchia posizione è diversa da quella nuova isMove viene impostata su true
        //    e viene salvata la posizione corrente come vecchia posizione
        //    in caso contrario isMove viene impostata su false

        if (isMove = (Vector3)oldPos != transform.position)
        {
            oldPos = transform.position;
        }

        if ((x != 0 || y != 0) && speed != 0)
        {
            animator.SetFloat("X", x);
            animator.SetFloat("Y", y);
        }
        animator.SetBool("isMove", isMove);
    }
}