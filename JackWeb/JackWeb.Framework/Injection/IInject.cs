using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JackWeb.Framework.Injection
{
    public interface IInject
    {
        void Prepare();
        T GetInstance<T>();
        object GetInstance(Type t);
    }
}
