using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField] CanvasGroup hudUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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


}
