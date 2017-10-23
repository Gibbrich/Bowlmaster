using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ball))]
public class BallDragLaunch : MonoBehaviour
{
    public GameObject Floor;
    
    private Ball ball;
    private float timeStart;
    private Vector3 startPosition;
    private int ballMovingDirectionBeforeStart;
    
    // Use this for initialization
    void Start()
    {
        ball = GetComponent<Ball>();
    }

    public void DragStart()
    {
        if (!ball.IsInPlay)
        {
            timeStart = Time.timeSinceLevelLoad;
            startPosition = Input.mousePosition;
        }
    }

    public void DragEnd()
    {
        if (!ball.IsInPlay)
        {
            float dragDuration = Time.timeSinceLevelLoad - timeStart;

            float launchDirectionX = (Input.mousePosition.x - startPosition.x) / dragDuration;
            float launchDirectionZ = (Input.mousePosition.y - startPosition.y) / dragDuration;
            Vector3 launchDirection = new Vector3(launchDirectionX, 0, launchDirectionZ);

            ball.Launch(launchDirection);
        }
    }

    public void MoveStart(int xNudge)
    {
        ballMovingDirectionBeforeStart = xNudge;
    }

    private void Update()
    {
        if (!ball.IsInPlay && ballMovingDirectionBeforeStart != 0)
        {
            float maxX = (Floor.transform.localScale.x - ball.transform.localScale.x) / 2;
            float minX = -maxX;
            float ballSupposedX = ball.transform.position.x + ballMovingDirectionBeforeStart;
            float ballFutureX = Mathf.Clamp(ballSupposedX, minX, maxX);
            
            ball.transform.position = new Vector3(ballFutureX, ball.transform.position.y, ball.transform.position.z);
        }
    }
}