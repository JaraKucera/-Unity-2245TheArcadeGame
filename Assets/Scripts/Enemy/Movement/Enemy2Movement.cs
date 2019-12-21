using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Movement : MonoBehaviour
{
    //Movement2 Script 0----------0     Point to point
    private Vector3 goalPosition;
    public float speed = 15f;
    private void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, goalPosition, step);
        if (Vector3.Distance(transform.position, goalPosition) < 0.001f)
        {
            SwapDirection();
        }
    }
    private void SwapDirection()
    {
        goalPosition.x *= -1f;
        goalPosition.y *= -1f;
    }
    public void Start() => goalPosition = new Vector3(Random.Range(-12f, 12f), Random.Range(-6f, 8f), 0f);
    public void SetSpeed(float speed) => this.speed = speed;
}
