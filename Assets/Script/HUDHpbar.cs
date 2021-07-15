using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDHpbar : MonoBehaviour
{
    public Transform target;
    public RectTransform canvas;
    public RectTransform hpBar;
    public Camera mainCam;
    public GameObject hpBarPrefabs;
    public GameObject hpObj;
    public int maxHp;
    void Start()
    {
        hpObj = Instantiate(hpBarPrefabs);
        target = gameObject.transform;
        canvas = GameObject.Find("Canvas").GetComponent<RectTransform>();
        hpObj.transform.parent = canvas;
        hpBar = hpObj.GetComponent<RectTransform>();
        hpBar.localScale = new Vector3(1, 1, 1);
        mainCam = Camera.main;
        maxHp = transform.parent.GetComponent<EnemyController>().enemyHp;
    }

    void Update()
    {
        Vector3 curPos = target.transform.position;
        Vector2 screenPoint = Camera.main.WorldToScreenPoint(curPos);
        Vector2 canvasPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, screenPoint, mainCam, out canvasPos);
        if (hpBar != null)
        {
            hpBar.localPosition = canvasPos;
            hpBar.GetComponent<Slider>().value = (float)transform.parent.GetComponent<EnemyController>().enemyHp / (float)maxHp;
        }
    }

    public void DestroyHpBar()
    {
        Destroy(hpBar.gameObject);
    }
}
