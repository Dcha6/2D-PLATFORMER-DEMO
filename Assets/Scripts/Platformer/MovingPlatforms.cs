﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    public GameObject platform;
    public float moveSpeed;
    public Transform currentPoint;
    public Transform[] points;
    public int pointSelection;

    void Start()
    {
        currentPoint = points[pointSelection];
    }

    void Update()
    {
        if(platform != null) {
            platform.transform.position = Vector3.MoveTowards(platform.transform.position, currentPoint.position, Time.deltaTime * moveSpeed);
            if (platform.transform.position == currentPoint.position)
            {
                //countdown
                pointSelection++;
                if (pointSelection == points.Length)
                {
                    pointSelection = 0;
                }
                currentPoint = points[pointSelection];
            }
        }
    }
}
