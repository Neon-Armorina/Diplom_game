using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog : MonoBehaviour
{

    public GameObject Player;
    public float riseSpeed;

    private bool CanGetHigher = true;
    private Vector3 playerTrans;

    public void Update()
    {
        if (Player != null && (Player.transform.position.y > transform.position.y + 1) && CanGetHigher)
        {
            CanGetHigher = false;
            playerTrans = Player.transform.position;
            StartCoroutine("GetHigher");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
        }
    }

    private IEnumerator GetHigher()
    {
        while (transform.position.y < playerTrans.y)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + riseSpeed * Time.deltaTime, transform.position.z);
        }

        CanGetHigher = true;

        yield return null;
    }
}
