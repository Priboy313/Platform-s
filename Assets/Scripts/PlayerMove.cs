using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

//в инспекторе мы можем выбрать, какие слои будут землёй
public LayerMask whatIsGround;
//какие слои являются трамплинами
public LayerMask whatIsTrampoline;
//позиция для проверки касания земли
public Transform groundCheck;
public Transform trampolineCheck;
//переменная, которая будет true, если крыса находится на земле
public bool isGrounded;
//если true, то гг на трамплине и должен лететь вверх
public bool isTramplined;
//значение величины силы
public float jumpForce;
public float trampForce = 0;
//переменная для скорости движения
public float speed;
//ссылочная переменная для компонента Rigidbody2D
Rigidbody2D rb;

//переменная контроля направления крысы
public bool isLookingLeft;
//public object rb;

void Start () {
    rb = GetComponent <Rigidbody2D> ();
}

void Update () {
    //проверка, нажат-ли прыжок и находится-ли крыса на земле
    if (Input.GetKeyDown (KeyCode.W) && isGrounded) {
        //применяем силу на Rigidbody2D вдоль оси Y для прыжка
        rb.AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse);
        //sпереключаем переменную, чтобы предотвратить следующий прыжок, или мы могли бы снова прыгнуть (до того, как isGrounded будет переключена в FixedUpdate ())
        isGrounded = false;
    }
    if(isTramplined && trampForce != 0){
        rb.AddForce (Vector2.up * 0, ForceMode2D.Impulse);
        rb.AddForce (Vector2.up * trampForce, ForceMode2D.Impulse);
        trampForce = 0;
        isTramplined= false;
    }
}

void FixedUpdate () {
//изменяем переменную, зависит от результата Physics2D.OverlapPoint
isGrounded = Physics2D.OverlapPoint (groundCheck.position, whatIsGround);
isTramplined = Physics2D.OverlapPoint (groundCheck.position, whatIsTrampoline);

//декларация переменной с её инициализацией значением полученным с горизонтальной оси (значение лежит в области между -1 и 1)
float x = Input.GetAxis ("Horizontal");
//декларация локального вектора и инициализация посчитанным значением
//x: значение от InputManager * speed
//: принять текущее значение, мы не будем его менять, из-за использования силы тяжести
//z: должно быть равно нулю, нам не нужно движение по оси Z
Vector3 move = new Vector3 (x * speed, rb.velocity.y, 0f);
//изменить скорость игрока на вычисленный вектор
rb.velocity = move;
//проверка, совпадает ли направление взгляда с направлением движения
if (x < 0 && !isLookingLeft)
//вызов функции поворота крысы, если проверка совпала
TurnTheRat ();
//проверка, совпадает ли направление взгляда с направлением движения
if (x > 0 && isLookingLeft)
//вызов функции поворота крысы, если проверка совпала
TurnTheRat ();
}

//функция поворота крысы
void TurnTheRat ()
{
//смена переменной показывающей направление взгляда на обратное значение
isLookingLeft = !isLookingLeft;
//поворот крысы через инвертацию размера по оси х
transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
}

}