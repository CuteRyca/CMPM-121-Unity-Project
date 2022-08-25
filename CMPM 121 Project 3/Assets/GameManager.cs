using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class GameManager : MonoBehaviour
{
    public AudioMixer mixer;
    
    public void ChangeScene(string sceneName) 
    {
        SceneManager.LoadScene(sceneName);
    }
    public void SetMasterVolume(float value) 
    {
        mixer.SetFloat("MasterVolume", value);
        PlayerPrefs.SetFloat("MasterVolume", value);
    }
    public void SetMusicVolume(float value)
    {
        mixer.SetFloat("MusicVolume", value);
        PlayerPrefs.SetFloat("MusicVolume", value);
    }
    public void SetSFXVolume(float value)
    {
        mixer.SetFloat("SFXVolume", value);
        PlayerPrefs.SetFloat("SFXVolume", value);
    }
}
