using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineContr : MonoBehaviour
{
//ссылочная переменная для аниматора
Animator anim;
//ссылочная переменная для rigidbody2D
Rigidbody2D rb;
//ссылочная переменная
TrampolineContr tp;
PlayerMove pm;

public static bool isCollis = false;

    void Start () {
        //делаем ссылку на Animator
        anim = GetComponent <Animator> ();
        //делаем ссылку на Rigidbody2D
        rb = GetComponent <Rigidbody2D> ();
        tp = GetComponent <TrampolineContr> ();
        pm = GetComponent <PlayerMove> ();
    }

    void Update(){

        if(isCollis){
            anim.SetBool("playerCollision", true);
            }

    }

    void OnTriggerEnter2D (Collider2D other){
        if (other.tag == "Player"){
            anim.SetBool("playerCollision", true);
        }
    }

    public void AnimStop(){
        anim.SetBool("playerCollision", false);
    }

}
