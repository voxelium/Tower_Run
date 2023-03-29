using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class LevelCreator : MonoBehaviour
{

    [SerializeField] private PathCreator pathCreator;
    [SerializeField] private Tower towerTemplate;
    [SerializeField] private int humanTowerCount;


    // Start is called before the first frame update
    private void Start()
    {
        GenerateLevel();
    }

    private void GenerateLevel()
    {
        float roadLength = pathCreator.path.length;
        float distanceBetweenTower = roadLength / humanTowerCount;
        float distanceTravelled = 0;
        Vector3 spawnPoint;

        for (int i = 0; i < humanTowerCount; i++)
        {
            distanceTravelled += distanceBetweenTower;
            spawnPoint = pathCreator.path.GetPointAtDistance(distanceTravelled, EndOfPathInstruction.Stop);

            Instantiate(towerTemplate, spawnPoint, Quaternion.identity);
        }

    }

   


}
