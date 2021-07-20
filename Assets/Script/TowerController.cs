using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TowerController : MonoBehaviour
{
    public TowerBuildingManager towerBuildingManager;
    public UpGradeManager upGradeManager;
    public int attackPower;
    public float attackCurTime;
    public float attackSpeed;
    public GameObject targetEnemy;
    public GameObject bulletPrefab;
    public GameObject bulletSound;

    public int powerSp = 10;
    public int speedSp = 10;
    public enum TOWERSTATE
    {
        IDLE = 0,
        ATTACK,
        NONE
    }
    public TOWERSTATE towerState;
    EnemyDetecting enemyDetecting;
    void Start()
    {
        towerState = TOWERSTATE.IDLE;
        enemyDetecting = GetComponentInChildren<EnemyDetecting>();
        upGradeManager = GameObject.Find("UpGradeManager").GetComponent<UpGradeManager>();
        towerBuildingManager = GameObject.Find("TowerBuildingManager").GetComponent<TowerBuildingManager>();
    }


    void Update()
    {
        switch (towerState)
        {
            case TOWERSTATE.IDLE:
                if (enemyDetecting.enemies.Count > 0 && targetEnemy == null)
                {
                    targetEnemy = enemyDetecting.enemies[0];
                    towerState = TOWERSTATE.ATTACK;

                }
                break;
            case TOWERSTATE.ATTACK:
                if (targetEnemy != null)
                {
                    
                    targetEnemy = enemyDetecting.enemies[0];
                    Vector3 dir = transform.localRotation.eulerAngles;
                    dir.x = 0;
                    transform.localRotation = Quaternion.Euler(dir);
                    attackCurTime += Time.deltaTime;
                    if (attackCurTime > attackSpeed)
                    {
                        transform.LookAt(targetEnemy.transform);
                        attackCurTime = 0;
                        GameObject bullet = Instantiate(bulletPrefab);
                        bulletSound.transform.position = transform.position;
                        Instantiate(bulletSound);
                        bullet.transform.position = transform.position;
                        bullet.GetComponent<BulletController>().target = targetEnemy;
                        bullet.GetComponent<BulletController>().bulletDamage = attackPower;
                    }
                }
                else
                {
                    towerState = TOWERSTATE.IDLE;
                }
                break;

            case TOWERSTATE.NONE:
                break;

            default:
                break;
        }

    }
}
