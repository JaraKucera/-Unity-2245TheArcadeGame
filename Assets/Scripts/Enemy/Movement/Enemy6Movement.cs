using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy6Movement : MonoBehaviour
{
    //Random Movement
    private Vector3 goalPosition;
    public float speed = 15f;
    private void Start() => randomPositionGen();
    private void randomPositionGen() => goalPosition = new Vector3(Random.Range(-12f, 12f), Random.Range(-11f, 11f), 0f);
    private void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, goalPosition, step);
        if (Vector3.Distance(transform.position, goalPosition) < 0.001f)
        {
            randomPositionGen();
        }
    }
    public void SetSpeed(float speed) => this.speed = speed;
}
