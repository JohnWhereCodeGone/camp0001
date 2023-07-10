using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ColorChanger : MonoBehaviour
{
    [SerializeField]
    private Color colorNormal;
    [SerializeField]
    private Color colorChanger;
    [SerializeField]
    public Renderer componentColor;
    public void ColorPress()
    {
        if (Input.GetKeyDown(KeyCode.Y) == true)
        {

            componentColor.material.color = colorChanger;

        }
        
        if (Input.GetKeyUp(KeyCode.Y) == true)
        {
            componentColor.material.color = colorNormal;
        }

    }
    public void Awake()
    {
        componentColor = gameObject.GetComponent<Renderer>();
        
    }




    // Update is called once per frame
    void Update()
    {
        ColorPress();
        Awake();
    }
}
