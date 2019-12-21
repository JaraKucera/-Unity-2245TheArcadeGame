using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD_Lives : MonoBehaviour
{
    public TMPro.TextMeshProUGUI lives;
    void Update() => lives.text = ("L I V E S: " + GameManager.instance.GetLives().ToString());
}
