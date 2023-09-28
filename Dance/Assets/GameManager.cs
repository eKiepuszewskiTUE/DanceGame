using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // Spawns pickup at random location within the playspace
    void SpawnPickup()
    {
        float screen_width = Screen.width;
        float screen_height = Screen.height;
        Vector2 location = new Vector2(Random.value * screen_width, Random.value * screen_height);
    }
}
