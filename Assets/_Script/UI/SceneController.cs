using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
  

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    public void LoadLobby()
    {
       SceneManager.LoadScene(0);
       
    }
}
