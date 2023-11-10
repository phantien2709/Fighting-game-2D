using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LevelUI : MonoBehaviour
{
    public Text AnnouncerTextLine1;
    public Text AnnouncerTextLine2;
    public Text LevelTimer;
    public Slider[] healthSliders;
    public GameObject[] winIndicatorGrids;
    public GameObject winIndicator;
    public static LevelUI instance;
    public static LevelUI GetInstance()
    {
        return instance;
    }
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
    public void AddWinIndicator()
    {
        GameObject go = Instantiate(winIndicator,transform.position,Quaternion.identity) as GameObject;
    }
}
