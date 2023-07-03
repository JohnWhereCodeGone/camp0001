using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrisonBrag : MonoBehaviour
{

    public int murderCount;

    [ContextMenu("How popular are you?")]

    public void Popularity()
    {

        switch (murderCount)
        {
            case >= 100:
                Debug.Log("No one's gonna drop the soap round' you!");
                    break;
            case >= 50:
                Debug.Log("Holy moly you're a real psycho ain't ya?");
                    break;
            case >= 10:
                Debug.Log("You're alright, bud");
                break;
            case >= 5:
                Debug.Log("You got nuffin on the rest of us");
                break;
            case <= 0:
                Debug.Log("Whimpy-ass small time crook, get outta here.");
                break;
        }
    }

}
