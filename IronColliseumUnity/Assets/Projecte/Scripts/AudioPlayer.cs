using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class AudioPlayer : MonoBehaviour
{

    public AudioClip[] clips;
    public AudioMixer audioMixer;
    public void PlaySound(int index)
    {
        GameObject go = new GameObject();
        AudioSource source = go.AddComponent<AudioSource>();
        //AudioMixer audioMixer = Resources.Load<AudioMixer>("MainMixer");

        AudioMixerGroup[] audioMixGroup = audioMixer.FindMatchingGroups("Master");

        source.outputAudioMixerGroup = audioMixGroup[1];


        source.clip = clips[index];
      

        source.spread = 0;

        source.Play();

        Destroy(go, clips[index].length);
    }

}
