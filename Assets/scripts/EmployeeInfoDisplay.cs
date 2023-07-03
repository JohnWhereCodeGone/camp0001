using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeInfoDisplay : MonoBehaviour
{
    [SerializeField]
    private List<Employee> employee;
    [SerializeField]
    private Queue<Employee> employeeQueue = new Queue<Employee>();

    [ContextMenu("Add to queue")]
    public void AddToQueue()
    {
        foreach (Employee emp in employee)
        {
            employeeQueue.Enqueue(emp);
        }
    }

    [ContextMenu("Process the first in queue")]
    public void ProcessQueue()
    {

        if (employeeQueue.Count <= 0)
        {
            Debug.Log("Queue is empty dumb dumb.");
            return;
        }
        
        Employee employee = employeeQueue.Dequeue();
        
        Debug.Log("Howdy, name's " + employee.employeeName);
    }

    [ContextMenu("List my employees")]
    public void EmployeeInfo()
    {

        foreach (Employee emp in employee)
        {
            Debug.Log("Stop smooching me. my name is " + emp.employeeName + " I am " + emp.employeeAge + "\n years old. In addition, I'm " + emp.employeeHeight + " meters tall. I may or may not have been a president, guy. You're making me feel " + emp.emotion);
        }

    }
}
