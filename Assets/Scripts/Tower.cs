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



}
