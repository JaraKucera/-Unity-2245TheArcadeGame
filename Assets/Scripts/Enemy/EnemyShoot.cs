using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    private float shootSpeed = 0.5f;
    void Start() => InvokeRepeating("Shoot", 0f, shootSpeed);
    public void SetShootSpeed(float speed) => shootSpeed = speed;
    private void Shoot()
    {
        GameObject bullet = (GameObject)Instantiate(Resources.Load("EnemyBullet"));
        bullet.transform.position = this.transform.position;
    }
}
