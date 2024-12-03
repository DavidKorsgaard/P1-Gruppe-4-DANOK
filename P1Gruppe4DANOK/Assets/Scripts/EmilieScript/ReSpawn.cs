using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject[] spriteImages; // Array of sprites to spawn (Sprite 1, Sprite 2, etc.)
    public RectTransform respawnPanel; // The panel where the sprites will be spawned

    private void Start()
    {
        SpawnAllSprites();
    }

    private void SpawnAllSprites()
    {
        // Calculates the world-space corners of the respawn panel
        Vector3[] corners = new Vector3[4]; // Vector3 represents a 3D point in space
        respawnPanel.GetWorldCorners(corners); //GetWorldCorners is a method of RectTransform

        // Loops through all sprite images and spawns them
        foreach (var spriteImage in spriteImages)
        {
            Vector3 spawnPosition = new Vector3(
                Random.Range(corners[0].x, corners[2].x), //corners[0].x is the bottom left x, corners[2].x is top right
                Random.Range(corners[0].y, corners[2].y), 
                corners[0].z 
            );

            // Instantiates the sprite image
            GameObject newImage = Instantiate(spriteImage, spawnPosition, Quaternion.identity, respawnPanel);

                
            RectTransform rectTransform = newImage.GetComponent<RectTransform>();
                
            // Converts world position to local position relative to the respawnPanel
            rectTransform.anchoredPosition = respawnPanel.InverseTransformPoint(spawnPosition);
                  
        }
    }
}