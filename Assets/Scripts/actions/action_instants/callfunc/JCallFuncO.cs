using System;

using UnityEngine;

namespace JUnity.Actions
{
    public class JCallFuncO : JCallFunc
    {
        public Action<object> CallFunctionO { get; private set; }
        public object Object { get; private set; }

        #region Constructors

        public JCallFuncO()
        {
            Object = null;
            CallFunctionO = null;
        }

        public JCallFuncO(Action<object> selector, object pObject) : this()
        {
            Object = pObject;
            CallFunctionO = selector;
        }

        #endregion Constructors

        protected internal override JActionState StartAction(GameObject target)
        {
            return new JCallFuncOState (this, target);

        }

    }

    public class JCallFuncOState : JCallFuncState
    {
        protected Action<object> CallFunctionO { get; set; }
        protected object Object { get; set; }

        public JCallFuncOState (JCallFuncO action, GameObject target)
            : base(action, target)
        {   
            CallFunctionO = action.CallFunctionO;
            Object = action.Object;
        }

        public override void Execute()
        {
            if (null != CallFunctionO)
            {
                CallFunctionO(Object);
				CallFunctionO = null;
            }
        }
    }
}