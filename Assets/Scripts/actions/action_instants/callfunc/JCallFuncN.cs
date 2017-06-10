using System;

using UnityEngine;

namespace JUnity.Actions
{
    public class JCallFuncN : JCallFunc
    {
        public Action<GameObject> CallFunctionN { get; private set; }

        #region Constructors

        public JCallFuncN() : base()
        {
        }

        public JCallFuncN(Action<GameObject> selector) : base()
        {
            CallFunctionN = selector;
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new JCallFuncNState (this, target);

        }

    }

    public class JCallFuncNState : JCallFuncState
    {

        protected Action<GameObject> CallFunctionN { get; set; }

        public JCallFuncNState (JCallFuncN action, GameObject target)
            : base(action, target)
        {   
            CallFunctionN = action.CallFunctionN;
        }

        public override void Execute()
        {
            if (null != CallFunctionN)
            {
                CallFunctionN(Target);
				CallFunctionN = null;
            }
            //if (m_nScriptHandler) {
            //    JScriptEngineManager::sharedManager()->getScriptEngine()->executeFunctionWithobject(m_nScriptHandler, m_pTarget, "GameObject");
            //}
        }

    }
}