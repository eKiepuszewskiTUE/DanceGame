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

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        mode = Mode.topdown;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mode == Mode.topdown)
        {
            ReadInputsTopdown();
        }
    }

    private void FixedUpdate()
    {
        //Store user input as a movement vector
        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        //Apply the movement vector to the current position, which is
        //multiplied by deltaTime and speed for a smooth MovePosition
        rb.MovePosition(transform.position + m_Input * Time.deltaTime * movement_speed);
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
        Destroy(pickup);
        Debug.Log("collect pickup");
    }

    // Upon being caught by the enemy activate the evading sequence
    void ActivateEnemyAttack()
    {
        Debug.Log("enemy attack");
    }
}
