using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

class unityFire : MonoBehaviour 
{
	public static void moveByItem(GameObject item,Vector3 pos)
	{
        //也可以写成transform.Translate(Vector3 * Speed);
        item.transform.Translate(pos);
	}

    public static void simpleMoveItem(GameObject item, float time, float speed, Vector3 angle = default(Vector3))
    {
        item.GetComponent<SC>().moveTime(time, speed, angle);
    }

    public static void simpleMoveTargetItem(GameObject item, float time, Vector3 target)
    {
        item.GetComponent<SC>().moveTimeTarget(time, target);
    }

    public static void simpleRotateItem(GameObject item,float time,Vector3 rotateSpeed)
    {
        item.GetComponent<SC>().rotateTime(time, rotateSpeed);
    }

    public static void simpleRotateTargetItem(GameObject item, float time, Vector3 rotateTarget)
    {
        item.GetComponent<SC>().rotateTimeTarget(time, rotateTarget);
    }

    public static GameObject addItem(string objname,Vector3 pos,Vector3 angle=default(Vector3))
	{
		GameObject itemp = Resources.Load<GameObject> (objname);
		Quaternion qangle;
		if (angle == default(Vector3))
				qangle = itemp.transform.rotation;
		else
				qangle = calu.Vector3ToQuaternion(angle);
		return Instantiate (itemp, pos, qangle);
	}

	public static void deleteItem(GameObject item)
	{
		Destroy (item);
	}

	public static Vector3 getItemPos(GameObject item)
	{
		return item.transform.position;
	}

    public static void setItemPos(GameObject item, Vector3 pos)
    {
        item.transform.position = pos;
    }

    public static Vector3 getItemAngle(GameObject item) //返回方向向量
	{
	    Quaternion q=item.transform.rotation;
        Vector3 result = calu.QuaternionToVector3(q);
      
        return result; 
    }

	public static void rotateByItem(GameObject item,Vector3 angle) //直接传旋转角
	{
		item.transform.Rotate(angle,Space.Self);
	}

	public static void addItemForce(GameObject item,float power,Vector3 angle) //一般angle传up right forward或者基于此的变换
	{
		Rigidbody rb = item.GetComponent<Rigidbody> ();
		Vector3 pos = item.transform.TransformDirection(angle);
		rb.AddForce(pos * power);
	}

	public static void setItemVelocity(GameObject item,float v,Vector3 angle)
	{
		Rigidbody rb = item.GetComponent<Rigidbody> ();
		rb.velocity = angle * v;
	}

	public static void addItemVelocity(GameObject item,float v,Vector3 angle)
	{
		Rigidbody rb = item.GetComponent<Rigidbody> ();
		rb.velocity += angle * v;
	}

	public static GameObject findItem(string itemName)
	{
		return GameObject.Find(itemName);
	}

	public static void exit()
	{
		Application.Quit();
	}

	public static void changeScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}

	public static void setCameraDepth(string cameraName,int depth)
	{
		GameObject item = unityFire.findItem (cameraName);
		Camera c = item.GetComponent<Camera> ();
		c.depth = depth;
	}

    public static Vector3 getMousePos()
    {
        return Input.mousePosition;
    }

    public static Vector3 toWorldPos(Vector3 mousePos)
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        return hit.point;
    }

    public static GameObject getRayItem(Vector3 pos)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
            return hit.collider.gameObject;
        else
            return null;
    }

    public static Vector3 lookAt(GameObject itemA, GameObject itemB) //B撞A，B是参数A是this
    {
        Vector3 result = getItemPos(itemA) - getItemPos(itemB);
        result.Normalize();
        return result;
    }

    public static void setItemScale(GameObject item, float x = 0, float y = 0, float z = 0)
    {
        item.transform.localScale += new Vector3(x, y, z);
    }
}
