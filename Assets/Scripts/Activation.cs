using UnityEngine;

public class Activation : MonoBehaviour
{

  public GameObject graph;
  public bool isAlive=true;
  public float timer = -1 ;
  //public bool timerIsRunning = false;



    void Update()
    {

      if (!isAlive)
          {
            if (timer > 0)
            {

                timer -= Time.deltaTime;
            }
            else
            {
              graph.SetActive(true);
              //transform.GetChild(0).SetActive(true);
              timer = -1;
              isAlive = true;
            }
          }

    }
}
