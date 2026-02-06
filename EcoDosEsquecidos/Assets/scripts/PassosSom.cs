using UnityEngine;

public class PassosSom : MonoBehaviour
{
    [Header("Som de Passo")]
    public AudioSource audioSource;
    public AudioClip somPasso;

    // Esse método é chamado pela animação
    public void TocarPasso()
    {
        if (audioSource != null && somPasso != null)
        {
            audioSource.PlayOneShot(somPasso);
        }
    }
}