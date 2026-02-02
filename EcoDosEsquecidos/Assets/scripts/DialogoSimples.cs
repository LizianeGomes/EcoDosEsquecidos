using UnityEngine;
using TMPro;

public class DialogoSimples : MonoBehaviour
{
    public TMP_Text texto;
    public GameObject painel;

    public GameObject painelNome;
    public TMP_Text nomeTexto;

    public TMP_Text textoTutorial; // texto pequeno

    [TextArea]
    public string[] mensagens;

    public int indiceNome = 2;

    int indice = 0;

    void Start()
    {
        painel.SetActive(true);
        painelNome.SetActive(false);

        textoTutorial.gameObject.SetActive(true);

        texto.text = mensagens[indice];
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            indice++;

            if (indice < mensagens.Length)
            {
                texto.text = mensagens[indice];

                // nome
                if (indice == indiceNome)
                {
                    painelNome.SetActive(true);
                    nomeTexto.text = "Lara";
                }
                else
                {
                    painelNome.SetActive(false);
                }

                // tutorial só na primeira fala
                if (indice == 0)
                {
                    textoTutorial.gameObject.SetActive(true);
                }
                else
                {
                    textoTutorial.gameObject.SetActive(false);
                }
            }
            else
            {
                painel.SetActive(false);
                painelNome.SetActive(false);
                textoTutorial.gameObject.SetActive(false);
            }
        }
    }
}
