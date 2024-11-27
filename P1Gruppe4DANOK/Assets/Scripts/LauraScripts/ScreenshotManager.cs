using UnityEngine;
using UnityEngine.UI; // For UI elements
using TMPro; // For TextMeshPro (if you're using it for text UI elements)
using System;
using System.IO;

public class ScreenshotManager : MonoBehaviour
{
    public GameObject[] uiElementsToHide;  // UI elements to hide during capture
    

    private string screenshotFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);  // Path to Pictures folder on your PC

    // Method to capture the screenshot
    public void CaptureScreenshot()
    {
        // Ensure the folder exists
        string folderPath = Path.Combine(screenshotFolder, "Selfies");
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        // Create a unique filename using timestamp
        string fileName = $"selfie_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.png";
        string filePath = Path.Combine(folderPath, fileName);

        // Hide UI before capturing
        ToggleUI(false);

        // Capture the screenshot
        ScreenCapture.CaptureScreenshot(filePath);
        Debug.Log($"Screenshot saved at: {filePath}");

        // After a short delay, show UI and update the gallery
        Invoke(nameof(RestoreUIAndUpdateGallery), 0.5f);  // Delay to ensure screenshot is saved before updating the gallery
    }

    // Method to restore UI and update gallery with the new selfie
    private void RestoreUIAndUpdateGallery()
    {
        // Show UI elements again
        ToggleUI(true);

        // Display the most recent selfie in the gallery
        string folderPath = Path.Combine(screenshotFolder, "Selfies");
        string[] files = Directory.GetFiles(folderPath, "*.png");
        if (files.Length > 0)
        {
            string mostRecentFile = files[files.Length - 1];  // The most recently captured file
            UpdateGallery(mostRecentFile);
        }
    }

    // Method to update the gallery with the new screenshot
    private void UpdateGallery(string screenshotPath)
    {
        Texture2D texture = LoadTextureFromPath(screenshotPath);
        if (texture == null) return;

        // Convert the texture to a sprite and assign it to the gallery image
        Sprite newSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        
    }

    // Helper to load texture from file
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

    // Toggle visibility of UI elements (true = show, false = hide)
    private void ToggleUI(bool show)
    {
        foreach (GameObject element in uiElementsToHide)
        {
            if (element != null)
            {
                element.SetActive(show);
            }
        }
    }
}
