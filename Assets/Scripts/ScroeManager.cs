using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScroeManager : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI ScoreText;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        BirbScript.AddScore += UpdateScore;
        BirbScript.Dead += ResetScore;
    }

    private void UpdateScore(){
        score++;
        ScoreText.text = score.ToString();
    }
    public void ResetScore(){
        score = 0;
        ScoreText.text = score.ToString();
    }
}
