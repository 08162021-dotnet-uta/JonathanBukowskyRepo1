
using Project0.StoreApplication.Client;
using Project0.StoreApplication.Client.Views.Common;
using Project0.StoreApplication.Domain.Interfaces;

namespace Project0.StoreApplication.Testing.ViewTesting
{
    /// <summary>
    /// Provides all the setup for testing an IView impl
    /// </summary>
    public abstract class BaseViewTest
    {
        // this sut prop doesn't actually do much
        protected IView _Sut;
        protected Context _Context;
        protected IStorageDAO _MockStorage;

        public T GetView<T>() where T : IView, new()
        {
            var view = new T();
            BaseView.SetStorage(_MockStorage);
            view.SetContext(_Context);

            return view;
        }

        public BaseViewTest()
        {
            _Context = new Context();
            _MockStorage = new FakeStorage();
        }
    }
}