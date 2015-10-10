using UnityEngine;

namespace MTUnity.Actions
{
    public class MTPlace : MTActionInstant
    {
        public Vector3 Position { get; private set; }


        #region Constructors

        public MTPlace (Vector3 pos)
        {
            Position = pos;
        }

        public MTPlace (int posX, int posY , int posZ)
        {
            Position = new Vector3 (posX, posY,posZ);
        }

        #endregion Constructors

        protected internal override MTActionState StartAction(GameObject target)
        {
            return new MTPlaceState (this, target);

        }
    }

    public class MTPlaceState : MTActionInstantState
    {

        public MTPlaceState (MTPlace action, GameObject target)
            : base (action, target)
        { 
			Target.transform.localPosition = action.Position;
        }

    }

}