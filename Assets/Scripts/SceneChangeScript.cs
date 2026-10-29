using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip click;

    public void CityScene()
    {
        ChangeScene("CityScene");
    }
    public void MainMenu()
    {
        ChangeScene("MainMenu");
    }
    public void TowerScene()
    {
        ChangeScene("TowerScene");
    }

    void ChangeScene(string sceneName)
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(click);
        }
        InterstitialAd ad = AdManager.Instance != null ? AdManager.Instance.interstitialAd : null;

        if (ad != null && ad.isReady)
            ad.ShowAd(sceneName);               
        else
            SceneManager.LoadScene(sceneName);  
    }

    public void ExitGame()
    {
        if (audioSource != null) audioSource.PlayOneShot(click);
        Application.Quit();
    }
}