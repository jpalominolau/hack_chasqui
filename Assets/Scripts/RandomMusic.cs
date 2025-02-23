using UnityEngine;

public class RandomMusicPlayer : MonoBehaviour
{
    public AudioSource audioSource;   // Reference to the AudioSource component
    public AudioClip[] musicTracks;   // Array of music tracks

    private int lastTrackIndex = -1;  // Store last played track index to avoid repetition

    void Start()
    {
       
        if (musicTracks.Length > 0)
        {
            PlayRandomTrack();
        }
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayRandomTrack(); 
        }
        
    }

    void PlayRandomTrack()
    {
        if (musicTracks.Length == 0) return;

        int randomIndex;

        
        do
        {
            randomIndex = Random.Range(0, musicTracks.Length);
        } while (randomIndex == lastTrackIndex && musicTracks.Length > 1);

        lastTrackIndex = randomIndex;

        audioSource.clip = musicTracks[randomIndex];
        audioSource.Play();
    }
}