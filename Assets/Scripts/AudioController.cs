using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource[] audioSources;

    private void Start()
    {
        // Get all AudioSource components in the scene
        audioSources = FindObjectsOfType<AudioSource>();
    }

    public void ToggleMute()
    {
        foreach (AudioSource source in audioSources)
        {
            source.mute = !source.mute;
        }
    }
}