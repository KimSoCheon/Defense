using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameMGR : MonoBehaviour
{
    public Text myHpText;
    public int myHp = 3;
    public int enemyDamage = 1;
    public int bossDamage = 2;
    void Start()
    {
        
    }

    void Update()
    {
        myHpText.text = " : " + myHp;

        if(myHp <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            myHp = myHp - enemyDamage;
            Destroy(other.gameObject);
        }

        if(gameObject.tag == "Boss")
        {
            myHp = myHp - bossDamage;
            Destroy(other.gameObject);
        }
    }
}
