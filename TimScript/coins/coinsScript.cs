using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinsScript : MonoBehaviour
{
    // need to import unityengine UI 
    private Text coinText;
    private GameObject coin;
    // count score
    private int scoreCount =0;
    // Start is called before the first frame update
    void Start()
    {
        coin = GameObject.FindWithTag("coin");
        coinText=GameObject.Find("coinText").GetComponent<Text>();
    }
    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "coin"){
                 Destroy(collision.gameObject);
                // add the update score and show to UI
                scoreCount++;
                coinText.text="x"+scoreCount;
        }
    }
}
