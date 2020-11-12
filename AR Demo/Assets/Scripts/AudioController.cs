
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
    [SerializeField]
    AudioClip targetFound;
    [SerializeField]
    AudioClip targetLost;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayFoundSound()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(targetFound);
    }

    public void PlayLostSound()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(targetLost);
    }
}
