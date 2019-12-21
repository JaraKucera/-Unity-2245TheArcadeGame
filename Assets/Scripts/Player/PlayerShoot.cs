using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float fireRate = 5f;
    private float nextTimeToFire = 0f;
    private int level = 0;

    public int GetLevel() => level;
    public bool ReduceLevel()
    {
        level--;
        if (level <= 0)
        {
            level = 1;
            return false;
        }
        return true;
    }
    void Update()
    {
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Joystick1Button1)) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;

            if (level == 1 || level == 3 || level == 4 || level == 6 || level == 7 || level == 9)
            {
                this.gameObject.GetComponentInChildren<FrontMuzzleShoot>().Shoot(level);
            }

            if (level != 1 || level != 4 || level != 7)
            {
                gameObject.GetComponentInChildren<RightMuzzleShoot>().Shoot(level);
                gameObject.GetComponentInChildren<LeftMuzzleShoot>().Shoot(level);
            }
        }
    }
    public void levelUp()
    {
        if (level != 9) //Level Cap to 9
        {
            level++;
        }
    }
}
