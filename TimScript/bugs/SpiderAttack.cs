using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpiderAttack : MonoBehaviour
{
    private float dist;
    public GameObject spiderFire;
    public GameObject player;
    
    private float fireRate; 
    private List<GameObject> fireClones = new List<GameObject>();
    private float nextFire; 
    // Start is called before the first frame update
    void Start()
    {
        nextFire = Time.time;
        fireRate = 2f;
    }
    // Update is called once per frame
    void Update()
    {
        Fireball(); 
    }
    // fire ball that spider throw to the player when the player gets in to his zone. The fire ball will follow the player 
    void Fireball(){
        dist = Vector3.Distance(player.transform.position, transform.position);
        if(dist <= 200){
            if(Time.time > nextFire){
               GameObject fireClone = (GameObject)Instantiate(spiderFire, transform.position, Quaternion.identity);
               fireClones.Add(fireClone);
               nextFire = Time.time + fireRate;
            }
        }
    }
     // method to extinguish the fire after the dog touch the droplet 
    public void removeFire(){
         foreach (GameObject fire in fireClones){
             Destroy(fire);
         }
         fireClones.Clear();
         
    }
}
