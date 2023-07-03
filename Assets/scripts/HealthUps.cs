using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUps : MonoBehaviour
{
    [SerializeField]
    private Player_Health pickups;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            pickups.HealthGain(20);
            Debug.Log("Healthups Working!");

        }

    }
}
