using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreboardManager : MonoBehaviour
{
    public List<TextMeshPro> scoreTexts3D;
    public List<TextMeshProUGUI> scoreTexts2D;

    public string scoreText = "Coins Collected: ";

    private int score = 0;

    public void UpdateScore(int input)
    {
        score += input;

        string newText = scoreText + score.ToString();

        foreach (TextMeshPro text in scoreTexts3D)
        {
            text.SetText(newText);
        }
        foreach (TextMeshProUGUI text in scoreTexts2D)
        {
            text.SetText(newText);
        }
    }
}
