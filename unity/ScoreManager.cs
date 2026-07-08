using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private float score = 0;

    void Update()
    {
        score += Time.deltaTime;

        scoreText.text =
            "SCORE: " +
            Mathf.FloorToInt(score);
    }
}