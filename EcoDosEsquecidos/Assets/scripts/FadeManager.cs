using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class FadeManager : MonoBehaviour
{
    public static FadeManager instance;

    public Image fadeImage;
    public float velocidade = 1.5f;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public void TrocarCenaComFade(string cena)
    {
        StartCoroutine(FadeOut(cena));
    }

    IEnumerator FadeOut(string cena)
    {
        float alpha = 0;

        while (alpha < 1)
        {
            alpha += Time.deltaTime * velocidade;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        SceneManager.LoadScene(cena);
    }
}
