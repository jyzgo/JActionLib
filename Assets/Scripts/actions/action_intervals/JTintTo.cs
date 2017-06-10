using UnityEngine;

namespace JUnity.Actions
{
    public class JTintTo : JFiniteTimeAction
    {
        public Color ColorTo { get; private set; }


        #region Constructors

		public JTintTo (float duration, float red, float green, float blue) : base (duration)
        {
            ColorTo = new Color (red, green, blue);
        }

        #endregion Constructors

        public override JFiniteTimeAction Reverse()
        {
            throw new System.NotImplementedException ();
        }

        protected internal override JActionState StartAction(GameObject target)
        {
            return new JTintToState (this, target);
        }
    }

    public class JTintToState : JFiniteTimeActionState
    {
        protected Color ColorFrom { get; set; }

        protected Color ColorTo { get; set; }

        public JTintToState (JTintTo action, GameObject target)
            : base (action, target)
        {   
            ColorTo = action.ColorTo;
            var protocol = Target;
            if (protocol != null)
            {
				ColorFrom = protocol.getColor();
            }
        }

        public override void Update (float time)
        {
            var protocol = Target;
            if (protocol != null)
            {
				
				protocol.GetComponent<Renderer> ().material.color = new Color ((ColorFrom.r + (ColorTo.r - ColorFrom.r) * time),
                    (ColorFrom.g + (ColorTo.g - ColorFrom.g) * time),
                    (ColorFrom.b + (ColorTo.b - ColorFrom.b) * time));
            }
        }

    }

}