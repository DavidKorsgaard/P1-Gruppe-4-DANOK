using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceChooser : MonoBehaviour
{
    
    
        public AudioSource thisPlaying;
        public AudioClip[] myClips; // Skiftet fra ArrayList[] til AudioClip[]

        private void Start()
        {
            // Loader alle AudioClip-filer fra mappen "Resources/Audio"
            myClips = Resources.LoadAll<AudioClip>("Audio");

            // Debugging: Tjek om klippene er blevet loadet korrekt
            foreach (var clip in myClips)
            {
                Debug.Log("Loaded AudioClip: " + clip.name);
            }
        }
        public void PlayRandomClip()
        {
            if (myClips.Length == 0)
            {
                Debug.LogWarning("No clips loaded!");
                return;
            }

            // Vælg et tilfældigt klip fra arrayet
            AudioClip randomClip = myClips[Random.Range(0, myClips.Length)];

            // Sæt klippet som AudioSource's clip og spil det
            thisPlaying.clip = randomClip;
            thisPlaying.Play();

            Debug.Log("Now playing: " + randomClip.name);
        }
        public void OnPlayButtonClicked()
        {
            PlayRandomClip();
        }
    


}

