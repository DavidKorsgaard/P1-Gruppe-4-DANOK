using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSpawnerScript : MonoBehaviour
{
    public GameObject[] SpriteImages; // Array of prefab images
    public RectTransform SpawnPanel; // Panel where images will spawn, RectTransform handles position and addtional Ui features

    public int clickCount = 0; // Tracks number of clicks
    private int SpriteIndex = 0; // Tracks the current sprite to use

    public void OnButtonClick()
    {
        //Click counter with post-increment 
        clickCount++;

        // Every second click, spawn an image (modulus operator)
        if (clickCount % 2 == 0)
        {
             SpawnImage();     
        }
    }

    private void SpawnImage()
    {
        if (SpriteImages.Length == 0) return;

        // Calculate the corners of the spawn panel
        Vector3[] corners = new Vector3[4];
        SpawnPanel.GetWorldCorners(corners);

        // Generate a random position in the spawn panel
        Vector3 SpawnPosition = new Vector3
        (
            Random.Range(corners[0].x, corners[2].x), // Random X between bottom left and top right corners
            Random.Range(corners[0].y, corners[2].y), // Random is not true random but a pseudo-random number generator
            corners[0].z
        );

        // Instantiate a new gameobject, using prefabs from SpriteImage
        GameObject NewImage = Instantiate(SpriteImages[SpriteIndex], SpawnPosition, Quaternion.identity, SpawnPanel);

        //SpriteImages[SpriteIndex] tells Instantiate what image to spawn,
            // - spawnpostion is random coordinates in the spawnpanel
            // - Quaternion.identity: This quaternion corresponds to "no rotation"
            // - SpawnPanel the area where 

        // Ensure the image stays in its local hierarchy
        RectTransform ImageTransform = NewImage.GetComponent<RectTransform>(); //A Unity method used to access any component attached to the GameObject

        // Convert to local position based on spawnPanel
        ImageTransform.anchoredPosition = SpawnPanel.InverseTransformPoint(SpawnPosition); //

        //anchored position is used to position a UI element within its parent container
        //Transforms that world space position into local position in SpawnPanel

        // Updating the image index with pre-increment
        SpriteIndex = ++SpriteIndex;
    }   
}