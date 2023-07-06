using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausedScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        GameManager.SubscribeToPause(Toggle);
    }
    private void Toggle(bool _State)
    {

        enabled = !_State;
        gameObject.SetActive(_State);
        

    }

}
