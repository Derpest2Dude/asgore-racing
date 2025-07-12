using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioSource menuMusic;
    public AudioSource nightMusic;
    public AudioSource rainbowMusic;

    public AudioSource beerDrinkingSound;
    public AudioSource crashSound;


    public void StartMenuMusic()
    {
        
        if (nightMusic.isPlaying)
        {
            nightMusic.Stop();
        }
        else if (rainbowMusic.isPlaying)
        {
            rainbowMusic.Stop();
        }
        else if (menuMusic.isPlaying)
        {
            menuMusic.Stop();
        }
        menuMusic.Play();
        
    }
    
    public void StartNightMusic()
    {
        if (nightMusic.isPlaying)
        {
            nightMusic.Stop();
        }
        else if (rainbowMusic.isPlaying)
        {
            rainbowMusic.Stop();
        }
        else if (menuMusic.isPlaying)
        {
            menuMusic.Stop();
        }
        nightMusic.Play();

    }
    
    public void StartRainbowMusic()
    {
        if (nightMusic.isPlaying)
        {
            nightMusic.Stop();
        }
        else if (rainbowMusic.isPlaying)
        {
            rainbowMusic.Stop();
        }
        else if (menuMusic.isPlaying)
        {
            menuMusic.Stop();
        }
        rainbowMusic.Play();

    }

    public void StopAllMusic()
    {
        if (nightMusic.isPlaying)
        {
            nightMusic.Stop();
        }
        if (rainbowMusic.isPlaying)
        {
            rainbowMusic.Stop();
        }
        if (menuMusic.isPlaying)
        {
            menuMusic.Stop();
        }
    }

    public void PlayDrinkBeerSound()
    {
        beerDrinkingSound.Play();
    }

    public void PlayCrashSound()
    {
        crashSound.Play();
    }
}
