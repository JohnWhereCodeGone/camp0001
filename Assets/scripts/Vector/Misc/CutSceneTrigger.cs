using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CutSceneTrigger : MonoBehaviour
{
    [SerializeField]
    private UnityEvent trigger; 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        trigger ?.Invoke();
    }
}
