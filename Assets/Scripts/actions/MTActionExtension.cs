﻿using UnityEngine;
using System.Collections;

namespace MTUnityAction{
public static class MTActionExtension  {


    #region Actions

	public static bool IsRunning(this GameObject target)
	{
		bool isActive = false;
		if (target && target.gameObject && target.gameObject.activeInHierarchy) {
			isActive = true;
		}
		return isActive;
	}

    public static void AddAction(this GameObject target,MTAction action, bool paused = false)
    {
		if (MTActionManager.instance != null)
				MTActionManager.instance.AddAction(action, target, paused);

    }

	public static void AddActions(this GameObject target,bool paused, params MTFiniteTimeAction[] actions)
    {
		if (MTActionManager.instance != null)
				MTActionManager.instance.AddAction(new MTSequence(actions), target, paused);

    }

	public static MTActionState Repeat(this GameObject target, uint times, params MTFiniteTimeAction[] actions)
    {
			return target.RunAction (new MTRepeat (new MTSequence(actions), times));
    }

	public static MTActionState Repeat (this GameObject target, uint times, MTFiniteTimeAction action)
    {
        return  target.RunAction (new MTRepeat (action, times));
    }

	public static MTActionState RepeatForever(this GameObject target, params MTFiniteTimeAction[] actions)
    {
        return target.RunAction(new MTRepeatForever (actions));
    }

	public static MTActionState RepeatForever(this GameObject target, MTFiniteTimeAction action)
    {
        return target.RunAction(new MTRepeatForever (action) { Tag = action.Tag });
    }

	public static MTActionState RunAction(this MonoBehaviour target, MTAction action)
	{
		Debug.Assert(action != null, "Argument must be non-nil");

		GameObject curObj = target.gameObject;
		return  curObj.RunAction (action);
	}

	public static MTActionState RunAction(this GameObject target, MTAction action)
    {
        Debug.Assert(action != null, "Argument must be non-nil");
		

		return  MTActionManager.instance.AddAction(action, target, !target.IsRunning());
    }

		public static MTActionState RunActions(this MonoBehaviour beh, params MTFiniteTimeAction[] actions)
		{
			GameObject curObj = beh.gameObject;
			return curObj.RunActions (actions);
		}

    public static MTActionState RunActions(this GameObject target, params MTFiniteTimeAction[] actions)
    {
        Debug.Assert(actions != null, "Argument must be non-nil");
		Debug.Assert(actions.Length > 0, "Paremeter: actions has length of zero. At least one action must be set to run.");
		

		var action = actions.Length > 1 ? new MTSequence(actions) : actions[0];

			return MTActionManager.instance.AddAction (action, target, !target.IsRunning());
    }




    public static void StopAllActions(this GameObject target)
    {
        if(MTActionManager.instance != null)
            MTActionManager.instance.RemoveAllActionsFromTarget(target);
    }

		public static void StopAllActions(this MonoBehaviour target)
		{
			target.gameObject.StopAllActions ();
		}

    public static void StopAction(this GameObject target, MTActionState actionState)
    {
        if(MTActionManager.instance != null)
            MTActionManager.instance.RemoveAction(actionState);
    }

		public static void StopAction(this MonoBehaviour target,MTActionState actionState)
		{
			target.gameObject.StopAction (actionState);
		}

	public static void StopAction(this GameObject target, int tag)
    {
        Debug.Assert(tag != -1, "Invalid tag");
			MTActionManager.instance.RemoveAction(tag, target);
    }
		public static void StopAction(this MonoBehaviour target,int tag)
		{
			target.gameObject.StopAction (tag);
		}

		public static MTAction GetAction(this GameObject target, int tag)
    {
        Debug.Assert(tag != -1, "Invalid tag");
			return MTActionManager.instance.GetAction(tag, target);
    }

    public static MTActionState GetActionState(this GameObject target, int tag)
    {
        Debug.Assert(tag != -1, "Invalid tag");
        return MTActionManager.instance.GetActionState(tag, target);
    }

    #endregion Actions

	public static bool getVisible(this GameObject target)
	{
		if (target) 
		{
			var render = target.GetComponent<Renderer> ();
			if (render && render.enabled == true) {
				return true;
			} 
			
		}

		return false;
	}

	public static void setVisible(this GameObject target ,bool curVis)
	{
		if (target) 
		{
			var render = target.GetComponent<Renderer> ();
			if (render) {
				render.enabled = curVis;
			}

		}
	}

	public static float getOpacity(this GameObject target)
	{
		if (target) 
		{
			var render = target.GetComponent<Renderer>();
			if (render && render.material) 
			{
				return render.material.color.a;
			}
			
		}
		return 0f;
	}

	public static void setOpacity(this GameObject target,float curA)
	{
		if (target) 
		{
			var render = target.GetComponent<Renderer>();
			if (render && render.material) 
			{
				var originColor = render.material.color;
					var newColor = new Color (originColor.r,originColor.g,originColor.b,curA);
			
					target.GetComponent<Renderer> ().material.color = newColor;
			}
			
		}
	}

	public static Color getColor(this GameObject target)
	{

		if (target) 
		{
			var render = target.GetComponent<Renderer>();
			if (render && render.material) 
			{
				var originColor = render.material.color;
				return originColor;
			}
			
		}

		return new Color();
	}

	public static void setColor(this GameObject target, Color curColor)
	{
		if (target) 
		{
			var render = target.GetComponent<Renderer>();
			if (render && render.material) 
			{
				render.material.color = curColor;
			}
			
		}
	}

}

}