using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//библиотека для управления сценами
using UnityEngine.SceneManagement;

public class MushroomController : MonoBehaviour {

//префаб взрыва
public GameObject Explosion;
//звук взрыва
public AudioClip Boom;
//как далеко гриб может отойти от начальной точки
public float distanceToRun;
//скорость движения гриба
public float speed;
//направление взгляда гриба
public bool isLookingLeft = true;
//стартовая позиция гриба
Vector3 startPos;
//линк на компонент Rigidbody2D
Rigidbody2D rb;

//выполнится один раз при старте гриба
void Start () {
//делаем линк на компонент Rigidbody2D
rb = GetComponent <Rigidbody2D> ();
//запоминаем стартовую позицию гриба
startPos = transform.position;
//будем сравнивать квадрат вектора расстояния с квадратом расстояния
//так как извлечение корня медленный процесс
distanceToRun = distanceToRun * distanceToRun;
}

//выполняется на каждом фиксированном интервале
void FixedUpdate () {
//проверить, что гриб смотрит налево
if (isLookingLeft) {
//посчитать вектор направления от стартовой точки к грибу
Vector2 dist = transform.position - startPos;
//проверить, что гриб слева от стартовой точки
//и расстояние между грибом и стартовой точкой больше разрешенного удаления
if (transform.position.x < startPos.x && dist.sqrMagnitude > distanceToRun) {
//вызвать функцию поворота
TurnTheMushroom ();
//начать движение направо
rb.velocity = new Vector2 (speed, rb.velocity.y);
//если проверка была отрицательной
} else {
//продолжить движение налево
rb.velocity = new Vector2 (-speed, rb.velocity.y);
}
}
//проверить, что гриб смотрит направо
if (!isLookingLeft) {
//посчитать вектор направления от стартовой точки к грибу
Vector2 dist = transform.position - startPos;
//проверить, что гриб справа от стартовой точки
//и расстояние между грибом и стартовой точкой больше разрешенного удаления
if (transform.position.x > startPos.x && dist.sqrMagnitude > distanceToRun) {
//вызвать функцию поворота
TurnTheMushroom ();
//начать движение налево
rb.velocity = new Vector2 (-speed, rb.velocity.y);
//если проверка была отрицательной
} else {
//продолжить движение направо
rb.velocity = new Vector2 (speed, rb.velocity.y);
}
}
}
//функция поворота гриба
void TurnTheMushroom ()
{
//изменить указатель направления взгляда на противоположный
isLookingLeft = !isLookingLeft;
//повернуть гриб
transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
}

///запустится, если коллайдер коснулся другого коллайдера
void OnCollisionEnter2D (Collision2D other) {
//проверить, что у коллайдера тэг Player
if (other.collider.gameObject.tag == "Player") {
//посмотреть имя загруженной сцены и загрузить такую сцену (reload)
SceneManager.LoadScene (SceneManager.GetActiveScene().name);
}
}

//запустится, если другой коллайдер попал в триггер
void OnTriggerEnter2D (Collider2D other) {
//проверить, что у коллайдера тэг Player
if (other.tag == "Player") {
//спавн взрыва
Instantiate (Explosion, transform.position, Quaternion.identity);
//проиграть звук взрыва
AudioSource.PlayClipAtPoint (Boom, transform.position);
//удалить гриб
Destroy (gameObject);

}
}
}