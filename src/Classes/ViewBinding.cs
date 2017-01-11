using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Interceptor
{
    public abstract class ViewBinding<DomainModel, ViewObject>
    {
        protected DomainModel _source { get; set; }
        protected Expression<Func<DomainModel, object>> _propertyExpr;
        protected ViewObject _target;

        public ViewBinding(DomainModel source, Expression<Func<DomainModel, object>> property, ref ViewObject target)
        {
            this._source = source;
            this._propertyExpr = property;
            this._target = target;
        }

        protected PropertyInfo _property
        {
            get
            {
                var member = _propertyExpr.Body as MemberExpression;
                var unary = _propertyExpr.Body as UnaryExpression;
                var expr = member ?? (unary != null ? unary.Operand as MemberExpression : null);
                return (PropertyInfo)expr.Member;
            }
        }

        public abstract void FromSource();

        public abstract void ToSource();
    }
}