using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePopping : MonoBehaviour
{
    private List<Vector2> positions = new List<Vector2>();
    public GameObject[] lifeMarkers;
    public GameObject lifeBulb;

    //Random
    Random rand = new Random();

    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i < lifeMarkers.Length; i++) {
            Vector2 position = new Vector2(lifeMarkers[i].transform.position[0], lifeMarkers[i].transform.position[1]);
            positions.Add(position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(RandomManager.instance.lifeMustPop && positions.Count > 0){
            int randIndex = RandomManager.instance.Binomial(positions.Count, 0.5f);
            Instantiate(lifeBulb, new Vector3(positions[randIndex].x,positions[randIndex].y,0), new Quaternion(0,0,0,0));
            RandomManager.instance.lifeMustPop = false;
            positions.RemoveAt(randIndex);
        }

    }
}
