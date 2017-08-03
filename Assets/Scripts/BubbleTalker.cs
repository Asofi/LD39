using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class BubbleTalker : MonoBehaviour {

    public Transform Bubble;
    public TMP_Text Text;
    Sequence PopOut;

    private void Awake()
    {
        Bubble.localScale = Vector3.zero;
    }

    public void Say(params string[] text)
    {
        if(PopOut != null)
            PopOut.Kill();
        PopOut = DOTween.Sequence();
        foreach (string str in text)
        {
            PopOut.AppendCallback(() => { Text.text = str; });
            PopOut.Append(Bubble.DOScale(1, 0.3f));
            PopOut.AppendInterval(1f);
            PopOut.Append(Bubble.DOScale(0, 0.3f));
        }
    }
}
