﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using PW.Core;

namespace PW
{
	public partial class PWNode {

		PWAnchor				GetAnchorFromField(string fieldName, int index = 0)
		{
			if (anchorFields.ContainsKey(fieldName))
				if (anchorFields[fieldName].anchors.Count < index)
					return anchorFields[fieldName].anchors[index];
			return null;
		}

		public void				SetAnchorEnabled(string fieldName, bool enabled, int index = 0)
		{
			PWAnchor	anchor = GetAnchorFromField(fieldName, index);

			if (anchor != null)
				anchor.enabled = enabled;
		}
	
		public void				SetAnchorName(string fieldName, string newName, int index = 0)
		{
			PWAnchor	anchor = GetAnchorFromField(fieldName, index);

			if (anchor != null)
				anchor.name = newName;
		}

		public void				SetAnchorColor(string fieldName, Color newColor, int index = 0)
		{
			PWAnchor	anchor = GetAnchorFromField(fieldName, index);

			if (anchor != null)
				anchor.color = newColor;
		}

		public void				UpdatePropVisibility(string fieldName, PWVisibility visibility, int index = 0)
		{
			PWAnchor	anchor = GetAnchorFromField(fieldName, index);

			if (anchor != null)
				anchor.visibility = visibility;
		}

		public void				UpdateMultiProp(string fieldName, int newCount, params string[] newNames)
		{
			if (!anchorFields.ContainsKey(fieldName))
				return ;
			
			var anchorField = anchorFields[fieldName];

			if (anchorField.anchors.Count > newCount)
			{
				while (anchorField.anchors.Count != newCount)
					anchorField.RemoveAnchor(anchorField.anchors.Count - 1);
			}
			else if (anchorField.anchors.Count < newCount)
			{
				while (anchorField.anchors.Count != newCount)
					anchorField.CreateNewAnchor();
			}

			if (newNames != null && newNames.Length != 0)
			{
				for (int i = 0; i < newNames.Length; i++)
					anchorField.anchors[i].name = newNames[i];
			}
		}

		public int				GetAnchorLinkCount(string fieldName, int index = 0)
		{
			PWAnchor	anchor = GetAnchorFromField(fieldName, index);

			if (anchor == null)
				return -1;
			else
				return anchor.linkCount;
		}

		public Rect?			GetAnchorRect(string fieldName, int index = 0)
		{
			PWAnchor	anchor = GetAnchorFromField(fieldName, index);

			if (anchor == null)
				return null;
			else
				return anchor.rect;
		}

		public IEnumerable< PWNode > 	GetOutputNodes()
		{
			return outputAnchorFields.Select(o => o.nodeRef);
		}

		public IEnumerable< PWNode >	GetInputNodes()
		{
			return inputAnchorFields.Select(o => o.nodeRef);
		}
	}
}
