using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    public GameObject shield;
    private bool isActive = false;
    private float nextTimeToShield = 0f;
    private float shieldRate = 0.5f;
    public bool ShieldActive() => isActive;
    public void Update()
    {
        if ((Input.GetKey(KeyCode.Joystick1Button4) || Input.GetKey(KeyCode.J) ) && Time.time >= nextTimeToShield){
            nextTimeToShield = Time.time + 1f / shieldRate;
            shield.SetActive(true);
            isActive = true;
            Invoke("TurnOffShield", 1f);
        }
    }
    private void TurnOffShield()
    {
        isActive = false;
        shield.SetActive(false);
    }
}
