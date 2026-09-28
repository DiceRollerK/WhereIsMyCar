using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip click;
    public void CityScene()
    {
        audioSource.PlayOneShot(click);
        SceneManager.LoadScene("CityScene");
    }
    public void MainMenu()
    {
        audioSource.PlayOneShot(click);
        SceneManager.LoadScene("MainMenu");
    }
    public void ExitGame()
    {
        audioSource.PlayOneShot(click);
        Application.Quit();
    }
}
