using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    void Start()
    {
        Rigidbody rigidbody = this.GetComponent<Rigidbody>();
        rigidbody.AddForce(Vector3.up * 1000);
    }
    //Destroys object once any camera can't see it
    private void OnBecameInvisible() => Destroy(gameObject);
}
