using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC : MonoBehaviour
{
    //move
    float moveNowTime;
    float moveTargetTime;
    float speed;
    Vector3 angle;
    bool isMove = false;
    //rotate
    float rotateNowTime;
    float rotateTargetTime;
    Vector3 rotateSpeed;
    bool isRotate = false;

    public void moveTime(float time,float speed,Vector3 angle = default(Vector3))
    {
        if (angle == default(Vector3))
            angle = unityFire.getItemAngle(this.gameObject);
        this.angle = angle;
        this.speed = speed;
        this.moveTargetTime = time;
        this.moveNowTime = 0;
        this.isMove = true;
    }

    public void moveTimeTarget(float time,Vector3 target)
    {
        Vector3 pos1 = unityFire.getItemPos(this.gameObject);
        Vector3 angle = target - pos1;
        float length = angle.magnitude;
        angle.Normalize();
        this.moveTime(time, length / time, angle);
    }

    public void rotateTime(float time,Vector3 rotateSpeed)
    {
        this.rotateSpeed = rotateSpeed;
        this.rotateNowTime = 0;
        this.rotateTargetTime = time;
        this.isRotate = true;
    }

    public void rotateTimeTarget(float time,Vector3 rotateTarget)
    {
        this.rotateTime(time, rotateTarget / time);
    }

    void FixedUpdate()
    {
        if(isMove)
        {
            moveNowTime += Time.deltaTime;
            if (moveNowTime < moveTargetTime)
            {
                transform.Translate(angle * speed * Time.deltaTime);
            }
            else
            {
                isMove = false;
            }
        }
        if(isRotate)
        {
            rotateNowTime += Time.deltaTime;
            if(rotateNowTime<rotateTargetTime)
            {
                transform.Rotate(rotateSpeed);
            }
            else
            {
                isRotate = false;
            }
        }
    }
}
