using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plauer : MonoBehaviour
{
    [Header("Move")]
    private float speed;
    private float distanceToPlayer;
    private Collider Finish;
    // Start is called before the first frame update
    void Start()
    {
        speed = Game_Controller_ABC.Speed;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }
    private void PlayerMove()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, transform.right, out hit))
        {
            distanceToPlayer = hit.distance;
            Finish = hit.collider;
        }
        else
            distanceToPlayer = 0;

        if (Finish.tag == "Finish")
        {
            transform.Translate(transform.right * (speed * 6f) * Time.deltaTime);
        }
        else if (distanceToPlayer > 10)
        {
            transform.Translate(transform.right * (speed * 3f) * Time.deltaTime);
        }
        else if (distanceToPlayer >= 4)
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }              
    }
}
