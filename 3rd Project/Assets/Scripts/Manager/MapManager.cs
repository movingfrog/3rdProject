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

    public void SecondMap()
    {
        SceneManager.LoadScene("SecondWorld");
    }

    public void ThirdMap()
    {
        SceneManager.LoadScene("ThirdWorld");
    }

    public void FourthMap()
    {
        SceneManager.LoadScene("FourthWorld");
    }
}
