using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//эта библиотека нужна для работы с интерфейсом
using UnityEngine.UI;

public class CoinController : MonoBehaviour {

//ссылка на объект с текстом
public GameObject TextObject;
//ссылка на текстовый компонент
Text textComponent;
//звук поднятия монеты
public AudioClip CoinSound;
//переменная подсчета монет
public int coin;

//запустится один раз при запуске скрипта
void Start () {
    //делаем линк на текстовый компонент, который находится на текстовом объекте
    textComponent = TextObject.GetComponent <Text> ();
}
public GameObject MapController;
public GameObject FirstOpen;

    public void OnCollisionEnter2D(Collision2D other) {
        //проверка, имеет-ли объект тэг Coin
        if (other.gameObject.tag == "Coin") {
        //увеличить переменную подсчета монет
        coin = coin + 1;
        //записать в текст результат счета монет, преобразованный в текстовую переменную
        textComponent.text = coin.ToString();
        //проиграть звук поднятия монеты на позиции крысы
        AudioSource.PlayClipAtPoint (CoinSound, transform.position);

            if(other.gameObject.name == "Coin_1gt"){
            MapController.GetComponent<map_control>().gate1 = true;
            }
        //удалить монету из сцены
        Destroy (other.gameObject);
        }
    }
}