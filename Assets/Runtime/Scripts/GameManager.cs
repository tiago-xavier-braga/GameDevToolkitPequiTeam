using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;
using InfinityRun.UI;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] OpenDoors openDoor;
    public CanvasGroup hudUI;
    [SerializeField] TextMeshProUGUI meterTxt;
    [SerializeField] TextMeshProUGUI gearsCollectedTxt;
    [SerializeField] TextMeshProUGUI powerUpsCollectedTxt;
    [SerializeField] float scoreMultiplier;
    [SerializeField] Vector3 gameOverPaneltarget;
    [SerializeField] TextMeshProUGUI finalScoreTxt;
    [SerializeField] Animator playerAnimator;
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
        if (!gameStarted)
        {
            UpdateScore();
        }

    }

    public void StartGame()
    {
        Debug.Log("GameStarted");
        gameStarted = true;
        hudUI.DOFade(1, 0.5f);
        playerAnimator.SetBool("Run", true);
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
        finalScoreTxt.text = Mathf.Round(meters) + "m";
        gameOverPanel.SetActive(true);
        gameOverPanel.GetComponent<Image>().DOFade(1, 1f);
        Debug.Log("GameOver");
    }


}