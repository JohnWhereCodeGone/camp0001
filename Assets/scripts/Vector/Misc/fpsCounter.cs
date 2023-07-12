using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class fpsCounter : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI counter;

    [SerializeField]
    private float updateFrequency;

    private float time;

    private void Awake()
    {
      counter.text = (1 / Time.deltaTime).ToString("000");

    }
    void Update()
    {
        time += Time.deltaTime * updateFrequency;
        if (time >= 1)
        {
        counter.text = (1 / Time.deltaTime).ToString("000");
            time--;
        }
    }
}
