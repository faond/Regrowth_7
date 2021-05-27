using UnityEngine;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour
{
    public static WinManager instance ;

    private void Awake()
    {
        if(instance != null){
          Debug.LogWarning("Il y a plus d'un WinManager");
          return ;
        }
        instance = this;
    }


    public GameObject winUI;

    public void OnPlayerWin(){
    
      winUI.SetActive(true);

    }

}
