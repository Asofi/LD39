using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GUIManager : MonoBehaviour {

    public RectTransform GameOver, Win;

	// Use this for initialization
	void Start () {
        EventManager.OnGameOver += EventManager_OnGameOver;
        EventManager.OnWin += EventManager_OnWin;
	}

    private void EventManager_OnWin()
    {
        Time.timeScale = 0;
        Win.DOLocalMoveY(0, 1).SetUpdate(true).SetEase(Ease.OutBack);
    }

    private void EventManager_OnGameOver()
    {
        GameOver.DOLocalMoveY(0, 1).SetUpdate(true).SetEase(Ease.OutBack);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);       
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
}
