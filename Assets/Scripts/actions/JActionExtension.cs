using UnityEngine;
using System.Collections;
using UnityEngine.UI;


namespace JUnity.Actions {
	public static class JActionExtension  {
		
		
		#region Actions
		
		public static bool IsRunning(this GameObject target)
		{
			bool isActive = false;
			if (target && target.gameObject && target.gameObject.activeInHierarchy) {
				isActive = true;
			}
			return isActive;
		}
		
		public static void AddAction(this GameObject target,JAction action, bool paused = false)
		{
			if (JActionManager.Instance != null)
				JActionManager.Instance.AddAction(action, target, paused);
			
		}
		
		public static void AddActions(this GameObject target,bool paused, params JFiniteTimeAction[] actions)
		{
			if (JActionManager.Instance != null)
				JActionManager.Instance.AddAction(new JSequence(actions), target, paused);
			
		}
		
		public static JActionState Repeat(this GameObject target, uint times, params JFiniteTimeAction[] actions)
		{
			return target.RunAction (new JRepeat (new JSequence(actions), times));
		}
		
		public static JActionState Repeat (this GameObject target, uint times, JFiniteTimeAction action)
		{
			return  target.RunAction (new JRepeat (action, times));
		}
		
		public static JActionState RepeatForever(this GameObject target, params JFiniteTimeAction[] actions)
		{
			return target.RunAction(new JRepeatForever (actions));
		}
		
		public static JActionState RepeatForever(this GameObject target, JFiniteTimeAction action)
		{
			return target.RunAction(new JRepeatForever (action) { Tag = action.Tag });
		}
		
		public static JActionState RunAction(this MonoBehaviour target, JAction action)
		{
			Debug.Assert(action != null, "Argument must be non-nil");
			
			GameObject curObj = target.gameObject;
			return  curObj.RunAction (action);
		}
		
		public static JActionState RunAction(this GameObject target, JAction action)
		{
			Debug.Assert(action != null, "Argument must be non-nil");
			
			
			return  JActionManager.Instance.AddAction(action, target, !target.IsRunning());
		}
		
		public static JActionState RunActions(this MonoBehaviour beh, params JFiniteTimeAction[] actions)
		{
			if(beh == null || beh.gameObject == null)
			{
				return null;
			}
			GameObject curObj = beh.gameObject;
			return curObj.RunActions (actions);
		}
		
		public static JActionState RunActions(this GameObject target, params JFiniteTimeAction[] actions)
		{
			Debug.Assert(actions != null, "Argument must be non-nil");
			Debug.Assert(actions.Length > 0, "Paremeter: actions has length of zero. At least one action must be set to run.");
			
			
			var action = actions.Length > 1 ? new JSequence(actions) : actions[0];
			if(JActionManager.Instance == null)
			{
				return null;
			}
			return JActionManager.Instance.AddAction (action, target, !target.IsRunning());
		}

		public static float GetParticleStartSize(this GameObject target)
		{
			var particleSys = target.GetComponent<ParticleSystem>();
			if(particleSys != null)
			{
				return particleSys.startSize ;
			}

			int childCount = target.transform.childCount;
			for (int i = 0; i < childCount; ++i) {
				var curSize = target.transform.GetChild(i).gameObject.GetParticleStartSize();
				if(curSize  > 0f)
				{
					return curSize;
				}
			}

			return -1f;
		}

		public static void SetParticleSize(this GameObject target,float size)
		{
			var particleSys = target.GetComponent<ParticleSystem>();
			if(particleSys != null)
			{
				particleSys.startSize = size;
			}
			int childCount = target.transform.childCount;
			for (int i = 0; i < childCount; ++i) {
				target.transform.GetChild(i).gameObject.SetParticleSize(size);
			}
		}
		
		public static void Hide(this GameObject target)
		{
			
			float curA = 0f;
			
			var render = target.GetComponent<Renderer>();
			if (render != null)// && render.material.HasProperty("_Color")) 
			{
				if(render is SpriteRenderer)
				{
					SpriteRenderer curRender = render as SpriteRenderer;
					
					Color originColor = curRender.color;
					var newColor = new Color (originColor.r,originColor.g,originColor.b,curA);
					curRender.color = newColor;
					
					
				}
				else if (render.material != null && render.material.HasProperty("_Color"))
				{
					var originColor = render.material.color;
					var newColor = new Color (originColor.r,originColor.g,originColor.b,curA);
					render.material.color = newColor;
					
				}
				
				
			}
			
			int childCount = target.transform.childCount;
			for (int i = 0; i < childCount; ++i) {
				target.transform.GetChild(i).gameObject.Hide();
			}
			
		}
		
		
		
		public static void StopAllActions(this GameObject target)
		{
			if(JActionManager.Instance != null)
				JActionManager.Instance.RemoveAllActionsFroJarget(target);
		}
		
		public static void StopAllActions(this MonoBehaviour target)
		{
			target.gameObject.StopAllActions ();
		}
		
		public static void StopAction(this GameObject target, JActionState actionState)
		{
			if(JActionManager.Instance != null)
				JActionManager.Instance.RemoveAction(actionState);
		}
		
		public static void StopAction(this MonoBehaviour target,JActionState actionState)
		{
			target.gameObject.StopAction (actionState);
		}
		
		public static void StopAction(this GameObject target, int tag)
		{
			Debug.Assert(tag != -1, "Invalid tag");
			if(JActionManager.Instance == null)
				return;
			JActionManager.Instance.RemoveAction(tag, target);
		}
		public static void StopAction(this MonoBehaviour target,int tag)
		{
			target.gameObject.StopAction (tag);
		}
		
		public static JAction GetAction(this GameObject target, int tag)
		{
			Debug.Assert(tag != -1, "Invalid tag");
			return JActionManager.Instance.GetAction(tag, target);
		}
		
		public static JActionState GetActionState(this GameObject target, int tag)
		{
			Debug.Assert(tag != -1, "Invalid tag");
			return JActionManager.Instance.GetActionState(tag, target);
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
				var convasGroup = target.GetComponent<CanvasGroup> ();
				if (convasGroup != null) {
					
					return convasGroup.alpha ;
				}
				
				
				var render = target.GetComponent<Renderer>();
				if (render != null)// && render.material.HasProperty("_Color")) 
				{
					if(render is SpriteRenderer)
					{
						SpriteRenderer curRender = render as SpriteRenderer;
						
						return curRender.color.a;
						
						
					}
					else if (render.material != null && render.material.HasProperty("_Color"))
					{
						var originColor = render.material.color;
						return originColor.a;
						
					}
					
					
				}
				
			}
			return 0f;
		}
		
		public static void setOpacity(this Transform curTransform,float curA)
		{
			var target = curTransform.gameObject;
			target.setOpacity (curA);
		}
		
		public static float getOpacity(this Transform curTransform)
		{
			GameObject target = curTransform.gameObject;
			return target.getOpacity ();
		}

		public static void setTextOpacity(this GameObject obj,float curA)
		{
			Text t = obj.GetComponent<Text>();
			t.setTextOpacity(curA);
		}

		public static void setTextOpacity(this Text target,float curA)
		{	
			
			if(target != null)
			{
				Color originalColor = target.color;
				target.color = new Color(originalColor.r,originalColor.g,originalColor.b,curA);
			}
		}

		public static float getOpacity(this Text curT)
		{
			if(curT != null)
			{
				return curT.color.a;
			}
			return 0f;
		}

		
		
		public static void setOpacity(this GameObject target,float curA)
		{
			if (target != null) 
			{
				
				
				var convasGroup = target.GetComponent<CanvasGroup> ();
				if (convasGroup != null) {
					convasGroup.alpha = curA;
					return;
				}
				


				var render = target.GetComponent<Renderer>();
				if (render != null)// && render.material.HasProperty("_Color")) 
				{
					if(render is SpriteRenderer)
					{
						SpriteRenderer curRender = render as SpriteRenderer;
						
						Color originColor = curRender.color;
						var newColor = new Color (originColor.r,originColor.g,originColor.b,curA);
						curRender.color = newColor;
						
						
					}
					else if (render.material != null && render.material.HasProperty("_Color"))
					{
						var originColor = render.material.color;
						var newColor = new Color (originColor.r,originColor.g,originColor.b,curA);
						render.material.color = newColor;
						
					}
					
					
				}
				
				int childCount = target.transform.childCount;
				for (int i = 0; i < childCount; ++i) {
					target.transform.GetChild(i).gameObject.setOpacity(curA);
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