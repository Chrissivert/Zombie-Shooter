using UnityEngine;

public class VolumeController : MonoBehaviour
{
    public AudioSource audioSource;

    private void Start()
    {
        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();
    }

    public void ChangeVolume(float newVolume)
    {
        // Clamp the newVolume value between 0.0 and 1.0
        newVolume = Mathf.Clamp01(newVolume);

        // Set the volume of the audio clip
        audioSource.volume = newVolume;
    }
}
