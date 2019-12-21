using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int health = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyBullet")
        {
            if (!(GetComponent<PlayerShield>().ShieldActive()))
            {
                health -= 1;
                Destroy(other.gameObject);
                HealthCheck();
            }
            else
            {
                //Debug.Log("No damage done, shield is active");
            }
        }
    }
    private void HealthCheck()
    {
        if (health <= 0)
        {
            GameManager.instance.ReduceHealth();
        }
    }
}
