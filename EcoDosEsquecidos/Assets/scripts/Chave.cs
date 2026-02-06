using UnityEngine;
using TMPro;

public class Chave : MonoBehaviour
{
    public TMP_Text textoNome;
    public float distanciaParaPegar = 3f;

    private Transform player;
    private AudioSource audioSource;

    void Start()
    {
        textoNome.text = "";
        player = GameObject.FindGameObjectWithTag("Player").transform;
        audioSource = GetComponent<AudioSource>();
    }

    void OnMouseEnter()
    {
        textoNome.text = "Chave";
    }

    void OnMouseExit()
    {
        textoNome.text = "";
    }

    void OnMouseDown()
    {
        float distancia = Vector2.Distance(transform.position, player.position);

        if (distancia <= distanciaParaPegar)
        {
            Inventario.temChave = true;
            textoNome.text = "";

            audioSource.Play();

            Destroy(gameObject, 0.3f);
        }
    }
}