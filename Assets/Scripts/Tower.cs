using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    //Vector2 используется здесь для генерации диапазона случайного количества так как Vector2 имеет два числа
    [SerializeField] Vector2Int HumanInTowerRange;
    [SerializeField] Human[] _humansTemplate;

    private List<Human> _humanInTower;

    private void Start()
    {
        //проинициализирован пустой лист из объектов Human
        _humanInTower = new List<Human>();

        int HumanInTowerCount = Random.Range(HumanInTowerRange.x, HumanInTowerRange.y);

        SpawnHumans(HumanInTowerCount);

    }


    private void SpawnHumans(int humanCount)
    {
        Vector3 spawnPoint = transform.position;

        for (int i = 0; i < humanCount; i++)
        {
            //выбирается случайный человек из массива людей
            Human spawnedHuman = _humansTemplate[Random.Range(0, _humansTemplate.Length)];

            //Заспавненный чкловек добавляется в список _humanInTower в качестве дочернего объекта к Tower,
            //поэтому в конце Instantiate используется просто transform(то есть transform Tower)
            _humanInTower.Add(Instantiate(spawnedHuman, spawnPoint, Quaternion.identity, transform));

            _humanInTower[i].transform.localPosition = new Vector3(0, _humanInTower[i].transform.localPosition.y, 0);

            //Устанавливает точку spawnPoint для следующего заспавненного человека в FixationPoint данного человека [i]
            spawnPoint = _humanInTower[i].FixationPoint.position;
        }

    }

    public List<Human> CollectHuman(Transform distanceChecker, float fixationMaxDistance)
    {
        for (int i = 0; i < _humanInTower.Count; i++)
        {
            float distanceBetweenPoints = CheckDistanceY(distanceChecker, _humanInTower[i].FixationPoint.transform);

            if (distanceBetweenPoints < fixationMaxDistance)
            {
                List<Human> collectedHumans = _humanInTower.GetRange(0, i+1);
                _humanInTower.RemoveRange(0, i + 1);
                return collectedHumans;
            }
        }

        return null;
    }


    private float CheckDistanceY(Transform distanceChecker, Transform humanFixationPoint)
    {
        Vector3 distanceCheckerY = new Vector3(0, distanceChecker.position.y, 0);
        Vector3 humanFixationPointY = new Vector3(0, humanFixationPoint.position.y, 0);

        return Vector3.Distance(distanceCheckerY, humanFixationPointY);
    }


}
