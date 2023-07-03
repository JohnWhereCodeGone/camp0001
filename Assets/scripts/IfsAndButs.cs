using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfsAndButs : MonoBehaviour
{
    [SerializeField]
    private float age;
    [ContextMenu("Check status")]

    public void CheckStatus()
    {
        switch (age)
        {
            case >= 65:
                Debug.Log("You are over or equal to 65");
                break;
            case >= 18:
                Debug.Log("You are over or equal to 18");
                break;
            case < 18:
                Debug.Log("You are underage.");
                break;
                
        }
    }
}
