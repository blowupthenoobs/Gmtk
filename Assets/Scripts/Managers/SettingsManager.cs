using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{ 
    public static SettingsManager Instance { get; private set; }

    private Camera cam;

    AudioSource playerAudio;

    private float volume;
    public float Volume
    {
        get
        {
            return volume;
        }
        set
        {
            volume = value;
            playerAudio.volume = volume;
        }
    }

    public Camera CurrentCamera
    {
        get
        {
            return cam;
        }
        set
        {
            cam = value;
            playerAudio = cam.gameObject.GetComponent<AudioSource>();
            playerAudio.volume = volume;
        }
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        CurrentCamera = Camera.main;
    }

    public void changeVolume(float value) // this can be removed. Just use .Volume = newValue
    {
        Volume = value;
    }
}