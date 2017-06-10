using UnityEngine;

namespace JUnity.Actions
{
    public class JUISizeChangeTo : JFiniteTimeAction
    {
        protected Vector2 Endsize;

        #region Constructors
        public JUISizeChangeTo (float duration, Vector2 size) : base (duration)
        {
            Endsize = size;
        }
        #endregion Constructors

        public Vector2 SizeEnd {
            get { return Endsize; }
        }

        protected internal override JActionState StartAction(GameObject target)
        {
            return new JUISizeChangeToState (this, target);
        }

        public override JFiniteTimeAction Reverse(){
            Debug.LogError("not support");
            //return new JUISizeChangeTo(Duration, new Vector2(- );
            return null;
        }
    }

    public class JUISizeChangeToState : JFiniteTimeActionState
	{
        RectTransform trans;
        protected Vector2 SizeDelta;
        protected Vector2 EndSize;
        protected Vector2 StartSize;
        public Vector2 PreviousSize {
            get;
            protected set;
        }

        public JUISizeChangeToState (JUISizeChangeTo action, GameObject target)
            : base (action, target)
        { 
            if(target == null)
            {
                return;
            }
            trans = target.GetComponent<RectTransform>();
            var targetUICurSize = trans.sizeDelta;
            SizeDelta = action.SizeEnd - targetUICurSize;
            PreviousSize = StartSize = targetUICurSize;
        }

        public override void Update (float time)
        {
            if (Target != null)
            {
				Vector2 newSize = StartSize + SizeDelta * time;
                PreviousSize = newSize;
                trans.sizeDelta = newSize;
            }
        }

    }

}