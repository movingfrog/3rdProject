using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("MapChoceScene");
    }

    public void FirstMap()
    {
        SceneManager.LoadScene("FirstWorld");
    }
}
