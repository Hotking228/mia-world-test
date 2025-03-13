using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RigidbodyMod : MonoBehaviour
{
    /// <summary>
    /// в игре референсе объекты падают с ускорением до определенной скорости
    /// </summary>
    [SerializeField] private float maxVelocity;
    /// <summary>
    /// ссылка на текущий рб
    /// </summary>
    private Rigidbody2D rb;

    /// <summary>
    /// получаем ссылку на рб
    /// </summary>
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// если находимся в триггере с компонентом StopSurface, то не двигаем текущий объект
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
    /// если выходим из объекта с компонентом StopSurface, разрешаем гравитацию
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent<StopSurface>() == null) return;

        rb.gravityScale = 1;
    }

    /// <summary>
    /// ограничиваем максимальную скорость падения
    /// </summary>
    private void Update()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);
    }
}
