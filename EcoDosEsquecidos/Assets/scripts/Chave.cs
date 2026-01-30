using UnityEngine;
using TMPro;

public class Chave : MonoBehaviour
{
    public TMP_Text textoNome;

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
        Inventario.temChave = true;
        textoNome.text = "";
        Destroy(gameObject);
    }
}

