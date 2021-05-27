using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager instance ;

    private void Awake()
    {
        if(instance != null){
          Debug.LogWarning("Il y a plus d'un GameOverManager");
          return ;
        }
        instance = this;
    }


    public GameObject gameOverUI;

    public void OnPlayerDeath(){
      if(CurrentSceneManager.instance.isPlayerPresentByDefault){
        DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
      }
      gameOverUI.SetActive(true);
    }

    public void RetryButton(){
        Inventory.instance.RemoveCoins(CurrentSceneManager.instance.coinsPickedUpInThisScene);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerHealth.instance.Respawn();
        gameOverUI.SetActive(false);
    }

    public void QuitButton(){
        Application.Quit();
    }

    public void MainMenuButton(){
        DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
        SceneManager.LoadScene("MainMenu");
    }
}
