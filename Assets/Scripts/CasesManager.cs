using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasesManager : MonoBehaviour
{
    public static CasesManager instance ;
    public int nbWiltCases; 

    private void Awake()
    {
        if(instance != null){
          Debug.LogWarning("Il y a plus d'un CasesManager");
          return ;
        }
        instance = this;
    }

    void Update(){
        bool win = true;
        nbWiltCases = transform.childCount;
        foreach(Transform child in transform){
            if(child.tag == "Wilt") win = false;
            else nbWiltCases--;
      }

      if(win) {
            WinManager.instance.OnPlayerWin();
            return;
      }
    }
}
