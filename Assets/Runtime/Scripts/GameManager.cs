using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] CanvasGroup hudUI;
    [SerializeField] TextMeshProUGUI meterTxt;
    [SerializeField] TextMeshProUGUI gearsCollectedTxt;
    [SerializeField] TextMeshProUGUI powerUpsCollectedTxt;
    [SerializeField] float scoreMultiplier;
    private float meters;
    private int gearsCoinsCount;
    private int powerUpsCount;
    public bool gameStarted = false;


    // Start is called before the first frame update
    void Start()
    {
        meterTxt.text = "" + 0;
        gearsCollectedTxt.text = "" + 0;
        powerUpsCollectedTxt.text = "" + 0;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
    }

    public void StartGame()
    {
        Debug.Log("GameStarted");
        gameStarted = true;
        hudUI.DOFade(1, 0.5f);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void UpdateScore()
    {
        meters += Time.deltaTime * scoreMultiplier;
        meterTxt.text = Mathf.Round(meters).ToString(); 
    }

    public void UpdateGears()
    {
        gearsCoinsCount++;
        gearsCollectedTxt.text = gearsCoinsCount.ToString();
    }

    public void UpdatePowerUps()
    {
        powerUpsCount++;
        powerUpsCollectedTxt.text = powerUpsCount.ToString();
    }

    public void BackToHome()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        Debug.Log("GameOver");
    }


}
