using System;

namespace MicroServiceNet.Attributes
{
    public class MicroServiceHostAttribute : Attribute
    {
        private readonly string _name;

        public MicroServiceHostAttribute(string name)
        {
            this._name = name;
        }

        public static string GetMicroService(Type interfac3)
        {

            foreach (var attr in interfac3.CustomAttributes)
            {
                if (attr.AttributeType.Name.Equals("MicroServiceHostAttribute"))
                {
                    foreach (var item in attr.ConstructorArguments)
                    {
                        return item.Value.ToString();
                    }
                }
            }

            return null;
        }
    }
}