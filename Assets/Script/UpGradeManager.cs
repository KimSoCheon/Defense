using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpGradeManager : MonoBehaviour
{
    public TowerBuildingManager towerBuildingManager;
    public GameObject upGradeTarget;

    public int stageLv;
    public Text stageLvText;
    public Text mySp;

    public Text powerSpText;
    public Text speedSpText;

    public int powerLv = 1;
    public int speedLv = 1;
    public int speedMaxLv = 7;
    void Start()
    {
        
    }

    void Update()
    {
        mySp.text = "Sp : " + towerBuildingManager.mySp;
        stageLvText.text = "StageLv : " + stageLv;
    }

    public void PowerUp()
    {
        if(upGradeTarget.GetComponent<TowerController>().attackPower < 76)
        {
            if (towerBuildingManager.mySp >= upGradeTarget.GetComponent<TowerController>().powerSp)
            {
                powerLv++;
                towerBuildingManager.mySp -= upGradeTarget.GetComponent<TowerController>().powerSp;
                upGradeTarget.GetComponent<TowerController>().attackPower += 3;
                upGradeTarget.GetComponent<TowerController>().powerSp += 10;
                powerSpText.text = "Sp : " + upGradeTarget.GetComponent<TowerController>().powerSp;
                powerSpText = GameObject.Find("PowerSp").GetComponent<Text>();
            }
        }
    }

    public void SpeedUp()
    {
        if (upGradeTarget.GetComponent<TowerController>().attackSpeed > 0.15f)
        {
            if (towerBuildingManager.mySp >= upGradeTarget.GetComponent<TowerController>().speedSp)
            {
                speedLv++;
                towerBuildingManager.mySp -= upGradeTarget.GetComponent<TowerController>().speedSp;
                upGradeTarget.GetComponent<TowerController>().attackSpeed -= 0.1f;
                upGradeTarget.GetComponent<TowerController>().speedSp *= 2;
                speedSpText.text = "Sp : " + upGradeTarget.GetComponent<TowerController>().speedSp;
                speedSpText = GameObject.Find("SpeedSp").GetComponent<Text>();
            }
        }
    }
}
