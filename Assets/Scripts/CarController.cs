using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private CameraQuake cameraQuake;
    private float[] PosX = {-2.12f, -0.75f, 0.75f, 2.12f}; // 각 차선의 X 좌표
    private int index = 1; // 플레이어의 초기 위치

    void Start() {
        cameraQuake = Camera.main.GetComponent<CameraQuake>();
    }

    void Update() {
        if (GameManager.Instance.GetGameOver()) {
            return;
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
            index = Math.Max(0, index - 1);
        } else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
            index = Math.Min(PosX.Length - 1, index + 1);
        }

        transform.position = new Vector3(PosX[index], transform.position.y, transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if  (collider.CompareTag("Obstacle")) {
            if (cameraQuake != null) {
                cameraQuake.Crash();
                GameManager.Instance.GameOver();
            }
        }
    }
}
