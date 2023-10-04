using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{

    //Speed of arrows
    private float Tempo;

    public bool hasStarted;

    public Conductor conductor;
    // Start is called before the first frame update
    void Start()
    {
        conductor = GameObject.FindGameObjectWithTag("Conductor").GetComponent<Conductor>();
        Tempo = conductor.SongBpm / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)//has game started?
        {
        /*    if (Input.anyKeyDown) //No - push any key to start
            {
                hasStarted = true;
            } */
        }
        else
        {
            transform.position -= new Vector3(0f, Tempo * Time.deltaTime, 0f); //yes- move arrows down
        }
    }
}
