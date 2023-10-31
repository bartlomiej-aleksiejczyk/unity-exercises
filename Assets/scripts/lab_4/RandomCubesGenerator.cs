using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class RandomCubesGenerator : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;
    int objectCounter = 0;
    // obiekt do generowania
    public GameObject block;
    public int objectsToGenerate = 10;
    public List<Material> materialList;

    List<Vector3> borderPositions = new List<Vector3>();

    Renderer renderer;
    Bounds bounds;


    void Start()
    {
        renderer = GetComponent<Renderer>();
        bounds = renderer.bounds;

        Vector3 objectSize = bounds.size;
        Vector3 objectCenter = bounds.center;

        Vector3 bottomLeft = objectCenter - objectSize / 2f;
        Vector3 bottomRight = new Vector3(objectCenter.x + objectSize.x / 2f, objectCenter.y - objectSize.y / 2f, objectCenter.z + objectSize.z / 2f);
        Vector3 topLeft = new Vector3(objectCenter.x - objectSize.x / 2f, objectCenter.y - objectSize.y / 2f, objectCenter.z - objectSize.z / 2f);
        Vector3 topRight = objectCenter + objectSize / 2f;

        borderPositions.Add(bottomLeft);
        borderPositions.Add(bottomRight);
        borderPositions.Add(topLeft);
        borderPositions.Add(topRight);

        // w momecie uruchomienia generuje 10 kostek w losowych miejscach
        List<float> posXRange = new List<float> { bottomLeft.x, bottomRight.x };
        List<float> posZRange = new List<float> { bottomLeft.z, bottomRight.z };

        for (int i = 0; i < objectsToGenerate; i++)
        {
            float randomPosX = UnityEngine.Random.Range(posXRange.Min(), posXRange.Max());
            float randomPosZ = UnityEngine.Random.Range(posZRange.Min(), posZRange.Max());
            this.positions.Add(new Vector3(randomPosX, 0.5f, randomPosZ));
        }

        foreach (Vector3 elem in positions)
        {
            Debug.Log(elem);
        }

        // uruchamiamy coroutine
        StartCoroutine(GenerujObiekt());
    }

    void Update()
    {

    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("wywo³ano coroutine");
        foreach (Vector3 pos in positions)
        {
            GameObject newBlock = Instantiate(this.block, pos, Quaternion.identity);
            newBlock.GetComponent<MeshRenderer>().material = GetRandomMaterial();
            yield return new WaitForSeconds(this.delay);
        }
        // zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
    }

    Material GetRandomMaterial()
    {
        int index = UnityEngine.Random.Range(0, materialList.Count);
        Material randomMat = materialList[index];
        return randomMat;
    }

}