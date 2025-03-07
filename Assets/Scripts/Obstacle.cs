using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float destroyPosY = -8f; // 파괴되는 위치

    void Update() {
        if (GameManager.Instance.GetGameOver()) {
            return;
        }
        
        transform.position += Vector3.down * GameManager.Instance.GetMoveSpeed() * Time.deltaTime;

        if (transform.position.y <= destroyPosY) {
            Destroy(gameObject);
            GameManager.Instance.AddScore();
        }
    }
}
