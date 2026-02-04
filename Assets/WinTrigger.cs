using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    bool won;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        won = true;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void OnGUI()
    {
        if (!won) return;

        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.fontSize = 60;
        style.alignment = TextAnchor.MiddleCenter;

        GUI.Label(
            new Rect(0, 0, Screen.width, Screen.height),
            "YOU WIN",
            style
        );
    }
}
