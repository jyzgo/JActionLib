# MTActionLib
A action lib for unity 

##How to use
```
using MTUnity.Actions;
```
##example:
 ###Move a cube(gameObject) to posA in 2s
 ```
  cube.RunActions(new MTMoveTo(2f,posA));
  ```
###Move cube to posA then to posB
  ```
  cube.RunActions(new MTMoveTo(2f,posA),new MTMoveTo(2f,posB));
  ```
  ###Sequence move, Move cube to posA then to posB
  ```
  cube.RunActions(new MTMoveTo(2f,posA),new MTMoveTo(2f,posB));
  ```
  ### Move a cube to posA, at the same time, scale it to 2times bigger
  
  ```
  cube.RunActions(new MTSpawn(new MTMoveTo(1f,posA),new MTScaleTo(new Vector3(2f,2f,2f)));
  ```
