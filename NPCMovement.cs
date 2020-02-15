using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public float moveSpeed;
    private Vector3 minWalkPoint;
    private Vector3 maxWalkPoint;

    private Rigidbody myRB;

    public bool isWalking;

    public float walkTime;
    private float walkCounter;
    public float waitTime;
    private float waitCounter;

    private int WalkDirection;

    public Collider walkZone;
    private bool hasWalkZone;

    public bool canMove;
    private DialogueManager dMan;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        dMan = FindObjectOfType<DialogueManager>();

        waitCounter = waitTime;
        walkCounter = walkTime;

        ChooseDirection();

        if(walkZone != null)
        {
            minWalkPoint = walkZone.bounds.min;
            maxWalkPoint = walkZone.bounds.max;
            hasWalkZone = true;
        }

        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!dMan.dialogActive)
        {
            canMove = true;
        }

        if(!canMove)
        {
            myRB.velocity = Vector3.zero;
            return;
        }


        if(isWalking)
        {
            walkCounter -= Time.deltaTime;

            switch(WalkDirection)
            {
            case 0:
                    myRB.velocity = new Vector3(0, 0, moveSpeed);
                    if(hasWalkZone && transform.position.z > maxWalkPoint.z)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;

            case 1:
                    myRB.velocity = new Vector3(moveSpeed, 0, 0);
                    if(hasWalkZone && transform.position.x > maxWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;

            case 2:
                    myRB.velocity = new Vector3(0, 0, -moveSpeed);
                    if (hasWalkZone && transform.position.z < minWalkPoint.z)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;

            case 3:
                    myRB.velocity = new Vector3(-moveSpeed, 0, 0);
                    if (hasWalkZone && transform.position.x < minWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;
            }

            if (walkCounter < 0)
            {
                isWalking = false;
                waitCounter = waitTime;
            }

        }
        else
        {
            waitCounter -= Time.deltaTime;

            myRB.velocity = Vector3.zero;

            if(waitCounter < 0)
            {
                ChooseDirection();
            }
        }
    }

    public void ChooseDirection()
    {
        WalkDirection = Random.Range(0, 4);
        isWalking = true;
        walkCounter = walkTime;


    }
}
