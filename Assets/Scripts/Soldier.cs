using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    public float speed;
    public float rotateSpeed;

    private void Move(Vector3 moveDirection)
    {
        transform.position += moveDirection * speed * Time.deltaTime;


    }

    private void Rotation()
    {


    }

    void Start()
    {

    }

    void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");

        var direction = new Vector3(x: horizontal, y: 0, z: vertical);
        Move(direction);

        var lookingAt = Quaternion.LookRotation(direction);
        //transform.rotation = Quaternion.RotateTowards (, lookingAt, direction.x);

        transform.rotation = Quaternion.LookRotation(direction);





    }
} 
