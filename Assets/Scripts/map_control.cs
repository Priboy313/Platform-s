using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map_control : MonoBehaviour
{
    public GameObject gate_1;
   public bool gate1 = false;
   public GameObject gate_2;
   public bool gate2 = false;

   Vector3 startPos;
   Vector3 startPos2;

    private void Start() {
        startPos = gate_1.transform.position;
        startPos2 = gate_2.transform.position;
    }

    private void Update() {
     //1st gate  
   if(gate1){
       gate_1.transform.position = new Vector3(gate_1.transform.position.x, gate_1.transform.position.y + 6, gate_1.transform.position.z);
   } else {
       gate_1.transform.position = new Vector3(startPos.x, startPos.y, startPos.z);
       }
     //2nd gate
    if(gate2){
       gate_2.transform.position = new Vector3(gate_2.transform.position.x, gate_2.transform.position.y + 6, gate_2.transform.position.z);
   } else {
       gate_2.transform.position = new Vector3(startPos2.x, startPos2.y, startPos2.z);
       }


   }
}
