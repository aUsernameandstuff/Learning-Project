using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BaloonInstanceCreater : MonoBehaviour
{
    public Transform[] BaloonPoints;
    public GameObject[] BaloonObjects;

    public float TimeBetweenBaloons = 1f;

    private void Start()
    {
        InvokeRepeating("CreateABalloon", TimeBetweenBaloons, TimeBetweenBaloons);
    }

    public void CreateABalloon()
    {
        //Random Balloon
        //Random Point

        Transform balloonPoint = BaloonPoints[Random.Range(0, BaloonPoints.Length)];
        GameObject balloonPrefab = BaloonObjects[Random.Range(0, BaloonObjects.Length)];

        Instantiate(balloonPrefab, balloonPoint.position, balloonPoint.rotation);
    }
}
