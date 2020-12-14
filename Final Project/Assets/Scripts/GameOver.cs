using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] UIManager UIManager;

    private TMPro.TextMeshProUGUI endText;

    private void Start() {
        Cursor.lockState = CursorLockMode.None;

        endText = transform.Find("Text").GetComponent<TMPro.TextMeshProUGUI>();
        endText.text = "Game Over. Score: " + UIManager.score;
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
