using System.Collections.Generic;

namespace Interceptor
{
    public sealed class Page_ViewBinder
    {
        private IList<IViewBinding> _viewBindings { get; set; }
        public void Add(IViewBinding strategy) { _viewBindings.Add(strategy); }

        public void FromSource()
        {
            foreach (IViewBinding binding in _viewBindings)
            {
                binding.FromSource();
            }
        }

        public void ToSource()
        {
            foreach (IViewBinding binding in _viewBindings)
            {
                binding.ToSource();
            }
        }

        public Page_ViewBinder() { _viewBindings = new List<IViewBinding>(); }
    }
}