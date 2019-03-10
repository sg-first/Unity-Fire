using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC : MonoBehaviour
{
    float nowTime;
    float targetTime;
    float speed;
    Vector3 angle;
    bool isMove = false;

    public void moveTime(float time,float speed,Vector3 angle = default(Vector3))
    {
        if (angle == default(Vector3))
            angle = unityFire.getItemAngle(this.gameObject);
        this.angle = angle;
        this.speed = speed;
        this.targetTime = time;
        this.nowTime = 0;
        this.isMove = true;
    }

    void FixedUpdate()
    {
        if(isMove)
        {
            nowTime += Time.deltaTime;
            Debug.Log(nowTime);
            if (nowTime < targetTime)
            {
                transform.Translate(angle * speed * Time.deltaTime);
            }
            else
            {
                isMove = false;
            }
        }
    }
}
