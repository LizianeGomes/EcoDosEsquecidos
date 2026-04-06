using UnityEngine;

[System.Serializable]
public class Dialogo
{
    [TextArea(2, 5)]
    public string texto;

    public Opcao[] opcoes;
}

[System.Serializable]
public class Opcao
{
    public string textoOpcao;
    public Dialogo proximoDialogo;
}