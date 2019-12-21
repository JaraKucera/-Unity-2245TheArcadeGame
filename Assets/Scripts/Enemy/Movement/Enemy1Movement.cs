using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Movement : MonoBehaviour
{
    //Movement1 Script <---------->
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
    private void SwapDirection() => goalPosition.x *= -1f;
    public void Start() => goalPosition = new Vector3(13f, GetComponent<Rigidbody>().transform.position.y, 0f);
    public void SetSpeed(float speed) => this.speed = speed;
}
