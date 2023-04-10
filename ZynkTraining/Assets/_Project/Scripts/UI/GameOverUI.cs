using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    public static GameOverUI Instance { get; private set; }

    void Awake() {
        Instance = this;
        gameObject.SetActive(false);
    }

    public void Display() {
        gameObject.SetActive(true);
        Controller.Instance.DisplayCursor(true);
        Controller.Instance.CanPause = false;
        
    }
}
