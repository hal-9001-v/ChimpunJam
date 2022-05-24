using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [Header("Button References")]
    [SerializeField] Button pauseButton;

    private PauseMenu _pauseMenu;
    private void Awake() {
        _pauseMenu =  FindObjectOfType<PauseMenu>();
        
        pauseButton.onClick.AddListener(() =>
        {
            PauseGame();
        });

    }

    private void PauseGame(){
        _pauseMenu.DisplayPauseMenu();
    } 
}
