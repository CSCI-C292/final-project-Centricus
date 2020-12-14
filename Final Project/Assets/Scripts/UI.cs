using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{

    [SerializeField] UIManager UIManager;
    private TMPro.TextMeshProUGUI scoreText;
    private TMPro.TextMeshProUGUI HPText;

    void Start()
    {
        scoreText = transform.Find("ScoreText").GetComponent<TMPro.TextMeshProUGUI>();
        HPText = transform.Find("HPText").GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + UIManager.score;
        HPText.text = "HP: " + UIManager.currentHP + "/" + UIManager.maxHP;
    }
}
