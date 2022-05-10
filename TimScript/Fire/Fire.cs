using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fire : MonoBehaviour

{

    public float moveSpeed = 1f;
    public GameObject Player;
    public GameObject cubes;
    public Text GameOverText;
  
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        GameOverText=GameObject.Find("GameOverText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
            transform.position =  Vector3.MoveTowards(transform.position, cubes.transform.position, 2f);
    }
    // detect the collison between the player and fire
    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag=="Player"){
            print("hello");
            Player.SetActive(false);
            GameOverText.enabled=true; 
            StartCoroutine(RestartGame());
        }
    }
     // restart the game
     IEnumerator RestartGame(){
        yield return new WaitForSeconds(2f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("TimLevel");
    }
}
