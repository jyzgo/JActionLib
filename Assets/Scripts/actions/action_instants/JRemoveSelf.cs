using System;
using System.Collections.Generic;

using UnityEngine;

namespace JUnity.Actions
{
    public class JRemoveSelf : JActionInstant
    {
        public bool IsNeedCleanUp { get; private set; }

        #region Constructors

        public JRemoveSelf ()
            : this (true)
        {
        }

        public JRemoveSelf (bool isNeedCleanUp)
        {
            IsNeedCleanUp = isNeedCleanUp;
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new JRemoveSelfState (this, target);

        }


        public override JFiniteTimeAction Reverse ()
        {
            return new JRemoveSelf (IsNeedCleanUp);
        }
    }

    public class JRemoveSelfState : JActionInstantState
    {
        protected bool IsNeedCleanUp { get; set; }

        public JRemoveSelfState (JRemoveSelf action, GameObject target)
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