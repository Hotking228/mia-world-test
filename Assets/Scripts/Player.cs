using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /// <summary>
    /// переменна€ определ€юща€, перет€гиваем ли мы объект, нужна дл€ скрипта CameraMove, 
    /// чтобы определить можно ли в данный момент двигать камерой
    /// </summary>
    private bool isFollow;
    public InteractibleObject currentObject;
    public bool IsFollow => isFollow;

    /// <summary>
    /// логика перетаскивани€ объекта
    /// </summary>
    void Update()
    {
        //--------------------------------------------------
        //с помощью рейкаста определ€ем тыкнули ли мы на объект который можем переносить
        // далее назначаем его как переносимый в текущий момент, если выполнено вышеописанное условие
        //и как раз в переменную isFollow кладем значение true, означающее что камерой двигать не можем
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

        //если перестали перетаскивать, убираем ссылку на объект и разрешаем двигать камерой
        if (Input.GetMouseButtonUp(0))
        {
            isFollow = false;
            currentObject = null;
        }

        // двигаем объект, ссылку на который назначили
        currentObject?.FollowMouse();
    }
}
