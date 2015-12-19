using UnityEngine;
using System.Collections;
using MTUnity.Actions;

public class TestAction : MonoBehaviour {

	// Use this for initialization
	void Start () {
		MTActionManager.instance.init ();
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
			var moveBy = new MTMoveBy(1,new Vector3(0,10,0));
			this.RunAction (moveBy);
		}

		if (GUILayout.Button("FadeOut")) 
		{
			resetObject();
			 var fadeOut = new MTFadeOut(2);
			 this.RunActions(fadeOut);
		}

		if (GUILayout.Button ("FadeIn")) {
			resetObject ();
			var fadeIn = new MTFadeIn (2);
			this.RunAction (fadeIn);
		}

		if (GUILayout.Button("ScaleTo")) 
		{
			resetObject();
			var scaleTo = new MTScaleTo(2,2,3,4);
			this.RunActions(scaleTo);
			
		}

		if(GUILayout.Button("JumpTo")){
			resetObject();
			var jumpTo = new MTJumpTo(2,new Vector3(0,0,0),2,3);
			this.RunAction(jumpTo);
		}

		if (GUILayout.Button ("Tint to")) {
			resetObject ();

			var TintTo = new MTTintTo (3f, 0.2f, 1f, 3f);

			this.RunAction (TintTo);

		}

//		if (GUILayout.Button ("RotateTo")) {
//			resetObject ();
////			var roTo = new MTRotateTo (2, 3,2,3);
////			this.RunAction (roTo);
//
//		}

		if (GUILayout.Button ("Sequence")) {
			resetObject ();
			var moveTo = new MTMoveTo (2, new Vector3 (10, 10, 10));
			var moveBy = new MTMoveBy(1,new Vector3(-1,1,-3));
			var jumpTo = new MTJumpTo(2,new Vector3(0,0,0),2,3);
			var TintTo = new MTTintTo (3f, 0.2f, 1f, 3f);

			this.RunActions(moveTo,moveBy,jumpTo,TintTo);

		}

		if (GUILayout.Button ("Spawn")) {
			resetObject ();

			var jumpTo = new MTJumpTo(2,new Vector3(0,0,0),2,3);
			var TintTo = new MTTintTo (3f, 0.2f, 1f, 3f);
//			var roTo = new MTRotateTo (2, 3,2,3);
			var spawn = new MTSpawn(jumpTo,TintTo);

			this.RunActions(spawn);

		}



		if (GUILayout.Button("Hide")) 
		{
			resetObject();
			var hide = new MTHide();
			this.RunActions(hide);
		}

		if (GUILayout.Button("Show")) 
		{
			resetObject();
			var show = new MTShow();
			this.RunActions(show);
		}


	}

	void resetObject()
	{
		this.transform.position = new Vector3 (1, 2, 2);
		this.StopAllActions ();
	}
		
}
