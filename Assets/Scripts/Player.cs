using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float TopBorder;
    [SerializeField] private float BottomBorder;
    [SerializeField] private float LeftBorder;
    [SerializeField] private float RightBorder;
    [SerializeField] private float Velocity;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x, + Mathf.Clamp(transform.position.y + Velocity*Time.deltaTime,BottomBorder,TopBorder), 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x, +Mathf.Clamp(transform.position.y - Velocity *Time.deltaTime, BottomBorder, TopBorder), 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x - Velocity * Time.deltaTime, LeftBorder, RightBorder), transform.position.y, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x + Velocity * Time.deltaTime, LeftBorder, RightBorder), transform.position.y, 0);
        }

    }
}
