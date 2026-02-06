using UnityEngine;

public class PassosSom : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip somPasso;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void TocarPasso()
    {
        audioSource.PlayOneShot(somPasso);
    }
}
