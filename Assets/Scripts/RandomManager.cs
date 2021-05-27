using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomManager : MonoBehaviour
{
    public static RandomManager instance { get; private set; }
    // public Slider difficulty;
    public bool lifeMustPop = false;
    public float difficulty = 0;
    public float nbWiltCases; 


    private void Awake()
    {
        if(instance != null){
          Debug.LogWarning("Il y a plus d'un RandomManager");
          return ;
        }
        instance = this;
    }

    public bool RandomTrueOrFalse(float p){
        return (Bernoulli(p) == 1);
    }

    public int Uniform(int min, int max){
        var rand = new System.Random(); 
        int u = rand.Next(min, max + 1);
        return u;
    }

    public int Bernoulli(float p){  
        float u = Random.Range(0.0f,1.0f);
        if (u <= p) return 1; // P( X = 1 ) = p
        return 0; // P( X = 0 ) = 1 - p
    }

    public int Binomial(int n, float p){
        int result = 0;
        for(int i=0; i<n; i++){
            result += Bernoulli(p);
        }
        return result;
    }

    // public int Poisson(float lambda){
    //     //Wikipédia : simulation avec la méthode de la transformée inverse
    //     int k = 0;
    //     float p = 1;
    //     float u;
    //     while (p > Exp(-lambda)) {
    //         u = Uniform(0.0f, 1.0f)
    //         p = p * u;
    //         k ++;
    //     }
    //     return k - 1;
    // }

    public int Geometric(float p){
        int count = 0;
        while(Bernoulli(p) != 1) count ++;
        return count;
    }
}
