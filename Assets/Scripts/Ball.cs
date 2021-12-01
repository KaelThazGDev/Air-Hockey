using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private bool playerWin;
    [SerializeField] private float Force;
    private bool firstForceApplied = false;
    private bool boxHitted = false;
    private int bounceTimes = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.GetComponent<Rigidbody2D>().velocity,Color.red);
    }


    // check if Player Score or not
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "BotGoal")
        {
            GameManager.instance.PlayerScore(true);
            new WaitForSeconds(2);
            transform.position = new Vector3(0, 8, 0);
            transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            firstForceApplied = false;
            GameManager.instance.SetBallHeadingPoint(0);
        }
        if (collision.gameObject.name == "PlayerGoal")
        {
            GameManager.instance.PlayerScore(false);
            new WaitForSeconds(2);
            transform.position = new Vector3(0, -6.3f, 0);
            transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            firstForceApplied = false;
        }
    }

    // return ball heading point to Game Manager so the bot can use 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (transform.GetComponent<Rigidbody2D>().velocity.y > 0)
        {
            GameManager.instance.BallHeadingTowardBot(true);
            bounceTimes = 0;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.GetComponent<Rigidbody2D>().velocity, 50f);
            if (hit.collider.name == "HitBox")
            {
                Debug.Log("hit");
                boxHitted = true;
                GameManager.instance.SetBallHeadingPoint(hit.point.x);
            }
            Vector2 wallHitPoint = hit.point;
            Vector2 wallHitDirection = new Vector2(transform.GetComponent<Rigidbody2D>().velocity.x * -1, transform.GetComponent<Rigidbody2D>().velocity.y);
            while (boxHitted == false)
            {
                RaycastHit2D rayFromWall = Physics2D.Raycast(wallHitPoint, wallHitDirection);
                if (rayFromWall.transform.gameObject.name == "HitBox")
                {
                    boxHitted = true;
                    GameManager.instance.SetBallHeadingPoint(rayFromWall.point.x);
                }
                else
                {
                    wallHitPoint = rayFromWall.point;
                    wallHitDirection = new Vector2(wallHitDirection.x * -1, wallHitDirection.y);
                    bounceTimes++;
                }
                if (bounceTimes > 10)
                {
                    break;
                }
            }
        }
        else
        {
            GameManager.instance.BallHeadingTowardBot(false);
        }
        // apply force when player or bot hit the ball

        if (collision.gameObject.tag == "Player" & !firstForceApplied)
        {
            float vX = (transform.position.x - collision.gameObject.transform.position.x)*Force;
            float vY = (transform.position.y - collision.gameObject.transform.position.y)*Force;

            transform.GetComponent<Rigidbody2D>().AddForce(new Vector2 (vX,vY), ForceMode2D.Impulse);
            firstForceApplied = true;
        }
    }




}
