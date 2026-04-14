using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Timeline;

public class MoveMarker : MonoBehaviour
{

    private float moveTime = 1f;
    public GameObject hitMarker;
    private Vector3 boundSize = new Vector3(1, 1, 1);
    public Transform upperX;
    public Transform lowerX;
    public Lockpick lockpick;
    private Vector3 topSpot;
    private Vector3 bottomSpot;


    private void Update()
    {

        topSpot = new Vector3(upperX.position.x, upperX.position.y, upperX.position.z);

        bottomSpot = new Vector3(lowerX.position.x, lowerX.position.y, lowerX.position.z);

        if (lockpick.lockUI != false)
        {

            StartCoroutine(MoveDown(bottomSpot));

        }

        if (lockpick.lockUI != true)
        {

            StopCoroutine(MoveDown(bottomSpot));
            StopCoroutine(MoveUp(topSpot));

        }

    }


    IEnumerator MoveUp(Vector3 target)
    {

        Vector3 startPos = hitMarker.transform.position;
        float timeElapsed = 0f;

        while (timeElapsed < moveTime)
        {

            hitMarker.transform.position = Vector3.Lerp(startPos, target, timeElapsed / moveTime);
            timeElapsed += Time.deltaTime;
            yield return null;

        }

        hitMarker.transform.position = target;

        StartCoroutine(MoveDown(bottomSpot));

    }

    IEnumerator MoveDown(Vector3 target)
    {

        Vector3 startPos = hitMarker.transform.position;
        float timeElapsed = 0f;

        while (timeElapsed < moveTime)
        {

            hitMarker.transform.position = Vector3.Lerp(startPos, target, timeElapsed / moveTime);
            timeElapsed += Time.deltaTime;
            yield return null;

        }

        hitMarker.transform.position = target;

        StartCoroutine(MoveUp(topSpot));

    }

    private void OnDrawGizmos()
    {

        Gizmos.color = Color.darkRed;
        Gizmos.DrawWireCube(upperX.position, boundSize);
        Gizmos.DrawWireCube(lowerX.position, boundSize);

    }

}