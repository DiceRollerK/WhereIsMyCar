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
    public void ExitGame()
    {
        audioSource.PlayOneShot(click);
        Application.Quit();
    }
}
