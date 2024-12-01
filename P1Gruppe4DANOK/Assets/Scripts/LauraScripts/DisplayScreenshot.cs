using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DisplayScreenshot : MonoBehaviour
{
    public Image galleryImage;  // Reference to the Image component in the gallery where the selfie will be displayed

    private string screenshotFolder;

    void Start()
    {
        // Set the folder where screenshots are saved (Pictures/Selfies folder)
        screenshotFolder = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures), "Selfies");

        // Ensure the folder exists
        if (!Directory.Exists(screenshotFolder))
        {
            Directory.CreateDirectory(screenshotFolder);
        }

        // Load the most recent screenshot when the game starts (or whenever you want)
        LoadLatestScreenshot();
    }

    // Load the most recent screenshot into the gallery
    private void LoadLatestScreenshot()
    {
        // Get all the screenshot files in the "Selfies" folder - *this is already in the other script*
        string[] files = Directory.GetFiles(screenshotFolder, "*.png");

        // If there are no screenshots, exit
        if (files.Length == 0)
        {
            Debug.LogWarning("No screenshots found in the folder.");
            return;
        }

        // Get the most recent screenshot (last in the list)
        string latestScreenshot = files[files.Length - 1]; // i already have a string called most recentfile-which one runs?

        // Load and display the most recent screenshot
        DisplayImage(latestScreenshot);
    }

    // Method to display the image in the gallery (UI Image component)
    private void DisplayImage(string path)
    {
        // Load the texture from the file
        Texture2D texture = LoadTextureFromPath(path);
        if (texture == null) return;

        // Convert texture to a sprite and assign to the gallery Image component
        Sprite newSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        galleryImage.sprite = newSprite;
    }

    // Helper method to load a texture from the file path
    private Texture2D LoadTextureFromPath(string path)
    {
        if (!File.Exists(path))
        {
            Debug.LogError($"File not found: {path}");
            return null;
        }

        // *i have this function 2 times*
        byte[] fileData = File.ReadAllBytes(path);
        Texture2D texture = new Texture2D(2, 2);
        if (texture.LoadImage(fileData))
        {
            return texture;
        }
        return null;
    }
}
