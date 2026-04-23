using UnityEngine;
using System.Collections;

public class FadeParaPreto : MonoBehaviour
{
    public CanvasGroup fade;
    public float duracaoFade = 1f;
    public float tempoVisivel = 1f;

    float tempo = 0f;
    bool jaFoi = false;

    void Update()
    {
        tempo += Time.deltaTime;

        if (tempo < duracaoFade)
        {
            float t = tempo / duracaoFade;
            fade.alpha = 1f - t;
        }
        else if (tempo < duracaoFade + tempoVisivel)
        {
            fade.alpha = 0f;
        }
        else if (tempo < duracaoFade * 2 + tempoVisivel)
        {
            float t = (tempo - duracaoFade - tempoVisivel) / duracaoFade;
            fade.alpha = t;
        }
        else if (!jaFoi)
        {
            jaFoi = true;
            StartCoroutine(TrocarCena());
        }
    }

    IEnumerator TrocarCena()
    {
        yield return new WaitForSeconds(0.2f);
        GameManager.Instance.CarregarCena("MenuPrincipal");
    }
}