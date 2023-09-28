using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    GameObject player;

    [SerializeField] float speed;

    [SerializeField] Sprite default_sprite;
    [SerializeField] Sprite stunned_sprite;

    // Is the enemy stunned/staggered after combat (he cannot move if true)
    public bool stunned;

    // Amount of time the enemy is stunned [in seconds]
    public float stun_time;

    Vector2 directionToPlayer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        stunned = false;
        GetComponent<SpriteRenderer>().sprite = default_sprite;
    }

    // Update is called once per frame
    void Update()
    {
        directionToPlayer = gameObject.transform.position - player.transform.position;
        //Debug.Log(directionToPlayer);
        directionToPlayer = directionToPlayer.normalized * -1f;

        if (!stunned)
        {
            gameObject.transform.Translate(directionToPlayer * Time.deltaTime * speed);
        }


        // REMOVE LATER (FOR DEBUG)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(StunEnemy());
        }
    }

    // Stun enemy for [stun_time] amount of seconds
    IEnumerator StunEnemy()
    {
        Debug.Log("start stun");
        stunned = true;
        GetComponent<SpriteRenderer>().sprite = stunned_sprite;
        yield return new WaitForSeconds(stun_time);
        GetComponent<SpriteRenderer>().sprite = default_sprite;
        stunned = false;
    }
}
