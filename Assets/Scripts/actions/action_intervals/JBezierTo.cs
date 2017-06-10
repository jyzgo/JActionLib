using UnityEngine;

namespace JUnity.Actions
{
    public class JBezierTo : JBezierBy
    {
        #region Constructors

        public JBezierTo (float t, JBezierConfig c)
            : base (t, c)
        {
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new JBezierToState (this, target);

        }

    }

    public class JBezierToState : JBezierByState
    {

        public JBezierToState (JBezierBy action, GameObject target)
            : base (action, target)
        { 
            var config = BezierConfig;

            config.ControlPoint1 -= StartPosition;
            config.ControlPoint2 -= StartPosition;
            config.EndPosition -= StartPosition;

            BezierConfig = config;
        }

    }

}