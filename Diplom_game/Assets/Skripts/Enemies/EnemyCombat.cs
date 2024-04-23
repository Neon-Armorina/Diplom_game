using FSM.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{

    [SerializeField] private GameObject _character;
    [SerializeField] private Vector2 _forceMultiplier;

    private Rigidbody2D rb;
    private int ForceDirection = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakePunch()
    {
        Debug.Log("Punch");
        if(_character.transform.position.x < transform.position.x)
            ForceDirection = 1;
        else
            ForceDirection = -1;

        rb.AddForce(_forceMultiplier * ForceDirection * Time.deltaTime * Character._punchforce, ForceMode2D.Impulse);
    }
}
