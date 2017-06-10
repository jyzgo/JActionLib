using UnityEngine;

namespace JUnity.Actions
{
    public class JJumpTo : JJumpBy
    {
        #region Constructors

        public JJumpTo (float duration, Vector3 position, float height, uint jumps) 
            : base (duration, position, height, jumps)
        {
        }

        #endregion Constructors

        protected internal override JActionState StartAction(GameObject target)
        {
            return new JJumpToState (this, target);

        }

    }

    public class JJumpToState : JJumpByState
    {

        public JJumpToState (JJumpBy action, GameObject target)
            : base (action, target)
        { 
			Delta = new Vector3 (Delta.x - StartPosition.x, Delta.y - StartPosition.y,Delta.z - StartPosition.z);
        }
    }

}