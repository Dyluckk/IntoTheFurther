﻿using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    public float speed = 15.0f;
    public GameObject projectile;
    public GameObject bulletSpawner;
    float yMax = 2.2f;
    float yMin = -3.5f;
    public float projectileSpeed = 20;
    public float fireRate = 1;
    public Animator playerAnimator;

    void Start() {
          
    }

    void Fire()
    {
        if (!(playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("shootAnimation")))
        {
            gameObject.GetComponent<AudioSource>().Play();
            GameObject bullet = Instantiate(projectile, bulletSpawner.transform.position, Quaternion.identity) as GameObject;
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(projectileSpeed, 0, 0);
            gameObject.GetComponent<Animator>().Play("shootAnimation");
        }
    }
    
    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("Fire", .0000001f, fireRate);
          
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
           CancelInvoke("Fire");
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            //transform.position += new Vector3(0, -speed * Time.deltaTime, 0);

            transform.position += Vector3.down * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            //transform.position += new Vector3(0, +speed * Time.deltaTime, 0);
            transform.position += Vector3.up * speed * Time.deltaTime;
        }

        //restrict player to game space
        float newY = Mathf.Clamp(transform.position.y, yMin, yMax);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        

    }

}