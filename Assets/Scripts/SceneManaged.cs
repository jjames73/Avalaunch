using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManaged : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Rules()
    {
        SceneManager.LoadScene("GameRules");
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
