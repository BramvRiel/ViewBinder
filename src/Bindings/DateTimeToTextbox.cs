using System;
using System.Linq.Expressions;
using System.Web.UI.WebControls;

namespace Interceptor.Bindings
{
    public class DateTimeToTextbox<DomainModel, ViewObject> : ViewBinding<DomainModel, ViewObject>, IViewBinding
    {
        public DateTimeToTextbox(DomainModel source, Expression<Func<DomainModel, object>> property, ref ViewObject target) : base(source, property, ref target)
        {
        }

        public override void FromSource()
        {
            var target = _target as TextBox;
            var source = _property.GetValue(_source) as DateTime?;
            if (target.Visible)
            {
                target.Text = source.Value.ToString("dd-MM-yyyy");
            }
        }

        public override void ToSource()
        {
            var target = _target as TextBox;
            DateTime source = new DateTime();
            DateTime.TryParse(target.Text, out source);
            _property.SetValue(_source, source);
        }
    }
}