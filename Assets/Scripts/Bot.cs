using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    [SerializeField] private float LeftBorder;
    [SerializeField] private float RightBorder;
    [SerializeField] private float Velocity;
    private float ballHeadingPoint;
    private bool movingLeft = true;
    void Start()
    {
        
    }

    void Update()
    {
        ballHeadingPoint = Mathf.Clamp(GameManager.instance.BallHeadingTowardPoint(), LeftBorder, RightBorder);
        if (GameManager.instance.IfBallHeadingTowardBot())
        {
            if (transform.position.x > ballHeadingPoint)
            {
                transform.position -= new Vector3(Velocity * Time.deltaTime, 0, 0);
            }
            else
            {
                transform.position += new Vector3(Velocity * Time.deltaTime, 0, 0);
            }
        }
        else
        {
            Patrol();
        }
    }

    private void Patrol()
    {
        if (transform.position.x > RightBorder)
        {
            movingLeft = true;
        }
        if (transform.position.x < LeftBorder)
        {
            movingLeft = false;
        }
        if (movingLeft)
        {
            transform.position -= new Vector3(Velocity * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.position += new Vector3(Velocity * Time.deltaTime, 0, 0);
        }
    }
}
