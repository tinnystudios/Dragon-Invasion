using UnityEngine;

public class HitEffect : MonoBehaviour
{
    public AudioSource HitAudioSource;

    private void Awake()
    {
        HitAudioSource.Play();
    }
}
