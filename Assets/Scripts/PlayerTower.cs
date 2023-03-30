using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTower : MonoBehaviour
{
    [SerializeField] private Human startHuman;
    [SerializeField] private Transform distanceChecker;
    [SerializeField] private float fixationMaxDistance;
    [SerializeField] private BoxCollider checkCollider;

    private List<Human> humans;

    private void Start()
    {
        humans = new List<Human>();
        Vector3 spawnPoint = transform.position;

        //в конце указывается transform родительского объекта
        humans.Add(Instantiate(startHuman, spawnPoint, Quaternion.identity, transform));

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Human human))
        {
            Tower collisionTower = human.GetComponentInParent<Tower>();

            List<Human> collectedHumans = collisionTower.CollectHuman(distanceChecker, fixationMaxDistance);

            if (collectedHumans != null)
            {
                InsertHuman(collectedHumans);
            }
        }
    }


    private void InsertHuman(List<Human> collectedHumans)
    {
        for (int i = collectedHumans.Count - 1; i >= 0; i--)
        {
            Human insertHuman = collectedHumans[i];
            humans.Insert(0, insertHuman);
            SetHumanPosition(insertHuman);
        }
    }

    private void SetHumanPosition(Human human)
    {
        human.transform.parent = transform;
        human.transform.localPosition = new Vector3(0, human.transform.localPosition.y, 0);
        human.transform.localRotation = Quaternion.identity;
    }

}
