using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private bool isDead;
    [SerializeField]
    private float health;
    [SerializeField]
    private float healGain;
    [SerializeField]
    private float maxHealth = 100;

    // Update is called once per frame
    public void Update()
    {


    }
    public void HealthGain(float _Life)
    {


        Debug.Log("Howdy, I gained " + _Life + " life!");
        health += _Life;

        if (health  >= maxHealth)
        {
            health = maxHealth;
        }

        

    }

    


    public void TakeDamage(float _Damage)
    {
        Debug.Log("Hello, I took " + _Damage + " damage!");
        health -= _Damage;

        if (health <= 0)
        {
            Die();
        }
    } 
    private void Die()
    {
        Debug.Log("Shiiiiiiied, you's a dead ass");
        gameObject.SetActive(false);
        isDead = true;
    }

    }
//Warning this is still better than EA.