using UnityEngine;
using System.Collections.Generic;

public class VoiceMaker : MonoBehaviour
{
    public AudioSource audioSource;          // Reference til AudioSource
    public AudioClip[] audioClips;           // Array med alle AudioClips
    private Dictionary<string, AudioClip> audioClipMap; // Map til hurtig adgang til klip

    private string audioClipName;            // Dynamisk genereret navn på lydklip
    public GameObject Logic;                 // Reference til Logic-objektet
    public Linqtestdocument Linqtestdocument;      // Reference til WordGenerator-scriptet
    private string[] Voices = { "_F1", "_F2", "_M1", "_M2" }; // Stemmetyper

    void Start()
    {
        // Initialiser komponenter og references
        audioSource = GetComponent<AudioSource>();
        Logic = GameObject.Find("Logic");
        Linqtestdocument = Logic.GetComponent<Linqtestdocument>();
        audioClips = Resources.LoadAll<AudioClip>("Audio");

        // Initialiser dictionary til at mappe lydklip med deres navne
        audioClipMap = new Dictionary<string, AudioClip>();
        foreach (var audioClip in audioClips)
        {
            if (!audioClipMap.ContainsKey(audioClip.name))
            {
                audioClipMap.Add(audioClip.name, audioClip);
            }
        }
        
        Debug.Log($"Loaded {audioClips.Length} audio clips.");
    }
    /*
    public void PlayAudio()
    {
        if (Linqtestdocument == null)
        {
            Debug.LogError("WordGenerator is not assigned.");
            return;
        }

        // Vælg en tilfældig stemme
        int randomIndex = Random.Range(0, Voices.Length);
        audioClipName = Linqtestdocument.ChosenWord + Voices[randomIndex];
        Debug.Log("Generated AudioClipName: " + audioClipName);

        // Spil lydklippet, hvis det findes i mappen
        if (audioClipMap.TryGetValue(audioClipName, out AudioClip clip))
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
        else
        {
            Debug.LogError($"AudioClip with name '{audioClipName}' not found.");
        }
    }

    public void PlayRandomClip()
    {
        if (audioClips.Length == 0)
        {
            Debug.LogWarning("No audio clips loaded!");
            return;
        }

        // Vælg et tilfældigt klip fra listen
        AudioClip randomClip = audioClips[Random.Range(0, audioClips.Length)];
        audioSource.clip = randomClip;
        audioSource.Play();

        Debug.Log("Now playing random clip: " + randomClip.name);
    }

    public void OnPlayButtonClicked()
    {
        PlayRandomClip();
    }
    */
}