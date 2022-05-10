using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Water : MonoBehaviour
{
    SpiderAttack spider;
    public GameObject fireBall;
    public GameObject player;
    private float dist;
    private float distLimit; 
    // Start is called before the first frame update
    void Start()
    {
        distLimit = 100f;
        spider = GameObject.FindGameObjectWithTag("Enemy").GetComponent<SpiderAttack>();
    }
    // Update is called once per frame
    void Update()
    {
        WaterSaver();
    }
    void WaterSaver(){
        dist = Vector3.Distance(player.transform.position, transform.position);
        if(dist<=distLimit){
            this.GetComponent<Renderer>().enabled = false;
            spider.removeFire();
        }
    }
}
