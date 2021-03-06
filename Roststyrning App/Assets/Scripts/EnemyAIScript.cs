﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIScript : MonoBehaviour
{

    public Transform player;
    public float playerDistance;
    public float rotationDampling;
    public float moveSpeed;
    public static bool isPlayerAlive = true;

    public bool isDamaging;
    public float damage = 10;


	void Update () {
        if(isPlayerAlive)
        {
        playerDistance = Vector3.Distance (player.position, transform.position);
          if (playerDistance < 25f)
           {
            LookAtPlayer();
           }
          if (playerDistance < 22f)
        {
            if (playerDistance > 5f)
            {
                Chase();
            }
            else if (playerDistance < 5f)
            {
                Attack();
            }           
        }

        }
    }

    void LookAtPlayer()
    {
        Quaternion rotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationDampling);

    } 

    void Chase()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    void Attack()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if(hit.collider.gameObject.tag == "Player")
            {
                hit.collider.gameObject.GetComponent<HealtScript>().health -= 5f;
            }
        }
    }

    private void OnTriggerStay(Collider col)
    {
       if(col.tag == "Player")
        {
            col.SendMessage((isDamaging) ? "TakeDamage" : "HealDamage", Time.deltaTime * damage);
        }
    }

    void Score()
    {
       //SunScore.Add();
    }


    private void OnCollisionEnter(Collision collision)
    {
      
        if (collision.transform.tag == "Enemy")
        {

            Destroy(collision.gameObject);
          


        }


    }
}

