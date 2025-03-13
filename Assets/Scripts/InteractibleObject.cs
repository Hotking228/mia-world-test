using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleObject : MonoBehaviour
{
    /// <summary>
    /// ������ �� ������ �������� ��� ����� Order in Layer ��� ������� � ���� - ���������
    /// </summary>
    [SerializeField] private SpriteRenderer sr;
    /// <summary>
    /// ������������� ��������, ������� �� ���������� ����� �������������
    /// </summary>
    [SerializeField] private int dragOrderInLayer;
    /// <summary>
    /// �������� ���������
    /// </summary>
    [SerializeField] private int defaultOrderInLayer;

    /// <summary>
    /// ��������� ��� ��������� ��������� �������� order in layer
    /// </summary>
    private void Start()
    {
        sr.sortingOrder = defaultOrderInLayer;
    }

    /// <summary>
    /// ���������� � ������� Player, �� ����� ������ ��������������, ����� ����������� ������ �� �������� ����
    /// </summary>
    public void StartFollow()
    {
        sr.sortingOrder = dragOrderInLayer;
    }

    /// <summary>
    /// ����� ���������� ������� �� �����, ���������� ����� ScreenToWorldPoint, ����� ��������� ���������� �� �������� � �������
    /// ����� ���� �� ������������, ����� 2 ���� �� ��������, �� ���� ����������������, ������� �� ������ �� ������������������
    /// </summary>
    public void FollowMouse()
    {
        transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, transform.position.z);
    }
}
