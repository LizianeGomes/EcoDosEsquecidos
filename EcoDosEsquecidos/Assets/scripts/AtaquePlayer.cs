using UnityEngine;

public class AtaquePlayer : MonoBehaviour
{
    public int dano = 10;
    public float alcance = 5f;
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

        Vector2 origem = transform.position;
        Vector2 direcao = sr.flipX ? Vector2.left : Vector2.right;

        RaycastHit2D hit = Physics2D.Raycast(
            origem,
            direcao,
            alcance,
            camadaInimigo
        );

        if (hit.collider != null)
        {
            VidaZumbi vida = hit.collider.GetComponent<VidaZumbi>();

            if (vida != null)
            {
                vida.TomarDano(dano);
            }
        }
        Debug.DrawRay(origem, direcao * alcance, Color.red, 0.2f);

    }
    
}