using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 15f;
    public static Vector3 playerPosition;
    void Start() => playerPosition = transform.position;
    void Update() => transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * speed, Input.GetAxis("Vertical") * Time.deltaTime * speed, 0f);

    public Vector3 GetPlayerPosition()
    {
        playerPosition = transform.position;
        return playerPosition;
    }
}
