using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationRock : MonoBehaviour
{
    public int speed;
    public GameObject Ground;
    private float dist;
    // rock rolling
    public void RockRolling(){
         dist = Vector3.Distance(transform.position, Ground.transform.position);
         if(dist>=500){
             transform.Rotate(speed * Time.deltaTime, 0.0f, 0.0f);  
         }
    }
}
