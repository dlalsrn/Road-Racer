using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraQuake : MonoBehaviour
{
    [SerializeField] private float quakeDuration = 0.5f; // 카메라 지진 시간
    [SerializeField] private float quakeItensity = 0.2f; // 카메라 지진강도
    private Vector3 originPos;

    void Start() {
        originPos = transform.position;
    }

    public void Crash() {
        StartCoroutine(Quake());
    }
    
    IEnumerator Quake() {
        float elapsedTime = 0f;
        while (elapsedTime < quakeDuration) {
             // 카메라 원점에서 랜덤한 위치 * 강도 만큼 카메라 위치 이동
            transform.position = originPos + (Vector3)Random.insideUnitCircle * quakeItensity;
            elapsedTime += Time.deltaTime; // 시간 측정
            yield return null;
        }
        transform.position = originPos;
    }
}
