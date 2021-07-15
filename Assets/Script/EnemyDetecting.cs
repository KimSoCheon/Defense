using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetecting : MonoBehaviour
{
    public List<GameObject> enemies;
    public TowerController towerController;

    void Start()
    {
        towerController = transform.parent.GetComponent<TowerController>();
    }
    private void Update()
    {
        if (enemies.Count > 0 && enemies[0] == null)
        {
            enemies.RemoveAt(0);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        towerController.targetEnemy = other.gameObject;
        towerController.towerState = TowerController.TOWERSTATE.ATTACK;
        enemies.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        towerController.targetEnemy = null;
        enemies.Remove(other.gameObject);
    }

}