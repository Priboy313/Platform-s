using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionsDestroyer : MonoBehaviour {

//как долго взрыв будет в сцене
public float timeToDestroy;

//выполнится один раз при старте скрипта
void Start () {
//удалить взрыв из сцены
Destroy (gameObject, timeToDestroy);
}
}