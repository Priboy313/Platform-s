using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yPlatformDBLmoving : MonoBehaviour
{
    
//скорость движения платформы
public float speed;
//время задержки в верхней точке
public float freez;
//позиция, где платформа должна повернуть назад
public Transform endPoint;
public Transform stPoint;
//позиция начала движения
Vector3 startPoint;
//ссылочная переменная для компонента Rigidbody2D
Rigidbody2D rb;
//скорость платформы в текущий момент
float currentSpeed;
bool ifis = true;
public bool down;

//выполнится при запуске скрипта
void Start () {
//запомнит стартовую точку платформы
startPoint = stPoint.transform.position;
//сделать ссыдку на Rigidbody2D
rb = GetComponent <Rigidbody2D> ();

if(down){
    speed *= -1;
}

//начальное направление движения
currentSpeed = speed;


}

//выполнятся через интервалы
void Update () {
                if(!down){
                    //проверка, находится-ли платформа выше конечной точки
                    if (transform.position.y >= endPoint.position.y){
                        if(ifis) currentSpeed = 0;
                    //скорость для вектора движения вниз
                    StartCoroutine(waiter());
                        //Debug.Log("maxCurSpeed = " + currentSpeed);
                    }
                    //проверка, находится-ли платформа ниже начальной точки
                    if (transform.position.y <= startPoint.y){
                    if(!ifis) currentSpeed = 0;
                    //скорость для вектора движения вверх 
                    StartCoroutine(waiter2());
                        //Debug.Log("minCurSpeed = " + currentSpeed);
                    }
                }else {
                    //проверка, находится-ли платформа выше конечной точки
                    if (transform.position.y <= endPoint.position.y){
                        if(ifis) currentSpeed = 0;
                    //скорость для вектора движения вниз
                    StartCoroutine(waiter());
                        //Debug.Log("maxCurSpeed = " + currentSpeed);
                    }
                    //проверка, находится-ли платформа ниже начальной точки
                    if (transform.position.y >= startPoint.y){
                    if(!ifis) currentSpeed = 0;
                    //скорость для вектора движения вверх 
                    StartCoroutine(waiter2());
                        //Debug.Log("minCurSpeed = " + currentSpeed);
                    }
                }
//направить платформу по вектору движения
rb.velocity = new Vector3 (0, currentSpeed, 0);
}
IEnumerator waiter()
{
    float dspeed = -speed;

    yield return new WaitForSeconds(freez);
    ifis = false;
    currentSpeed = dspeed;
}
IEnumerator waiter2()
{
    yield return new WaitForSeconds(freez);
    ifis = true;
    currentSpeed = speed;
}
}
