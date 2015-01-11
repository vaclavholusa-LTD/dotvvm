﻿using Redwood.Framework.Binding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redwood.Framework.Controls
{
	/// <summary>
	/// Base class for control that allows to select one of its item.
	/// </summary>
	public abstract class Selector : ItemsControl
	{
		protected Selector(string tagName)
			: base(tagName)
		{

		}

		/// <summary>
		/// Gets or sets the name of property in the <see cref="ItemsControl.DataSource"/> collection that will be displayed in the <see cref="ComboBox"/>.
		/// </summary>
		public string DisplayMember
		{
			get { return (string)GetValue(DisplayMemberProperty); }
			set { SetValue(DisplayMemberProperty, value); }
		}
		public static readonly RedwoodProperty DisplayMemberProperty =
			RedwoodProperty.Register<string, Selector>(t => t.DisplayMember, "");

		/// <summary>
		/// Gets or sets the name of property in the <see cref="ItemsControl.DataSource"/> collection that will be passed to the <see cref="SelectedValue"/> property.
		/// </summary>
		public string ValueMember
		{
			get { return (string)GetValue(ValueMemberProperty); }
			set { SetValue(ValueMemberProperty, value); }
		}
		public static readonly RedwoodProperty ValueMemberProperty =
			RedwoodProperty.Register<string, Selector>(t => t.ValueMember, "");


		/// <summary>
		/// Gets or sets the value selected in the <see cref="ComboBox"/>.
		/// </summary>
		public object SelectedValue
		{
			get { return GetValue(SelectedValueProperty); }
			set { SetValue(SelectedValueProperty, value); }
		}
		public static readonly RedwoodProperty SelectedValueProperty =
			RedwoodProperty.Register<object, Selector>(t => t.SelectedValue);


	}
}
