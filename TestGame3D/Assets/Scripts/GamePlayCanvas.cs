using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class GamePlayCanvas : MonoBehaviour
{
    [SerializeField] GameObject m_objProcess;
    [SerializeField] Image m_imgProcess;
    //
    [SerializeField] Image m_handImage;
    [SerializeField] GameObject m_btnRotate;
    [SerializeField] Image m_imgRotate;
    //
    Tween m_tween;
    private void Awake()
    {
        GameController.stopHandMoveEvent += OnStopMoveHand;
    }
    // Start is called before the first frame update
    void Start()
    {
        OnMoveHand();
        //OnRotate();
    }

    private void OnMoveHand()
    {
        RectTransform rect = m_handImage.GetComponent<RectTransform>();

        m_tween = rect.DOAnchorPos3DX(300, 1f).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
    }
    private void OnStopMoveHand()
    {
        m_tween.Kill();
        m_handImage.gameObject.SetActive(false);
        //
        OnRotate();
    }
    
    private void OnRotate()
    {
        //
        m_btnRotate.gameObject.SetActive(true);
        m_tween = m_btnRotate.transform.DOScale(Vector3.one * 1.3f, 1f).SetEase(Ease.Linear).OnComplete(()=> {
            m_btnRotate.transform.DOScale(Vector3.one * .3f, 1f);
        }).SetLoops(-1, LoopType.Yoyo); ;//m_imgRotate.transform.DORotate(new Vector3(0, 0, 350), 3f).SetLoops(-1,LoopType.Restart);
    }
    public void OnRotateOnClick()
    {
        m_btnRotate.gameObject.SetActive(false);
        m_tween.Kill();
        //
        OnMoveProcess();
    }

    private void OnMoveProcess()
    {
        m_objProcess.SetActive(true);
        float value = 0;
        m_tween = DOTween.To(() => value, x => value = x, 1f, 5f).OnUpdate(() => {
            m_imgProcess.fillAmount = value;
        }).OnComplete(() => {
            m_objProcess.SetActive(false);
        });
    }
}
