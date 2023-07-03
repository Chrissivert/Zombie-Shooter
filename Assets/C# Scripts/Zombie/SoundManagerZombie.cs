using UnityEngine;

public class ZombieSoundManager : MonoBehaviour
{
    public AudioClip[] zombieSounds;

    private AudioSource audioSource;

    public ManagerZombie managerZombie;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }



    private void PlayRandomZombieSound()
    {
        if (zombieSounds.Length > 0)
        {
            int randomIndex = Random.Range(0, zombieSounds.Length);
            AudioClip randomSound = zombieSounds[randomIndex];
            audioSource.clip = randomSound;
            audioSource.Play();
        }
    }

    // Call this method when you want the zombie to play a sound
    public void PlayZombieSound()
    {
        PlayRandomZombieSound();
    }

    private float GetSoundInterval()
    {
        int zombieCount = managerZombie.zombies.Count;

        // Adjust the interval based on the number of zombies
        float interval = 10f / (zombieCount + 1); // Increase the divisor to reduce the frequency

        return interval;
    }

    private System.Collections.IEnumerator PlaySoundBasedOnZombieCount()
    {
        while (true)
        {
            yield return new WaitForSeconds(GetSoundInterval());

            PlayRandomZombieSound();
        }
    }
}
