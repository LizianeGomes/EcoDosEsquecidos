using UnityEngine;

public class AtaquePlayer : MonoBehaviour
{
    public int dano = 10;
    public float alcance = 1.5f;
    public LayerMask camadaInimigo;

    private Animator anim;
    private SpriteRenderer sr;

    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Atacar();
        }
    }

    void Atacar()
    {
        anim.SetTrigger("Attack");

        Vector2 direcao = sr.flipX ? Vector2.left : Vector2.right;
        Vector2 origem = (Vector2)transform.position + direcao * 0.5f;

        RaycastHit2D hit = Physics2D.Raycast(
            origem,
            direcao,
            alcance,
            camadaInimigo
        );

        Debug.DrawRay(origem, direcao * alcance, Color.red, 0.3f);

        if (hit.collider != null)
        {
            Debug.Log("Acertou: " + hit.collider.name);

            VidaZumbi vida = hit.collider.GetComponent<VidaZumbi>();
            if (vida != null)
            {
                vida.TomarDano(dano);
            }
        }
        else
        {
            Debug.Log("Ataque não acertou ninguém");
        }
    }
}