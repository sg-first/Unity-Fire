using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class calu : MonoBehaviour
{
    public static Quaternion Vector3ToQuaternion(Vector3 angle)
    {
    		return Quaternion.Euler(angle);
    }
    
    public static Vector3 QuaternionToVector3(Quaternion angle)
    {
    		return angle.eulerAngles;
    }
    
    public static Vector3 selfRotateVector3(Vector3 orig,Vector3 angle)
    {
    		orig = calu.axisRotateVector3 (orig, angle.x, Vector3.right);
    		orig = calu.axisRotateVector3 (orig, angle.y, Vector3.up);
    		orig = calu.axisRotateVector3 (orig, angle.z, Vector3.forward);
    		return orig;
    }
    
    public static Vector3 axisRotateVector3(Vector3 orig,float angle,Vector3 axis)
    {
    		return Quaternion.AngleAxis(angle, axis) * orig;
    }

    public static Vector3 normalVector(Vector3 v1, Vector3 v2)
    {
        return new Vector3(v1.y * v2.z - v1.z * v2.y,
                            v1.x * v2.z - v1.z * v2.x,
                            v1.x * v2.y - v1.y * v2.x);
    }
}
