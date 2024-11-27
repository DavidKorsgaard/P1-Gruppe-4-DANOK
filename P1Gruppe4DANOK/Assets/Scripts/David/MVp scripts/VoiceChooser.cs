
using UnityEngine;
using System.Collections.Generic;

public class VoiceChooser : MonoBehaviour
{
    public AudioSource audioSource;          // Reference til AudioSource
    public AudioClip[] audioClips;           // Array med alle AudioClips
    private Dictionary<string, AudioClip> audioClipMap; // Map til hurtig adgang til klip

    private string audioClipName;            // Dynamisk genereret navn på lydklip
    public GameObject Logic;                 // Reference til Logic-objektet
    public WordGenerator WordGenerator;      // Reference til WordGenerator-scriptet
    private string[] Voices = { "_F1", "_F2", "_M1", "_M2" }; // Stemmetyper

    public GameObject ThumbsUp;
    public GameObject ThumbsDown;
    void Awake()
    {
        // Initialiser komponenter og references
        audioSource = GetComponent<AudioSource>();
        Logic = GameObject.Find("Logic");
        WordGenerator = Logic.GetComponent<WordGenerator>();
        audioClips = Resources.LoadAll<AudioClip>("Audio/F1");

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
    
    public void PlayAudio()
    {
        if (WordGenerator == null)
        {
            Debug.LogError("WordGenerator is not assigned.");
            return;
        }

        // Vælg en tilfældig stemme
        int randomIndex = Random.Range(0, Voices.Length);
        audioClipName = WordGenerator.ChosenWord + Voices[0];
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

    public void PlaySameAudio()
    {
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.PlayOneShot(audioSource.clip);
        }
        else
        {
            Debug.LogError("AudioSource or clip is missing!");
        }
    }
}