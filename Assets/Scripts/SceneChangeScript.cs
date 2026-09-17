using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeScript : MonoBehaviour
{
    public void CityScene()
    {
        SceneManager.LoadScene("CityScene");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
