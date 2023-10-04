using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{

    private SpriteRenderer render; //get the render of the button
    public Sprite DefaultImage; //normal image of button
    public Sprite PressedImage; //pressed image of button

    public KeyCode keyToPress;

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            render.sprite = PressedImage;
        }

        if (Input.GetKeyUp(keyToPress))
        {
            render.sprite = DefaultImage;
        }

    }
}