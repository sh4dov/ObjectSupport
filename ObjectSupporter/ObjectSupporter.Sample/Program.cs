using System;

namespace ObjectSupporter.Sample
{
    internal class Program
    {
        protected object LocalProperty { get; private set; }

        private static void Main(string[] args)
        {
            new Program().Tests();
        }

        private void LocalMethod()
        {
        }

        private void Tests()
        {
            string name;

            name = ObjectSupport.GetName(() => LocalProperty);
            Console.WriteLine("Local property name: {0}", name);

            name = ObjectSupport.GetName(() => LocalMethod());
            Console.WriteLine("Local method name: {0}", name);

            var variable = new object();
            name = ObjectSupport.GetName(() => variable);
            Console.WriteLine("Variable name: {0}", name);

            name = ObjectSupport.GetName(() => true);
            Console.WriteLine("Constant name: {0}", name);

            name = ObjectSupport.GetName(() => SampleEnum.EnumValue1);
            Console.WriteLine("Enum value name: {0}", name);

            name = ObjectSupport.GetName(() => null);
            Console.WriteLine("Null name: {0}", name);

            name = ObjectSupport.GetName<SampleClass>(c => c.Property);
            Console.WriteLine("Class property name: {0}", name);

            name = ObjectSupport.GetName<SampleClass>(c => c.Method());
            Console.WriteLine("Class method name: {0}", name);
        }

        private enum SampleEnum
        {
            EnumValue1
        }

        private class SampleClass
        {
            public object Property { get; private set; }

            public void Method()
            {
            }
        }
    }
}