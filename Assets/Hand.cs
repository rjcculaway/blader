using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit info;
        bool raycastResult = Physics.Raycast(ray, out info);
        if (info.collider != null) {
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.red, Time.deltaTime);
        }
        


    }
}
