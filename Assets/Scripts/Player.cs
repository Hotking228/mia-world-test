using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /// <summary>
    /// ���������� ������������, ������������ �� �� ������, ����� ��� ������� CameraMove, 
    /// ����� ���������� ����� �� � ������ ������ ������� �������
    /// </summary>
    private bool isFollow;
    public InteractibleObject currentObject;
    public bool IsFollow => isFollow;

    /// <summary>
    /// ������ �������������� �������
    /// </summary>
    void Update()
    {
        //--------------------------------------------------
        //� ������� �������� ���������� ������� �� �� �� ������ ������� ����� ����������
        // ����� ��������� ��� ��� ����������� � ������� ������, ���� ��������� ������������� �������
        //� ��� ��� � ���������� isFollow ������ �������� true, ���������� ��� ������� ������� �� �����
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
            if (hit)
            {
                InteractibleObject obj = hit.collider.GetComponent<InteractibleObject>();
                if (obj != null)
                {
                    isFollow = true;
                    currentObject = obj;
                    currentObject.StartFollow();
                }
            }
        }
        //-------------------------------------------------

        //���� ��������� �������������, ������� ������ �� ������ � ��������� ������� �������
        if (Input.GetMouseButtonUp(0))
        {
            isFollow = false;
            currentObject = null;
        }

        // ������� ������, ������ �� ������� ���������
        currentObject?.FollowMouse();
    }
}
