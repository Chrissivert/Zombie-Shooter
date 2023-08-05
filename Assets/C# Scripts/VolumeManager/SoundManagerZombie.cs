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

    private void Start()
    {
        StartCoroutine(PlayZombieSoundsRoutine());
    }

    IEnumerator PlayZombieSoundsRoutine()
    {
        while (true)
        {
            float timeToWait = GetSoundInterval();
            yield return new WaitForSeconds(timeToWait);

            PlayZombieSound(RandomizeZombieSound());
        }
    }

    public AudioClip RandomizeZombieSound()
    {
        if (zombieSounds.Length > 0)
        {
            int randomIndex = Random.Range(0, zombieSounds.Length);
            AudioClip randomSound = zombieSounds[randomIndex];
            audioSource.clip = randomSound;
        }
        return audioSource.clip;
    }

    public void PlayZombieSound(AudioClip zombieClip)
    {
        audioSource.Play();
    }

    private float GetSoundInterval()
    {
        int zombieCount = zombie.zombies.Count;
        float maxInterval = 600f; // Adjust this value as desired
        float maxZombieCount = 100f; // Adjust this value as desired

        // Calculate the interval based on the number of zombies
        float interval = Mathf.Lerp(0f, maxInterval, Mathf.InverseLerp(0, maxZombieCount, zombieCount));
        interval = Mathf.Clamp(interval, 1f, maxInterval);

        return interval;
    }

    public void ChangeVolume(float newVolume)
    {
        newVolume = Mathf.Clamp01(newVolume);
        audioSource.volume = newVolume;
    }
}
