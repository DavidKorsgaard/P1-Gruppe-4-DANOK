using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSpawnerScript : MonoBehaviour
{
    public GameObject[] SpriteImages; // Array of prefab images
    public RectTransform SpawnPanel; // Panel where images will spawn

    public int clickCount = 0; // Tracks number of clicks
    private int spriteIndex = 0; // Tracks the current sprite to use

    public void OnButtonClick()
    {
        //click count
        clickCount++;

        // Every second click, spawn an image
        if (clickCount % 2 == 0)
        {
    
             SpawnImage();
            
        }
    }


    private void SpawnImage()
    {
        if (SpriteImages.Length == 0) return;

        // Calculate the world-space corners of the spawn panel
        Vector3[] corners = new Vector3[4];
        SpawnPanel.GetWorldCorners(corners);

        // Generate a random position within the bounds of the panel
        Vector3 spawnPosition = new Vector3(
            Random.Range(corners[0].x, corners[2].x), // Random X between bottom left and top right corners
            Random.Range(corners[0].y, corners[2].y), // -||-
            corners[0].z
        );

        // Instantiate the sprite image
        GameObject NewImage = Instantiate(SpriteImages[spriteIndex], spawnPosition, Quaternion.identity, SpawnPanel);
    
        // Ensure the image stays in its local hierarchy
        RectTransform rectTransform = NewImage.GetComponent<RectTransform>();
            
        // Convert to local position based on spawnPanel
        rectTransform.anchoredPosition = SpawnPanel.InverseTransformPoint(spawnPosition);

        // Update the image index (loop back to the start if needed)
        spriteIndex = (spriteIndex + 1) % SpriteImages.Length;
      
    }

    
    
}