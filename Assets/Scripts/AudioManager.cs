using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public AudioMixer masterMixer;
    public Sprite[] sprites = new Sprite[2];

    Image soundToggleImage;

    bool runOnce = true;


    private void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

        soundToggleImage = GameObject.Find("SoundButton").GetComponent<Image>();
    }



    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound" + name + "not Found");
            return;
        }
        else
        {

            s.source.Play();
        }
        
    }

    public void BackgroundMusicOff()
    {
        if (runOnce == true)
        {
            masterMixer.SetFloat("Master", -80f);
            soundToggleImage.sprite = sprites[1];
            runOnce = false;

        }
        else
        {
            
            masterMixer.SetFloat("Master", 0);
            soundToggleImage.sprite = sprites[0];
            runOnce = true;

        }
    }
}
