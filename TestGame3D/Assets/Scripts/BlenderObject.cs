using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class BlenderObject : MonoBehaviour
{
    //[SerializeField] Collider m_collider;
    [SerializeField] float m_distanceCheck = 0.5f;
    [SerializeField] Transform m_targetPos;
    Vector3 m_mousePosition;

    private Vector3 m_posStart;
    private bool m_isDrag = true;
    private bool m_isMoveTarget = true;
    private void Start()
    {
        m_posStart = transform.position;
    }
    private Vector3 GetMouserPos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }
    private void OnMouseDown()
    {
        m_mousePosition = Input.mousePosition - GetMouserPos();
    }
    private void OnMouseDrag()
    {
        float x = Vector3.Distance(transform.position, m_posStart);
        if (x > 0.01f)
        {
            MoveTarget();
            return;
        }
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - m_mousePosition);

    }
    private void MoveTarget()
    {
        if (!m_isMoveTarget)
            return;
        m_isMoveTarget = false;
        GameController.StopHandMove();
        //Vector3 pos = new Vector3(m_targetPos.position.x, m_targetPos.position.y + 0.04f, m_targetPos.position.z);
        transform.DOMove(m_targetPos.position, 1f).SetEase(Ease.Linear);
    }
}
