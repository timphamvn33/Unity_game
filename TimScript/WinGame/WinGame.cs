using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WinGame : MonoBehaviour
{
    private Text WinGameText;
    // Start is called before the first frame update
    void Start()
    {
        WinGameText=GameObject.Find("WinGameText").GetComponent<Text>();
        WinGameText.enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision col){
        if (col.gameObject.tag == "Player")
         {
            WinGameText.enabled=true;
            StartCoroutine(RestartGame());
         }
    }
      IEnumerator RestartGame(){
        yield return new WaitForSeconds(2f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("TimLevel");
    }
}
