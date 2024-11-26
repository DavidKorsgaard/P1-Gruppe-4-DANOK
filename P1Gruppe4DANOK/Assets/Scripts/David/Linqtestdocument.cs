using System.Linq.Expressions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class Linqtestdocument : MonoBehaviour
{
    public AudioSource audioSource;          // Reference til AudioSource
    public AudioClip[] audioClips;           // Array med alle AudioClips
    public AudioClip myClips;
    

    //Array of DanokWords
    public string[] DanokWords;


    //Array of possible Consonants
    string[] Consonants = {"B", "D", "F", "G",
        "K", "L", "M", "N", "P", "S", "T", "V"};

    string[] Vocals = { "a", "u", "i" };

   

    public GameObject VoicePlayer;
    public VoiceChooser SpeechScript;

    public bool M1;
    public bool M2;
    public bool F1;
    public bool F2;

    private void Start()
    {
        VoicePlayer = GameObject.Find("Audiomanager");
        SpeechScript = VoicePlayer.GetComponent<VoiceChooser>();
        
        
    }



    
    
    


}
