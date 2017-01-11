using System;
using System.Linq.Expressions;
using System.Web.UI.WebControls;

namespace ViewBinder.Bindings
{
    public class IntToTextbox<DomainModel, ViewObject> : ViewBinding<DomainModel, ViewObject>, IViewBinding
    {
        public IntToTextbox(DomainModel source, Expression<Func<DomainModel, object>> property, ref ViewObject target) : base(source, property, ref target)
        {
        }

        public override void FromSource()
        {
            var target = _target as TextBox;
            var source = _property.GetValue(_source) as int?;
            if (target.Visible)
            {
                target.Text = source.ToString();
            }
        }

        public override void ToSource()
        {
            var target = _target as TextBox;
            int source = 0;
            int.TryParse(target.Text, out source);
            _property.SetValue(_source, source);
        }
    }
}