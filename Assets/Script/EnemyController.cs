using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyController : MonoBehaviour
{
    public TowerBuildingManager towerBuildingManager;
    public List<Transform> targetPos;
    public CharacterController characterController;
    public Transform curTargetPos;
    public float rotationSpeed = 10f;
    //public GameObject deadEffect;

    public int enemyHp;
    public float enemySpeed;
    public int enemySp;
    public int enemyDamage;
    public int lvCnt;
    public string EnemydataFilePath;
    public int myHp;
    public GameMGR gameMGR;
    void Start()
    {
        towerBuildingManager = GameObject.Find("TowerBuildingManager").GetComponent<TowerBuildingManager>();
        gameMGR = GameObject.Find("GameMGR").GetComponent<GameMGR>();
        for (int i = 1; i < 4; i++)
        {
            targetPos.Add(GameObject.Find("EnemyNode" + i).transform);
        }
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (targetPos != null)
        {
            curTargetPos = targetPos[0];
            float distance = Vector3.Distance(transform.position, curTargetPos.position);
            Vector3 dir = curTargetPos.position - transform.position;
            dir.y = 0;
            dir.Normalize();
            characterController.SimpleMove(dir * enemySpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), rotationSpeed * Time.deltaTime);
            
            if (distance < 0.2f)
            {
                targetPos.RemoveAt(0);
            }
        }
    }

    public void DamageByBullet(int dmg)
    {
        enemyHp -= dmg;
        if (enemyHp <= 0)
        {
            towerBuildingManager.mySp += enemySp;
            //GetComponentInChildren<HUDHpbar>().DestroyHpBar();
            //deadEffect.transform.position = transform.position;
            //Instantiate(deadEffect);
            Destroy(gameObject); // Àû Ã³Ä¡
        }
    }
}