using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    public float speed;
    bool wasCollected;
    //public Text scoreText;
    //int score;
    // Start is called before the first frame update
    void Start()
    {
        //score = 0;
        wasCollected = false;
       // scoreText = GameObject.Find("Score").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 30, 0) * speed * Time.deltaTime);
        if (wasCollected) 
        {
            transform.localScale *= 0.8f;
            Destroy(this.gameObject, 0.1f);
           // ScoreText.Text.scoreText.score += 1;
        }
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Player")) {
            wasCollected = true;
            //score += 1;
            //scoreText.text = "Score "+score;
        }
        
    }
}
