using UnityEngine;

public class ZumbiIA : MonoBehaviour
{
    public float velocidade = 2f;
    public float distanciaAtaque = 0.8f;
    public int dano = 10;
    public float tempoEntreAtaques = 1f;

    Transform player;
    VidaPlayer vidaPlayer;

    float proximoAtaque;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        vidaPlayer = player.GetComponent<VidaPlayer>();
    }

    void Update()
    {
        if (player == null) return;

        float distancia = Vector2.Distance(transform.position, player.position);

        if (distancia > distanciaAtaque)
        {
            Seguir();
        }
        else
        {
            Atacar();
        }
    }

    void Seguir()
    {
        Vector2 direcao = player.position - transform.position;

        // virar sprite
        if (direcao.x < 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (direcao.x > 0)
            transform.localScale = new Vector3(-1, 1, 1);

        transform.position = Vector2.MoveTowards(
            transform.position,
            player.position,
            velocidade * Time.deltaTime
        );
    }


    void Atacar()
    {
        if (Time.time > proximoAtaque)
        {
            vidaPlayer.TomarDano(dano);
            proximoAtaque = Time.time + tempoEntreAtaques;
        }
    }
}