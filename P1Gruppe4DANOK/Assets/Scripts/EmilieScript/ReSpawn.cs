using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject[] SpriteImages; 
    public RectTransform RespawnPanel; 

    private void Start()
    {
        SpawnAllSprites();
    }

    private void SpawnAllSprites()
    {
        
        Rect panelRect = RespawnPanel.rect;

        // Loops through all sprite images
        foreach (var SpriteImage in SpriteImages)
        {
            
            Vector2 randomPosition = new Vector2(
                Random.Range(panelRect.xMin, panelRect.xMax),
                Random.Range(panelRect.yMin, panelRect.yMax)
            );
            
            GameObject newImage = Instantiate(SpriteImage, RespawnPanel);

            RectTransform rectTransform = newImage.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = randomPosition;

        }
    }
}