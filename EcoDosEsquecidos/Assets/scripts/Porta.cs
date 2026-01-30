using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class Porta : MonoBehaviour
{
    public string cenaDestino;
    public TMP_Text textoMensagem;

    private bool podeTrocar = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player") || !podeTrocar)
            return;

        if (Inventario.temChave)
        {
            FadeManager.instance.TrocarCenaComFade(cenaDestino);
        }
        else
        {
            StartCoroutine(MostrarMensagem());
        }
    }

    IEnumerator MostrarMensagem()
    {
        podeTrocar = false;

        textoMensagem.text = "Porta trancada";

        yield return new WaitForSeconds(2f);

        textoMensagem.text = "";
        podeTrocar = true;
    }
}
