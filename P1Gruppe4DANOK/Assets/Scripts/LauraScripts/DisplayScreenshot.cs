using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DisplayScreenshot : MonoBehaviour
{
    public Image screenshotImage; // Assign this in the Inspector

    private void Start()
    {
        // Get the screenshot path from ScreenshotManager
        string path = ScreenshotManager.GetScreenshotPath();

        if (File.Exists(path))
        {
            // Load the screenshot file
            byte[] imageBytes = File.ReadAllBytes(path);
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(imageBytes);

            // Set the texture as a sprite
            screenshotImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        }
        else
        {
            Debug.LogWarning("Screenshot not found at: " + path);
        }
    }
}

