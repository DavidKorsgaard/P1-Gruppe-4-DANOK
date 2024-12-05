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

        // Getting the dimensions of the panel
        Rect panelRect = SpawnPanel.rect;

        // Generates a random position within the panel
        Vector2 randomPosition = new Vector2(
            Random.Range(panelRect.xMin, panelRect.xMax),
            Random.Range(panelRect.yMin, panelRect.yMax)
        );

        // Instantiates a new image as a child of the (parent) panel
        GameObject NewImage = Instantiate(SpriteImages[SpriteIndex], SpawnPanel);

        // Setting its position 
        RectTransform imageTransform = NewImage.GetComponent<RectTransform>();
        imageTransform.anchoredPosition = randomPosition;

        // Updating the image index with pre-increment
        SpriteIndex = ++SpriteIndex;
    }   
}