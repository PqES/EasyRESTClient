using System;
using System.Collections.Generic;
using System.Reflection;

namespace MicroServiceNet.Attributes
{
    public class MicroServiceAttribute : Attribute
    {
        private readonly string _route;
        private TypeRequest _action;

        public MicroServiceAttribute(string route, TypeRequest action)
        {
            this._route = route;
            this._action = action;
        }

        public static MicroService GetMicroService(MethodInfo methodInfo)
        {
            var attrs = methodInfo.GetCustomAttributes();

            foreach (var attr in attrs)
            {
                if (attr is MicroServiceAttribute authAttr)
                {
                    return new MicroService() { Name = authAttr._route, Action = authAttr._action };
                }
            }

            return null;
        }
    }
}