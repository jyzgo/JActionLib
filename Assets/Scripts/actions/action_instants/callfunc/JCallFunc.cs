using System;

using UnityEngine;

namespace JUnity.Actions
{
    public class JCallFunc : JActionInstant
    {
        public Action CallFunction { get; private set;}
        public string ScriptFuncName { get; private set; }


        #region Constructors

        public JCallFunc()
        {
            ScriptFuncName = "";
            CallFunction = null;
        }

        public JCallFunc(Action selector) : base()
        {
            CallFunction = selector;
        }

        #endregion Constructors

        protected internal override JActionState StartAction(GameObject target)
        {
            return new JCallFuncState (this, target);

        }

    }

    public class JCallFuncState : JActionInstantState
    {

        protected Action CallFunction { get; set;}
        protected string ScriptFuncName { get; set; }

        public JCallFuncState (JCallFunc action, GameObject target)
            : base(action, target)
        {   
            CallFunction = action.CallFunction;
            ScriptFuncName = action.ScriptFuncName;
        }

        public virtual void Execute()
        {
            if (null != CallFunction)
            {
                CallFunction();
				CallFunction = null;
            }
        }

        public override void Update (float time)
        {
            Execute();
        }
    }
}