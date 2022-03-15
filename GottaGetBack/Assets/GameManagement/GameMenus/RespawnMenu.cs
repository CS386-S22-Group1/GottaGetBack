using UnityEngine.SceneManagement;
using UnityEngine;

public class RespawnMenu : MonoBehaviour
{
    public void ResetGame()
    {
        SceneManager.LoadScene( 0 );
    }
}
