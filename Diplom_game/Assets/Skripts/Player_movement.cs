using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{

    private readonly string Horizontal = "Horizontal";

    [SerializeField] private float _speed;

    private void Update()
    {
        transform.Translate(Input.GetAxis(Horizontal) * Vector3.right * Time.deltaTime * _speed);
    }

}
