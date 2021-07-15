using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public GameObject mousePos;
    void Start()
    {
        
    }
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,out hit))
        {
            if (Input.GetMouseButton(1))
            {
                if (hit.collider.gameObject.tag == "Tower")
                {
                    hit.collider.gameObject.transform.position = hit.point;
                    hit.collider.gameObject.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
                }
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Tower")
        {
            
        }
    }
}
