using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

class unityFire : MonoBehaviour 
{
		public static void moveByItem(GameObject item,Vector3 pos)
		{
				item.transform.Translate(pos);
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

		public static Vector3 getItemAngle(GameObject item)
		{
				Quaternion q=item.transform.rotation;
				return calu.QuaternionToVector3(q);
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
}
