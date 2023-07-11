using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introSequenceStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CutSceneManager.instance.StartCutScene("introSequence");
    }


}
