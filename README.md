# MTActionLib
A action lib for unity 


#### What is the most elegant way to move/scale/fade/... an gameObject?
#### Normally in unity, below is what we normally do.
```
     public float speed;
     void Update() {
         float step = speed * Time.deltaTime;
         transform.position = Vector3.MoveTowards(transform.position, target.position, step);
     }
```
#### What if you want to move an gameObject go through an list of postion? Below is an example how to do it.

```
     public Vector3[] positions;
     public Transform ObjectToMove;
     public float MoveSpeed = 8;
     Coroutine MoveIE;
 
     void Start()
     {
         StartCoroutine(moveObject());
 
     }
 
     IEnumerator moveObject()
     {
         for (int i = 0; i < positions.Length; i++)
         {
             MoveIE = StartCoroutine(Moving(i));
             yield return MoveIE;
         }
     }
 
     IEnumerator Moving(int currentPosition)
     {
         while (ObjectToMove.transform.position != positions[currentPosition])
         {
             ObjectToMove.transform.position = Vector3.MoveTowards(ObjectToMove.transform.position, positions[currentPosition] , MoveSpeed * Time.deltaTime);
             yield return null;
         }
  
     }
```

#### What if you want lerp the color of during above action? 

```
//some mess code

```
#### MTActionLib use command pattern to simplify above movement, you don't need create extra script to deal with the actions,you only need to do something like this.

```
gameObject.RunActions(action1,action2,action3);
```
#### The action above could be an movement, an transformation, an color changing, an fade process, an callback function or even any number combination of all actions


## How to use
```
using MTUnity.Actions;
```

## example:
 ### Move a cube(gameObject) to posA in 2s
 ```
  cube.RunActions(new MTMoveTo(2f,posA));
  ```
### Move cube to posA then to posB
  ```
  cube.RunActions(new MTMoveTo(2f,posA),new MTMoveTo(2f,posB));
  ```
  ### Sequence move, Move cube to posA then to posB
  ```
  cube.RunActions(new MTMoveTo(2f,posA),new MTMoveTo(2f,posB));
  ```
  ### Simultaneously Action Move a cube to posA, at the same time, scale it to 2times bigger
  
  ```
  cube.RunActions(new MTSpawn(new MTMoveTo(1f,posA),new MTScaleTo(new Vector3(2f,2f,2f)));
  ```
