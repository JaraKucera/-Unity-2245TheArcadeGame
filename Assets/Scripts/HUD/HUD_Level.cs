using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD_Level : MonoBehaviour
{
    public TMPro.TextMeshProUGUI level;
    void Update() => level.text = ("L E V E L: " + GameManager.instance.GetLevel().ToString());
}
