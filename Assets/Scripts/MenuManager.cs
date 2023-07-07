using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject startMenu;
    public void StartGame() {

        startMenu.SetActive(false);
    }
    public void Quitgame() {
        Debug.Log("You have exit the game :(");
        Application.Quit();
    }


}
