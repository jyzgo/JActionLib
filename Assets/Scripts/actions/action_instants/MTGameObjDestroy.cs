using System;
using System.Collections.Generic;

using UnityEngine;

namespace JUnity.Actions
{
    public class MTGameObjDestroy : MTActionInstant
	{
		#region Constructors
		float _delayTime = 0f;
		bool checkChildInPool = false;
        public MTGameObjDestroy (float delayTime = 0f, bool checkChildInPool = false)
		{
			this.checkChildInPool = checkChildInPool;
			_delayTime = delayTime;
		}
		
		#endregion Constructors
		
		protected internal override JActionState StartAction(GameObject target)
		{
            return new MTGameObjDestroyState (this, target,_delayTime);
			
		}
		
		public override JFiniteTimeAction Reverse ()
		{
            return new MTGameObjDestroy (_delayTime, checkChildInPool);
		}
	}
	
    public class MTGameObjDestroyState : MTActionInstantState
	{
		float _delayTime = 0f;
		bool _checkChildInPool = false;

        public MTGameObjDestroyState (MTGameObjDestroy action, GameObject target,float delayTime = 0f, bool checkChildInPool = false)
			: base (action, target)
		{   
			_delayTime = delayTime;
			_checkChildInPool = checkChildInPool;
		}
		
		public override void Update (float time)
		{
			if (Target && Target.gameObject) 
			{
                GameObject.Destroy(Target);
			}
		}
		
	}
	
}