Unity-Fire
==========
Unity3D Package of Life-Fire style. You can use it to easily call Unity3d features.

API list
--------
* `GameObject addItem(string objname,Vector3 pos,Vector3 angleDirectionalVectors=default)` Create an object.
* `void deleteItem(GameObject item)` Delete an object.
* `void moveByItem(GameObject item,Vector3 pos)` Move relative to the object's original pos.
* `Vector3 getItemPos(GameObject item)` Get object pos.
* `Vector3 getItemAngle(GameObject item)` Get object current direction.
* `void rotateByItem(GameObject item,Vector3 angleDirectionalVectors)` Rotate relative to the object's original current direction vector.
* `void addItemForce(GameObject item,float power,Vector3 angleDirectionalVectors)` Exert a force on an object (Instantaneous).
* `void setItemVelocity(GameObject item,float v,Vector3 angleDirectionalVectors)` Set the speed of object.
* `void addItemVelocity(GameObject item,float v,Vector3 angle)` Add a speed to object (synthesized on previous speed basis).
* `GameObject findItem(string itemName)` Find object reference by name.
* `void exit()` Exit program.
* `void changeScene(string sceneName)` Change scene.
* `void setCameraDepth(string cameraName,int depth)` Set the level at which the camera image is displayed on the screen.
* `void setItemScale(GameObject item, float x = 0, float y = 0, float z = 0)` Zoom an object.
