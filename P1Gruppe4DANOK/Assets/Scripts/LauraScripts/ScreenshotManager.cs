using UnityEngine;
using System;
using System.IO;

public class ScreenshotManager : MonoBehaviour
{
    // UI elements to hide during screenshot capture (optional)
    public GameObject[] uiElementsToHide;
    public GameObject buttonToHidePermanently;  // Button that will remain hidden after capturing

    private string screenshotFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);  // Path to the Pictures folder

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

        // Hide UI before capturing (optional)
        ToggleUI(false);

        // Capture the screenshot and save it
        ScreenCapture.CaptureScreenshot(filePath);
        Debug.Log($"Screenshot saved at: {filePath}");

        // After a short delay, restore the UI
        Invoke(nameof(RestoreUI), 0.5f);  // Adjust delay if needed
    }

    // Method to restore UI and hide the permanent button
    private void RestoreUI()
    {
        // Show all UI elements again, except the button that should be permanently hidden
        ToggleUI(true);
        if (buttonToHidePermanently != null)
        {
            buttonToHidePermanently.SetActive(false);
        }
    }

    // Helper to toggle visibility of UI elements
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
