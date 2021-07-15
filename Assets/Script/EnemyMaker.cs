using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyMaker : MonoBehaviour
{
    public UpGradeManager upGradeManager;
    public GameObject enemyPrefab;
    public float curTime;
    public float coolTime = 2f;
    public int enemyCnt = 0;
    public int enemyMaxCnt;
    public bool isRunning = false;

    public Text timeCurText;
    public float timeCur = 10f;
    public float timeCool;

    public int enemyHp = 10;
    public float enemySpeed = 1;
    public int enemySp = 1;
    public int enemyDamage = 1;
    public int lvCnt;
    public string EnemydataFilePath;
    void Start()
    {
        upGradeManager = GameObject.Find("UpGradeManager").GetComponent<UpGradeManager>();

        List<Dictionary<string, object>> data = CSVReader.Read(EnemydataFilePath);
        if (lvCnt < data.Count)
        {
            enemyMaxCnt = int.Parse(data[lvCnt]["MaxCnt"].ToString());
            enemyHp = int.Parse(data[lvCnt]["Hp"].ToString());
            enemySpeed = float.Parse(data[lvCnt]["Speed"].ToString());
            enemySp = int.Parse(data[lvCnt]["Sp"].ToString());
            enemyDamage = int.Parse(data[lvCnt]["Damage"].ToString());
        }
    }
    void Update()
    {
        timeCurText = GameObject.Find("TimeCurText").GetComponent<Text>();

        if (enemyCnt > enemyMaxCnt)
        {
            isRunning = false;
        }
        if (isRunning == false)
        {
            int a = (int)timeCur;
            timeCur -=  Time.deltaTime;
            timeCurText.text = "다음스테이지 시작까지 남은 시간 : " + (int)timeCur;

            if (timeCur < timeCool)
            {
                timeCur = 15;
                List<Dictionary<string, object>> data = CSVReader.Read(EnemydataFilePath);
                if (lvCnt < data.Count)
                {
                    enemyMaxCnt = int.Parse(data[lvCnt]["MaxCnt"].ToString());
                    enemyHp = int.Parse(data[lvCnt]["Hp"].ToString());
                    enemySpeed = float.Parse(data[lvCnt]["Speed"].ToString());
                    enemySp = int.Parse(data[lvCnt]["Sp"].ToString());
                    enemyDamage = int.Parse(data[lvCnt]["Damage"].ToString());

                }
                lvCnt++;
                enemyCnt = 0;
                upGradeManager.stageLv++;
                isRunning = true;
            }
        }





        if (isRunning)
        {
            curTime += Time.deltaTime;
            if (curTime > coolTime)
            {
                curTime = 0;
                if(enemyMaxCnt != 1)
                {
                    GameObject obj = Instantiate(enemyPrefab, transform.position, transform.rotation);
                    obj.transform.rotation = transform.rotation;
                    obj.name = "Enemy_" + enemyCnt;
                    obj.GetComponent<EnemyController>().enemyHp = enemyHp;
                    obj.GetComponent<EnemyController>().enemySpeed = enemySpeed;
                    obj.GetComponent<EnemyController>().enemySp = enemySp;
                    obj.GetComponent<EnemyController>().enemyDamage = enemyDamage;
                    enemyCnt++;
                }
            }
        }
    }
}
