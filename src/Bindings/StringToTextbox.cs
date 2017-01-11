using System;
using System.Linq.Expressions;
using System.Web.UI.WebControls;

namespace ViewBinder.Bindings
{
    public class StringToTextbox<DomainModel, ViewObject> : ViewBinding<DomainModel, ViewObject>, IViewBinding
    {
        public StringToTextbox(DomainModel source, Expression<Func<DomainModel, object>> property, ref ViewObject target) : base(source, property, ref target)
        {

        }

        public override void FromSource()
        {
            var tb = _target as TextBox;
            if (tb.Visible)
            {
                tb.Text = (string)_property.GetValue(_source);
            }
        }

        public override void ToSource()
        {
            var tb = _target as TextBox;
            _property.SetValue(_source, tb.Text);
        }

    }
}