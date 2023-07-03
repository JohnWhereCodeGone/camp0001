using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    [SerializeField]
    private Player_Health playerHP;
    [SerializeField]
    private float damage;
        
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerHP.TakeDamage(damage);

        }
        
    }

}
//Warning this is still better than EA.