using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GUIManager : MonoBehaviour {

    public RectTransform GameOver;

	// Use this for initialization
	void Start () {
        EventManager.OnGameOver += EventManager_OnGameOver;
	}

    private void EventManager_OnGameOver()
    {
        GameOver.DOLocalMoveY(0, 1).SetUpdate(true).SetEase(Ease.OutBack);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);       
    }

    // Update is called once per frame
    void Update () {
		
	}
}
