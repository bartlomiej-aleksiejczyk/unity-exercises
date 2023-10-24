using System.Collections.Generic;
using UnityEngine;

public class InstantizeObjects : MonoBehaviour
{
    public List<GameObject> gameObjects;
    public List<Vector3> positions;

    const float NUMBER_OF_OBJECTS = 6;

    void Start()
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        for (int i = 0; i < NUMBER_OF_OBJECTS; i++)
        {
            gameObjects.Add(cube);
        }

        CreateRandomPositions(positions);
        for (int i = 0; i < NUMBER_OF_OBJECTS; i++)
        {
            Instantiate(gameObjects[i], positions[i], Quaternion.identity);
        }
    }

    void CreateRandomPositions(List<Vector3> list)
    {
        System.Random random = new System.Random();
        HashSet<float> allXValues = new HashSet<float>();
        HashSet<float> allZValues = new HashSet<float>();
        for (int i = 0; i < NUMBER_OF_OBJECTS; i++)
        {

            float x = random.Next(1, 9);
            bool isXUnique = allXValues.Add(x);
            while (!isXUnique)
            {
                x = random.Next(1, 9);
                isXUnique = allXValues.Add(x);
            }

            float z = random.Next(1, 9);
            bool isZUnique = allZValues.Add(z);
            while (!isZUnique)
            {
                z = random.Next(1, 9);
                isZUnique = allZValues.Add(z);
            }

            Vector3 position = transform.position + new Vector3(x, 0.5f, z);
            list.Add(position);
        }
    }
}
