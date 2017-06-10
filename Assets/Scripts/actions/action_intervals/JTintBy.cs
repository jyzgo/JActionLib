using UnityEngine;

namespace JUnity.Actions
{

    public class JTintBy : JFiniteTimeAction
    {
        public float DeltaB { get; private set; }
        public float DeltaG { get; private set; }
        public float DeltaR { get; private set; }


        #region Constructors

        public JTintBy (float duration, float deltaRed, float deltaGreen, float deltaBlue) : base (duration)
        {
            DeltaR = deltaRed;
            DeltaG = deltaGreen;
            DeltaB = deltaBlue;
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new JTintByState (this, target);
        }

        public override JFiniteTimeAction Reverse ()
        {
            return new JTintBy (Duration, (float)-DeltaR, (float)-DeltaG, (float)-DeltaB);
        }
    }


    public class JTintByState : JFiniteTimeActionState
    {
        protected float DeltaB { get; set; }

        protected float DeltaG { get; set; }

        protected float DeltaR { get; set; }

        protected float FromB { get; set; }

        protected float FromG { get; set; }

        protected float FromR { get; set; }

        public JTintByState (JTintBy action, GameObject target)
            : base (action, target)
        {   
            DeltaB = action.DeltaB;
            DeltaG = action.DeltaG;
            DeltaR = action.DeltaR;

            var protocol = target;
            if (protocol != null)
            {
				var color = protocol.getColor();
                FromR = color.r;
                FromG = color.g;
                FromB = color.b;
            }
        }

        public override void Update (float time)
        {
            var protocol = Target;
            if (protocol != null)
            {
				var newColor = new Color ((FromR + DeltaR * time),
                    (FromG + DeltaG * time),
                    (FromB + DeltaB * time));


				protocol.setColor (newColor); 
            }
        }

    }

}