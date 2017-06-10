using System;

using UnityEngine;

namespace JUnity.Actions
{
    public class JCallFuncND : JCallFuncN
    {
        public Action<GameObject, object> CallFunctionND { get; private set; }
        public object Data { get; private set; }


        #region Constructors

        public JCallFuncND(Action<GameObject, object> selector, object d) : base()
        {
            Data = d;
            CallFunctionND = selector;
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new JCallFuncNDState (this, target);

        }
    }

    public class JCallFuncNDState : JCallFuncState
    {
        protected Action<GameObject, object> CallFunctionND { get; set; }
        protected object Data { get; set; }

        public JCallFuncNDState (JCallFuncND action, GameObject target)
            : base(action, target)
        {   
            CallFunctionND = action.CallFunctionND;
            Data = action.Data;
        }

        public override void Execute()
        {
            if (null != CallFunctionND)
            {
                CallFunctionND(Target, Data);
				CallFunctionND = null;
            }
        }
    }
}