using UnityEngine;
using UnityEngine.UI;

public class Transformation : MonoBehaviour
{

  public Animator animator;
  public float timer = -1 ;
  public bool timerIsRunning = false;
  //public Slider difficulty;

  public Slider difficulty;


  public void Update(){
    if (timerIsRunning)
        {
          if (timer > 0 && gameObject.tag == "Bloom")
          {
              timer -= Time.deltaTime;
          }
          else
          {
            animator.SetTrigger("Wilt");
            if(transform.childCount > 0){
              for(int i=0 ; i<transform.childCount; i++){
               transform.GetChild(i).gameObject.GetComponent<Animator> ().SetTrigger("Wilt");
              }
             }
            gameObject.tag = "Wilt";
            timer = -1;
            timerIsRunning = false;
          }
        }

  }



  private void OnCollisionEnter2D(Collision2D collision)
  {
      if(collision.transform.CompareTag("Player") && gameObject.tag == "Wilt")
      {
        animator.SetTrigger("Bloom");
        if(transform.childCount > 0){
          for(int i=0 ; i<transform.childCount; i++){
           transform.GetChild(i).gameObject.GetComponent<Animator> ().SetTrigger("Bloom");
           //Debug.LogWarning(difficulty.value);
           // ICI CA COINCE
          }
        }
        gameObject.tag = "Bloom";
        int rand = RandomManager.instance.Bernoulli(RandomManager.instance.difficulty);
        if( rand == 1 ){
          timer = RandomManager.instance.Geometric(RandomManager.instance.difficulty)*2 + 7;
          timerIsRunning = true;
        }
      }
  }
}
