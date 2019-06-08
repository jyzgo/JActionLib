using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JUnity.Actions
{
	public class JGraphicsFadeTo : JFiniteTimeAction
	{
		public float ToOpacity { get; private set; }
        Graphic[] texts;

		#region Constructors

		public JGraphicsFadeTo (float duration, float opacity,params Graphic[] target) : base (duration)
		{
			ToOpacity = opacity;
            if (target.Length == 0)
            {
                Debug.LogError("At least one text!");
            }
            texts = target;
		}

		#endregion Constructors

		protected internal override JActionState StartAction(GameObject target)
		{
			return new JGraphicsFadeToState (this, target,texts);
		}

		public override JFiniteTimeAction Reverse()
		{
			throw new NotImplementedException();
		}
	}

    public class JGraphicsFadeToState : JFiniteTimeActionState
    {
        protected List<float> FromOpacity = new List<float>();
        protected float ToOpacity { get; set; }
        Graphic[] _texts;

        TextMesh _textMesh;

        public JGraphicsFadeToState(JGraphicsFadeTo action, GameObject target, params Graphic[] texts)
            : base(action, target)
        {
            if (action != null)
            {
                ToOpacity = action.ToOpacity;
            }
            _texts = texts;

            if (target != null)
            {
                if (_texts != null)
                {
                    for (int i = 0; i < _texts.Length; i++)
                    {
                        FromOpacity.Add(_texts[i].color.a);
                    }
                }

            }
        }

        public override void Update(float time)
        {
            if (_texts != null)
            {
                for (int i = 0; i < _texts.Length; i++)
                {
                    var text = _texts[i];
                    if (text != null)
                    {
                        Color newColor = text.color;
                        newColor.a = FromOpacity[i] + (ToOpacity - FromOpacity[i]) * time;
                        text.color = newColor;
                    }

                }
            }
        }
    }

}