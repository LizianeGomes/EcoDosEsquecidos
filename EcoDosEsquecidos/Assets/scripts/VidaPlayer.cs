using UnityEngine;

public class VidaPlayer : MonoBehaviour
{
    public int vidaMaxima = 100;
    public int vidaAtual;

    void Start()
    {
        vidaAtual = vidaMaxima;
    }

    public void TomarDano(int dano)
    {
        vidaAtual -= dano;

        Debug.Log("Vida da Lara: " + vidaAtual);

        if (vidaAtual <= 0)
        {
            Morrer();
        }
    }

    void Morrer()
    {
        Debug.Log("Lara morreu");
        // aqui depois você pode reiniciar cena
    }
}