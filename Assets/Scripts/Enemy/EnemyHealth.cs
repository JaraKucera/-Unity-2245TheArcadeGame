using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private int health = 10;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BulletPlayer1"))
        {
            health -= 5;
            Destroy(other.gameObject);
            HealthCheck();
        }
        else if (other.gameObject.CompareTag("BulletPlayer2"))
        {
            health -= 10;
            Destroy(other.gameObject);
            HealthCheck();
        }
        else if (other.gameObject.CompareTag("BulletPlayer3"))
        {
            health -= 15;
            Destroy(other.gameObject);
            HealthCheck();
        }
    }
    public void SetHealth(int health) => this.health = health;
    private void HealthCheck()
    {
        if (health <= 0)
        {
            GameManager.instance.RemoveFromEnemies(gameObject);
            GameManager.instance.IncreaseScore();
            Explode();
            Destroy(gameObject);
        }
    }

    private void Explode()
    {
        GameObject explode = (GameObject)Instantiate(Resources.Load("Explosion2"));
        explode.transform.position = transform.position;
        explode.GetComponent<ParticleSystem>();
    }
}
