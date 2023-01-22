using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

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
        gearsCollectedTxt.text = meters.ToString();
    }

    public void UpdatePowerUps()
    {
        powerUpsCount++;
        powerUpsCollectedTxt.text = meters.ToString();
    }

    public void GameOver()
    {
        Debug.Log("GameOver");
    }


}
