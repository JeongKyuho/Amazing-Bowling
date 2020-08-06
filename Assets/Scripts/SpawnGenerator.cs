using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGenerator : MonoBehaviour
{
    private BoxCollider area;
    public GameObject[] propPrefabs;
    public int count = 100;

    private List<GameObject> props = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        area = GetComponent<BoxCollider>();

        for(int i = 0; i < 100; i++)
        {
            Spawn();
        }

        area.enabled = false;
    }

    private void Spawn()
    {
        int selection = Random.Range(0, propPrefabs.Length);
        GameObject selectedPrefab = propPrefabs[selection];
        Vector3 spawnPos = GetRandomPosition();

        GameObject instance = Instantiate(selectedPrefab, spawnPos, Quaternion.identity);
        props.Add(instance);
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 basePosition = transform.position;
        Vector3 size = area.size;

        float posX = basePosition.x + Random.Range(-size.x / 2, size.x / 2);
        float posY = basePosition.y + Random.Range(-size.y / 2, size.y / 2);
        float posZ = basePosition.z + Random.Range(-size.z / 2, size.z / 2);

        Vector3 spawnPos = new Vector3(posX, posY, posZ);

        return spawnPos;
    }

    public void Reset()
    {
        for(int i = 0; i < props.Count; i++)
        {
            props[i].transform.position = GetRandomPosition();
            props[i].SetActive(true);
        }
    }
}
