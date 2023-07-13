using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class ItemSpin : MonoBehaviour
{
    [SerializeField]
    public int rotSpeed;
    public float yRotation = 0f;

    public EmployeeInformation localEmployeeInfo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EmployeeVisualizer.instance.AddAnItem(localEmployeeInfo);
            gameObject.SetActive(false);
        }
    }


    void Update()
    {
        transform.localEulerAngles += Time.deltaTime * rotSpeed * transform.up;
    }
}
