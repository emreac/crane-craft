using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioClipType { collectClip,putClip,doneClip,winClip,paintClip}
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] private AudioSource audioSource;
    public AudioClip collectClip;
    public AudioClip putClip;
    public AudioClip doneClip;
    public AudioClip winClip;
    public AudioClip paintClip;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }
    public void PlayAudio(AudioClipType clipType)
    {
        if(audioSource != null)
        {
            AudioClip audioClip = null;
            if(clipType == AudioClipType.collectClip)
            {
                audioClip = collectClip;
            }else if (clipType == AudioClipType.putClip)
            {
                audioClip = putClip;
            }
            else if (clipType == AudioClipType.doneClip)
            {
                audioClip = doneClip;
            }
            else if (clipType == AudioClipType.winClip)
            {
                audioClip = winClip;
            }
            else if (clipType == AudioClipType.paintClip)
            {
                audioClip = paintClip;
            }

            audioSource.PlayOneShot(audioClip,0.6f);
        }
    }
}
