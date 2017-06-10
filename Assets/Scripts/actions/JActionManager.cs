using System.Collections.Generic;
using System;
using UnityEngine;
using JUnity;

namespace JUnity.Actions
{
	public class JActionManager : Singleton<JActionManager>
    {
        internal class HashElement
        {
            public int ActionIndex;
            public List<JActionState> ActionStates;
            public JActionState CurrentActionState;
            public bool CurrentActionSalvaged;
            public bool Paused;
			public GameObject Target;
        }

		static List<GameObject> tmpKeysArray= new List<GameObject>(128);

		readonly Dictionary<GameObject, HashElement> targets = new Dictionary<GameObject, HashElement>();

        bool currentTargetSalvaged;
        HashElement currentTarget;
        bool targetsAvailable = false;

		protected JActionManager()
		{
			
		}

		public new void OnDestroy ()
		{
			this.RemoveAllActions();
			base.OnDestroy ();
		}

        public JAction GetAction(int tag, GameObject target)
        {
            Debug.Assert(tag != (int)JActionTag.Invalid);

            // Early out if we do not have any targets to search
            if (targets.Count == 0)
                return null;

            HashElement element;
            if (targets.TryGetValue(target, out element))
            {
                if (element.ActionStates != null)
                {
                    int limit = element.ActionStates.Count;
                    for (int i = 0; i < limit; i++)
                    {
                        var action = element.ActionStates[i].Action;

                        if (action.Tag == tag)
                        {
                            return action;
                        }
                    }
//                   Debug.LogWarning ("JUnityAction : GetActionByTag: Tag " + tag + " not found");//Comment Mark,Don't Delete
                }
            }
            else
            {
//				Debug.LogWarning ("JUnityAction : GetActionByTag: Target not found");//Comment Mark,Don't Delete
            }
            return null;
        }

        public JActionState GetActionState(int tag, GameObject target)
        {
            Debug.Assert(tag != (int)JActionTag.Invalid);

            // Early out if we do not have any targets to search
            if (targets.Count == 0)
                return null;

            HashElement element;
            if (targets.TryGetValue(target, out element))
            {
                if (element.ActionStates != null)
                {
                    int limit = element.ActionStates.Count;
                    for (int i = 0; i < limit; i++)
                    {
                        var actionState = element.ActionStates[i];

                        if (actionState.Action.Tag == tag)
                        {
                            return actionState;
                        }
                    }
//					Debug.LogWarning ("JUnityAction : GetActionStateByTag: Tag " + tag + " not found");//Comment Mark,Don't Delete
                }
            }
            else
            {
//				Debug.LogWarning ("JUnityAction : GetActionStateByTag: Target not found");//Comment Mark,Don't Delete
            }
            return null;
        }

        public int NumberOfRunningActionsInTarget(GameObject target)
        {
            HashElement element;
            if (targets.TryGetValue(target, out element))
            {
                return (element.ActionStates != null) ? element.ActionStates.Count : 0;
            }
            return 0;
        }

        public void Update()
        {
            if (!targetsAvailable)
                return;
			float dt = Time.deltaTime;
            int count = targets.Count;

//			Debug.Log ("tarr count " + count);

//			while (tmpKeysArray.Count < count)
//            {
//				tmpKeysArray = new GameObject[tmpKeysArray.Count * 2];
//            }
//            targets.Keys.CopyTo(tmpKeysArray, 0);


			tmpKeysArray.Clear();
			var enumK = targets.GetEnumerator();
			while(enumK.MoveNext())
			{
				tmpKeysArray.Add(enumK.Current.Key);
			}

//			tmpKeysArray.AddRange (targets.Keys);



            for (int i = 0; i < count; i++)
            {
                HashElement elt;
                if (!targets.TryGetValue(tmpKeysArray[i], out elt))
                {
                    continue;
                }



                currentTarget = elt;
                currentTargetSalvaged = false;

                if (!currentTarget.Paused)
                {
                    // The 'actions' may change while inside this loop.
                    for (currentTarget.ActionIndex = 0;
                        currentTarget.ActionIndex < currentTarget.ActionStates.Count;
                        currentTarget.ActionIndex++)
                    {

                        currentTarget.CurrentActionState = currentTarget.ActionStates[currentTarget.ActionIndex];
                        if (currentTarget.CurrentActionState == null)
                        {
                            continue;
                        }

                        currentTarget.CurrentActionSalvaged = false;

                        currentTarget.CurrentActionState.Step(dt);

                        if (currentTarget.CurrentActionSalvaged)
                        {
                            // The currentAction told the node to remove it. To prevent the action from
                            // accidentally deallocating itself before finishing its step, we retained
                            // it. Now that step is done, it's safe to release it.

                            //currentTarget->currentAction->release();
                        }
                        else if (currentTarget.CurrentActionState.IsDone)
                        {
                            currentTarget.CurrentActionState.Stop();

                            var actionState = currentTarget.CurrentActionState;
                            // Make currentAction nil to prevent removeAction from salvaging it.
                            currentTarget.CurrentActionState = null;
                            RemoveAction(actionState);
                        }
                        currentTarget.CurrentActionState = null;
                    }
                }

                // only delete currentTarget if no actions were scheduled during the cycle (issue #481)
                if (currentTargetSalvaged && currentTarget.ActionStates.Count == 0)
                {
                    DeleteHashElement(currentTarget);
                }


				if (tmpKeysArray [i] == null || ((GameObject)tmpKeysArray [i]).gameObject == null) {
					DeleteHashElement (currentTarget);
				}
            }

            // issue #635
            currentTarget = null;

//			for (int i = 0; i < toRemove.Count; i++) {
//				
//			}
        }

        internal void DeleteHashElement(HashElement element)
        {
            element.ActionStates.Clear();
            targets.Remove(element.Target);
            element.Target = null;
            targetsAvailable = targets.Count > 0;
        }

        internal void ActionAllocWithHashElement(HashElement element)
        {
            if (element.ActionStates == null)
            {
                element.ActionStates = new List<JActionState>();
            }
        }


        #region Action running

		public void PauseTarget(GameObject target)
        {
            HashElement element;
            if (targets.TryGetValue(target, out element))
            {
                element.Paused = true;
            }
        }

		public void ResumeTarget(GameObject target)
        {
            HashElement element;
            if (targets.TryGetValue(target, out element))
            {
                element.Paused = false;
            }
        }

		public List<GameObject> PauseAllRunningActions()
        {
			var idsWithActions = new List<GameObject>();

			var tarEnum = targets.GetEnumerator ();
			while (tarEnum.MoveNext ()) {
				var element = tarEnum.Current.Value;
				if (!element.Paused)
				{
					element.Paused = true;
					idsWithActions.Add(element.Target);
				}

			}


            return idsWithActions;
        }

		public void ResumeTargets(List<GameObject> targetsToResume)
        {
            for (int i = 0; i < targetsToResume.Count; i++)
            {
                ResumeTarget(targetsToResume[i]);
            }
        }

        #endregion Action running


		public static JActionState RunActions(params JFiniteTimeAction[] actions)
		{
			var cur = JActionManager.Instance.gameObject;
			return cur.RunActions(actions);
		}

		public static void StopAction(JActionState state)
		{
			var instance = JActionManager.Instance.gameObject;
			instance.StopAction(state);
		}


        #region Adding/removing actions

        public JActionState AddAction(JAction action, GameObject target, bool paused = false)
        {
            Debug.Assert(action != null);
            Debug.Assert(target != null);

            HashElement element;
            if (!targets.TryGetValue(target, out element))
            {
                element = new HashElement();
                element.Paused = paused;
                element.Target = target;
                targets.Add(target, element);
                targetsAvailable = true;
            }

            ActionAllocWithHashElement(element);
            var isActionRunning = false;

			for (int i = 0; i < element.ActionStates.Count; i++) {
				var existingState = element.ActionStates [i];
				if (existingState.Action == action)
				{
					isActionRunning = true;
					break;
				}
			}
				
            Debug.Assert(!isActionRunning, "JUnityAction : Action is already running for this target.");
            var state = action.StartAction(target);
            element.ActionStates.Add(state);

            return state;
        }

        public void RemoveAllActions()
        {
            if (!targetsAvailable)
                return;

            int count = targets.Count;
//			if (tmpKeysArray.Count < count)
//            {
//                tmpKeysArray = new GameObject[tmpKeysArray.Length * 2];
//            }

//            targets.Keys.CopyTo(tmpKeysArray, 0);
			tmpKeysArray.Clear();
			tmpKeysArray.AddRange (targets.Keys);

            for (int i = 0; i < count; i++)
            {
                RemoveAllActionsFroJarget(tmpKeysArray[i]);
            }
        }

		public void RemoveAllActionsFroJarget(GameObject target)
        {
            if (target == null)
            {
                return;
            }

            HashElement element;
            if (targets.TryGetValue(target, out element))
            {
                if (element.ActionStates.Contains(element.CurrentActionState) && (!element.CurrentActionSalvaged))
                {
                    element.CurrentActionSalvaged = true;
                }

                element.ActionStates.Clear();

                if (currentTarget == element)
                {
                    currentTargetSalvaged = true;
                }
                else
                {
                    DeleteHashElement(element);
                }
            }
        }

        public void RemoveAction(JActionState actionState)
        {
            if (actionState == null || actionState.OriginalTarget == null)
            {
                return;
            }

			GameObject target = actionState.OriginalTarget;
            HashElement element;
            if (targets.TryGetValue(target, out element))
            {
                int i = element.ActionStates.IndexOf(actionState);

                if (i != -1)
                {
                    RemoveActionAtIndex(i, element);
                }
                else
                {
//					Debug.LogWarning ("JUnityAction: removeAction: Action not found");//Comment Mark,Don't Delete
                }
            }
            else
            {
//				Debug.LogWarning ("JUnityAction: removeAction: Target not found");//Comment Mark,Don't Delete
            }
        }

        internal void RemoveActionAtIndex(int index, HashElement element)
        {
            var action = element.ActionStates[index];

            if (action == element.CurrentActionState && (!element.CurrentActionSalvaged))
            {
                element.CurrentActionSalvaged = true;
            }

            element.ActionStates.RemoveAt(index);

            // update actionIndex in case we are in tick. looping over the actions
            if (element.ActionIndex >= index)
            {
                element.ActionIndex--;
            }

            if (element.ActionStates.Count == 0)
            {
                if (currentTarget == element)
                {
                    currentTargetSalvaged = true;
                }
                else
                {
                    DeleteHashElement(element);
                }
            }
        }

        internal void RemoveAction(JAction action, GameObject target)
        {
            if (action == null || target == null)
                return;

            HashElement element;
            if (targets.TryGetValue(target, out element))
            {
                int limit = element.ActionStates.Count;
                bool actionFound = false;

                for (int i = 0; i < limit; i++)
                {
                    var actionState = element.ActionStates[i];

                    if (actionState.Action == action && actionState.OriginalTarget == target)
                    {
                        RemoveActionAtIndex(i, element);
                        actionFound = true;
                        break;
                    }
                }

                if (!actionFound)
				{
//					Debug.LogWarning ("JUnityAction : RemoveAction: Action not found");//Comment Mark,Don't Delete
				}

            }
            else
            {
//				Debug.LogWarning ("JUnityAction : RemoveAction: Target not found");//Comment Mark,Don't Delete
            }

        }

        public void RemoveAction(int tag, GameObject target)
        {
            Debug.Assert((tag != (int)JActionTag.Invalid));
            Debug.Assert(target != null);

            // Early out if we do not have any targets to search
            if (targets.Count == 0)
                return;

            HashElement element;
            if (targets.TryGetValue(target, out element))
            {
                int limit = element.ActionStates.Count;
                bool tagFound = false;

                for (int i = 0; i < limit; i++)
                {
                    var actionState = element.ActionStates[i];

                    if (actionState.Action.Tag == tag && actionState.OriginalTarget == target)
                    {
                        RemoveActionAtIndex(i, element);
                        tagFound = true;
                        break;
                    }
                }

                if (!tagFound)
				{
//					Debug.LogWarning ("JUnityAction : removeActionByTag: Tag " + tag + " not found");
				}
            }
            else
            {
//				Debug.LogWarning ("JUnityAction : removeActionByTag: Target not found");//Comment Mark,Don't Delete
            }
        }

        #endregion Adding/removing actions
    }
}