using System;

namespace ObjectSupporter.Sample
{
    internal class Program
    {
        private enum SampleEnum
        {
            EnumValue1
        }

        protected object LocalProperty { get; private set; }

        private static void Main(string[] args)
        {
            new Program().Tests();
        }

        private void LocalMethod()
        {
        }

        private int LocalMethodWithArguments(int arg1, int arg2)
        {
            return 0;
        }

        private void Tests()
        {
            string name;

            name = ObjectSupport.GetName(() => LocalProperty);
            Console.WriteLine("Local property name: {0}", name);

            name = ObjectSupport.GetName<Action>(() => LocalMethod);
            Console.WriteLine("Local method name: {0}", name);

            name = ObjectSupport.GetName<Func<int, int, int>>(() => LocalMethodWithArguments);
            Console.WriteLine("Local method with arguments name: {0}", name);

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

            name = ObjectSupport.GetName<SampleClass, Action>(c => c.Method);
            Console.WriteLine("Class method name: {0}", name);

            name = ObjectSupport.GetName<SampleClass, Func<string, string, int>>(c => c.MethodWithArguments);
            Console.WriteLine("Class method with arguments name: {0}", name);
        }

        private class SampleClass
        {
            public object Property { get; private set; }

            public void Method()
            {
            }

            public int MethodWithArguments(string arg1, string arg2)
            {
                return 0;
            }
        }
    }
}