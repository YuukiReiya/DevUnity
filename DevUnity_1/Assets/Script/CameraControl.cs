using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //  ターゲットを注視
        transform.LookAt(target);

        //  カメラの前後反転
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            Vector3 lPos = transform.localPosition;
            transform.localPosition = new Vector3(lPos.x, lPos.y, -lPos.z);
        }
    }
}
