using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStartButton : MonoBehaviour
{
    void Start() {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(() => {
            SceneManager.LoadScene("Scenes/GameScene");
        });
    }

}
