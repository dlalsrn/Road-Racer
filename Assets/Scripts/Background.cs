using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private float posY = 7.5f;
    private float dis = 5f; // 위에 있는 background와의 Y값 차이

    void Update()
    {
        if (GameManager.Instance.GetGameOver()) {
            return;
        }
        
        if (transform.position.y <= -posY) {
            transform.position += new Vector3(transform.position.x, dis * 3, transform.position.z);
        } 

        transform.position += Vector3.down * GameManager.Instance.GetMoveSpeed() * Time.deltaTime;
    }
}
