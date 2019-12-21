using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    void Start()
    {
        Rigidbody rigidbody = this.GetComponent<Rigidbody>();
        Vector3 dir = GameManager.instance.GetShipPosition() - this.transform.position;
        dir = dir.normalized;
        rigidbody.AddForce(dir * 500);
    }
    private void OnBecameInvisible() => Destroy(gameObject);
}
