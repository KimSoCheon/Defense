using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TowerBuildingManager : MonoBehaviour
{
    public GameObject upgradePopUp;
    public UpGradeManager upGradeManager;

    public EnemyController enemyController;

    public GameObject towerPrefab;
    public GameObject tower;
    public int mySp = 10;
    public int costSp = 1;
    public int towerUpCost = 1;



    public int towerName;
    void Start()
    {
        upGradeManager = GameObject.Find("UpGradeManager").GetComponent<UpGradeManager>();
    }
    void Update()
    {
        if (upgradePopUp.activeSelf == true)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    //Debug.Log(hit.collider.gameObject.tag);
                    switch (hit.collider.gameObject.tag)
                    {
                        case "Block":
                            if(mySp >= costSp)
                            {
                                mySp -= costSp;
                                tower = Instantiate(towerPrefab) as GameObject;
                                towerName++;
                                tower.name = "Tower";
                                tower.transform.position = hit.collider.transform.position + new Vector3(0, 1.5f, 0);
                                costSp++;
                            }
                            else
                            {
                                tower = null;
                            }
                            break;
                        case "BlockNon":
                            Debug.Log("타워를 지을수 없는 곳입니다::::");
                            break;
                        case "Tower":
                            upgradePopUp.SetActive(true);
                            upGradeManager.upGradeTarget = hit.collider.gameObject;
                            break;
                    }
                }
            }
        }
    }
}