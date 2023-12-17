using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{

    
    [SerializeField]
private TMP_Text _scoreText;

private int _score;

private int _maxScore;

public void SetMaxScore(int value)
{
    _maxScore = value;
    UpdateUI(); // Memastikan pembaruan UI terjadi setiap kali nilai maksimum skor diubah
}

 

public void AddScore(int value)

{

_score += value;

UpdateUI();

}
public void UpdateUI()

{

_scoreText.text = "Score: " + _score + " / " + 77;

}
    // Start is called before the first frame update
    void Start()
    {
        _score = 0;

_maxScore = 0;

UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
