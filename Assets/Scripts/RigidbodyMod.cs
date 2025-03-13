using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RigidbodyMod : MonoBehaviour
{
    /// <summary>
    /// � ���� ��������� ������� ������ � ���������� �� ������������ ��������
    /// </summary>
    [SerializeField] private float maxVelocity;
    /// <summary>
    /// ������ �� ������� ��
    /// </summary>
    private Rigidbody2D rb;

    /// <summary>
    /// �������� ������ �� ��
    /// </summary>
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// ���� ��������� � �������� � ����������� StopSurface, �� �� ������� ������� ������
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(rb.gravityScale == 0) return;

        if (collision.GetComponent<StopSurface>())
        {
            rb.velocity = Vector3.zero;
            rb.gravityScale = 0;
        }
    }

    /// <summary>
    /// ���� ������� �� ������� � ����������� StopSurface, ��������� ����������
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent<StopSurface>() == null) return;

        rb.gravityScale = 1;
    }

    /// <summary>
    /// ������������ ������������ �������� �������
    /// </summary>
    private void Update()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);
    }
}
