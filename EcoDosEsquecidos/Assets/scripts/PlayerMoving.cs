using UnityEngine;

public class PlayerMoving2D : MonoBehaviour
{
    [Header("Componentes")]
    private Rigidbody2D rb2D;
    private Animator animator;
    private SpriteRenderer spriteRenderer; // Para virar o personagem

    [Header("Movimento Point & Click")]
    public float velocidade = 3f; // Velocidade de movimento
    public LayerMask layerMascaraChao; // Layer do chão onde pode clicar (defina no Inspector)
    public Transform pontoAlvo; // Opcional: objeto vazio para visualizar o alvo (arraste no Inspector)

    private Vector2 posicaoAlvo; // Posição X onde clicou (Y fica igual à do player)
    private Camera camPrincipal; // Referência da câmera principal
    private bool estaAndando = false;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        camPrincipal = Camera.main;

        // Inicializa posição alvo na posição atual
        posicaoAlvo = transform.position;

        // Configura Rigidbody para movimento horizontal suave (sem gravidade se não precisar)
        rb2D.gravityScale = 0f; // Sem gravidade vertical
        rb2D.freezeRotation = true; // Não gira
    }

    private void Update()
    {
        // Detecta clique do mouse
        if (Input.GetMouseButtonDown(0))
        {
            MoverParaPontoClicado();
        }

        // Move o player para o alvo HORIZONTALMENTE
        MoverHorizontalmente();

        // Atualiza animação
        AtualizarAnimacao();
    }

    private void MoverParaPontoClicado()
    {
        // Converte posição do mouse para mundo 2D
        Vector2 posMouseMundo = camPrincipal.ScreenToWorldPoint(Input.mousePosition);

        // Raycast para baixo até bater no chão (ajuste distance se precisar)
        RaycastHit2D hit = Physics2D.Raycast(posMouseMundo, Vector2.down, Mathf.Infinity, layerMascaraChao);

        if (hit.collider != null)
        {
            // Define alvo só na horizontal (Y igual ao player)
            posicaoAlvo = new Vector2(hit.point.x, transform.position.y);
            estaAndando = true;

            // Opcional: move o pontoAlvo para visualizar
            if (pontoAlvo != null)
                pontoAlvo.position = posicaoAlvo;
        }
    }

    private void MoverHorizontalmente()
    {
        if (estaAndando)
        {
            // Calcula direção para o alvo
            float direcaoX = Mathf.Sign(posicaoAlvo.x - transform.position.x);

            // Aplica velocidade ao Rigidbody (só X)
            rb2D.linearVelocity = new Vector2(direcaoX * velocidade, rb2D.linearVelocity.y);

            // Para quando chegou (com tolerância pequena)
            if (Mathf.Abs(transform.position.x - posicaoAlvo.x) < 0.1f)
            {
                rb2D.linearVelocity = Vector2.zero;
                estaAndando = false;
            }
        }
        else
        {
            rb2D.linearVelocity = Vector2.zero; // Para completamente
        }
    }

    private void AtualizarAnimacao()
    {
        float velocidadeX = rb2D.linearVelocity.x;

        // Define parâmetro de velocidade no Animator (crie um Float chamado "VelocidadeX" no Animator)
        if (animator != null)
            animator.SetFloat("VelocidadeX", Mathf.Abs(velocidadeX));

        // Vira o sprite baseado na direção
        if (velocidadeX > 0.1f)
            spriteRenderer.flipX = false; // Olha para direita
        else if (velocidadeX < -0.1f)
            spriteRenderer.flipX = true; // Olha para esquerda
    }
}