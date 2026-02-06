using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Porta : MonoBehaviour
{
    public TMP_Text textoNome;
    public string proximaCena;
    public AudioSource somPorta;
    public float distanciaParaAbrir = 1.2f;

    Transform player;
    bool abriu = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        textoNome.text = "";
    }

    void OnMouseEnter()
    {
        if (Inventario.temChave)
            textoNome.text = "";
        else
            textoNome.text = "Trancada";
    }

    void OnMouseExit()
    {
        textoNome.text = "";
    }

    void Update()
    {
        if (abriu) return;
        if (!Inventario.temChave) return;

        float distancia = Vector2.Distance(transform.position, player.position);

        if (distancia <= distanciaParaAbrir)
        {
            abriu = true;
            textoNome.text = "";
            somPorta.Play();
            Invoke("TrocarCena", 0.6f);
        }
    }

    void TrocarCena()
    {
        SceneManager.LoadScene(proximaCena);
    }
}