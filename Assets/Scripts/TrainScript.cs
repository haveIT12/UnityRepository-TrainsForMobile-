using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainScript : MonoBehaviour
{
    public float speed;
    public float speedNext;
    public int upgLvl;
    public int[] upgCost;
    public GameObject[] wagon;
    public int number;
    public int trainPrice;
    public string[] city;
    public string nameTrain;
    public bool isTrainOnlyForPassengers;

    public Road road;

    public float speedrotation;
    public int target;
    public bool isBeforeFinish;
    public bool isTrainMoving = true;
    public bool moveForward = true;


    void Start()
    {
        target = 0;
    }
    private void FixedUpdate()
    {
        //if (isTrainMoving == true)
        //{
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, road.path[target].transform.position, Time.fixedDeltaTime * speed);
            gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, road.path[target].transform.rotation, Time.fixedDeltaTime * speed*2);
            //gameObject.transform.forward = path[target].transform.position - gameObject.transform.position;
        //}
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Start")
        {
            moveForward = true;
            target += 1;
        }
        if (collision.tag == "Finish")
        {
            moveForward = false;
            target -= 1;
        }
        if (collision.tag == road.roadpath)
        {
                if (moveForward == true)
                    target += 1;
                else
                    target -= 1;
        }
    }
}
