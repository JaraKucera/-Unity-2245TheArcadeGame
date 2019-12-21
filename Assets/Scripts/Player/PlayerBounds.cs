using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    private Vector2 screenBounds;
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
    }
    private void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + 1, screenBounds.x - 1);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + 2, screenBounds.y - 2);
        viewPos.z = 0;
        transform.position = viewPos;
    }
}
