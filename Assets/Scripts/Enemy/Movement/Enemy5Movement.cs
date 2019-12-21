using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5Movement : MonoBehaviour
{
    public float speed = 30f;
    private Vector3 goalPosition;
    private int directionSwitch = 1; //1 = top left, 0 = midpoint, -1 = top right
    private int changeUnit = -1;
    private float spawnY;

    public void Start()
    {
        spawnY = GetComponent<Rigidbody>().transform.position.y;
        goalPosition = new Vector3(-10f, spawnY, 0f);

    }
    private void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, goalPosition, step);
        if (Vector3.Distance(transform.position, goalPosition) < 0.001f)
        {
            SwapDirection();
        }
    }
    //Triangle Movement without top upsideDown
    private void SwapDirection()
    {
        if (directionSwitch == 1) //at bottom left move center
        {
            goalPosition = new Vector3(0f, (spawnY + 7), 0f);
            changeUnit = 1;
            directionSwitch = 0;
        }
        else if (directionSwitch == 0 && changeUnit == 1) //at center move bottom right
        {
            goalPosition = new Vector3(10f, spawnY, 0f);
            changeUnit = 0;
        }
        else if (directionSwitch == 0 && changeUnit == 0) //at bottom right move center
        {
            goalPosition = new Vector3(0f, (spawnY + 7), 0);
            directionSwitch = 2;
        }
        else if (directionSwitch == 2)//at center move top left
        {
            goalPosition = new Vector3(-10f, spawnY, 0f);
            directionSwitch = 1;
        }
        else
        {
            Debug.LogError("SwapDirection Method in Enemy5Movement Script Error");
        }
    }
    public void SetSpeed(float speed) => this.speed = speed;
}
