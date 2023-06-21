using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    public GameObject StartPanel;
    public GameObject GameOverPanel;
    public GameObject tapText;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI HighScoreText1;
    public TextMeshProUGUI HighScoreText2;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        tapText.SetActive(false);
        StartPanel.GetComponent<Animator>().Play("PanelUp");
    }

    public void GameOver()
    {
        GameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

}
