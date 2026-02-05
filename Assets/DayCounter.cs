using TMPro;
using UnityEngine;

public class DayCounter : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text dayText;

    [Header("Day Settings")]
    public int startDay = 1;

    int day;

    void Awake()
    {
        day = startDay;
        UpdateUI();
    }

    // Call this when the player sleeps
    public void Sleep()
    {
        day++;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (dayText != null)
            dayText.text = $"Day {day}";
    }

    public int GetDay()
    {
        return day;
    }
}
