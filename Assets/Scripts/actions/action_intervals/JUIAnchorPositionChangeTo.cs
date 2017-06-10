using UnityEngine;

namespace JUnity.Actions
{
    public class JUIAnchorPositionChangeTo : JFiniteTimeAction
    {
        protected Vector2 EndPosition;

        #region Constructors
        public JUIAnchorPositionChangeTo (float duration, Vector2 position) : base (duration)
        {
            EndPosition = position;
        }
        #endregion Constructors

        public Vector2 PositionEnd {
            get { return EndPosition; }
        }

        protected internal override JActionState StartAction(GameObject target)
        {
            return new JUIAnchorPositionChangeToState (this, target);
        }

        public override JFiniteTimeAction Reverse(){
            Debug.LogError("not support");
            //return new JUISizeChangeTo(Duration, new Vector2(- );
            return null;
        }
    }

    public class JUIAnchorPositionChangeToState : JFiniteTimeActionState
	{
        RectTransform trans;
        protected Vector2 PositionDelta;
        protected Vector2 EndPosition;
        protected Vector2 StartPosition;
        public Vector2 PreviousPosition {
            get;
            protected set;
        }

        public JUIAnchorPositionChangeToState (JUIAnchorPositionChangeTo action, GameObject target)
            : base (action, target)
        { 
            if(target == null)
            {
                return;
            }
            trans = target.GetComponent<RectTransform>();
            var targetUICurPosition = trans.anchoredPosition;
            PositionDelta = action.PositionEnd - targetUICurPosition;
            PreviousPosition = StartPosition = targetUICurPosition;
        }

        public override void Update (float time)
        {
            if (Target != null)
            {
                Vector2 newSize = StartPosition + PositionDelta * time;
                PreviousPosition = newSize;
                trans.anchoredPosition = newSize;
            }
        }

    }

}