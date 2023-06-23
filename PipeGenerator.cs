using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : MonoBehaviour
{
    public GameObject pipePrefab;

    private float countDown;
    public float timeDuration;
    public bool enableGeneratePipe; // cho phep sinh ra ong

    private void Awake()
    {
        countDown = 1f; // 1s sau khi duoc cho phep se sinh ra ong
        enableGeneratePipe = false;
    }

    void Update()
    {
        if (enableGeneratePipe == true)
        {
            countDown -= Time.deltaTime;
            // dong code nay dung de tao ra 1 dong ho dem nguoc, de dem nguoc thoi gian tao ra ong
            // ham Update duoc goi them FPS (tuc la 30FPS thi se duoc goi 30 lan 1 giay) 
            // Time.deltaTime = 1/FPS, moi frame countDown se bi tru di 1/30(s) => Sau 1s countDown se bi tru di dung 1s

            if(countDown <= 0)
            {
                Instantiate(pipePrefab, new Vector3(10, Random.Range(-1.2f, 2.1f), 0), Quaternion.identity);
                // dong code nay co chuc nang tao ra ong sau countDown <= 0
                // Instantiate la ham giup chung ta nhan ban doi tuong ban dau va tra ban sao ra

                countDown = timeDuration;
                // gan lai countDown = timeDuration de tiep tuc tao ra ong khi countDown <= 0
            }
        }
    }
}
