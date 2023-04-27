using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOptionController : MonoBehaviour {
    private int oriScreenW;
    private int oriScreenH;
    
    private void Init() {
        this.oriScreenW = Screen.currentResolution.width;
        this.oriScreenH = Screen.currentResolution.height;
    }

    private void Start() {
        Init();
    }

    public void Resolution(int num) {
        switch (num) {
            case 1 :
                Screen.SetResolution(this.oriScreenW, this.oriScreenH, FullScreenMode.FullScreenWindow);
                break;
            case 2 :
                Screen.SetResolution(1920, 1080, FullScreenMode.FullScreenWindow);
                break;
            case 3 : 
                Screen.SetResolution(2560, 1080, FullScreenMode.FullScreenWindow);
                break;
        }
    }

    public void FPSOption(int num) {
        Application.targetFrameRate = num;
    }

    public void VsyncOption(int num) {
        QualitySettings.vSyncCount = num;
    }

    public void QualityOption(int num) {
        QualitySettings.SetQualityLevel(num);
    }
}
