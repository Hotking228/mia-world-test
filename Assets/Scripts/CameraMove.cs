using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    /// <summary>
    /// ссылка на Player для определения, можно ли двигать камеру
    /// </summary>
    [SerializeField] private Player player;
    //-------------------------
    //левая и правая границы возможного положения камеры
    [SerializeField] private float leftBorder;
    [SerializeField] private float rightBorder;
    //-------------------------
    /// <summary>
    /// скорость перемещения камеры
    /// </summary>
    [SerializeField] private float cameraSpeed;
    /// <summary>
    /// старое положение мыши
    /// </summary>
    private float startMouseX = 0;
    /// <summary>
    /// положение камеры в момент начала её перемещения
    /// </summary>
    private float startCamX;

    private void Update()
    {
        //запоминаем старое положение камеры и мыши по оХ
        if (Input.GetMouseButtonDown(0))
        {
            startMouseX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            startCamX = transform.position.x;
        }

        //передвигаем камеру, если не перетаскиваем объект
        if (Input.GetMouseButton(0))
        {
            if (player.IsFollow) return;

            float mouseX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;//получаем положение мыши в мировых координатах
            float cameraXPos = Mathf.Clamp(startCamX + startMouseX - mouseX, leftBorder, rightBorder);//получаем новое положение камеры по оХ, в зависимости от нового положения мыши и ограничиваем крайними возможными положениями
            transform.position = Vector3.Lerp(transform.position,new Vector3(cameraXPos, transform.position.y, transform.position.z), cameraSpeed * Time.deltaTime);//для мягкости перемещения используем линейную интерполяцию
        }
    }
}
