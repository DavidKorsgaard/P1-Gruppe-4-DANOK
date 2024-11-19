using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceChooser : MonoBehaviour
{
    public AudioSource thisPlaying;
    public bool isPlaying;
    public AudioClip[] myClips; // Skiftet fra ArrayList[] til AudioClip[]

    private void Start()
    {
        // Loader alle AudioClip-filer fra mappen "Resources/audio/foo"
        myClips = Resources.LoadAll<AudioClip>("audio/foo");

        // Debugging: Tjek om klippene er blevet loadet korrekt
        foreach (var clip in myClips)
        {
            Debug.Log("Loaded AudioClip: " + clip.name);
        }
    }
}
