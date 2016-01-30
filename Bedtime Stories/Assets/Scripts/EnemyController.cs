using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public GameObject[] waypoints;
    int waypointCounter = 0;
    float moveSpeed = 2f;
    [SerializeField]
    float health;
    float maxHealth = 5f;

	// Use this for initialization
	void Start () {

        MoveTowardsWaypoint();
        health = maxHealth;
    }
	
	// Update is called once per frame
	void Update () {

        MoveTowardsWaypoint();

    }

    void MoveTowardsWaypoint()
    {
        float step = moveSpeed * Time.deltaTime;
        Vector3 tempTranslate = Vector3.MoveTowards(this.transform.position, waypoints[waypointCounter].transform.position, step);
        //this.gameObject.transform.Translate(tempTranslate * moveSpeed * Time.deltaTime);
        transform.position = tempTranslate;

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Waypoint")
        {
            waypointCounter++;
        }

        if(col.tag == "TurretA_Bullet")
        {
            health--;
            Destroy(col.gameObject);
            if (health <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
