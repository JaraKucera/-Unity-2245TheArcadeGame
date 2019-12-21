using UnityEngine;

public class HUD_Score : MonoBehaviour
{
    public TMPro.TextMeshProUGUI score;
    void Update() => score.text = ("S C O R E: " + GameManager.instance.GetScore().ToString());
}
