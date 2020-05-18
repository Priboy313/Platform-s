using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map_control : MonoBehaviour
{
    public GameObject gate_1;
   public bool gate1 = false;

   Vector3 startPos;

    private void Start() {
        startPos = gate_1.transform.position;
    }

    private void Update() {
       
   if(gate1){
       gate_1.transform.position = new Vector3(gate_1.transform.position.x, gate_1.transform.position.y + 6, gate_1.transform.position.z);
   } else {
       gate_1.transform.position = new Vector3(startPos.x, startPos.y, startPos.z);
       }



   }
}
