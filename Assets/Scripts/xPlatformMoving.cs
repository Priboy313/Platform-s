using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xPlatformMoving : MonoBehaviour {

//скорость движения платформы
public float speed;
//время задержки в верхней точке
public float freez;
//позиция, где платформа должна повернуть назад
public Transform endPoint;
//позиция начала движения
Vector3 startPoint;
//ссылочная переменная для компонента Rigidbody2D
Rigidbody2D rb;
//скорость платформы в текущий момент
float currentSpeed;
bool ifis = true;
public bool left;

//выполнится при запуске скрипта
void Start () {
//запомнит стартовую точку платформы
startPoint = transform.position;
//сделать ссыдку на Rigidbody2D
rb = GetComponent <Rigidbody2D> ();

if(left){
    speed*=-1;
}
//начальное направление движения
currentSpeed = speed;


}

//выполнятся через интервалы
void Update () {
            if(!left){
                //проверка, находится-ли платформа выше конечной точки
                if (transform.position.x >= endPoint.position.x){
                    if(ifis) currentSpeed = 0;
                //скорость для вектора движения вниз
                StartCoroutine(waiter());
                    //Debug.Log("maxCurSpeed = " + currentSpeed);
                }
                //проверка, находится-ли платформа ниже начальной точки
                if (transform.position.x <= startPoint.x){
                if(!ifis) currentSpeed = 0;
                //скорость для вектора движения вверх 
                StartCoroutine(waiter2());
                    //Debug.Log("minCurSpeed = " + currentSpeed);
                }
            } else{
                //проверка, находится-ли платформа выше конечной точки
                if (transform.position.x <= endPoint.position.x){
                    if(ifis) currentSpeed = 0;
                //скорость для вектора движения вниз
                StartCoroutine(waiter());
                    //Debug.Log("maxCurSpeed = " + currentSpeed);
                }
                //проверка, находится-ли платформа ниже начальной точки
                if (transform.position.x >= startPoint.x){
                if(!ifis) currentSpeed = 0;
                //скорость для вектора движения вверх 
                StartCoroutine(waiter2());
                    //Debug.Log("minCurSpeed = " + currentSpeed);
                }

            }

//направить платформу по вектору движения
rb.velocity = new Vector3 (currentSpeed, 0, 0);
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