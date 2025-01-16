using UnityEngine;
using UnityEngine.UI;  // For UI elements like Image
using System;
using System.IO;

public class DisplayScreenshot : MonoBehaviour
{
    public Image galleryImage;  // Reference to the Image component in the gallery

    private string screenshotFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);  
    /* (same path as in screenshotmanager) i make a new one for readibilty. Path to the Pictures folder. Provided by the .NET framework to get the path of a specific system 
    folder dynamically retrieves the correct folder path based on the user's operating system and settings*/

    void Start()
    {
        // Calling the method. Load and display the most recent screenshot when the game starts
        LoadLatestScreenshot();
    }

    // Load the most recent screenshot and display it
    private void LoadLatestScreenshot() //not accesible from outside. void does not return anything 
    {
        string folderPath = Path.Combine(screenshotFolder, "Selfies"); 
        /*Finds the path to the selfie folder. path.combine for crossplatform combatibility. also instead of + seperator. 
         Combining paths tells the program: "Go to the screenshotFolder, then look inside the Selfies subfolder."*/

        // Get all screenshot files (ending with .png) in the folder and adds it to the string
        string[] files = Directory.GetFiles(folderPath, "*.png");

        // If no files are found, return
        if (files.Length == 0) // == 0 means no entries in the array 
        {
            Debug.LogWarning("No screenshots found in the folder.");
            return;
        }

        // Get the most recent screenshot (the last file in the array)
        // -1 accounts for the fact that we count from 0. aka 0 is the first placeholder in the array. you alwas acces the top/newest number 
        string latestScreenshot = files[files.Length - 1];

        // Display the image 
        DisplayImage(latestScreenshot);
    }

    // Display the image in the gallery
    private void DisplayImage(string path)
    {
        // Load texture from file
        Texture2D texture = LoadTextureFromPath(path);
        if (texture == null) return;

        // Convert texture to sprite and assign to the gallery Image component
        Sprite newSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        galleryImage.sprite = newSprite;
    }

    // Helper to load texture from file path
    private Texture2D LoadTextureFromPath(string path)
    {
        if (!File.Exists(path))
        {
            Debug.LogError($"File not found: {path}");
            return null;
        }

        //make it easier for the computer.  loading raw byte data from the file and decoding it into a format that Unity understands.
        byte[] fileData = File.ReadAllBytes(path); 
        Texture2D texture = new Texture2D(2, 2); //2, 2 are placeholders that will be replaced in displayImage method (magic numbers ups) 
        if (texture.LoadImage(fileData))
        {
            return texture;
        }
        return null;
    }
}
