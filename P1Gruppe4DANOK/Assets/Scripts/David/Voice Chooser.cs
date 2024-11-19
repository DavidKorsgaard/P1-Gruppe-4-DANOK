using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD

=======
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
>>>>>>> 8c73d8dff5fcd1687f6eb2ecad50f4e2e60e6584
