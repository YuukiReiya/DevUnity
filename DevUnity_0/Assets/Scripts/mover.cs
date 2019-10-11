using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover : MonoBehaviour
{
    public float speed;
    public float r;
    private float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        time += Time.time;
        var pos = this.transform.position;
        pos.x += Mathf.Sin(time);
        pos.z += Mathf.Sin(time);
        this.transform.position = pos;
    }
}
