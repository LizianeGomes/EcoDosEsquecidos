using UnityEngine;

public class ZumbiIA : MonoBehaviour
{
    [Header("Referências")]
    public Transform player;

    [Header("Movimento")]
    public float velocidade = 2f;
    public float distanciaAtaque = 5f;

    private Animator anim;
    private Rigidbody2D rb;
    private bool atacando = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        if (anim == null)
            Debug.LogError("ZumbiIA: Animator NÃO encontrado!");

        if (rb == null)
            Debug.LogError("ZumbiIA: Rigidbody2D NÃO encontrado!");

        // Travar eixo Y e rotação UMA VEZ
        rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;
    }

    void Update()
    {
        if (player == null || anim == null) return;

        float distancia = Vector2.Distance(transform.position, player.position);

        if (distancia > distanciaAtaque)
        {
            // ANDAR
            atacando = false;
            anim.SetBool("Attack", false);
            anim.SetBool("andando", true);

            Vector2 direcao = (player.position - transform.position).normalized;
            transform.position += (Vector3)direcao * velocidade * Time.deltaTime;
        }
        else
        {
            // ATACAR
            atacando = true;
            anim.SetBool("andando", false);
            anim.SetBool("Attack", true);

            rb.linearVelocity = Vector2.zero;
        }

        // Virar sprite
        if (player.position.x > transform.position.x)
            transform.localScale = new Vector3(1, 1, 1);
        else
            transform.localScale = new Vector3(-1, 1, 1);
    }
}