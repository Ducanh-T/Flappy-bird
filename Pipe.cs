using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update() // Hàm Update duoc goi dua trên FPS: 30FPS tuc la ham Update duoc goi 30 lan/s
    {
        Move();
    }

    private void Move()
    {
        transform.position += Vector3.left * speed * Time.deltaTime; //Time.deltaTime = 1/FPS
    }
}
