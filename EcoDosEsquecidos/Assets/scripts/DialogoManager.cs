using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogoManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI textoDialogo;

    public GameObject painelDialogo;
    public GameObject painelOpcoes;

    public Button botaoOpcaoPrefab;
    public Transform containerOpcoes;

    public float velocidadeTexto = 0.01f;

    private Dialogo dialogoAtual;
    private bool escrevendo = false;
    private Coroutine rotinaTexto;

    void Update()
    {
        // PULAR TEXTO COM CLIQUE
        if (Input.GetMouseButtonDown(0) && escrevendo)
        {
            PularTexto();
        }
    }

    public void IniciarDialogo(Dialogo dialogo)
    {
        painelDialogo.SetActive(true);
        painelOpcoes.SetActive(true);

        dialogoAtual = dialogo;
        MostrarDialogo();
    }

    void MostrarDialogo()
    {
        // Limpar botões antigos
        foreach (Transform filho in containerOpcoes)
        {
            Destroy(filho.gameObject);
        }

        // Começar escrita
        if (rotinaTexto != null)
            StopCoroutine(rotinaTexto);

        rotinaTexto = StartCoroutine(EscreverTexto(dialogoAtual.texto));
    }

    IEnumerator EscreverTexto(string texto)
    {
        escrevendo = true;
        textoDialogo.text = "";

        foreach (char letra in texto)
        {
            textoDialogo.text += letra;
            yield return new WaitForSeconds(velocidadeTexto);
        }

        escrevendo = false;

        // Só cria opções depois que termina de escrever
        CriarOpcoes();
    }

    void PularTexto()
    {
        if (rotinaTexto != null)
            StopCoroutine(rotinaTexto);

        textoDialogo.text = dialogoAtual.texto;
        escrevendo = false;

        CriarOpcoes();
    }

    void CriarOpcoes()
    {
        foreach (Opcao opcao in dialogoAtual.opcoes)
        {
            Button novoBotao = Instantiate(botaoOpcaoPrefab, containerOpcoes);

            novoBotao.GetComponentInChildren<Text>().text = opcao.textoOpcao;

            novoBotao.onClick.AddListener(() =>
            {
                EscolherOpcao(opcao);
            });
        }
    }

    void EscolherOpcao(Opcao opcao)
    {
        if (escrevendo) return;

        if (opcao.proximoDialogo != null)
        {
            dialogoAtual = opcao.proximoDialogo;
            MostrarDialogo();
        }
        else
        {
            EncerrarDialogo();
        }
    }

    void EncerrarDialogo()
    {
        painelDialogo.SetActive(false);
        painelOpcoes.SetActive(false);
    }
}