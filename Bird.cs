using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bird : MonoBehaviour

{
    private Rigidbody2D rigibody;
    public float jumpForce;
    private bool levelStart;
    public GameObject gameController;
    public GameObject message;
    private int score;
    public Text scoreText;

    // Start is called before the first frame update
    private void Awake()
    {
        rigibody = this.gameObject.GetComponent<Rigidbody2D>();
        levelStart = false;
        rigibody.gravityScale = 0;
        score = 0;
        message.GetComponent<SpriteRenderer>().enabled = true; // Component SpriteRenderer dong vai tro luu tru hinh anh cua gameObject
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SoundController.instance.PlayThisSound("wing", 0.5f);
            if(levelStart == false)
            {
                levelStart = true;
                rigibody.gravityScale = 6;

                gameController.GetComponent<PipeGenerator>().enableGeneratePipe = true;
                // truy cap vao bien enableGeneratePipe cua script PipeGenerator, gan lai no bang true de cho phep tao ra ong sau khi an phim space
                // Khi chung ta muon lay script tu 1 gameObject, ta phai dung ham getComponent

                message.GetComponent<SpriteRenderer>().enabled = false;
            }
            BirdMoveUp();
        }
    }

    private void BirdMoveUp()
    {
        rigibody.velocity = Vector2.up * jumpForce;
    }

    //Khi 2 Collider va cham vao nhau, ham OnCollisionEnter se duoc goi => dung de reload lai game khi con chim va cham vao ong 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SoundController.instance.PlayThisSound("hit", 0.5f);
        ReloadScene();
        score = 0;
    }

    //Khi 1 Collider va cham voi 1 Trigger(Collider vo hinh de tinh diem khi chim bay qua ong), ham OnTriggerEnter se duoc goi
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SoundController.instance.PlayThisSound("point", 0.5f);
        score += 1;
        scoreText.text = score.ToString();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("gameplay");
    }
}
