using UnityEngine;

public class AtaquePlayer : MonoBehaviour
{
    public Transform pontoAtaque;
    public float alcanceAtaque = 0.8f;
    public LayerMask camadaInimigo;

    public int dano = 1;
    public float tempoEntreAtaques = 0.6f;

    private float proximoAtaque;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && Time.time >= proximoAtaque)
        {
            Atacar();
            proximoAtaque = Time.time + tempoEntreAtaques;
        }
    }

    void Atacar()
    {
        animator.SetTrigger("atacar");

        Collider2D[] inimigos = Physics2D.OverlapCircleAll(
            pontoAtaque.position,
            alcanceAtaque,
            camadaInimigo
        );

        foreach (Collider2D inimigo in inimigos)
        {
            VidaZumbi vida = inimigo.GetComponent<VidaZumbi>();

            if (vida != null)
            {
                vida.TomarDano(dano);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (pontoAtaque == null) return;

        Gizmos.DrawWireSphere(pontoAtaque.position, alcanceAtaque);
    }
}