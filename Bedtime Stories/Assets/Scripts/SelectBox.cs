using UnityEngine;
using System.Collections;

public class SelectBox : MonoBehaviour {

    public int myTowerNumber;

    public TowerSpawner mySpawner;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        if (!mySpawner.towerSpawned)
        {
            StartTowerSpawn();
        }
    }

    void StartTowerSpawn()
    {
        mySpawner.SpawnTower(myTowerNumber);
    }




}
