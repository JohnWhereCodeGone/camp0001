using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_New : MonoBehaviour
{
    public string playerName = "Mike Labowski";
    public int playerAge = 25;
    [SerializeField]
    private bool isMale = true;
    [SerializeField]
    private float height = 4.78f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello, my name is " + playerName + "\n" + " I am " + playerAge + " years old.");
        Debug.Log("I am a " + GenderCheck() + ", I'm also " + height + " meters tall");

    }
    private string GenderCheck()
    {
        if (isMale == true)
        {
            return "male";
            
        }
        return "female";
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
