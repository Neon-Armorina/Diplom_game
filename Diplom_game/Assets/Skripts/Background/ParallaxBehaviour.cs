using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBehaviour : MonoBehaviour
{

    [SerializeField] private Transform followingTarget;
    [SerializeField] private float moveSpeedX;
    [SerializeField, Range(0f, 1f)] private float parallaxStrenght = 0.1f;
    [SerializeField] private bool disableVerticalParallax;
    private Vector3 targetPreviousPosition;

    private void Start()
    {
        if (!followingTarget) 
            followingTarget = Camera.main.transform;

        targetPreviousPosition = followingTarget.position;
    }

    private void Update()
    {
        var delta = followingTarget.position - targetPreviousPosition;

        if (disableVerticalParallax)
            delta.y = 0f;

        targetPreviousPosition = followingTarget.position;

        transform.position += delta * parallaxStrenght;
    }

    private void FixedUpdate()
    {
        transform.position = transform.position + Vector3.right * moveSpeedX * Time.deltaTime;
    }
}
