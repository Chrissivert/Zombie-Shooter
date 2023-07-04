using UnityEngine;
using System.Collections;

public class ZombieSoundManager : MonoBehaviour
{
    public AudioClip[] zombieSounds;
    private AudioSource audioSource;

    public Zombie zombie;
    public float volume;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        ChangeVolume(volume);
    }

    private void Update()
    {
       StartCoroutine(timeToWaitBasedOnAmountOfZombies(GetSoundInterval()));
    }

    IEnumerator timeToWaitBasedOnAmountOfZombies(float timeToWait)
    {
        while (true)
        {
            PlayZombieSound(RandomizeZombieSound());
            yield return new WaitForSeconds(timeToWait);
        }
    }

    private AudioClip RandomizeZombieSound()
    {
        if (zombieSounds.Length > 0)
        {
            int randomIndex = Random.Range(0, zombieSounds.Length);
            AudioClip randomSound = zombieSounds[randomIndex];
            audioSource.clip = randomSound;
        }
        return audioSource.clip;
    }

    // Call this method when you want the zombie to play a sound
    public void PlayZombieSound(AudioClip zombieClip)
    {
        audioSource.Play();
    }

    private float GetSoundInterval()
    {
        int zombieCount = zombie.zombies.Count;
        float interval = 0.5f / (zombieCount + 1); // Increase the divisor to reduce the frequency

      return interval;
    }

    public void ChangeVolume(float newVolume)
    {
        // Clamp the newVolume value between 0.0 and 1.0
        newVolume = Mathf.Clamp01(newVolume);

        // Set the volume of the audio clip
        audioSource.volume = newVolume;
    }
}
