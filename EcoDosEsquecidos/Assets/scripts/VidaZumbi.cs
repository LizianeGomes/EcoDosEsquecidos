using UnityEngine;

public class VidaZumbi : MonoBehaviour
{
    public int vida = 3;

    private Animator anim;
    private Collider2D col;
    private ZumbiIA ia;

    void Start()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        ia = GetComponent<ZumbiIA>();
    }

    public void TomarDano(int dano)
    {
        vida -= dano;
        Debug.Log("Zumbi tomou dano! Vida atual: " + vida);

        if (vida <= 0)
        {
            Morrer();
        }
    }

    void Morrer()
    {
        anim.SetBool("Morto", true);

        // desliga IA
        if (ia != null)
            ia.enabled = false;

        // desliga colisão
        col.enabled = false;

        // destrói depois da animação
        Destroy(gameObject, 2f); // ajuste pro tempo da animação
    }
}

