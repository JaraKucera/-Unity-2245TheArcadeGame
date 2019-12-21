using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontMuzzleShoot : MonoBehaviour
{
    public void Shoot(int level)
    {
        if (level == 1 || level == 3)
        {
            GameObject bullet = (GameObject)Instantiate(Resources.Load("PlayerBullet1"));
            bullet.transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
        }
        else if (level == 4 || level == 6)
        {
            GameObject bullet = (GameObject)Instantiate(Resources.Load("PlayerBullet2"));
            bullet.transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
        }
        else if (level == 7 || level == 9)
        {
            GameObject bullet = (GameObject)Instantiate(Resources.Load("PlayerBullet3"));
            bullet.transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
        }

    }
}
