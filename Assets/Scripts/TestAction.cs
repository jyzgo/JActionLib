using UnityEngine;
using System.Collections;
using JUnity.Actions;

public class TestAction : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	bool canMove = false;
	void Update()
	{
		if (canMove) {
		

		}
	}
	


	void OnGUI()
	{



		if (GUILayout.Button ("MoveTo")) {
			resetObject ();
			var moveBy = new JMoveBy(1,new Vector3(0,10,0));
			this.RunAction (moveBy);
		}

		if (GUILayout.Button("FadeOut")) 
		{
			resetObject();
			 var fadeOut = new JFadeOut(2);
			 this.RunActions(fadeOut);
		}

		if (GUILayout.Button ("FadeIn")) {
			resetObject ();
			var fadeIn = new JFadeIn (2);
			this.RunAction (fadeIn);
		}

		if (GUILayout.Button("ScaleTo")) 
		{
			resetObject();
			var scaleTo = new JScaleTo(2,2,3,4);
			this.RunActions(scaleTo);
			
		}

		if(GUILayout.Button("JumpTo")){
			resetObject();
			var jumpTo = new JJumpTo(2,new Vector3(0,0,0),2,3);
			this.RunAction(jumpTo);
		}

		if (GUILayout.Button ("Tint to")) {
			resetObject ();

			var TintTo = new JTintTo (3f, 0.2f, 1f, 3f);

			this.RunAction (TintTo);

		}

//		if (GUILayout.Button ("RotateTo")) {
//			resetObject ();
////			var roTo = new JRotateTo (2, 3,2,3);
////			this.RunAction (roTo);
//
//		}

		if (GUILayout.Button ("Sequence")) {
			resetObject ();
			var moveTo = new JMoveTo (2, new Vector3 (10, 10, 10));
			var moveBy = new JMoveBy(1,new Vector3(-1,1,-3));
			var jumpTo = new JJumpTo(2,new Vector3(0,0,0),2,3);
			var TintTo = new JTintTo (3f, 0.2f, 1f, 3f);

			this.RunActions(moveTo,moveBy,jumpTo,TintTo);

		}

		if (GUILayout.Button ("Spawn")) {
			resetObject ();

			var jumpTo = new JJumpTo(2,new Vector3(0,0,0),2,3);
			var TintTo = new JTintTo (3f, 0.2f, 1f, 3f);
//			var roTo = new JRotateTo (2, 3,2,3);
			var spawn = new JSpawn(jumpTo,TintTo);

			this.RunActions(spawn);

		}



		if (GUILayout.Button("Hide")) 
		{
			resetObject();
			var hide = new JHide();
			this.RunActions(hide);
		}

		if (GUILayout.Button("Show")) 
		{
			resetObject();
			var show = new JShow();
			this.RunActions(show);
		}


	}

	void resetObject()
	{
		this.transform.position = new Vector3 (1, 2, 2);
		this.StopAllActions ();
	}
		
}
