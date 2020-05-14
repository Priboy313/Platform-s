using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDestroy : MonoBehaviour
{


    //префаб взрыва
public GameObject Explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }


        //запустится, если другой коллайдер попал в триггер
        void OnTriggerEnter2D (Collider2D other) {
        //проверить, что у коллайдера тэг Player
        if (other.tag == "Trap") {
        //спавн взрыва
        Instantiate (Explosion, transform.position, Quaternion.identity);

        //удалить гриб
        Destroy (gameObject);
            }
        }
}
