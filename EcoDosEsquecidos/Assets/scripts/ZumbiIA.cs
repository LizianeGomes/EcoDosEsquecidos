using UnityEngine;

public class ZumbiIA : MonoBehaviour
{
    public Transform player;
    public float velocidade = 2f;
    public float distanciaAtaque = 5f;

    private Animator anim;
    private bool atacando = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (player == null) return;

        float distancia = Vector2.Distance(transform.position, player.position);

        if (distancia > distanciaAtaque)
        {
            // ANDAR
            atacando = false;
            anim.SetBool("Attack", false);

            Vector2 direcao = (player.position - transform.position).normalized;
            transform.position += (Vector3)direcao * velocidade * Time.deltaTime;

            anim.SetBool("andando", true);
        }
        else
        {
            // ATACAR
            atacando = true;
            anim.SetBool("andando", false);
            anim.SetBool("Attack", true);
        }

        // Virar sprite
        if (player.position.x > transform.position.x)
            transform.localScale = new Vector3(1, 1, 1);
        else
            transform.localScale = new Vector3(-1, 1, 1);
    }
}