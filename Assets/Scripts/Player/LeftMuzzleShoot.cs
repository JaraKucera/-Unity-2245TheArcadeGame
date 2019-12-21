using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMuzzleShoot : MonoBehaviour
{
    public void Shoot(int level)
    {
        if (level == 2 || level == 3)
        {
            GameObject bullet = (GameObject)Instantiate(Resources.Load("PlayerBullet1"));
            bullet.transform.position = new Vector3(transform.position.x, transform.position.y, 0f);

        }
        else if (level == 5 || level == 6)
        {
            GameObject bullet = (GameObject)Instantiate(Resources.Load("PlayerBullet2"));
            bullet.transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
        }
        else if (level == 8 || level == 9)
        {
            GameObject bullet = (GameObject)Instantiate(Resources.Load("PlayerBullet3"));
            bullet.transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
        }

    }
}
