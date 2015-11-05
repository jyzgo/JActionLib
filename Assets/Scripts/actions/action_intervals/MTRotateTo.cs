using System;

using UnityEngine;

namespace MTUnity.Actions
{
    public class MTRotateTo : MTFiniteTimeAction
    {

        #region Constructors
    
        public float Duration{get;private set;}
        public Vector3 TargetAngle{get;private set;}

        public MTRotateTo(float duration,Vector3 toAngle):base(duration)
        {
            Duration = duration;
            TargetAngle = toAngle;
        }

        #endregion Constructors

        protected internal override MTActionState StartAction(GameObject target)
        {
            return new MTRotateToState (this, target);
        }

        public override MTFiniteTimeAction Reverse()
        {
            throw new NotImplementedException();
        }
    }


    public class MTRotateToState : MTFiniteTimeActionState
    {


        public MTRotateToState (MTRotateTo action, GameObject target)
            : base (action, target)
        { 

            FromAngle = Target.transform.localRotation;
            ToAngle = Quaternion.Euler( action.TargetAngle);
            InTime = action.Duration;
        }

        Quaternion FromAngle;
        Quaternion ToAngle;
        float InTime;
        float curTime = 0f;

        public override void Update (float time)
        {

            Target.transform.localRotation = Quaternion.Lerp(FromAngle,ToAngle,curTime/InTime);

            curTime += Time.deltaTime;

        }

    }
}