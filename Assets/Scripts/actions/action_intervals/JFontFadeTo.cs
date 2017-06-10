using System;

using UnityEngine;
using UnityEngine.UI;

namespace JUnity.Actions
{
	public class JFontFadeTo : JFiniteTimeAction
	{
		public float ToOpacity { get; private set; }

		#region Constructors

		public JFontFadeTo (float duration, float opacity) : base (duration)
		{
			ToOpacity = opacity;
		}

		#endregion Constructors

		protected internal override JActionState StartAction(GameObject target)
		{
			return new JFontFadeToState (this, target);
		}

		public override JFiniteTimeAction Reverse()
		{
			throw new NotImplementedException();
		}
	}

	public class JFontFadeToState : JFiniteTimeActionState
	{
		protected float FromOpacity { get; set; }
		protected float ToOpacity { get; set; }

		Text _text;
		TextMesh _textMesh;

		public JFontFadeToState (JFontFadeTo action, GameObject target)
			: base (action, target)
		{
			if (action != null) {
				ToOpacity = action.ToOpacity;
			}

			if (target != null) {
				_text = target.GetComponent<Text> ();
				if (_text != null) {
					FromOpacity = _text.color.a;
				} else {
					_textMesh = target.GetComponent<TextMesh> ();
					if (_textMesh != null) {
						FromOpacity = _textMesh.color.a;
					}
				}
			}
		}

		public override void Update (float time)
		{
			if (_text != null) {
				Color newColor = _text.color;
				newColor.a = FromOpacity + (ToOpacity - FromOpacity) * time;
				_text.color = newColor;
			} else if (_textMesh != null) {
				Color newColor = _textMesh.color;
				newColor.a = FromOpacity + (ToOpacity - FromOpacity) * time;
				_textMesh.color = newColor;
			}
		}
	}

}