using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonup9 : MonoBehaviour
{

    public GameObject trigger;
 
 void Start () {
         trigger.SetActive (false);
     }
 
 void OnTriggerEnter(Collider _col){
         if (_col.gameObject.CompareTag ("button9")) {
             trigger.SetActive (true);
                 }
         }

         void OnTriggerExit(Collider _col){
         if (_col.gameObject.CompareTag ("button9")) {
             trigger.SetActive (false);
         }
     }
}
