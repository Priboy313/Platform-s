using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampContrl : MonoBehaviour
{
    //ссылочная переменная для аниматора
Animator anim;
//ссылочная переменная для rigidbody2D
Rigidbody2D rb;
//ссылочная переменная
PlayerMove pm;

public GameObject Player; 

public static bool isCollis = false;
public bool ifis = true;
public float bust;

    void Start () {
        //делаем ссылку на Animator
        anim = GetComponent <Animator> ();
        pm = GameObject.Find("GG").GetComponent<PlayerMove>();
    }

    void Update(){

        if(isCollis){
            anim.SetBool("playerCollision", true);
            }

    }

    void OnTriggerEnter2D (Collider2D other){
        if (other.tag == "Player" && ifis){
            Player.GetComponent<PlayerMove>().trampForce = bust;
            anim.SetBool("playerCollision", true);
            ifis = false;
        }
    }

    public void AnimStop(){
        ifis = true;
        anim.SetBool("playerCollision", false);
    }
}
