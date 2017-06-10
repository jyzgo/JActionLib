using UnityEngine;

namespace JUnity.Actions
{
    public class JPlace : JActionInstant
    {
        public Vector3 Position { get; private set; }


        #region Constructors

		bool _isWorld = false;
		public JPlace (Vector3 pos,bool isWorld = false)
        {
            Position = pos;
			_isWorld = isWorld;
        }

        public JPlace (int posX, int posY , int posZ)
        {
            Position = new Vector3 (posX, posY,posZ);
        }

        #endregion Constructors

        protected internal override JActionState StartAction(GameObject target)
        {
			return new JPlaceState (this, target,_isWorld);

        }
    }

    public class JPlaceState : JActionInstantState
    {

		public JPlaceState (JPlace action, GameObject target,bool isWorld)
            : base (action, target)
        { 
			if(isWorld)
			{
				Target.transform.position = action.Position;
			}else
			{
				Target.transform.localPosition = action.Position;
			}
        }

    }

}