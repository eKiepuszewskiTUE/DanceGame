using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    public enum Mode
    {
        topdown,
        fight
    }

    public Mode mode;

    [SerializeField]
    private float movement_speed;

    private float horizontal_movement;
    private float vertical_movement;
    private Vector2 movement_vector;

    // Start is called before the first frame update
    void Start()
    {
        mode = Mode.topdown;
    }

    // Update is called once per frame
    void Update()
    {
        if (mode == Mode.topdown)
        {
            ReadInputsTopdown();
        }

        movement_vector = new Vector2(horizontal_movement, vertical_movement).normalized * movement_speed * Time.deltaTime;
        gameObject.transform.Translate(movement_vector);
    }

    // Reads the players inputs (for now it's just the keyboard inputs)
    void ReadInputsTopdown()
    {
        horizontal_movement = Input.GetAxis("Horizontal");
        vertical_movement = Input.GetAxis("Vertical");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "pickup")
        {
            CollectPickup(collision.gameObject);
        }
        if (collision.gameObject.tag == "enemy")
        {
            ActivateEnemyAttack();
        }
    }

    // Collect given pickup
    void CollectPickup(GameObject pickup)
    {
        Debug.Log("collect pickup");
    }

    // Upon being caught by the enemy activate the evading sequence
    void ActivateEnemyAttack()
    {
        Debug.Log("enemy attack");
    }
}
