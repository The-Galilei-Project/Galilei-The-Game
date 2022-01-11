using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake(){
        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }

    //Salva il gioco
    public void SaveState(){
        //Debug.Log("Salvataggio");
    }
    //Carica il gioco
    public void LoadState(Scene s, LoadSceneMode mode){
        SceneManager.sceneLoaded -= LoadState;
        //Debug.Log("Caricamento");
    }
}