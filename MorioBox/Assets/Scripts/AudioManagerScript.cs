using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioManagerScript : MonoBehaviour
{
    [SerializeField] Image SoundOffIcon;
    [SerializeField] Image SoundOnIcon;
    private bool Muted = false;
    public Sound[] Sounds;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in Sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.Volume;
            s.source.pitch = s.Pitch;

        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(Sounds, Sound => Sound.name == name);
        s.source.Play();
    } 
    
    public void Mute()
    {
        if(Muted == false)
        {
            Muted = true;
            AudioListener.pause = true;
            SoundOffIcon.enabled = true;
            SoundOnIcon.enabled = false;
        }
        else
        {
            Muted = false;
            AudioListener.pause = false;
            SoundOffIcon.enabled = false;
            SoundOnIcon.enabled = true;

        }
    }
}
