using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityFunctions : MonoBehaviour
{
    /*    private void Awake()
        {

        }
        private void OnEnable()
        {

        }

        // Start is called before the first frame update
        void Start()
        {

        }
        private void OnDisable()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        private void LateUpdate()
        {

        }
        private void FixedUpdate()
        {

        }*/
    public Color Color = Color.white;
    public Color ExitColor = Color.white;
    private void OnMouseEnter()
    {
        GetComponent<MeshRenderer>().material.color = Color;
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.SetActive(false);
        }
    }
    
    private void OnMouseExit()
    {
        
        GetComponent<MeshRenderer>().material.color = ExitColor;
    }
}
