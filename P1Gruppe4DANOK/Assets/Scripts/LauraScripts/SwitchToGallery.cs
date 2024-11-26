using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchToGallery : MonoBehaviour
{
   public void GoToSelfieGalleryScene()
    {
        SceneManager.LoadScene("SelfiegalleryScene");
    }
}
