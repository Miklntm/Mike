using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ontrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider col) { 
         if (col.name == "Joueur")
         {

            Debug.Log("ntm");

        }
    
    }    
    

}
