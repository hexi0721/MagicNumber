using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance {  get; private set; }

    public AudioClip yeahAudio;

    AudioSource efxsource;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        efxsource = GetComponent<AudioSource>();
    }


    public void PlayAudio(AudioClip audioClip)
    {
        
        efxsource.PlayOneShot(audioClip);
    }

}
