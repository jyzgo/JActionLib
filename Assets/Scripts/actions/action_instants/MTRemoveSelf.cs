using System;
using System.Collections.Generic;

using UnityEngine;

namespace JUnity.Actions
{
    public class MTRemoveSelf : MTActionInstant
    {
        public bool IsNeedCleanUp { get; private set; }

        #region Constructors

        public MTRemoveSelf ()
            : this (true)
        {
        }

        public MTRemoveSelf (bool isNeedCleanUp)
        {
            IsNeedCleanUp = isNeedCleanUp;
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new MTRemoveSelfState (this, target);

        }


        public override JFiniteTimeAction Reverse ()
        {
            return new MTRemoveSelf (IsNeedCleanUp);
        }
    }

    public class MTRemoveSelfState : MTActionInstantState
    {
        protected bool IsNeedCleanUp { get; set; }

        public MTRemoveSelfState (MTRemoveSelf action, GameObject target)
            : base (action, target)
        {   
            IsNeedCleanUp = action.IsNeedCleanUp;
        }

        public override void Update (float time)
        {
            if (Target && Target.gameObject) 
            {
                UnityEngine.Object.Destroy(Target.gameObject);
            }
        }

    }

}