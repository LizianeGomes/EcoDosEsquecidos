using UnityEngine;
using TMPro;

public class Chave : MonoBehaviour
{
    public TMP_Text textoNome;
    public float distanciaParaPegar = 1.2f;

    private Transform player;

    void Start()
    {
        textoNome.text = "";
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void OnMouseEnter()
    {
        textoNome.text = "Chave";
    }

    void OnMouseExit()
    {
        // Só apaga se for a própria chave
        if (textoNome.text == "Chave")
            textoNome.text = "";
    }

    void OnMouseDown()
    {
        float distancia = Vector2.Distance(transform.position, player.position);

        if (distancia <= distanciaParaPegar)
        {
            Inventario.temChave = true;

            // Só apaga se for a própria chave
            if (textoNome.text == "Chave")
                textoNome.text = "";

            Destroy(gameObject);
        }
    }
}
