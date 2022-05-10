using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Saws : MonoBehaviour
{
    public float amp;
    public float speed;
    public float yStart;
    public GameObject player;
    private float dist;
    public float xPosition;
    public float zPosition;
    public float zScaleStart;
    public bool isSaw;
    private Text GameOverText;

    // Start is called before the first frame update
    void Start()
    {
        GameOverText=GameObject.Find("GameOverText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        SawMove();
        SawCollision();
    }
    // move the saw up and down
    void SawMove(){
        float yPosition = yStart+Mathf.Sin(Time.time*speed)*amp;
        float zScale = zScaleStart + Mathf.Sin(Time.time*speed)*amp;
        transform.position = new Vector3(xPosition,yPosition , zPosition);
        if(isSaw){
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, zScale );
        }
        
    }
    
    // check if the player colide the saw and di
     void SawCollision(){
            dist = Vector3.Distance(transform.position, player.transform.position);
            if(dist<80){
                player.SetActive(false);
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
