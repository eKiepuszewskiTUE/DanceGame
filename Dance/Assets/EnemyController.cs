using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    GameObject player;

    [SerializeField]
    float speed;

    Vector2 directionToPlayer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        directionToPlayer = gameObject.transform.position - player.transform.position;
        //Debug.Log(directionToPlayer);
        directionToPlayer = directionToPlayer.normalized * -1f;

        gameObject.transform.Translate(directionToPlayer * Time.deltaTime * speed);
    }
}
