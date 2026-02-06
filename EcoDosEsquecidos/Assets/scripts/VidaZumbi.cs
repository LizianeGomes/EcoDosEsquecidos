using UnityEngine;

public class VidaZumbi : MonoBehaviour
{
    public int vida = 50;

    public void TomarDano(int dano)
    {
        vida -= dano;

        if (vida <= 0)
        {
            Morrer();
        }
    }

    void Morrer()
    {
        Destroy(gameObject);
    }
}
