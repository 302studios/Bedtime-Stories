using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{

    public GameObject[] waypoints;
    int waypointCounter = 0;
    float moveSpeed = 2f;
    float speedMod = 1f;
    [SerializeField]
    float health;
    float maxHealth = 10f;

    // Use this for initialization
    void Start()
    {

        MoveTowardsWaypoint();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

        MoveTowardsWaypoint();

    }

    void MoveTowardsWaypoint()
    {
        float step = moveSpeed * Time.deltaTime;
        Vector3 tempTranslate = Vector3.MoveTowards(this.transform.position, waypoints[waypointCounter].transform.position, step);
        //this.gameObject.transform.Translate(tempTranslate * moveSpeed * Time.deltaTime);
        transform.position = tempTranslate;

    }

    IEnumerator Slowed(float secs)
    {
        speedMod = .3f;
        yield return new WaitForSeconds(secs);
        speedMod = 1f;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Waypoint")
        {
            waypointCounter++;
        }


        if (col.tag == "Gumball_Bullet")
        {
            health--;
            Destroy(col.gameObject);
            if (health <= 0)
            {
                Destroy(this.gameObject);
            }
        }

        if (col.tag == "TeddyBear_Bullet")
        {
            health -= 3f;
            Destroy(col.gameObject);
            if (health <= 0)
            {
                Destroy(this.gameObject);
            }
        }

        if (col.tag == "Lego_Bullet")
        {
            //health--;
            //Destroy(col.gameObject);

            StartCoroutine(Slowed(3f));

            if (health <= 0)
            {
                Destroy(this.gameObject);
            }
        }

        if (col.tag == "Laser_Bullet")
        {
            health -= 10;
            Destroy(col.gameObject);
            if (health <= 0)
            {
                Destroy(this.gameObject);
            }
        }

        if (col.tag == "Endpoint")
        {
            // Insert Stat tracker health subtraction
        }
    }

}

