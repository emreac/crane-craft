using System.Collections;
using UnityEngine;

public class MachineSoundController : MonoBehaviour
{
    public AudioSource startSound;
    public AudioSource workingSound;
    public AudioSource stopSound;
    public AudioSource hyrodlicSound;

    private bool isMachineRunning = false;

    void Update()
    {
        if (Input.GetAxis("Vertical") > 0)  // Assuming vertical joystick movement starts the machine
        {
            StartMachine();
        }
        else if (Input.GetAxis("Vertical") < 0)  // Assuming vertical joystick movement stops the machine
        {
            StopMachine();
        }
    }

    public void StartMachine()
    {
       // StartCoroutine(FadeIn(startSound,0.5f));
        if (!isMachineRunning)
        {
            isMachineRunning = true;
            startSound.Play();
            workingSound.PlayDelayed(startSound.clip.length);  // Play working sound after the start sound
        }
    }

    public void StopMachine()
    {
        if (isMachineRunning)
        {
            isMachineRunning = false;
            workingSound.Stop();
            stopSound.Play();
        }
    }

    IEnumerator FadeIn(AudioSource audioSource, float duration)
    {
        float currentTime = 0;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(0, 1, currentTime / duration);
            yield return null;
        }
    }
    IEnumerator FadeOut(AudioSource audioSource, float duration)
    {
        float currentTime = 0;
        float startVolume = audioSource.volume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, 0, currentTime / duration);
            yield return null;
        }

        audioSource.Stop();
    }

}
