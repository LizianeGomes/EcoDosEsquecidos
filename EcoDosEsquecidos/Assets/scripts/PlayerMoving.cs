using UnityEngine;

public class MovimentoPointClick : MonoBehaviour
{
    public float velocidade = 5f;
    public float forcaPulo = 7f;
    public Transform checadorChao;
    public LayerMask layerChao;

    private Vector3 destino;
    private bool mover = false;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    private bool noChao;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Checar chão
        noChao = Physics2D.OverlapCircle(checadorChao.position, 0.1f, layerChao);
        animator.SetBool("noChao", noChao);

        // Clique do mouse
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.WorldToScreenPoint(transform.position).z;

            Vector3 posicaoMundo = Camera.main.ScreenToWorldPoint(mousePos);
            destino = new Vector3(posicaoMundo.x, transform.position.y, transform.position.z);
            mover = true;

            spriteRenderer.flipX = destino.x < transform.position.x;
        }

        // Movimento horizontal
        if (mover && noChao)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                destino,
                velocidade * Time.deltaTime
            );

            animator.SetBool("andando", true);

            if (Vector3.Distance(transform.position, destino) < 0.05f)
            {
                mover = false;
                animator.SetBool("andando", false);
            }
        }
        else
        {
            animator.SetBool("andando", false);
        }

        // PULO
        if (Input.GetKeyDown(KeyCode.Space) && noChao)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, forcaPulo);
            animator.SetBool("pulando", true);
        }

        // Reset do pulo ao cair
        if (noChao)
        {
            animator.SetBool("pulando", false);
        }
    }
}
