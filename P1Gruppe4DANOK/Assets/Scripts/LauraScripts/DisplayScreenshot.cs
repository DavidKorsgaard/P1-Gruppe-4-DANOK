using UnityEngine;
using UnityEngine.UI;  // For UI elements like Image
using System;
using System.IO;

public class DisplayScreenshot : MonoBehaviour
{
    public Image galleryImage;  // Reference to the Image component in the gallery

    private string screenshotFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);  // Path to the Pictures folder

    void Start()
    {
        // Load and display the most recent screenshot when the game starts
        LoadLatestScreenshot();
    }

    // Load the most recent screenshot and display it
    private void LoadLatestScreenshot()
    {
        string folderPath = Path.Combine(screenshotFolder, "Selfies");

        // Get all screenshot files in the folder
        string[] files = Directory.GetFiles(folderPath, "*.png");

        // If no files are found, return
        if (files.Length == 0)
        {
            Debug.LogWarning("No screenshots found in the folder.");
            return;
        }

        // Get the most recent screenshot (the last file in the array)
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

        byte[] fileData = File.ReadAllBytes(path);
        Texture2D texture = new Texture2D(2, 2);
        if (texture.LoadImage(fileData))
        {
            return texture;
        }
        return null;
    }
}
