using UnityEngine;

public class MovimentoPointClick : MonoBehaviour
{
    public float velocidade = 5f;

    private Vector3 destino;
    private bool mover = false;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Clique do mouse
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.WorldToScreenPoint(transform.position).z;

            Vector3 posicaoMundo = Camera.main.ScreenToWorldPoint(mousePos);

            destino = new Vector3(posicaoMundo.x, transform.position.y, transform.position.z);
            mover = true;

            // Verifica direção para virar o sprite
            if (destino.x < transform.position.x)
                spriteRenderer.flipX = true;   // esquerda
            else
                spriteRenderer.flipX = false;  // direita
        }

        // Movimento
        if (mover)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                destino,
                velocidade * Time.deltaTime
            );

            animator.SetBool("andando", true);

            if (Vector3.Distance(transform.position, destino) < 0.01f)
            {
                mover = false;
                animator.SetBool("andando", false);
            }
        }
        else
        {
            animator.SetBool("andando", false);
        }
    }
}
