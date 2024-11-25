using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsDesign : MonoBehaviour
{
    //variables for colour
    public Color newColor; // Set the desired color in the Inspector
    public GameObject toggleParent;

    //image 
    public Image newImage;

    void Start()
    {
        // Find all Toggle components in the scene
        Toggle[] allToggles = FindObjectsOfType<Toggle>();

        foreach (Toggle toggle in allToggles)
        {
            // Access the Toggle's background Image
            Image backgroundImage = toggle.GetComponentInChildren<Image>();
            if (backgroundImage != null)
            {
                // Change the background color
                backgroundImage.color = newColor;
            }
            if (Checkmark.i)
        }
    }
}

