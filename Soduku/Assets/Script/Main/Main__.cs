using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Main__ : MonoBehaviour
{
    
 public Button EasyButton;
    public Button MiddleButton;
    public Button HardButton;
    public void ClickOn_Easy(){
        SceneManager.LoadScene("MainGame");
        Main_GameSetting.EasyMiddleHard_Number = 1;
    }
     public void ClickOn_Middle(){
        SceneManager.LoadScene("MainGame");
        Main_GameSetting.EasyMiddleHard_Number = 2;

    }
     public void ClickOn_Hard(){
        SceneManager.LoadScene("MainGame");
        Main_GameSetting.EasyMiddleHard_Number = 3;

    }
}
