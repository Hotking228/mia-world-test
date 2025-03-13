using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    /// <summary>
    /// ������ �� Player ��� �����������, ����� �� ������� ������
    /// </summary>
    [SerializeField] private Player player;
    //-------------------------
    //����� � ������ ������� ���������� ��������� ������
    [SerializeField] private float leftBorder;
    [SerializeField] private float rightBorder;
    //-------------------------
    /// <summary>
    /// �������� ����������� ������
    /// </summary>
    [SerializeField] private float cameraSpeed;
    /// <summary>
    /// ������ ��������� ����
    /// </summary>
    private float startMouseX = 0;
    /// <summary>
    /// ��������� ������ � ������ ������ � �����������
    /// </summary>
    private float startCamX;

    private void Update()
    {
        //���������� ������ ��������� ������ � ���� �� ��
        if (Input.GetMouseButtonDown(0))
        {
            startMouseX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            startCamX = transform.position.x;
        }

        //����������� ������, ���� �� ������������� ������
        if (Input.GetMouseButton(0))
        {
            if (player.IsFollow) return;

            float mouseX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;//�������� ��������� ���� � ������� �����������
            float cameraXPos = Mathf.Clamp(startCamX + startMouseX - mouseX, leftBorder, rightBorder);//�������� ����� ��������� ������ �� ��, � ����������� �� ������ ��������� ���� � ������������ �������� ���������� �����������
            transform.position = Vector3.Lerp(transform.position,new Vector3(cameraXPos, transform.position.y, transform.position.z), cameraSpeed * Time.deltaTime);//��� �������� ����������� ���������� �������� ������������
        }
    }
}
