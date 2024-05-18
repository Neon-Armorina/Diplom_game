using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public Transform player;
    public GameObject[] RoomPrefabs;
    public GameObject firstRoom;
    public Vector3 offset;

    private List<GameObject> spawnedRooms = new List<GameObject>();


    private void Start()
    {
        spawnedRooms.Add(firstRoom);
    }

    private void Update()
    {
        if (player.position.y > transform.position.y - 2) 
        {
            transform.position = transform.position + offset;
            SpawnRoom();
        }
    }

    private void SpawnRoom()
    {
        GameObject newRoom = Instantiate(RoomPrefabs[Random.Range(0, RoomPrefabs.Length)]);
        newRoom.transform.position = transform.position;
        spawnedRooms.Add(newRoom);

        if (spawnedRooms.Count > 5)
        {
            Debug.Log("DELETE");
            DestroyImmediate(spawnedRooms[0].gameObject);
            spawnedRooms.RemoveAt(0);
        }
    }
}
