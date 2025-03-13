using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleObject : MonoBehaviour
{
    /// <summary>
    /// Ссылка на спрайт рендерер для смены Order in Layer как сделано в игре - референсе
    /// </summary>
    [SerializeField] private SpriteRenderer sr;
    /// <summary>
    /// соответсвенно значение, которое мы используем когда перетаскиваем
    /// </summary>
    [SerializeField] private int dragOrderInLayer;
    /// <summary>
    /// значение дефолтное
    /// </summary>
    [SerializeField] private int defaultOrderInLayer;

    /// <summary>
    /// назначаем для рендерера дефолтное значение order in layer
    /// </summary>
    private void Start()
    {
        sr.sortingOrder = defaultOrderInLayer;
    }

    /// <summary>
    /// вызывается в скрипте Player, во время начала перетаскивания, чтобы передвинуть спрайт на передний план
    /// </summary>
    public void StartFollow()
    {
        sr.sortingOrder = dragOrderInLayer;
    }

    /// <summary>
    /// метод следования объекта за мышью, используем метод ScreenToWorldPoint, чтобы перевести координаты из экранных в мировые
    /// лучше было бы закэшировать, чтобы 2 раза не вызывать, но игра нетребовательная, поэтому не влияет на производительность
    /// </summary>
    public void FollowMouse()
    {
        transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, transform.position.z);
    }
}
